/*********************************************************
 * FRXS zhangliang@frxs.com 10/28/2015 8:32:17 AM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 用户保存一次请求上下文信息
    /// </summary>
    public class RequestContext
    {
        /// <summary>
        /// 构造一个默认的自定义数据记录容器
        /// </summary>
        private readonly IDictionary<string, object> _customerAdditionDatas = new Dictionary<string, object>();

        /// <summary>
        /// 一次API接口访问请求上下文信息，用于在后续的流转处理中保存数据
        /// </summary>
        /// <param name="httpContext">http请求上下文</param>
        /// <param name="systemOptions">系统设置对象</param>
        public RequestContext(HttpContextBase httpContext, SystemOptions systemOptions)
        {
            httpContext.CheckNullThrowArgumentNullException("httpContext");
            systemOptions.CheckNullThrowArgumentNullException("systemOptions");
            this.HttpContext = httpContext;
            this.SysOptions = systemOptions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext">http请求上下文</param>
        /// <param name="systemOptions">系统设置对象</param>
        /// <param name="requestDto">请求参数data对象</param>
        /// <param name="actionDescriptor">当前请求接口描述</param>
        /// <param name="rawRequestParams">当前上送参数原始对象</param>
        /// <param name="decryptedRequestParams">当前上送参数解密后对象</param>
        public RequestContext(
            HttpContextBase httpContext,
            SystemOptions systemOptions,
            object requestDto,
            IActionDescriptor actionDescriptor,
            RequestParams rawRequestParams,
            RequestParams decryptedRequestParams)
            : this(httpContext, systemOptions)
        {
            this.RequestDto = requestDto;
            this.ActionDescriptor = actionDescriptor;
            this.RawRequestParams = rawRequestParams;
            this.DecryptedRequestParams = decryptedRequestParams;
        }

        /// <summary>
        /// HttpContextBase
        /// </summary>
        public HttpContextBase HttpContext { get; private set; }

        /// <summary>
        /// 系统配置信息
        /// </summary>
        public SystemOptions SysOptions { get; private set; }

        /// <summary>
        /// 原始上送请求参数对象(一般校验签名等需要原始数据的请使用此参数对象)
        /// </summary>
        public RequestParams RawRequestParams { get; set; }

        /// <summary>
        /// 解密后的上送参数对象
        /// </summary>
        public RequestParams DecryptedRequestParams { get; set; }

        /// <summary>
        /// 此对象是上送的数据对象，此数据其实是实现了IRequestDto的请求上送参数类
        /// </summary>
        public object RequestDto { get; set; }

        /// <summary>
        /// 当前请求上下文接口描述信息
        /// </summary>
        public IActionDescriptor ActionDescriptor { get; set; }

        /// <summary>
        /// 自定义的数据，方便从上到下传递数据;仅限于当前上下文传递数据
        /// </summary>
        public IDictionary<string, object> AdditionDatas
        {
            get
            {
                return this._customerAdditionDatas;
            }
        }

        /// <summary>
        /// 获取当前请求获取缓存键信息，方便重写实现类里直接使用
        /// 只要接口名称+序列化格式+提交的数据包不变，生成的那么缓存键就不会变化，因此实现针对不同接口和不同请求数据包进行缓存
        /// 由于是针对字符串进行缓存，因此在提交不同预期序列化返回（XML,JSON）会保存2份不同的缓存
        /// 注意：这里的缓存键仅仅是针对同一接口同一参数的缓存键，不是针对这个应用的全局缓存键
        /// </summary>
        /// <param name="subCacheKey">同一操作上下文，有可能需要不同的子缓存键；可以增加子缓存键，防止冲突</param>
        /// <returns>返回本次请求缓存键</returns>
        public string GetRequestCacheKey(string subCacheKey = null)
        {
            //接口描述不能为空
            this.ActionDescriptor.CheckNullThrowArgumentNullException("ActionDescriptor");
            this.DecryptedRequestParams.CheckNullThrowArgumentNullException("DecryptedRequestParams");

            //默认就是最原始的上送参数
            var data = this.DecryptedRequestParams.Data;

            //忽略掉用户名称和编号
            if (this.ActionDescriptor.Cache.IgnoreUserIdAndUserName)
            {
                //IRequestDto requestObj = this.RequestDto as IRequestDto;
                //忽略掉用户信息KEY计算方式，先获取到上送的对象，然后获取到所有参数属性字典，在忽略掉用户ID和用户名称，再对字典进行JSON串行化
                //如果不忽略掉当前接口操作用户，那么接口缓存将成为了私有缓存，即达不到预期使用全局缓存的目的
                data =
                    this.RequestDto.GetAttributes()
                        .Where(
                            o => !new string[] { "UserId", "UserName" }.Contains(o.Key, StringComparer.OrdinalIgnoreCase))
                        .ToList()
                        .SerializeObjectToJosn();
            }

            //生成当前请求接口缓存键
            var apiRequestCacheKey = "{0}.{1}.{2}.{3}".With(this.ActionDescriptor.ActionName,
                this.ActionDescriptor.Version,
                subCacheKey ?? "_SYS_", //外部不指定子缓存键，就指定系统默认缓存键，这样可以在一定时候，使用匹配模式，批量全部删除系统缓存等
                MD5.Encrypt(data + this.DecryptedRequestParams.Format).ToUpper());

            //检测是否定义了前缀
            return this.ActionDescriptor.Cache.Prefix.IsNullOrEmpty()
                ? apiRequestCacheKey
                : "{0}.{1}".With(ActionDescriptor.Cache.Prefix, apiRequestCacheKey);
        }

        /// <summary>
        /// 此方法仅仅用户获取上送接口操作用户UserId和UserName对象；
        /// </summary>
        /// <param name="default">如果设置了默认的返回委托，在获取用户失败的情况下（null），会返回委托返回值</param>
        /// <returns></returns>
        public UserIdentity GetCurrentUserIdentity(Func<UserIdentity> @default)
        {
            //为null，直接返回默认值
            if (this.RequestDto.IsNull())
            {
                return @default();
            }

            //对象是否实现了IRequestDto，直接转型下
            IRequestDto requestDto = this.RequestDto as IRequestDto;

            //转型失败，直接返回默认值
            if (requestDto.IsNull())
            {
                return @default();
            }

            //外部校验用户是否上送正确
            if (!this.SysOptions.ValidUserIdAndUserNameFun.IsNull() && !this.SysOptions.ValidUserIdAndUserNameFun(requestDto))
            {
                return @default();
            }

            //返回数据当前用户信息
            return new UserIdentity() { UserId = requestDto.UserId, UserName = requestDto.UserName };
        }

        /// <summary>
        /// 获取系统框架服务容器
        /// </summary>
        public ServicesContainer ServicesContainer
        {
            get { return ServicesContainer.Current; }
        }
    }
}