/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/27/2016 8:47:24 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 消息的重要度
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EventDegreeAttribute : Attribute
    {
        /// <summary>
        /// 重要度
        /// </summary>
        public Degree Degree { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="degree">重要度</param>
        public EventDegreeAttribute(Degree degree)
        {
            this.Degree = degree;
        }
    }
}
