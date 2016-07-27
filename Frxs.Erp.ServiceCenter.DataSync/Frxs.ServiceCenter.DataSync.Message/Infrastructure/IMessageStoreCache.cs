/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/18/2016 2:34:04 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 用于判断指定查看是否在消息数据中心注册
    /// 此类在实现过程中，需要实现缓存功能
    /// </summary>
    public interface IMessageStoreCache
    {
        /// <summary>
        /// 查看是否已经注册
        /// </summary>
        /// <param name="wid">查看编号</param>
        /// <returns>true/false</returns>
        bool MessageStoreExists(int wid);
    }
}
