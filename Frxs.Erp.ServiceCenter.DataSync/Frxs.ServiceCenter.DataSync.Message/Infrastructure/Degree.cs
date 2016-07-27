/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/27/2016 11:13:52 AM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 事件消息的重要度(定义一个重要度可以在消息处理策略上给与不同的处理)
    /// </summary>
    public enum Degree
    {
        /// <summary>
        /// 重要度高（消息必须到到）
        /// </summary>
        High = 0,

        /// <summary>
        /// 正常，可以再重试后如果还不成功，可以丢弃
        /// </summary>
        Normal,

        /// <summary>
        /// 最低，发送失败，直接丢弃
        /// </summary>
        Low
    }
}
