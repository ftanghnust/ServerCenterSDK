/*********************************************************
 * FRXS 小马哥 2016/4/9 16:54:35
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// SaleOrderDetailsPick实体类
    /// </summary>
    [Serializable]
    public class SaleOrderPreDetailsPick
    {
        #region 模型
        /// <summary>
        /// 编号(SaleOrderDetailsPick.ID)
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 商品编号(Prouct.ProductID)
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// WCProduct.WCProductID
        /// </summary>
        public int WCProductID { get; set; }

        /// <summary>
        /// 商品SKU
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 描述商品名称(Product.ProductName)
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品的国际条码
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// 对货数量
        /// </summary>
        public decimal? CheckQty { get; set; }

        /// <summary>
        /// 商品图片用于移动端(Products.ImageUrl200*200)
        /// </summary>
        public string ProductImageUrl200 { get; set; }

        /// <summary>
        /// 商品图片用于PC端(Products.ImageUrl200*200)
        /// </summary>
        public string ProductImageUrl400 { get; set; }

        /// <summary>
        /// 货架号区号
        /// </summary>
        public int ShelfAreaID { get; set; }

        /// <summary>
        /// 货位ID
        /// </summary>
        public int? ShelfID { get; set; }

        /// <summary>
        /// 货位编号
        /// </summary>
        public string ShelfCode { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public decimal SaleQty { get; set; }

        /// <summary>
        /// 购买单位
        /// </summary>
        public string SaleUnit { get; set; }

        /// <summary>
        /// 购买单位包装数
        /// </summary>
        public decimal SalePackingQty { get; set; }

        /// <summary>
        /// 拣货数量
        /// </summary>
        public decimal? PickQty { get; set; }

        /// <summary>
        /// 拣货人员ID
        /// </summary>
        public int? PickUserID { get; set; }

        /// <summary>
        /// 拣货人员名称
        /// </summary>
        public string PickUserName { get; set; }

        /// <summary>
        /// 拣货时间
        /// </summary>
        public DateTime? PickTime { get; set; }

        /// <summary>
        /// 对货时间
        /// </summary>
        public DateTime? CheckTime { get; set; }

        /// <summary>
        /// 对货人员ID
        /// </summary>
        public int? CheckUserID { get; set; }

        /// <summary>
        /// 对货人员名称
        /// </summary>
        public string CheckUserName { get; set; }

        /// <summary>
        /// 对货是否正确(0:错误;1:正确）
        /// </summary>
        public int? IsCheckRight { get; set; }

        /// <summary>
        /// 是否为后来添加商品(0:不是;1:是的)
        /// </summary>
        public int IsAppend { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        public string ModifyUserName { get; set; }

        /// <summary>
        /// 配送预定数量
        /// </summary>
        public decimal PreQty { get; set; }

        /// <summary>
        /// 配送单位价格
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 库存单位-小
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 库存单位实发数量
        /// </summary>
        public decimal UnitQty { get; set; }

        /// <summary>
        /// 库存单位价格
        /// </summary>
        public decimal UnitPrice { get; set; }

        #endregion

    }
}
