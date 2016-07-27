
/*****************************
* Author:leidong
*
* Date:2016-04-19
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// SaleOrderPre实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SaleOrderPre : BaseModel
    {

        #region 模型
        /// <summary>
        /// 订单编号
        /// </summary>
        [DataMember]
        [DisplayName("订单编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string OrderId { get; set; }

        /// <summary>
        /// 结算ID
        /// </summary>
        [DataMember]
        [DisplayName("结算ID")]

        public string SettleID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 仓库柜台ID
        /// </summary>
        [DataMember]
        [DisplayName("仓库柜台ID")]

        public int? SubWID { get; set; }

        /// <summary>
        /// 下单时间(OrderStatus=1;格式:yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [DataMember]
        [DisplayName("下单时间(OrderStatus=1;格式:yyyy-MM-dd HH:mm:ss)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// 下单类型(0:客户;1:客服代客)
        /// </summary>
        [DataMember]
        [DisplayName("下单类型(0:客户;1:客服代客)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int OrderType { get; set; }

        /// <summary>
        /// 仓库编号(Warehouse.WCode)
        /// </summary>
        [DataMember]
        [DisplayName("仓库编号(Warehouse.WCode)")]

        public string WCode { get; set; }

        /// <summary>
        /// 仓库名称(Warehouse.WName)
        /// </summary>
        [DataMember]
        [DisplayName("仓库名称(Warehouse.WName)")]

        public string WName { get; set; }

        /// <summary>
        /// 仓库柜台编号(Warehouse.WCode)
        /// </summary>
        [DataMember]
        [DisplayName("仓库柜台编号(Warehouse.WCode)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SubWCode { get; set; }

        /// <summary>
        /// 仓库柜台名称(Warehouse.WName)
        /// </summary>
        [DataMember]
        [DisplayName("仓库柜台名称(Warehouse.WName)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SubWName { get; set; }

        /// <summary>
        /// 下单门店ID
        /// </summary>
        [DataMember]
        [DisplayName("下单门店ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopID { get; set; }

        /// <summary>
        /// 下单门店人员ID
        /// </summary>
        [DataMember]
        [DisplayName("下单门店人员ID")]

        public int? XSUserID { get; set; }

        /// <summary>
        /// 门店类型(0:加盟店;1:签约店;)
        /// </summary>
        [DataMember]
        [DisplayName("门店类型(0:加盟店;1:签约店;)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopType { get; set; }

        /// <summary>
        /// 下单门店编号
        /// </summary>
        [DataMember]
        [DisplayName("下单门店编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopCode { get; set; }

        /// <summary>
        /// 下单门店名称
        /// </summary>
        [DataMember]
        [DisplayName("下单门店名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopName { get; set; }

        /// <summary>
        /// 订单状态(0:草稿(代客下单才有);1:等待确认;2:等待拣货;3:正在拣货;4:拣货完成;5:打印完成;6:正在配送中;7:交易完成;8:客户交易取消;9:客服交易关闭）
        /// </summary>
        [DataMember]
        [DisplayName("订单状态(0:草稿(代客下单才有);1:等待确认;2:等待拣货;3:正在拣货;4:拣货完成;5:打印完成;6:正在配送中;7:交易完成;8:客户交易取消;9:客服交易关闭）")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Status { get; set; }

        /// <summary>
        /// 门店省ID(Shop.ProvinceID)
        /// </summary>
        [DataMember]
        [DisplayName("门店省ID(Shop.ProvinceID)")]

        public int? ProvinceID { get; set; }

        /// <summary>
        /// 门店市ID(Shop.CityID)
        /// </summary>
        [DataMember]
        [DisplayName("门店市ID(Shop.CityID)")]

        public int? CityID { get; set; }

        /// <summary>
        /// 门店区ID(Shop.RegionID)
        /// </summary>
        [DataMember]
        [DisplayName("门店区ID(Shop.RegionID)")]

        public int? RegionID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("")]

        public string ProvinceName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("")]

        public string CityName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("")]

        public string RegionName { get; set; }

        /// <summary>
        /// 门店地址(Shop.Address)
        /// </summary>
        [DataMember]
        [DisplayName("门店地址(Shop.Address)")]

        public string Address { get; set; }

        /// <summary>
        /// 门店地址全称(Shop.FullAddress)
        /// </summary>
        [DataMember]
        [DisplayName("门店地址全称(Shop.FullAddress)")]

        public string FullAddress { get; set; }

        /// <summary>
        /// 门店收货人名称(Shop.LinkMan)
        /// </summary>
        [DataMember]
        [DisplayName("门店收货人名称(Shop.LinkMan)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string RevLinkMan { get; set; }

        /// <summary>
        /// 门店收货人电话(Shop.Telephone)
        /// </summary>
        [DataMember]
        [DisplayName("门店收货人电话(Shop.Telephone)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string RevTelephone { get; set; }

        /// <summary>
        /// 确认时间(OrderStatus=2;格式:yyyy-MM-dd HH:mm:ss)(1>>2)(0>>2)
        /// </summary>
        [DataMember]
        [DisplayName("确认时间(OrderStatus=2;格式:yyyy-MM-dd HH:mm:ss)(1>>2)(0>>2)")]

        public DateTime? ConfDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime SendDate { get; set; }

        /// <summary>
        /// 门店所属线路
        /// </summary>
        [DataMember]
        [DisplayName("门店所属线路")]

        public int? LineID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("")]

        public string LineName { get; set; }

        /// <summary>
        /// 门店每日订单流水号(打印二维码时生成)
        /// </summary>
        [DataMember]
        [DisplayName("门店每日订单流水号(打印二维码时生成)")]

        public int? StationNumber { get; set; }

        /// <summary>
        /// 拣货开始时间(OrderStatus=3;格式:yyyy-MM-dd HH:mm:ss;)(2>>3)
        /// </summary>
        [DataMember]
        [DisplayName("拣货开始时间(OrderStatus=3;格式:yyyy-MM-dd HH:mm:ss;)(2>>3)")]

        public DateTime? PickingBeginDate { get; set; }

        /// <summary>
        /// 拣货完成时间(OrderStatus=4;格式:yyyy-MM-dd HH:mm:ss;完成对货才有值)(3>>4)
        /// </summary>
        [DataMember]
        [DisplayName("拣货完成时间(OrderStatus=4;格式:yyyy-MM-dd HH:mm:ss;完成对货才有值)(3>>4)")]

        public DateTime? PickingEndDate { get; set; }

        /// <summary>
        /// 缺货率SUM(Case when SaleOrderPreDetails.SaleQty>SaleOrderPreDetails.PreQty then 0 else SaleOrderPreDetails.PreQty-SaleOrderPreDetails.SaleQty end)/SUM(SaleOrderPreDetails.PreQty)
        /// </summary>
        [DataMember]
        [DisplayName("缺货率SUM(Case when SaleOrderPreDetails.SaleQty>SaleOrderPreDetails.PreQty then 0 else SaleOrderPreDetails.PreQty-SaleOrderPreDetails.SaleQty end)/SUM(SaleOrderPreDetails.PreQty)")]

        public decimal? StockOutRate { get; set; }

        /// <summary>
        /// 装箱人员ID
        /// </summary>
        [DataMember]
        [DisplayName("装箱人员ID")]

        public int? PackingEmpID { get; set; }

        /// <summary>
        /// 装箱人员名称
        /// </summary>
        [DataMember]
        [DisplayName("装箱人员名称")]

        public string PackingEmpName { get; set; }

        /// <summary>
        /// 装箱完成时间
        /// </summary>
        [DataMember]
        [DisplayName("装箱完成时间")]

        public DateTime? PackingTime { get; set; }

        /// <summary>
        /// 打印标识(0:未打印;1:已打印)
        /// </summary>
        [DataMember]
        [DisplayName("打印标识(0:未打印;1:已打印)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsPrinted { get; set; }

        /// <summary>
        /// 打印完成时间(OrderStatus=5;格式:yyyy-MM-dd HH:mm:ss)(4>>5;3>>5)
        /// </summary>
        [DataMember]
        [DisplayName("打印完成时间(OrderStatus=5;格式:yyyy-MM-dd HH:mm:ss)(4>>5;3>>5)")]

        public DateTime? PrintDate { get; set; }

        /// <summary>
        /// 打印人员ID
        /// </summary>
        [DataMember]
        [DisplayName("打印人员ID")]

        public int? PrintUserID { get; set; }

        /// <summary>
        /// 打印人员名称
        /// </summary>
        [DataMember]
        [DisplayName("打印人员名称")]

        public string PrintUserName { get; set; }

        /// <summary>
        /// 配送开始时间(OrderStatus=6;格式:yyyy-MM-dd HH:mm:ss)(5>>6)
        /// </summary>
        [DataMember]
        [DisplayName("配送开始时间(OrderStatus=6;格式:yyyy-MM-dd HH:mm:ss)(5>>6)")]

        public DateTime? ShippingBeginDate { get; set; }

        /// <summary>
        /// 配送人员ID(司机)
        /// </summary>
        [DataMember]
        [DisplayName("配送人员ID(司机)")]

        public int? ShippingUserID { get; set; }

        /// <summary>
        /// 配送人员名称(司机)
        /// </summary>
        [DataMember]
        [DisplayName("配送人员名称(司机)")]

        public string ShippingUserName { get; set; }

        /// <summary>
        /// 配送完成时间(OrderStatus=6;格式:yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [DataMember]
        [DisplayName("配送完成时间(OrderStatus=6;格式:yyyy-MM-dd HH:mm:ss)")]

        public DateTime? ShippingEndDate { get; set; }

        /// <summary>
        /// 交易完成时间(OrderStatus=7;格式:yyyy-MM-dd HH:mm:ss)(5>>7)
        /// </summary>
        [DataMember]
        [DisplayName("交易完成时间(OrderStatus=7;格式:yyyy-MM-dd HH:mm:ss)(5>>7)")]

        public DateTime? FinishDate { get; set; }

        /// <summary>
        /// 客户交易取消时间(OrderStatus=8;格式:yyyy-MM-dd HH:mm:ss)(1>>8)(0:直接物理删除)
        /// </summary>
        [DataMember]
        [DisplayName("客户交易取消时间(OrderStatus=8;格式:yyyy-MM-dd HH:mm:ss)(1>>8)(0:直接物理删除)")]

        public DateTime? CancelDate { get; set; }

        /// <summary>
        /// 交易关闭时间(OrderStatus=9;格式:yyyy-MM-dd HH:mm:ss)(2/3/4/5/6>>9)(仓库后台可直接处理)
        /// </summary>
        [DataMember]
        [DisplayName("交易关闭时间(OrderStatus=9;格式:yyyy-MM-dd HH:mm:ss)(2/3/4/5/6>>9)(仓库后台可直接处理)")]

        public DateTime? CloseDate { get; set; }

        /// <summary>
        /// 交易关闭原因
        /// </summary>
        [DataMember]
        [DisplayName("交易关闭原因")]

        public string CloseReason { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]

        public string Remark { get; set; }

        /// <summary>
        /// 单品总金额(已包括单品促销金额, =sum(SaleOrderDetails.SubAmt))
        /// </summary>
        [DataMember]
        [DisplayName("单品总金额(已包括单品促销金额, =sum(SaleOrderDetails.SubAmt))")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal TotalProductAmt { get; set; }

        /// <summary>
        /// 订单优惠金额(预留,固定为0)
        /// </summary>
        [DataMember]
        [DisplayName("订单优惠金额(预留,固定为0)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal CouponAmt { get; set; }

        /// <summary>
        /// 门店合计提点金额sum(SaleOrderDettail.SubAddAmt)
        /// </summary>
        [DataMember]
        [DisplayName("门店合计提点金额sum(SaleOrderDettail.SubAddAmt)")]

        public decimal? TotalAddAmt { get; set; }

        /// <summary>
        /// 最后计算金额/应付金额（=TotalProductAmt-CouponAmt+TotalAddAmt)
        /// </summary>
        [DataMember]
        [DisplayName("最后计算金额/应付金额（=TotalProductAmt-CouponAmt+TotalAddAmt)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal PayAmount { get; set; }

        /// <summary>
        /// 门店合计总积分(=sum(saleOrderDetails.SubPoint)
        /// </summary>
        [DataMember]
        [DisplayName("门店合计总积分(=sum(saleOrderDetails.SubPoint)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal TotalPoint { get; set; }

        /// <summary>
        /// 合计绩效积分(司机，门店基础=sum(saleOrderDetails.SubBasePoint)
        /// </summary>
        [DataMember]
        [DisplayName("合计绩效积分(司机，门店基础=sum(saleOrderDetails.SubBasePoint)")]

        public decimal? TotalBasePoint { get; set; }

        /// <summary>
        /// 用户删除订单标识(0:不显示;1:显示)
        /// </summary>
        [DataMember]
        [DisplayName("用户删除订单标识(0:不显示;1:显示)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int UserShowFlag { get; set; }

        /// <summary>
        /// 客户端下单来源(0:android;1:iOS;2:PC;)
        /// </summary>
        [DataMember]
        [DisplayName("客户端下单来源(0:android;1:iOS;2:PC;)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ClientType { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [DataMember]
        [DisplayName("创建日期")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [DataMember]
        [DisplayName("创建用户ID")]

        public int? CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]

        public string CreateUserName { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        [DisplayName("最后修改时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户ID")]

        public int? ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户名称")]

        public string ModifyUserName { get; set; }
        #endregion
        

        //增加日结算相关标识

        /// <summary>
        ///   '日结算ID(Settlement.ID)'
        /// </summary>
        [DataMember]
        public string Sett_ID { get; set; }

        /// <summary>
        /// 日结算时间
        /// </summary>
        [DataMember]
        public DateTime? Sett_Date { get; set; }

        /// <summary>
        /// 日结算标识(0:未结　1:已结)
        /// </summary>
        [DataMember]
        public int Sett_Flag { get; set; }
    }
}