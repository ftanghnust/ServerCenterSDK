/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/21 17:05:55
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// 
    /// </summary>
    internal class DefaultSignService : ISignService
    {

        /// <summary>
        /// 数据签名;只进行值的签名
        /// </summary>
        /// <param name="signParams">待签名的数据字典</param>
        /// <returns></returns>
        //private string Sign(ApiDictionary signParams)
        //{
        //    string joinStr = this._appSecret + string.Join("", (from item in signParams.Values select item).ToArray()) + this._appSecret;
        //    return this.MD5(joinStr).ToUpper();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns></returns>
        public string Sign(IDictionary<string, string> requestParams)
        {
            return "";
        }
    }
}
