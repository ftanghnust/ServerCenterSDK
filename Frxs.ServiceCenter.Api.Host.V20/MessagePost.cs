/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/30/2016 4:06:36 PM
 * *******************************************************/
using System;
using System.Messaging;

namespace Frxs.ServiceCenter.Api.Host
{
    public class MessagePost : IDisposable
    {
        private MessageQueue myQueue;
        private bool isCanWrite = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public MessagePost(string path)
        {
            this.myQueue = new MessageQueue(path);
            this.myQueue.Formatter = new BinaryMessageFormatter();
            this.isCanWrite = this.myQueue.CanWrite;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="messaglog"></param>
        /// <returns></returns>
        public bool Post<T>(T entity, string messaglog)
        {
            bool result;
            try
            {
                if (this.isCanWrite)
                {
                    Message myMessage = new Message(entity, new BinaryMessageFormatter());
                    myMessage.Label = messaglog;
                    myMessage.Recoverable = true;
                    this.myQueue.Send(myMessage);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch(Exception ex)
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fun"></param>
        public void Receive<T>(Action<T> fun)
        {
            while (true)
            {
                T v = (T)((object)this.myQueue.Receive().Body);
                fun(v);
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
