/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/22/2016 10:48:14 AM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 全量同步管理器
    /// </summary>
    public class DataSyncHandlerManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSyncConfig GetDataSyncConfig()
        {
            using (StreamReader sr = new StreamReader("DataSync.json"))
            {
                return new DefaultJosnSerializer().Deserialize<DataSyncConfig>(sr.ReadToEnd());
            }
        }
    }
}
