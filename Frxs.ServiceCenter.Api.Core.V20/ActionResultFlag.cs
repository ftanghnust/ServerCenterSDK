/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/26/2015 4:02:14 PM
 * *******************************************************/
using System.ComponentModel;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 所有接口返回代码枚举
    /// </summary>
    public enum ActionResultFlag
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        SUCCESS = 0,

        /// <summary>
        /// 系统错误
        /// </summary>
        [Description("系统错误")]
        FAIL = 1,

        /// <summary>
        /// 密钥验证失败
        /// </summary>
        [Description("密钥验证失败 ")]
        ERR_SIGN = 2,

        /// <summary>
        /// 系统错误
        /// </summary>
        [Description("系统错误")]
        EXCEPTION = 3,

        /// <summary>
        /// 连接超时
        /// </summary>
        [Description("连接超时")]
        TIMEOUT = 4,

        /// <summary>
        /// 解密上送参数失败
        /// </summary>
        [Description("解密上送参数失败")]
        DECRYPT_REQUEST_FAIL = 5,

        /// <summary>
        /// 未知错误
        /// </summary>
        [Description("未知错误")]
        OTHER = 999
    }
}