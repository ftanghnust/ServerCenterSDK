/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/30/2016 4:06:36 PM
 * *******************************************************/
using Frxs.ServiceCenter.Api.Core;
using System;
using System.Messaging;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl
{
    /// <summary>
    /// 默认使用微软的消息队列来作为缓冲器
    /// </summary>
    internal class MSMQ : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly MessageQueue myQueue;
        private readonly bool isCanWrite = false;

        /// <summary>
        /// 日志记录器，默认空实现
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">消息队列路径</param>
        public MSMQ(string path)
        {
            this.myQueue = new MessageQueue(path);
            this.myQueue.Formatter = new BinaryMessageFormatter();
            this.isCanWrite = this.myQueue.CanWrite;
            this.Logger = NullLogger.Instance;
        }

        /// <summary>
        /// 同步发送消息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="messaglabel"></param>
        /// <returns></returns>
        public bool Send<T>(T entity, string messaglabel)
        {
            bool result;
            try
            {
                if (this.isCanWrite)
                {
                    var myMessage = new System.Messaging.Message(entity, new BinaryMessageFormatter())
                    {
                        Label = messaglabel,
                        Recoverable = true
                    };

                    this.myQueue.Send(myMessage);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception exc)
            {
                this.Logger.Error(exc);
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 同步接收消息
        /// </summary>
        /// <param name="action"></param>
        public void Receive<T>(Action<T> action)
        {
            while (true)
            {
                try
                {
                    //同步接收消息队列数据
                    T data = (T)(this.myQueue.Receive().Body);

                    //处理数据委托
                    action(data);
                }
                catch (Exception exc)
                {
                    this.Logger.Error(exc);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.myQueue.Close();
            this.myQueue.Dispose();
        }
    }
}
