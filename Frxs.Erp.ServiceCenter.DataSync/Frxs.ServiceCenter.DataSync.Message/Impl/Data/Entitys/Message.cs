/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 6:18:49 PM
 * *******************************************************/
using Frxs.ServiceCenter.Data.Core;
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl.Data.Entitys
{
    /// <summary>
    /// 消息实体与数据库映射对象
    /// </summary>
    public class Message : BaseEntity
    {
        /// <summary>
        /// 消息ID编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 事件主题
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 消息摘要
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime Created { get; set; }

    }
}