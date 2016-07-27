/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 仓库报表参数 创建(Created)事件
    /// </summary>
    [Serializable, EventGroup("Base", "SysAppSetting.01")]
    public class SysAppSettingCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 仓库报表参数 编号
        /// </summary>
        public int ID { get; set; }
    }
}
