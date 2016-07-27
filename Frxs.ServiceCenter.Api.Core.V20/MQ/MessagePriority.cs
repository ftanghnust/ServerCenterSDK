/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/1/27 10:28:08
 * *******************************************************/
using System.ComponentModel;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 消息优先级
    /// </summary>
    public enum MessagePriority
    {
        /// <summary>
        /// 最高
        /// </summary>
        [Description("最高")]
        Highest,

        /// <summary>
        /// 非常高
        /// </summary>
        [Description("非常高")]
        VeryHigh,

        /// <summary>
        /// 高
        /// </summary>
        [Description("高")]
        High,

        /// <summary>
        /// 高于正常级别
        /// </summary>
        [Description("高于正常级别")]
        AboveNormal,

        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal,

        /// <summary>
        /// 低
        /// </summary>
        [Description("低")]
        Low,

        /// <summary>
        /// 非常低
        /// </summary>
        [Description("非常低")]
        VeryLow,

        /// <summary>
        /// 最低
        /// </summary>
        [Description("最低")]
        Lowest

    }
}
