/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/22/2016 6:20:15 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 全量同步配置器
    /// </summary>
    [Serializable]
    public class DataSyncConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public DataSync[] DataSyncs { get; set; }
    }
}
