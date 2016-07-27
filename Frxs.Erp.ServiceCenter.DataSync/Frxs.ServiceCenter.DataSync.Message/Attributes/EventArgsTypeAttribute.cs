/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/27/2016 8:47:24 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 事件关联的事件参数
    /// 如果对应的实现IEvent事件类为定义此特性，那么事件将会使用自身作为事件参数，将不会校验事件参数的继承性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EventArgsTypeAttribute : Attribute
    {
        /// <summary>
        /// 事件参数类型
        /// </summary>
        public Type Type { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">事件参数类型，此类型必须继承自：MessageBodyBase</param>
        /// <see cref="MessageBodyBase"/>
        public EventArgsTypeAttribute(Type type)
        {
            if (!typeof(MessageBodyBase).IsAssignableFrom(type))
            {
                throw new Exception(string.Format(Resource.Resource.EventArgsTypeAttribute_ERR,
                    type.FullName,
                    typeof(MessageBodyBase).FullName));
            }
            this.Type = type;
        }
    }
}
