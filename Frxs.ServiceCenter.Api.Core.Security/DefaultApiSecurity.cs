/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/8 18:27:43
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 系统框架默认的安全接口，此接口什么都没有做，直接原路返回，即上送参数解密，下送参数解密；
    /// 具体实现类可以继承此类，对上送参数解密，下送数据加密，已经数据签名进行校验等
    /// </summary>
    public class ApiSecurity : DefaultApiSecurity
    {
        /// <summary>
        /// 
        /// </summary>
        public ApiSecurity() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawRequestParams"></param>
        /// <returns></returns>
        public override RequestParamsDecryptResult RequestParamsDecrypt(RequestParams rawRequestParams)
        {
            return base.RequestParamsDecrypt(rawRequestParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="decryptedRequestParams"></param>
        /// <param name="actionResultString"></param>
        /// <returns></returns>
        public override string ResponseEncrypt(RequestParams decryptedRequestParams, string actionResultString)
        {
            return base.ResponseEncrypt(decryptedRequestParams, actionResultString);
        }
    }
}
