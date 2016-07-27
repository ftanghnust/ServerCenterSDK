/*********************************************************
 * FRXS 小马哥 2016/6/13 9:35:14
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model.Deliver
{
    /// <summary>
    /// 对货操作修改商品实体
    /// </summary>
    [Serializable]
    public class CheckedGoodsNumInfo //: BaseModel
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        [Required]
        public int ProductId { get; set; }

        /// <summary>
        /// 修改数量
        /// </summary>
        [Required]
        public decimal Number { get; set; }

        /// <summary>
        /// 对货是否正确(0:错误;1:正确）
        /// </summary>
        [Required]
        public int IsCheckRight { get; set; }
    }
}
