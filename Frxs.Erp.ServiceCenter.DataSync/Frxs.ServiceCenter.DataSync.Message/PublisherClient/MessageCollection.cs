/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/27/2016 9:30:41 AM
 * *******************************************************/
using System;
using System.Collections.Concurrent;

namespace Frxs.ServiceCenter.DataSync.Message.PublisherClient
{
    /// <summary>
    /// 发布端内部使用的消息队列缓存池
    /// </summary>
    public class MessageCollection
    {
        /// <summary>
        /// 
        /// </summary>
        private static ConcurrentQueue<string> _instance = new ConcurrentQueue<string>();

        /// <summary>
        /// 获取消息队列缓冲池
        /// </summary>
        public static ConcurrentQueue<string> Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
