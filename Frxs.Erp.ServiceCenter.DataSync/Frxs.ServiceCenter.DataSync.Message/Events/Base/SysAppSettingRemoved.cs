/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 仓库报表参数 移除(Remove)事件
    /// </summary>
    [Serializable, EventGroup("Base", "SysAppSetting.03")]
    public class SysAppSettingRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 仓库报表参数 编号
        /// </summary>
        public int ID { get; set; }

    }
}
