using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/8 18:27:43
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Frxs.ServiceCenter.Api.Host
{
    /// <summary>
    /// 系统框架默认的安全接口，此接口什么都没有做，直接原路返回，即上送参数解密，下送参数解密
    /// 如果约定了加密上送参数，下送数据，可以直接修改下面2个方法里的加密解密方式即可
    /// </summary>
    public class DES3ApiSecurity : DefaultApiSecurity
    {
        /// <summary>
        /// 缓存器
        /// </summary>
        private ICacheManager _cacheManager;

        /// <summary>
        /// 将缓存器注入到当前安全接口
        /// </summary>
        /// <param name="cacheManager">缓存器</param>
        public DES3ApiSecurity(ICacheManager cacheManager)
        {
            this._cacheManager = cacheManager;
        }

        /// <summary>
        /// 直接返回上送数据
        /// </summary>
        /// <param name="rawRequestParams">上送参数对象解密</param>
        /// <returns></returns>
        public override RequestParamsDecryptResult RequestParamsDecrypt(RequestParams rawRequestParams)
        {
            ////进行解密操作
            //var AppKey = rawRequestParams.AppKey;

            ////从数据库读取到appkey对应的解密密钥，保存到下面变量
            //var key = "";

            ////解密data业务参数包
            //string data = DES3.Decrypt(key, rawRequestParams.Data);

            ////将解密后的参数返回
            //return new RequestParamsDecryptResult(true, rawRequestParams, new RequestParams()
            //{
            //    Data = data,
            //    ActionName = rawRequestParams.ActionName,
            //    AppKey = rawRequestParams.AppKey,
            //    Format = rawRequestParams.Format,
            //    Sign = rawRequestParams.Sign,
            //    TimeStamp = rawRequestParams.TimeStamp,
            //    Version = rawRequestParams.Version
            //});

            return base.RequestParamsDecrypt(rawRequestParams);

            //return new RequestParamsDecryptResult(false, "上送参数解密错误", rawRequestParams, rawRequestParams);
        }

        /// <summary>
        /// 直接返回下送数据
        /// </summary>
        /// <param name="actionResultString">actionResult对象格式化字符串</param>
        /// <param name="decryptedRequestParams">解密后的上送参数对象</param>
        /// <returns></returns>
        public override string ResponseEncrypt(RequestParams decryptedRequestParams, string actionResultString)
        {

            //进行加密操作
            var AppKey = decryptedRequestParams.AppKey;

            //从数据库读取到appkey对应的解密密钥，保存到下面变量
            var key = "";

            //对actionResultString参数进行加密操作

            // return DES3.Encrypt("510AC015E85A40AEBF24CE8X", actionResultString);
            return base.ResponseEncrypt(decryptedRequestParams, actionResultString);
        }
    }
}
