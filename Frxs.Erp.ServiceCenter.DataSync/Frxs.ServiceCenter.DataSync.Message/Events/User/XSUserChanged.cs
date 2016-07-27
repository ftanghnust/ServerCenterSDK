/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 用户更新(Changed)事件
    /// </summary>
    [Serializable, EventGroup("User", "XSUser.02")]
    public class XSUserChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int XSUserID { get; set; }

    }
}
