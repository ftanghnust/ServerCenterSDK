﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Promotion.Model
{
    public class SaleCartDetail
    {
        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 下单门店ID
        /// </summary>
        public int ShopID { get; set; }

        /// <summary>
        /// 下单门店人员ID
        /// </summary>
        public int XSUserID { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// 预订数量
        /// </summary>
        public decimal PreQty { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

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
        /// 商品SKU
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 商品条码
        /// </summary>
        public string ProductBarCode { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string ProductImageUrl200 { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string ProductImageUrl400 { get; set; }

        /// <summary>
        /// 商品单位
        /// </summary>
        public string SaleUnit { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 库存单位促销价格
        /// </summary>
        public decimal PromotionUnitPrice { get; set; }

        /// <summary>
        /// 库存单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 库存单位价格
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 调整后的最终金额(=ifnull(PromotionPrice,UnitPrice) *UnitQty)
        /// </summary>
        public decimal SubAmt { get; set; }

        /// <summary>
        /// 门店库存单位平台率(%)(=WProducts.ShopAddPerc)
        /// </summary>
        public decimal ShopAddPerc { get; set; }

        /// <summary>
        /// 门店库存单位积分(=WProducts.ShopPoint)
        /// </summary>
        public decimal ShopPoint { get; set; }


        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }

        #endregion
    }
}