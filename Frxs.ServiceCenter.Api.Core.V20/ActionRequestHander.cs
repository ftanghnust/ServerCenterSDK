/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using System;
using System.Linq;
using System.Web;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// API接口入口类
    /// </summary>
    internal class ActionRequestHander : IActionRequestHander
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMediaTypeFormatterFactory _mediaTypeFormatterFactory;
        private readonly IActionSelector _actionSelector;
        private readonly IActionFactory _actionFactory;
        private readonly IResponse _response;
        private readonly IActionInvoker _actionInvoker;
        private readonly IApiSecurity _apiSecurity;
        private readonly ICacheManager _cacheManager;
        private readonly HttpContextBase _httpContext;
        private readonly IRequestParamsBinder _requestParamsBinder;
        private readonly IRequestDtoBinder _requestDtoBinder;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediaTypeFormatterFactory">格式化输出器</param>
        /// <param name="actionSelector">接口查找器</param>
        /// <param name="actionFactory">创建创建器</param>
        /// <param name="actionInvoker">接口执行器</param>
        /// <param name="response">接口输出器</param>
        /// <param name="apiSecurity">接口加密解密</param>
        /// <param name="cacheManager">缓存器</param>
        /// <param name="httpContext">当前http请求上下文</param>
        /// <param name="requestDtoBinder">业务参数绑定器</param>
        /// <param name="requestParamsBinder">上送参数绑定器</param>
        public ActionRequestHander(
            IMediaTypeFormatterFactory mediaTypeFormatterFactory,
            IActionSelector actionSelector,
            IActionFactory actionFactory,
            IActionInvoker actionInvoker,
            IResponse response,
            IApiSecurity apiSecurity,
            ICacheManager cacheManager,
            HttpContextBase httpContext,
            IRequestParamsBinder requestParamsBinder,
            IRequestDtoBinder requestDtoBinder)
        {
            mediaTypeFormatterFactory.CheckNullThrowArgumentNullException("mediaTypeFormatterFactory");
            actionSelector.CheckNullThrowArgumentNullException("actionSelector");
            actionFactory.CheckNullThrowArgumentNullException("actionFactory");
            actionInvoker.CheckNullThrowArgumentNullException("actionInvoker");
            response.CheckNullThrowArgumentNullException("response");
            apiSecurity.CheckNullThrowArgumentNullException("apiSecurity");
            cacheManager.CheckNullThrowArgumentNullException("cacheManager");
            httpContext.CheckNullThrowArgumentNullException("httpContext");

            this._mediaTypeFormatterFactory = mediaTypeFormatterFactory;
            this._actionSelector = actionSelector;
            this._actionFactory = actionFactory;
            this._actionInvoker = actionInvoker;
            this._response = response;
            this._apiSecurity = apiSecurity;
            this._cacheManager = cacheManager;
            this._httpContext = httpContext;
            this._requestDtoBinder = requestDtoBinder;
            this._requestParamsBinder = requestParamsBinder;
        }

        /// <summary>
        /// API框架入口函数
        /// </summary>
        public void Execute()
        {
            //初始化请求上下
            RequestContext requestContext = new RequestContext(_httpContext, SystemOptionsManager.Current);

            //添加自定义的键，便于传递给后续接口,方法使用，记录下入口时间
            requestContext.AdditionDatas.Add("startTime", DateTime.Now);

            //1.获取原始的上送参数对象
            requestContext.RawRequestParams = this._requestParamsBinder.GetRequestParams();

            //期望返回的数据格式
            ResponseFormat responseFormat = new MediaTypeFormatterMappingManager(requestContext).GetResponseFormat();

            //创建一个格式化输出器
            var mediaTypeFormatter = this._mediaTypeFormatterFactory.Create(responseFormat);

            //从缓存里直接获取到接口描述对象（注意在未指定版本的情况下，会自动获取接口最新版本）
            ActionDescriptor actionDescriptor =
                this._actionSelector.GetActionDescriptor(requestContext.RawRequestParams.ActionName,
                    requestContext.RawRequestParams.Version);

            //检测接口是否存在
            if (actionDescriptor.IsNull())
            {
                var actionResult = new ActionResult()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info =
                        Resource.CoreResource.ActionRequestHander_NotFoundAction.With(
                            requestContext.RawRequestParams.ActionName)
                };
                this._response.ResponseSerializedStringToClient(requestContext, responseFormat,
                    mediaTypeFormatter.SerializedActionResultToString(requestContext, actionResult));
                return;
            }

            //赋值下上下文的接口描述对象
            requestContext.ActionDescriptor = actionDescriptor;

            //加解密管理器
            ApiSecurityManager apiSecurityManager = new ApiSecurityManager(this._apiSecurity);

            //解密上送参数对象
            var requestParamsDecryptResult = apiSecurityManager.RequestParamsDecrypt(requestContext.RawRequestParams,
                actionDescriptor);

            //上送参数原始数据以及解密后的数据
            requestContext.DecryptedRequestParams = requestParamsDecryptResult.DecryptedRequestParams;

            //解密上送参数失败，直接返回
            if (!requestParamsDecryptResult.IsSuccess)
            {
                var actionResult = new ActionResult()
                {
                    Flag = ActionResultFlag.DECRYPT_REQUEST_FAIL,
                    Info = requestParamsDecryptResult.Message ?? Resource.CoreResource.DECRYPT_REQUEST_FAIL
                };
                this._response.ResponseSerializedStringToClient(requestContext, responseFormat,
                    mediaTypeFormatter.SerializedActionResultToString(requestContext, actionResult));
                return;
            }

            //获取上送参数RequestDto对象
            requestContext.RequestDto = this._requestDtoBinder.Bind(requestContext, actionDescriptor);
            //调用下方法(2016-07-05加，加此动作原因是让依赖注入可以获取到当前值，有机会再创建接口前，进行上送参数值的注入
            //由此来获得改变注入对象行为的的机会
            if (!requestContext.RequestDto.IsNull())
            {
                (requestContext.RequestDto as RequestDtoBase).BeforeValid();
            }
           
            //2.检测是否设置了白名单；如果校验不通过，直接返回拒绝消息，可以在外部使用WhiteIpManager.Ips.Add方法添加新的白名单
            var clientIp = requestContext.HttpContext.Request.GetClientIp();
            if (!WhiteIpManager.Ips.IsValid(clientIp))
            {
                this._response.ResponseSerializedStringToClient(requestContext, responseFormat,
                    mediaTypeFormatter.SerializedActionResultToString(requestContext,
                        new ActionResult()
                        {
                            Flag = ActionResultFlag.FAIL,
                            Info = Resource.CoreResource.ActionRequestHander_WhiteIpRefuse.With(clientIp)
                        }));
                return;
            }

            //3 验证授权器
            var validResult = new AuthenticationManager().Valid(requestContext, actionDescriptor);
            if (!validResult.IsValid)
            {
                var actionResult = new ActionResult()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info =
                        validResult.Message.IsNullOrEmpty()
                            ? Resource.CoreResource.ActionRequestHander_AppKeyAuthentication_Attribute
                            : validResult.Message
                };
                this._response.ResponseSerializedStringToClient(requestContext, responseFormat,
                    mediaTypeFormatter.SerializedActionResultToString(requestContext, actionResult));
                return;
            }

            //5.接口特性校验器;比如：https，是否过期，是否开启ajax等
            ActionRequestValidatorResult actionValidatorResult = new ActionRequestValidatorManager().Valid(requestContext);
            if (!actionValidatorResult.IsValid)
            {
                this._response.ResponseSerializedStringToClient(requestContext, responseFormat,
                    mediaTypeFormatter.SerializedActionResultToString(requestContext, actionValidatorResult.ActionResult));
                return;
            }

            //序列化后的字符串
            string actionResultString;
            //6.设置了全局ActionResult缓存拦截；接口应用了缓存特性，并且缓存时间设置为大于0的时间，框架就执行缓存策略；
            //此缓存策略为当前请求缓存，执行缓存不会执行Action.Execute()方法；效率最高效
            //获取此次请求级别的cacheKey；缓存键为版本号，接口名称，上送参数等构成
            string requestCacheKey = requestContext.GetRequestCacheKey();
            //记录下缓存器，方便后续使用
            requestContext.AdditionDatas.Add("cacheManager", this._cacheManager);
            //保存到临时属性
            requestContext.AdditionDatas.Add("requestCacheKey", requestCacheKey);
            //设置了缓存，并且缓存时间大于0，并且缓存器里存在缓存键
            if (actionDescriptor.Cache.CacheTime > 0 && this._cacheManager.IsSet(requestCacheKey))
            {
                //从缓存获取ActionResult对象
                actionResultString = this._cacheManager.Get<string>(requestCacheKey);
                //缓存时间记录下，方便输出给客户端
                requestContext.AdditionDatas.Add("cacheTime", actionDescriptor.Cache.CacheTime);
            }
            else
            {
                //创建action并激活
                IAction action = this._actionFactory.Create(requestContext, actionDescriptor);
                //执行业务逻辑开始的时间
                requestContext.AdditionDatas.Add("actionExecuteStartTime", DateTime.Now);
                //执行Action方法
                ActionResult actionResult = this._actionInvoker.Execute(action);
                //执行完业务逻辑结束的时间
                requestContext.AdditionDatas.Add("actionExecuteEndTime", DateTime.Now);
                //序列化ActionResult对象返回序列化后的字符串
                actionResultString = mediaTypeFormatter.SerializedActionResultToString(requestContext, actionResult);
                //写入缓存
                if (actionDescriptor.Cache.CacheTime > 0)
                {
                    this._cacheManager.Set(requestCacheKey, actionResultString, actionDescriptor.Cache.CacheTime);
                }
                //释放资源
                this._actionFactory.ReleaseAction(action);
            }

            //记录下结束时间
            requestContext.AdditionDatas.Add("endTime", DateTime.Now);

            //7.进行接口访问记录器(便于后台统计接口访问量),为了不影响到API接口输出，开启新的线程执行记录器，异步执行；并忽略掉记录器里的错误信息
            ApiAccessRecordPublisher.Publish(actionResultString, requestContext, new ActionLifeTime(requestContext));

            //8.输出数据给客户端
            this._response.ResponseSerializedStringToClient(requestContext, responseFormat,
                apiSecurityManager.ResponseEncrypt(requestContext.DecryptedRequestParams, actionDescriptor,
                    actionResultString));
        }

    }
}