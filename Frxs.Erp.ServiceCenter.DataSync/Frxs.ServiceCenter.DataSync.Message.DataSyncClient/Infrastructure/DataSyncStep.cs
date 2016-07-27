/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/22/2016 6:20:48 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 步骤
    /// </summary>
    [Serializable]
    public class DataSyncStep
    {
        /// <summary>
        /// 同步的表名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 事件处理的类型
        /// </summary>
        public string Type { get; set; }
    }
}
