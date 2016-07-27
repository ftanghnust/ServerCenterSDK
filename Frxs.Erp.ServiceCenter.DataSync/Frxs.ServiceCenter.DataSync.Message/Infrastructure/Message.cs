/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 9:27:14 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 消息传输对象
    /// </summary>
    [Serializable]
    public class Message<T> :
        IEquatable<Message<T>>,
        IComparable<Message<T>>,
        IComparable where T : IMessageBody
    {
        /// <summary>
        /// 消息唯一ID，有序
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 消息主题，也即：消息事件(EventName)
        /// 比如：OrderCreated,OrderChanged,OrderDelete等
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// 消息对应的仓库ID，如果是全局消息，此值为：0
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 消息摘要,此消息体保存的时候可能会序列化成JSON或者XML或者进行字节序列化
        /// 比如：{OrderId:"10001"}
        /// </summary>
        public T Body { get; set; }

        /// <summary>
        /// 消息发布时间
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Message<T> other)
        {
            if (null == other)
                return false;
            return this.Id.Equals(other.Id);
        }

        /// <summary>
        /// IComparable.CompareTo
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Message<T> other)
        {
            if (null == other)
            {
                return -1;
            }
            return this.Id.CompareTo(other.Id);
        }

        /// <summary>
        /// IComparable.CompareTo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj is Message<T>)
            {
                return this.CompareTo((Message<T>)obj);
            }
            return -1;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Id:{0},Topic:{1},WID:{2}",
                this.Id, this.Topic, this.WID);
        }
    }
}