/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    ///  仓库创建(Created)事件
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "Warehouse.01")]
    public class WarehouseCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WID { get; set; }
    }
}
