/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/22/2016 6:20:33 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 所有逻辑同步
    /// </summary>
    [Serializable]
    public class DataSync
    {
        /// <summary>
        /// 显示类型(如果设置值为Line则直接显示为横线)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 同步的表名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DataSyncStep[] Steps { get; set; }
    }
}
