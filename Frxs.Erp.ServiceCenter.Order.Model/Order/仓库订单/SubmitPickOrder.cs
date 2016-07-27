/*********************************************************
 * FRXS 小马哥 2016/4/19 9:43:53
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model.Order
{
    /// <summary>
    /// 拣货提交传入参数
    /// </summary>
    public class SubmitPickOrder
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        [Required]
        public string OrderId { get; set; }

        /// <summary>
        /// 拣货人编号
        /// </summary>
        [Required]
        public int PickUserID { get; set; }

        /// <summary>
        /// 拣货人名称
        /// </summary>
        [Required]
        public string PickUserName { get; set; }

        /// <summary>
        /// 商品信息
        /// </summary>
        [Required]
        public List<PickOrderProducts> ProductsData { get; set; }
    }

    /// <summary>
    /// 拣货商品详信息
    /// </summary>
    public class PickOrderProducts
    {

        /// <summary>
        /// 编号(SaleOrderDetails.ID)
        /// </summary>
        public string DetailsID { get; set; }

        /// <summary>
        /// 编号(SaleOrderPreDetailsPick.ID)
        /// </summary>
        public string DetailsPickID { get; set; }

        /// <summary>
        /// 货区编号
        /// </summary>
        [Required]
        public int? ShelfAreaID { get; set; }

        /// <summary>
        /// 购买单位/更换后的单位
        /// </summary>
        [Required]
        public string SaleUnit { get; set; }

        /// <summary>
        /// 单位包装数
        /// </summary>
        [Required]
        public decimal SalePackingQty { get; set; }

        /// <summary>
        /// 拣货数量/实际购买数量
        /// </summary>
        [Required]
        public decimal PickQty { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        [Required]
        public int ProductID { get; set; }

        /// <summary>
        /// 预定数量
        /// </summary>
        [Required]
        public decimal PreQty { get; set; }

        /// <summary>
        /// 是否修改单位
        /// </summary>
        public int IsSet { get; set; }
    }
}
