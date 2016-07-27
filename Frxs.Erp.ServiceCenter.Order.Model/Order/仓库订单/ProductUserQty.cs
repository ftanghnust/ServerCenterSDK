/*********************************************************
 * FRXS 小马哥 2016/6/20 18:00:25
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model.Order
{
    /// <summary>
    /// 商品可用数量对应实体
    /// </summary>
    [Serializable]
    public class ProductUserQty
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 商品可使用库存数量
        /// </summary>
        public decimal ProductUserNum { get; set; }
    }
}
