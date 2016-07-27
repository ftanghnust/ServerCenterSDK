/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/23/2015 10:04:21 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 使用反射来获取action描述信息
    /// </summary>
    public class ReflectedActionDescriptor : IActionDescriptor
    {
        /// <summary>
        /// 保存接口版本
        /// </summary>
        private readonly ActionConfigItem _actionConfig = null;
        private readonly ActionConfigItem _globalActionConfig = null;
        /// <summary>
        /// action描述信息
        /// </summary>
        /// <param name="actionType">实现IAction类型的类类型</param>
        public ReflectedActionDescriptor(Type actionType)
        {
            actionType.CheckNullThrowArgumentNullException("actionType");
            if (!actionType.IsAssignableToActionBase())
            {
                throw new Exception("Action必须继承ActionBase");
            }
            //接了类型
            this.ActionType = actionType;
            //上送参数类型
            this.RequestDtoType = actionType.BaseType.GetGenericArguments()[0];
            //下送参数类型
            this.ResponseDtoType = actionType.BaseType.GetGenericArguments()[1];
            //初始化接口外部配置
            this._actionConfig = ApiConfigManager.Configs[this.ActionName, this.Version];
            //全局接口配置;兜底
            this._globalActionConfig = ApiConfigManager.GlobalActionConfig;
        }

        /// <summary>
        /// 当前接口类型
        /// </summary>
        public Type ActionType { get; private set; }

        /// <summary>
        /// 上送参数对象类型
        /// </summary>
        public Type RequestDtoType
        {
            get;
            private set;
        }

        /// <summary>
        /// 下送数据对象类型
        /// </summary>
        public Type ResponseDtoType
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取指定的特性信息
        /// </summary>
        /// <typeparam name="T">继承自Attribute的类型</typeparam>
        /// <returns>获取指定类型的特性对象</returns>
        protected T GetCustomAttribute<T>() where T : Attribute
        {
            if (this.ActionType.IsNull())
            {
                throw new ArgumentNullException("ActionType");
            }
            var customerAttributes = this.ActionType.GetCustomAttributes(typeof(T), false);
            if (customerAttributes.Any())
            {
                return customerAttributes[0] as T;
            }
            return null;
        }

        /// <summary>
        /// 获取实现了某个接口或者抽象类的所有特性类
        /// </summary>
        /// <typeparam name="T">查找继承与T的所有特性类</typeparam>
        /// <returns>找不指定类型，返回一个空的集合</returns>
        protected IList<T> GetCustomAttributes<T>() where T : Attribute
        {
            if (this.ActionType.IsNull())
            {
                throw new ArgumentNullException("ActionType");
            }
            IList<T> customAttributes = new List<T>();
            var customerAttributes = this.ActionType.GetCustomAttributes(typeof(T), false);
            if (customerAttributes.IsNull() || customAttributes.IsEmpty())
            {
                return customAttributes;
            }
            foreach (T customerAttribute in customerAttributes.OfType<T>())
            {
                customAttributes.Add(customerAttribute);
            }
            return customAttributes;
        }

        /// <summary>
        /// 获取定义在当前Action类型上面的所有AOP拦截特性集合
        /// </summary>
        /// <returns>返回接口定义的所有拦截器特性,可以多次定义拦截器</returns>
        public IEnumerable<IActionFilter> ActionFilters
        {
            get
            {
                //保存接口所有的过滤器，包括全局的，特有定义的；注意下面的执行顺序，全局过滤器最先被执行
                IList<IActionFilter> actionFilterAttributes = new List<IActionFilter>();

                //1.先找出全局过滤器
                GlobalActionFiltersManager.Filters.GetActionFilters().ToList().ForEach(o =>
                {
                    //添加到拦截器集合
                    actionFilterAttributes.Add(o);
                });

                //2.找出定义在接口类上面的过滤器（必须要继承自ActionFilterBaseAttribute）
                foreach (var o in this.ActionType.GetCustomAttributes().Where(item => item is ActionFilterBaseAttribute).Cast<ActionFilterBaseAttribute>())
                {
                    //添加到拦截器集合
                    actionFilterAttributes.Add(o);
                }

                //返回全局过滤器
                return actionFilterAttributes;
            }
        }

        /// <summary>
        /// 获取单个接口授权，签名校验
        /// </summary>
        public IEnumerable<IAuthentication> Authentications
        {
            get
            {
                //所有的权限验证器（全局的验证器要先执行，特性上面单独的验证器后执行）
                IList<IAuthentication> actionAuthenticationBaseAttribute = new List<IAuthentication>();

                //0.获取全局注册的授权器(需要进行授权访问)
                var authentications = ServicesContainer.Current.ResolverAll<IAuthentication>().OrderByDescending(o => o.Order);
                foreach (var authentication in authentications)
                {
                    actionAuthenticationBaseAttribute.Add(authentication);
                }

                //1.获取特性上定义的独立授权特性
                IList<IAuthentication> actionAuthenticationBaseAttributes = this.ActionType.GetCustomAttributes()
                    .OfType<AuthenticationBaseAttribute>()
                    .Cast<IAuthentication>()
                    .ToList();

                //排序后在加入
                foreach (var item in actionAuthenticationBaseAttributes.OrderByDescending(o => o.Order))
                {
                    actionAuthenticationBaseAttribute.Add(item);
                }

                //3.返回接口授权集合
                return actionAuthenticationBaseAttribute;
            }
        }

        /// <summary>
        /// 接口支持的http方式POST/GET；在为空的情况下，支持2种提交模式
        /// 优先级为：0.外部自定义配置，1.接口自身配置，2.全局配置
        /// </summary>
        public HttpMethod HttpMethod
        {
            get
            {
                //外部定义了，就取外部定义策略
                if (!this._actionConfig.IsNull() && this._actionConfig.HttpMethod.HasValue)
                {
                    return this._actionConfig.HttpMethod.Value;
                }

                //请求特性标注
                var httpMethodAttribute = this.GetCustomAttribute<HttpMethodAttribute>();

                //自身的特性标注
                return !httpMethodAttribute.IsNull()
                    ? httpMethodAttribute.HttpMethod
                    : this._globalActionConfig.HttpMethod.Value;
            }
        }

        /// <summary>
        /// 是否需要https安全连接
        /// 优先级为：1.外部自定义配置，2.接口自身配置
        /// </summary>
        public bool RequireHttps
        {
            get
            {
                //外部是否有配置
                if (!this._actionConfig.IsNull() && this._actionConfig.RequireHttps.HasValue)
                {
                    return this._actionConfig.RequireHttps.Value;
                }

                //需要http请求
                var requireHttpsAttribute = this.GetCustomAttribute<RequireHttpsAttribute>();

                //没有配置取自身的配置
                return !requireHttpsAttribute.IsNull() || this._globalActionConfig.RequireHttps.Value;

            }
        }

        /// <summary>
        /// 接口是否已经取消
        /// 优先级为：1.外部自定义配置，2.接口自身配置
        /// </summary>
        public bool IsObsolete
        {
            get
            {
                //外部定义了，就取外部定义策略
                if (!this._actionConfig.IsNull() && this._actionConfig.Obsolete.HasValue)
                {
                    return this._actionConfig.Obsolete.Value;
                }

                //是否过期了
                var obsoleteAttribute = this.GetCustomAttribute<ObsoleteAttribute>();

                //外部未配置策略
                return !obsoleteAttribute.IsNull() || this._globalActionConfig.Obsolete.Value;
            }
        }

        /// <summary>
        /// 当前接口版本
        /// </summary>
        public string Version
        {
            get
            {
                var versionAttribute = this.GetCustomAttribute<VersionAttribute>();
                //如果定义了特性版本，就直接取特性版本
                return !versionAttribute.IsNull() ? versionAttribute.Version.ToString() : "0.0";
            }
        }

        /// <summary>
        /// 接口描述信息
        /// </summary>
        public string Description
        {
            get
            {
                var descriptionAttribute = this.GetCustomAttribute<DescriptionAttribute>();
                return !descriptionAttribute.IsNull() ? descriptionAttribute.Description : this.ActionName;
            }
        }

        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName
        {
            get
            {
                //外部定义了，就取外部定义策略
                if (!this._actionConfig.IsNull() && !this._actionConfig.GroupName.IsNull())
                {
                    return this._actionConfig.GroupName;
                }

                //自己定义的特性
                var actionGroupAttribute = this.GetCustomAttribute<ActionGroupAttribute>();
                if (!actionGroupAttribute.IsNull() && !actionGroupAttribute.GroupName.IsNull())
                {
                    return actionGroupAttribute.GroupName;
                }

                //兜底
                return this._globalActionConfig.GroupName;
            }

        }

        /// <summary>
        /// 接口作者是谁
        /// </summary>
        public string AuthorName
        {
            get
            {
                var authorAttribute = this.GetCustomAttribute<AuthorAttribute>();
                return !authorAttribute.IsNull() ? authorAttribute.Name : string.Empty;
            }
        }

        /// <summary>
        /// 获取缓存特性,请注意null值判断
        /// </summary>
        public ActionResultCacheAttribute Cache
        {
            get
            {
                //外部定义了缓存策略就使用外部定义的
                if (!this._actionConfig.IsNull() && this._actionConfig.CacheTime.HasValue)
                {
                    return new ActionResultCacheAttribute(this._actionConfig.CachePrefix,
                        this._actionConfig.CacheTime ?? 0, _actionConfig.CacheKeyIgnoreUserIdAndUserName ?? true);
                }

                //接口是否应用了缓存特性
                var actionResultCacheAttribute = this.GetCustomAttribute<ActionResultCacheAttribute>();

                //如果存在直接使用自己的缓存特性
                if (!actionResultCacheAttribute.IsNull())
                {
                    return actionResultCacheAttribute;
                }

                //兜底
                return new ActionResultCacheAttribute(this._globalActionConfig.CachePrefix,
                    this._globalActionConfig.CacheTime ?? 0,
                    this._globalActionConfig.CacheKeyIgnoreUserIdAndUserName ?? true);
            }
        }

        /// <summary>
        /// 待移除的缓存匹配键
        /// </summary>
        public string[] UnloadCacheKeys
        {
            get
            {
                //外部定义了缓存策略就使用外部定义的
                if (!this._actionConfig.IsNull() && !this._actionConfig.UnloadCacheKeys.IsNull())
                {
                    return this._actionConfig.UnloadCacheKeys;
                }

                //接口是否应用了缓存特性
                var unloadCachekeysAttribute = this.GetCustomAttribute<UnloadCachekeysAttribute>();

                //如果存在直接使用自己的缓存特性
                if (!unloadCachekeysAttribute.IsNull() && !unloadCachekeysAttribute.UnloadCacheKeys.IsNull())
                {
                    return unloadCachekeysAttribute.UnloadCacheKeys;
                }

                //兜底
                return this._globalActionConfig.UnloadCacheKeys;
            }
        }

        /// <summary>
        /// 是否需要判断当前操作用户ID和用户名是否未空
        /// </summary>
        public bool RequiredUserIdAndUserName
        {
            get
            {
                //外部是否启用了外部自定义配置
                if (!this._actionConfig.IsNull() && this._actionConfig.RequiredUserIdAndUserName.HasValue)
                {
                    return this._actionConfig.RequiredUserIdAndUserName.Value;
                }

                //未设置就看接口泛型传入参数第一个是否继承了IRequiredUserIdAndUserName
                return typeof(IRequiredUserIdAndUserName).IsAssignableFrom(this.ActionType.BaseType.GetGenericArguments()[0]);
            }
        }

        /// <summary>
        /// 是否允许AjaxRequest请求此接口
        /// 优先级为：1.外部自定义配置，2.接口自身的EnableAjaxRequestAttribute标注，3.全局配置
        /// </summary>
        public bool EnableAjaxRequest
        {
            get
            {
                //外部是否启用了外部自定义配置
                if (!this._actionConfig.IsNull() && this._actionConfig.EnableAjaxRequest.HasValue)
                {
                    return this._actionConfig.EnableAjaxRequest.Value;
                }

                //是否允许AJAX
                var enableAjaxRequestAttribute = this.GetCustomAttribute<EnableAjaxRequestAttribute>();
                //存在特性标注，直接返回配置
                if (!enableAjaxRequestAttribute.IsNull())
                {
                    return enableAjaxRequestAttribute.EnableAjaxRequest;
                }

                //自身免疫配置，用系统全局配置
                return this._globalActionConfig.EnableAjaxRequest.Value;
            }
        }

        /// <summary>
        /// 是否允许记录日志
        /// </summary>
        public bool EnableRecordApiLog
        {
            get
            {
                //外部定义了，就取外部定义策略
                if (!this._actionConfig.IsNull() && this._actionConfig.EnableRecordApiLog.HasValue)
                {
                    return this._actionConfig.EnableRecordApiLog.Value;
                }

                //自己定义的特性
                var enableRecordApiLogAttribute = this.GetCustomAttribute<EnableRecordApiLogAttribute>();
                if (!enableRecordApiLogAttribute.IsNull())
                {
                    return enableRecordApiLogAttribute.EnableRecordApiLog;
                }

                //兜底
                return this._globalActionConfig.EnableRecordApiLog.Value;
            }
        }

        /// <summary>
        /// 是否允许打包到SDK
        /// </summary>
        public bool CanPackageToSdk
        {
            get
            {
                //外部定义了，就取外部定义策略
                if (!this._actionConfig.IsNull() && this._actionConfig.CanPackageToSdk.HasValue)
                {
                    return this._actionConfig.CanPackageToSdk.Value;
                }

                //增加了禁止打包的特性
                var disablePackageSdkAttribute = this.GetCustomAttribute<DisablePackageSdkAttribute>();
                if (!disablePackageSdkAttribute.IsNull())
                {
                    return false;
                }

                //兜底
                return this._globalActionConfig.CanPackageToSdk.Value;
            }
        }

        /// <summary>
        /// 是否走IApiSecurity加解密流程
        /// </summary>
        public bool DataSignatureTransmission
        {
            get
            {
                //外部定义了，就取外部定义策略
                if (!this._actionConfig.IsNull() && this._actionConfig.DataSignatureTransmission.HasValue)
                {
                    return this._actionConfig.DataSignatureTransmission.Value;
                }

                //禁止走加解密接口流程
                var disableDataSignatureTransmissionAttribute = this.GetCustomAttribute<DisableDataSignatureTransmissionAttribute>();
                if (!disableDataSignatureTransmissionAttribute.IsNull())
                {
                    return false;
                }

                //兜底
                return this._globalActionConfig.DataSignatureTransmission.Value;
            }
        }

        /// <summary>
        /// 是否允许匿名访问
        /// </summary>
        public bool AllowAnonymous
        {
            get
            {
                //外部定义了，就取外部定义策略
                if (!this._actionConfig.IsNull() && this._actionConfig.AllowAnonymous.HasValue)
                {
                    return this._actionConfig.AllowAnonymous.Value;
                }

                //自定义特性了
                var allowAnonymousAttribute = this.GetCustomAttribute<AllowAnonymousAttribute>();
                if (!allowAnonymousAttribute.IsNull())
                {
                    return true;
                }

                //兜底配置
                return this._globalActionConfig.AllowAnonymous.Value;
            }
        }

        /// <summary>
        /// 如果接口定义了ActionNameAttribute特性安装特性指定的接口名称，否则安装类名称去掉Action结尾作为接口名称 
        /// 注意：忽略大小写
        /// </summary>
        public string ActionName
        {
            get
            {
                //接口名称
                var actionNameAttribute = this.GetCustomAttribute<ActionNameAttribute>();

                //是否含有前缀
                string prefix = string.Empty;

                //接口所在程序集是否定义了统一的接口前缀
                var apiPrefixAttributes = (ApiPrefixAttribute[])this.ActionType.Assembly.GetCustomAttributes(typeof(ApiPrefixAttribute), false);
                if (!apiPrefixAttributes.IsNull() && apiPrefixAttributes.Any())
                {
                    prefix = apiPrefixAttributes[0].Prefix;
                }

                //如果手工指定了Action名称，那么使用指定的名称
                if (!actionNameAttribute.IsNull())
                {
                    return prefix.IsNullOrEmpty() ? actionNameAttribute.Name : "{0}.{1}".With(prefix, actionNameAttribute.Name);
                }

                //有可能安Action结尾，但是长度不够，直接返回自身类型作为接口名称
                if (this.ActionType.Name.Length <= "Action".Length)
                {
                    return prefix.IsNullOrEmpty() ? this.ActionType.Name : "{0}.{1}".With(prefix, this.ActionType.Name);
                }

                //不指定名称，就使用自身类型，去掉Action后缀（如果有的话）作为接口名称
                string actionName = this.ActionType.Name.EndsWith("Action", StringComparison.OrdinalIgnoreCase)
                            ? this.ActionType.Name.Substring(0, this.ActionType.Name.Length - "Action".Length)
                            : this.ActionType.Name;

                //返回接口名称
                return prefix.IsNullOrEmpty() ? actionName : "{0}.{1}".With(prefix, actionName);

            }
        }

        /// <summary>
        /// 特性路由器
        /// </summary>
        public RouteAttribute Route
        {
            get
            {
                //外部定义了，就取外部定义策略
                if (!this._actionConfig.IsNull() && !this._actionConfig.RouteUrl.IsNullOrEmpty())
                {
                    return new RouteAttribute(this._actionConfig.RouteUrl);
                }

                //返回当前的路由
                return this.GetCustomAttribute<RouteAttribute>();
            }
        }
    }
}