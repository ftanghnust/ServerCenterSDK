/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/20 9:02:06
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 上送参数对象绑定器接口
    /// </summary>
    public interface IRequestParamsBinder
    {
        /// <summary>
        /// 获取上送的参数对象
        /// </summary>
        /// <returns></returns>
        RequestParams GetRequestParams();
    }
}
