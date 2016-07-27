/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/21 17:04:09
 * *******************************************************/

using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// 数据签名
    /// </summary>
    public interface ISignService
    {
        /// <summary>
        /// 数据签名
        /// </summary>
        /// <param name="requestParams">待签名的上送参数集合</param>
        /// <returns></returns>
        string Sign(IDictionary<string,string> requestParams);
    }
}
