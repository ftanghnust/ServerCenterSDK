/*********************************************************
 * FRXS 小马哥 2016/7/18 星期一 16:07:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model.Order
{
    /// <summary>
    /// 提交拣货返回消息对象
    /// </summary>
    public class ReturnSubmitInfo
    {
        /// <summary>
        /// 提交拣货结果
        /// </summary>
        public bool IsResult { get; set; }

        /// <summary>
        /// 返回标识
        /// </summary>
        public int Flag { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Info { get; set; }
    }
}
