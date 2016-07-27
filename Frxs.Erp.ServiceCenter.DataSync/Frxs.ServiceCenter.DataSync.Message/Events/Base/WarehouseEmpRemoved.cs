/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 仓库员工 移除(Remove)事件
    /// </summary>
    [Serializable, EventGroup("Base", "WarehouseEmp.03")]
    public class WarehouseEmpRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 仓库员工编号
        /// </summary>
        public int EmpID { get; set; }

    }
}
