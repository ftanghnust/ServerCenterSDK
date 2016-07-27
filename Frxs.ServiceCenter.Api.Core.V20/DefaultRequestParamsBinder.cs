/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/18 9:02:06
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 上送参数对象绑定器
    /// </summary>
    internal class DefaultRequestParamsBinder : IRequestParamsBinder
    {
        /// <summary>
        /// 
        /// </summary>
        readonly IValueProvidersManager _valueProviderManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueProviderManager">值提供器管理器</param>
        public DefaultRequestParamsBinder(IValueProvidersManager valueProviderManager)
        {
            this._valueProviderManager = valueProviderManager;
        }

        /// <summary>
        /// 获取接口框架上送参数对象
        /// </summary>
        /// <returns></returns>
        public RequestParams GetRequestParams()
        {
            return new DefaultModelBinder().Bind<RequestParams>(this._valueProviderManager);
        }
    }
}
