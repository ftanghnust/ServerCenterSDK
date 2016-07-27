/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/2/2016 8:40:50 AM
 * *******************************************************/

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 消费消息，也即从消息中间件里获取消息
    /// </summary>
    /// <typeparam name="T">事件消息体类型</typeparam>
    public interface IMessageConsumer<T> where T : IMessageBody
    {
        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="wid">对应的仓库ID，不指定的话，安装依次获取</param>
        /// <param name="startMessageId">开始的消息ID，如果为空或者为null的话，将会从第一条消息开始</param>
        /// <param name="number">每次消息多少条消息</param>
        /// <returns></returns>
        MessageConsumeResult<T> Consume(int? wid, string startMessageId, int number);
    }
}