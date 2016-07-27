/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/1/27 10:24:16
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 默认实现一个空的消息发送实现
    /// </summary>
    public class NullMessage : IMessage
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly NullMessage _instance = new NullMessage();

        /// <summary>
        /// 
        /// </summary>
        private NullMessage() { }

        /// <summary>
        /// 
        /// </summary>
        public static IMessage Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 默认实现什么也不做
        /// </summary>
        /// <param name="messageLable"></param>
        /// <param name="messageBody"></param>
        public void Send<T>(string messageLable, T messageBody)
        {

        }
    }
}
