/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 7:08:54 PM
 * *******************************************************/
using System;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 仓库消息存储关系映射表
    /// </summary>
    [Serializable]
    public class MessageStore
    {
        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 存储消息的数据表(在实际实现中，如果存储形式为分表形式，
        /// 那么存储的就是表名，如果是分库存储存储的就是连接字符串等等)
        /// </summary>
        public string StorageName { get; set; }
    }
}