using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// 仓库子机构订单信息 
    /// 为判断仓库子机构是否可以被安全删除，需要查询相关订单信息，特增加此类
    /// </summary>
    public class WarehouseBillExt
    {
        /// <summary>
        /// 单据号
        /// </summary>
        public string BillID { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        public string BillType { get; set; }
    }
}
