/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/8/2016 8:47:37 AM
 * *******************************************************/
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl.Data.Entitys
{
    /// <summary>
    /// 序列号生成器
    /// </summary>
    public class SequentialNumber : BaseEntity
    {
        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 月   
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// 日
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// 消息ID的最大值
        /// </summary>
        public long MaxIdentity { get; set; }

    }
}
