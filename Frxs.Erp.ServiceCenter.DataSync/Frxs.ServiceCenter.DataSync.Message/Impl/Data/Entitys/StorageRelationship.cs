/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 7:08:54 PM
 * *******************************************************/
using System;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl.Data.Entitys
{
    /// <summary>
    /// 仓库消息存储关系映射表
    /// </summary>
    public class StorageRelationship : BaseEntity
    {
        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 存储消息的数据表
        /// </summary>
        public string StorageName { get; set; }

        /// <summary>
        /// 仓库消费消息到了那个索引号
        /// </summary>
        public string LastConsumeMessageId { get; set; }

        /// <summary>
        /// 最后消费时间
        /// </summary>
        public DateTime? LastConsumeTime { get; set; }
    }
}