/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 9:31:25 AM
 * *******************************************************/

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 消息发布接口定义
    /// </summary>
    /// <typeparam name="T">事件消息对象类型</typeparam>
    public interface IMessagePublisher<T> where T : IMessageBody
    {
        /// <summary>
        /// 发布消息
        /// </summary>
        /// <returns></returns>
        bool Publish(Message<T> message) ;
    }
}
