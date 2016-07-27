/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/4/2016 10:38:17 AM
 * *******************************************************/
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient
{
    /// <summary>
    /// 返回接受对象
    /// </summary>
    public class ResponseResult<T>
    {
        /// <summary>
        /// 是否成功0成功，其他值为不成功
        /// </summary>
        public int Flag { get; set; }

        /// <summary>
        /// flag的描述
        /// </summary>
        public string FlagDescription { get; set; }

        /// <summary>
        /// 缓存时间
        /// </summary>
        public DateTime CachedTime { get; set; }

        /// <summary>
        /// 返回的ID值
        /// </summary>
        public MessageConsumeResult<T> Data { get; set; }

        /// <summary>
        /// 接口返回的消息
        /// </summary>
        public string Info { get; set; }
    }

}
