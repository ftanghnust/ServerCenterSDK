/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 11/2/2015 8:32:16 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// 默认的SDK访问实现;注意：请不要讲此实现类设置成全局单例类
    /// </summary>
    public class DefaultApiClient : IApiClient
    {
        //服务器地址
        private string _svrUrl = string.Empty;
        private string _appKey = string.Empty;
        private string _appSecret = string.Empty;
        private IApiLogger _topLogger;      //日志记录器
        private bool _disableTrace = true;
        private int _timeout = 100000;//100秒
        private ResponseFormat _responseFormat = ResponseFormat.JSON;
        private Encoding _encoding = Encoding.UTF8; //输出值类型
        private ICacheManager _cacheManager;
        private Func<ApiUser> _defaultUser;
        private IApiSecurity _apiSecurity;
        private ISignService _signService;

        /// <summary>
        /// 默认的SDK访问实现类;
        /// </summary>
        /// <param name="svrUrl">API接口服务器地址，如果servUrl参数未指定；优先级比配置文件高</param>
        /// <param name="appKey">客户端APPKEY(预留)；优先级比配置文件高</param>
        /// <param name="appSecret">客户端APPKEY加密密钥(预留)；优先级比配置文件高</param>
        /// <param name="sdkConfigSectionName">配置节点</param>
        /// <param name="defaultUser">获取操作当前接口用户委托</param>
        /// <param name="apiSecurity">加密解密服务，公开出来，让调用者去实现具体的加解密过程</param>
        /// <param name="signService">数据签名服务，公开出来，让调用者去实现具体的数据签名流程</param>
        public DefaultApiClient(
            string svrUrl = "",
            string appKey = "",
            string appSecret = "",
            string sdkConfigSectionName = "",
            Func<ApiUser> defaultUser = null,
            ISignService signService = null,
            IApiSecurity apiSecurity = null)
        {
            //先读取下配置文件是否存在
            if (!string.IsNullOrWhiteSpace(sdkConfigSectionName))
            {
                var sdkConfig = this.GetSdkDefaultConfig(sdkConfigSectionName);
                if (null == sdkConfig)
                {
                    throw new Exception("web.config未配置SDK节点:" + sdkConfigSectionName);
                }
                this._svrUrl = sdkConfig.ServerUrl ?? string.Empty;
                this._appKey = sdkConfig.AppKey ?? string.Empty;
                this._appSecret = sdkConfig.AppSecret ?? string.Empty;
            }

            //直接设置优先
            if (!string.IsNullOrWhiteSpace(svrUrl))
            {
                this._svrUrl = svrUrl;
            }
            if (!string.IsNullOrWhiteSpace(appKey))
            {
                this._appKey = appKey;
            }
            if (!string.IsNullOrWhiteSpace(appSecret))
            {
                this._appSecret = appSecret;
            }

            //未指定接口服务器地址
            if (string.IsNullOrWhiteSpace(this._svrUrl))
            {
                throw new Exception("请求接口SvrUrl地址未配置，请先配置。");
            }

            //获取用户委托
            this._defaultUser = defaultUser;

            //加密解密接口
            this._apiSecurity = (apiSecurity ?? new DefaultApiSecurity());

            //数据签名
            this._signService = (signService ?? new DefaultSignService());

            this._topLogger = new DefaultApiLogger();
            this._cacheManager = new DefaultCacheManager();

        }

        /// <summary>
        /// 默认100000（100秒）
        /// </summary>
        /// <param name="timeout">超时时间</param>
        public void SetTimeout(int timeout)
        {
            this._timeout = timeout;
        }

        /// <summary>
        /// 默认False(启用日志记录器)
        /// </summary>
        /// <param name="disableTrace">是否禁用日志记录器true/false</param>
        public void SetDisableTrace(bool disableTrace)
        {
            this._disableTrace = disableTrace;
        }

        /// <summary>
        /// 设置日志记录器
        /// </summary>
        /// <param name="topLogger">新的logger实现，如果设置为null则代表禁用日志记录器</param>
        public void SetTopLogger(IApiLogger topLogger)
        {
            this._topLogger = topLogger ?? NullApiLogger.Instance;
        }

        /// <summary>
        /// 重新设置新的SDK本地缓存器
        /// </summary>
        /// <param name="cacheManager">新的缓存器</param>
        public void SetCacheManager(ICacheManager cacheManager)
        {
            if (null == cacheManager)
            {
                throw new Exception("参数cacheManager不能为null");
            }
            this._cacheManager = cacheManager;
        }

        /// <summary>
        /// 获取服务器地址委托，参数1为接口名称，参数2为返回值
        /// 为什么定义此委托，当我们将所有接口打包成一个DLL的时候，
        /// 其实后端可能是几个服务器，所以我们需要根据接口名称来判断连接那个服务器
        /// </summary>
        public Func<string, string> GetServerUrlFun;

        /// <summary>
        /// 获取SDK本地缓存系统，缓存器里的所有缓存键集合
        /// </summary>
        public IEnumerable<string> GetAllCacheKeys()
        {
            return this._cacheManager.GetAllKeys();
        }

        /// <summary>
        /// 设置返回值序列化类型(暂时未实现XML格式化，系统默认JSON格式化)
        /// </summary>
        /// <param name="responseFormat">需要服务器返回的格式化类型</param>
        public void SetResponseFormat(ResponseFormat responseFormat)
        {
            //this._responseFormat = responseFormat;
        }

        /// <summary>
        /// 获取默认的配置信息
        /// </summary>
        /// <param name="sectionName">WEB.config配置节点名称</param>
        /// <returns></returns>
        private SdkConfiguration GetSdkDefaultConfig(string sectionName)
        {
            var sectionConfig = ConfigurationManager.GetSection(sectionName);
            if (!(sectionConfig is IConfigurationSectionHandler))
            {
                return null;
            }
            return (SdkConfiguration)sectionConfig;
        }

        /// <summary>
        /// 对数据进行摘要签名
        /// </summary>
        /// <param name="content">待进行MD5签名的原始数据</param>
        /// <returns>返回大写的32位摘要数据</returns>
        private string Md5(string content)
        {
            byte[] b = Encoding.Default.GetBytes(content);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = string.Empty;
            for (int i = 0; i < b.Length; i++)
            {
                ret += b[i].ToString("x").PadLeft(2, '0');
            }
            return ret.ToUpper();
        }

        /// <summary>
        /// 构造提交参数
        /// </summary>
        /// <typeparam name="T">请求返回的对象类型</typeparam>
        /// <param name="request">请求参数包</param>
        /// <returns></returns>
        private IDictionary<string, string> BuildPostData<T>(RequestBase<T> request) where T : ResponseBase
        {
            string appKey = this._appKey;
            string actionName = request.GetApiName();
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string format = this._responseFormat.ToString();
            //版本，预留空，方便服务器接口版本切换
            string version = request.GetVersion();
            //先对data数据加密
            string data = this._apiSecurity.RequestEncrypt(request.GetRequestJsonData());

            //构造上送参数
            IDictionary<string, string> requestParams = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            requestParams.Add("AppKey", appKey);
            requestParams.Add("ActionName", actionName);
            requestParams.Add("TimeStamp", timeStamp);
            requestParams.Add("Format", format);
            requestParams.Add("Version", version);
            requestParams.Add("Data", data);
            //根据签名的上送参数进行数据签名
            string sign = this._signService.Sign(requestParams);
            //加入签名参数
            requestParams.Add("Sign", sign);

            //返回
            return requestParams;
        }

        /// <summary>
        /// 根据请求获取缓存键，计算方式：MD5(输出类型+请求类型+请求API+请求方式+请求数据包);确保缓存键的唯一性
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="request">请求参数包对象</param>
        /// <returns>根据请求参数包计算出缓存键，防止缓存冲突</returns>
        private string GetRequestCacheKey<T>(RequestBase<T> request) where T : ResponseBase
        {
            return request.GetApiName() + "." + this.Md5(typeof(T).FullName + request.GetType().FullName + request.GetHttpMethod() + request.GetRequestJsonData());
        }

        /// <summary>
        /// 请注意返回有可能未null，需要判断
        /// </summary>
        /// <typeparam name="T">
        /// <![CDATA[返回格式化字符串（JSON/XML）对应的输出实体类型，需要继承TopRespBase抽象基类]]>
        /// </typeparam>
        /// <param name="request">
        /// <![CDATA[请求参数类，需继承：RequestBase<>抽象基类]]>
        /// </param>
        /// <param name="cacheOptions">
        /// <![CDATA[
        /// 如果不启用SDK本地缓存，设置null即可，系统将会自动设置成默认设置
        /// 是否进行SDK本地缓存，如果设置为true(默认false)，返回对象将直接从本地SDK缓存里获取，
        /// 第一次访问不存在的时候，会自动将获取到的输出值压入本地缓存，下次调用同样接口参数相同的情况下
        /// 不会请求接口API，而是会直接获取本地缓存返回，建议将变化很不频繁的字典，配置对象数据可以缓存下，提高访问效率(默认过期时间60分钟)
        /// ]]>
        /// </param>
        /// <returns>返回一个继承自：TopRespBase的数据对象</returns>
        public T Execute<T>(RequestBase<T> request, CacheOptions cacheOptions = null) where T : ResponseBase
        {
            //检测是否定义获取服务器地址委托，定义了就使用委托
            if (null != this.GetServerUrlFun)
            {
                this._svrUrl = this.GetServerUrlFun(request.GetApiName());
            }

            //缓存是否设置了,如果设置为null，自动启用默认缓存设置
            cacheOptions = (cacheOptions ?? new CacheOptions() { FromLocalCache = false });

            //系统缓存键，默认为空，只有当CacheOptions.FromLocalCache为true的时候才生成
            var cacheKey = string.Empty;

            //尝试直接从SDK本地缓存里读取数据
            if (cacheOptions.FromLocalCache)
            {
                //根据请求数据包生成对应的缓存键，防止缓存键的冲突
                cacheKey = this.GetRequestCacheKey(request);
                //直接从本地缓存里获取缓存对象
                var cacheItem = this._cacheManager.Get(cacheKey);
                //存在缓存对象，直接返回对象，无需连接API接口访问
                if (null != cacheItem && cacheItem.Data is T)
                {
                    return (T)cacheItem.Data;
                }
            }

            //调试信息
            if (!this._disableTrace)
            {
                this._topLogger.Info(string.Format("请求方法：{0}{1}", Environment.NewLine, request.GetApiName()));
            }

            //获取用户委托存在，并且还未手工设置用户名称（设计失误，UserId应该设计成可空类型）
            if (null != this._defaultUser && string.IsNullOrWhiteSpace(request.UserName))
            {
                request.UserId = this._defaultUser().UserId;
                request.UserName = this._defaultUser().UserName;
            }

            //参数组装
            var postData = this.BuildPostData(request);

            //请求数据
            string requestData = string.Join("&", (from item in postData select item.Key + "=" + item.Value).ToArray());

            //调试信息
            if (!this._disableTrace)
            {
                this._topLogger.Info(string.Format("请求参数：{0}{1}?{2}", Environment.NewLine, this._svrUrl, requestData));
            }

            HttpWebUtils httpWebUtils = new HttpWebUtils { Timeout = this._timeout };

            try
            {
                //是否指定是用POST提交数据
                HttpRespBody respBody = null;

                if (HttpMethod.POST == request.GetHttpMethod())
                {
                    if (request is IApiUploadRequest<T>)
                    {
                        IApiUploadRequest<T> uploadRequest = request as IApiUploadRequest<T>;
                        IDictionary<string, FileItem> fileParams = Utils.CleanupDictionary(uploadRequest.GetFileParameters());
                        respBody = httpWebUtils.DoPost(this._svrUrl, postData, fileParams);
                    }
                    else
                    {
                        respBody = httpWebUtils.DoPost(this._svrUrl, postData);
                    }
                }
                else
                {
                    respBody = httpWebUtils.DoGet(this._svrUrl, postData);
                }

                //对下送的数据进行解密
                var responseDtoDecryptResult = this._apiSecurity.ResponseDecrypt(respBody.Body);

                //解密失败
                if (!responseDtoDecryptResult.IsSuccess)
                {
                    if (!this._disableTrace)
                    {
                        this._topLogger.Error("解密失败，原始数据：" + responseDtoDecryptResult.Data);
                    }
                    return default(T);
                }

                //解密成功，使用解密后的数据
                respBody.Body = responseDtoDecryptResult.Data;

                //调试信息
                if (!this._disableTrace)
                {
                    //返回的HttpHeader头信息
                    this._topLogger.Info(string.Format("返回HttpHeaders：{0}{1}", Environment.NewLine,
                        string.Join(Environment.NewLine, respBody.Headers.Select(o => string.Format("{0}:{1}", o.Key, o.Value)))));
                    //返回数据
                    this._topLogger.Info(string.Format("返回数据：{0}{1}", Environment.NewLine, respBody.Body));
                }

                //替换掉不规则的json特殊字符串文件
                foreach (var item in request.GetReplaces())
                {
                    respBody.Body = respBody.Body.Replace(item.Key, item.Value);
                }

                //反序列化出对象
                T respObj = (this._responseFormat == ResponseFormat.JSON) ?
                    new ApiJsonParser<T>().Parse(respBody.Body, this._encoding) : new ApiXmlParser<T>().Parse(respBody.Body, this._encoding);

                //记录下返回的JSON数据，方便调试
                respObj.Resp_Body = respBody.Body;

                //记录下上送的JSON数据包，方便调试
                respObj.Resp_ReqData = string.Format("{0}?{1}", this._svrUrl, requestData);

                //服务器HTTPHeader头信息(里面包含了服务器一些执行情况信息，比如Api-Time-Used（执行此次API花费的毫秒数）)
                respObj.Resp_Headers = respBody.Headers;

                //设置了压入缓存到本地SDK缓存器就将对象缓存起来，方便下次直接使用
                if (cacheOptions.FromLocalCache && null != respObj)
                {
                    this._cacheManager.Set(cacheKey, respObj, cacheOptions.CacheTime);
                }

                //返回反序列化对象
                return respObj;

            }
            catch (Exception ex)
            {
                if (!this._disableTrace)
                {
                    this._topLogger.Error(ex.StackTrace);
                }
                return default(T);
            }
        }
    }
}