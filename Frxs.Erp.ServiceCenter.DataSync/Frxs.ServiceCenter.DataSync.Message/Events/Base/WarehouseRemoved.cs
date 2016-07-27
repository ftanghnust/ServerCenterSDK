/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 仓库移除(Removed)事件
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "Warehouse.03")]
    public class WarehouseRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WID { get; set; }
    }
}
