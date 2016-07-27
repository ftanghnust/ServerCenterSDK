
/*****************************
* Author:chujl
*
* Date:2016-04-18
******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// WaitDeliverData实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WaitDeliverData : BaseModel
    {

        #region 模型
        /// <summary>
        /// 订单编码  (用于查询等待配送信息)
        /// </summary>
        [DataMember]
        [DisplayName("订单编码")]
        public string OrderId { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        [DataMember]
        [DisplayName("门店ID")]
        public int ShopID { get; set; }

        /// <summary>
        /// WID
        /// </summary>
        [DataMember]
        [DisplayName("WID")]
        public int WID { get; set; }

        /// <summary>
        /// 下单人员ID
        /// </summary>
        [DataMember]
        [DisplayName("下单人员ID")]
        public int XSUserID { get; set; }

        /// <summary>
        /// 门店类型（门店类型(0:加盟店;1:签约店;)）
        /// </summary>
        [DataMember]
        [DisplayName("门店类型")]
        public int ShopType { get; set; }

        /// <summary>
        /// 门店编码
        /// </summary>
        [DataMember]
        [DisplayName("门店编码")]
        public string ShopCode { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        [DataMember]
        [DisplayName("门店名称")]
        public string ShopName { get; set; }

        /// <summary>
        /// 门店联系人
        /// </summary>
        [DataMember]
        [DisplayName("门店联系人")]
        public string RevLinkMan { get; set; }

        /// <summary>
        /// 门店全址
        /// </summary>
        [DataMember]
        [DisplayName("门店全址")]
        public string FullAddress { get; set; }

        /// <summary>
        /// 门店地址
        /// </summary>
        [DataMember]
        [DisplayName("门店地址")]
        public string Address { get; set; }

        /// <summary>
        /// 门店地址
        /// </summary>
        [DataMember]
        [DisplayName("门店地址")]
        public string RevTelephone { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        [DataMember]
        [DisplayName("流水号")]
        public string StationNumber { get; set; }

        /// <summary>
        /// 结算方式名称
        /// </summary>
        [DataMember]
        [DisplayName("结算方式名称")]
        public string SettleTypeName { get; set; }

        /// <summary>
        /// OrderType
        /// </summary>
        [DataMember]
        [DisplayName("OrderType")]
        public int OrderType { get; set; }


        /// <summary>
        /// ShippingBeginDate
        /// </summary>
        [DataMember]
        [DisplayName("ShippingBeginDate")]
        public DateTime? ShippingBeginDate { get; set; }

        /// <summary>
        /// ShippingEndDate
        /// </summary>
        [DataMember]
        [DisplayName("ShippingEndDate")]
        public DateTime? ShippingEndDate { get; set; }


        #endregion


    }

    /// <summary>
    /// PickingData实体类 (用于查询等待配送信息)
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class PickingData : BaseModel
    {

        #region 模型
        /// <summary>
        /// 订单编码
        /// </summary>
        [DataMember]
        [DisplayName("订单编码")]
        public string OrderId { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        [DataMember]
        [DisplayName("门店ID")]
        public int ShopID { get; set; }

        /// <summary>
        /// WID
        /// </summary>
        [DataMember]
        [DisplayName("WID")]
        public int WID { get; set; }

        /// <summary>
        /// 门店编码
        /// </summary>
        [DataMember]
        [DisplayName("门店编码")]
        public string ShopCode { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        [DataMember]
        [DisplayName("门店名称")]
        public string ShopName { get; set; }
        #endregion


    }

    /// <summary>
    /// 实体类 (订单信息)
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class DeliverOrderInfo : BaseModel
    {
        /// <summary>
        /// 单号
        /// </summary>
        [DataMember]
        public string OrderId { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        [DataMember]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        [DataMember]
        public int StationNumber { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        [DataMember]
        public decimal SaleQty { get; set; }

        /// <summary>
        /// 商品金额或订单金额     （后面改过一次 GetDeliverOrderInfoAction 接口对应 saleOrderPre.TotalProductAmt)
        /// </summary>
        [DataMember]
        public decimal PayAmount { get; set; }

        /// <summary>
        /// 门店积分
        /// </summary>
        [DataMember]
        public decimal TotalPoint { get; set; }

        /// <summary>
        /// 周转箱
        /// </summary>
        [DataMember]
        public int Package1Qty { get; set; }

        /// <summary>
        /// 纸箱数
        /// </summary>
        [DataMember]
        public int Package2Qty { get; set; }

        /// <summary>
        /// 易碎品
        /// </summary>
        [DataMember]
        public int Package3Qty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
        /// <summary>
        /// 装箱员
        /// </summary>
        [DataMember]
        public string PackingEmpName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int? PackingEmpID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime? PackingTime { get; set; }

    }

    /// <summary>
    /// 实体类 (订单信息)
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class ProductData : BaseModel
    {

        /// <summary>
        /// 商品货类
        /// </summary>
        [DataMember]
        public string ShelfAreaType { get; set; }

        /// <summary>
        /// 商品货类CODE
        /// </summary>
        [DataMember]
        public string ShelfAreaCode { get; set; }

        /// <summary>
        /// 货区对货时间
        /// </summary>
        [DataMember]
        public DateTime? AreaCheckTime { get; set; }

        /// <summary>
        /// 货区拣货时间
        /// </summary>
        [DataMember]
        public DateTime? PickEndTime { get; set; }

        /// <summary>
        ///  商品信息集合
        /// </summary>
        [DataMember]
        public IList<ProductDetail> ProdcutDetailList { get; set; }
    }

    /// <summary>
    /// 商品信息
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class ProductDetail : BaseModel
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        [DataMember]
        public string ProductId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string SKU { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        [DataMember]
        public string BarCode { get; set; }

        /// <summary>
        /// 配送数量
        /// </summary>
        [DataMember]
        public decimal SaleQty { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ShelfAreaID { get; set; }

        /// <summary>
        /// 货区编码
        /// </summary>
        [DataMember]
        public string ShelfAreaCode { get; set; }

        /// <summary>
        /// 货区名称
        /// </summary>
        [DataMember]
        public string ShelfAreaName { get; set; }

        /// <summary>
        /// 商品对货时间
        /// </summary>
        [DataMember]
        public DateTime? CheckTime { get; set; }

        /// <summary>
        /// 销售单位
        /// </summary>
        [DataMember]
        public string SaleUnit { get; set; }

        /// <summary>
        /// 拣货员编号
        /// </summary>
        [DataMember]
        public int PickUserId { get; set; }

        /// <summary>
        /// 拣货员姓名
        /// </summary>
        [DataMember]
        public string PickUserName { get; set; }

        /// <summary>
        /// 商品货位
        /// </summary>
        [DataMember]
        public string ShelfCode { get; set; }

    }


    /// <summary>
    /// 商品信息用于后台
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class ProductDetailExt : ProductDetail
    {

        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public string SaleUnit { get; set; }
        /// <summary>
        /// 销售价格
        /// </summary>
        [DataMember]
        public decimal SalePrice { get; set; }
        /// <summary>
        /// 订货数量
        /// </summary>
        [DataMember]
        public decimal PreQty { get; set; }
        /// <summary>
        /// 平台率
        /// </summary>
        [DataMember]
        public decimal ShopAddPerc { get; set; }
        /// <summary>
        /// 门店积分
        /// </summary>
        [DataMember]
        public decimal SubPoint { get; set; }
        /// <summary>
        /// 绩效积分
        /// </summary>
        [DataMember]
        public decimal SubBasePoint { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int ShelfID { get; set; }

        /// <summary>
        /// 货架
        /// </summary>
        [DataMember]
        public string ShelfCode { get; set; }
        /// <summary>
        /// 拣货员
        /// </summary>
        [DataMember]
        public string PickUserName { get; set; }
        /// <summary>
        /// 分类1
        /// </summary>
        [DataMember]
        public string ShopCategoryId1Name { get; set; }

        /// <summary>
        /// 分类2
        /// </summary>
        [DataMember]
        public string ShopCategoryId2Name { get; set; }

        /// <summary>
        /// 分类3
        /// </summary>
        [DataMember]
        public string ShopCategoryId3Name { get; set; }

        /// <summary>
        /// 小计
        /// </summary>
        [DataMember]
        public decimal SubAmt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal SubAddAmt { get; set; }




    }

    /// <summary>
    /// 用于配送对账单
    /// </summary>
    public class SaleDeliverOrderInfo
    {
        /// <summary>
        /// 订单编码
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 门店编码
        /// </summary>
        public string ShopCode { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal? TotalProductAmt { get; set; }

        /// <summary>
        /// 总绩效分
        /// </summary>
        public decimal? TotalBasePoint { get; set; }

        /// <summary>
        /// 门店积分
        /// </summary>
        public decimal? TotalPoint { get; set; }

        /// <summary>
        /// 订单数
        /// </summary>
        public int? TotalOrderCount { get; set; }

        /// <summary>
        /// 时间 格式（yyyy-MM-dd）
        /// </summary>
        public string PackingTime { get; set; }


    }

}