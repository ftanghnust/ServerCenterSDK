/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/14/2016 2:38:03 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 事件分组
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EventGroupAttribute : Attribute
    {
        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName { get; private set; }

        /// <summary>
        /// 子分组
        /// </summary>
        public string SubGroupName { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupName">分组名称</param>
        /// <param name="subGroupName">子分组</param>
        public EventGroupAttribute(string groupName, string subGroupName = "")
        {
            this.GroupName = groupName;
            this.SubGroupName = subGroupName;
        }
    }
}
