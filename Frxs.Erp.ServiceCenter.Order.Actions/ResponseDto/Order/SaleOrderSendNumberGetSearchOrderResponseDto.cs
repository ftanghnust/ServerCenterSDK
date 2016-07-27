using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;

namespace Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto
{
    public class SaleOrderSendNumberGetSearchOrderResponseDto
    {
        public SaleOrderPreResponseDto SaleOrderPre { get; set; }

        //#region 模型
        ///// <summary>
        ///// 订单编号
        ///// </summary>
       
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string OrderId { get; set; }

        ///// <summary>
        ///// 结算ID
        ///// </summary>
       

        //public string SettleID { get; set; }

        ///// <summary>
        ///// 仓库ID(Warehouse.WID)
        ///// </summary>
       
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int WID { get; set; }

        ///// <summary>
        ///// 仓库柜台ID
        ///// </summary>
       

        //public int? SubWID { get; set; }

        ///// <summary>
        ///// 下单时间(OrderStatus=1;格式:yyyy-MM-dd HH:mm:ss)
        ///// </summary>
        
        //[Required(ErrorMessage = "{0}不能为空")]
        //public DateTime? OrderDate { get; set; }

        ///// <summary>
        ///// 下单类型(0:客户;1:客服代客)
        ///// </summary>
       
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int OrderType { get; set; }

        ///// <summary>
        ///// 仓库编号(Warehouse.WCode)
        ///// </summary>
     

        //public string WCode { get; set; }

        ///// <summary>
        ///// 仓库名称(Warehouse.WName)
        ///// </summary>
       

        //public string WName { get; set; }

        ///// <summary>
        ///// 仓库柜台编号(Warehouse.WCode)
        ///// </summary>
      
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string SubWCode { get; set; }

        ///// <summary>
        ///// 仓库柜台名称(Warehouse.WName)
        ///// </summary>
      
        //public string SubWName { get; set; }

        ///// <summary>
        ///// 下单门店ID
        ///// </summary>
    
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int ShopID { get; set; }

        ///// <summary>
        ///// 下单门店人员ID
        ///// </summary>
       

        //public int? XSUserID { get; set; }

        ///// <summary>
        ///// 门店类型(0:加盟店;1:签约店;)
        ///// </summary>
       
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int ShopType { get; set; }

        ///// <summary>
        ///// 下单门店编号
        ///// </summary>
     
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string ShopCode { get; set; }

        ///// <summary>
        ///// 下单门店名称
        ///// </summary>
      
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string ShopName { get; set; }

        ///// <summary>
        ///// 订单状态(0:草稿(代客下单才有);1:等待确认;2:等待拣货;3:正在拣货;4:拣货完成;5:打印完成;6:正在配送中;7:交易完成;8:客户交易取消;9:客服交易关闭）
        ///// </summary>
      
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int Status { get; set; }

        ///// <summary>
        ///// 门店省ID(Shop.ProvinceID)
        ///// </summary>
      

        //public int? ProvinceID { get; set; }

        ///// <summary>
        ///// 门店市ID(Shop.CityID)
        ///// </summary>
      

        //public int? CityID { get; set; }

        ///// <summary>
        ///// 门店区ID(Shop.RegionID)
        ///// </summary>
       

        //public int? RegionID { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
    

        //public string ProvinceName { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
       

        //public string CityName { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
      

        //public string RegionName { get; set; }

        ///// <summary>
        ///// 门店地址(Shop.Address)
        ///// </summary>
      

        //public string Address { get; set; }

        ///// <summary>
        ///// 门店地址全称(Shop.FullAddress)
        ///// </summary>
       

        //public string FullAddress { get; set; }

        ///// <summary>
        ///// 门店收货人名称(Shop.LinkMan)
        ///// </summary>
       
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string RevLinkMan { get; set; }

        ///// <summary>
        ///// 门店收货人电话(Shop.Telephone)
        ///// </summary>
     
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string RevTelephone { get; set; }

        ///// <summary>
        ///// 确认时间(OrderStatus=2;格式:yyyy-MM-dd HH:mm:ss)(1>>2)(0>>2)
        ///// </summary>
       

        //public DateTime? ConfDate { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
       
        //[Required(ErrorMessage = "{0}不能为空")]
        //public DateTime SendDate { get; set; }

        ///// <summary>
        ///// 门店所属线路
        ///// </summary>
    

        //public int? LineID { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
       

        //public string LineName { get; set; }

        ///// <summary>
        ///// 门店每日订单流水号(打印二维码时生成)
        ///// </summary>
       

        //public int? StationNumber { get; set; }

        ///// <summary>
        ///// 拣货开始时间(OrderStatus=3;格式:yyyy-MM-dd HH:mm:ss;)(2>>3)
        ///// </summary>
     

        //public DateTime? PickingBeginDate { get; set; }

        ///// <summary>
        ///// 拣货完成时间(OrderStatus=4;格式:yyyy-MM-dd HH:mm:ss;完成对货才有值)(3>>4)
        ///// </summary>
        

        //public DateTime? PickingEndDate { get; set; }

        ///// <summary>
        ///// 缺货率SUM(Case when SaleOrderPreDetails.SaleQty>SaleOrderPreDetails.PreQty then 0 else SaleOrderPreDetails.PreQty-SaleOrderPreDetails.SaleQty end)/SUM(SaleOrderPreDetails.PreQty)
        ///// </summary>
       

        //public decimal? StockOutRate { get; set; }

        ///// <summary>
        ///// 装箱人员ID
        ///// </summary>
      

        //public int? PackingEmpID { get; set; }

        ///// <summary>
        ///// 装箱人员名称
        ///// </summary>
      
        //public string PackingEmpName { get; set; }

        ///// <summary>
        ///// 装箱完成时间
        ///// </summary>
       

        //public DateTime? PackingTime { get; set; }

        ///// <summary>
        ///// 打印标识(0:未打印;1:已打印)
        ///// </summary>
       
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int IsPrinted { get; set; }

        ///// <summary>
        ///// 打印完成时间(OrderStatus=5;格式:yyyy-MM-dd HH:mm:ss)(4>>5;3>>5)
        ///// </summary>
   

        //public DateTime? PrintDate { get; set; }

        ///// <summary>
        ///// 打印人员ID
        ///// </summary>
      

        //public int? PrintUserID { get; set; }

        ///// <summary>
        ///// 打印人员名称
        ///// </summary>
     

        //public string PrintUserName { get; set; }

        ///// <summary>
        ///// 配送开始时间(OrderStatus=6;格式:yyyy-MM-dd HH:mm:ss)(5>>6)
        ///// </summary>
       

        //public DateTime? ShippingBeginDate { get; set; }

        ///// <summary>
        ///// 配送人员ID(司机)
        ///// </summary>
       

        //public int? ShippingUserID { get; set; }

        ///// <summary>
        ///// 配送人员名称(司机)
        ///// </summary>
     

        //public string ShippingUserName { get; set; }

        ///// <summary>
        ///// 配送完成时间(OrderStatus=6;格式:yyyy-MM-dd HH:mm:ss)
        ///// </summary>
      

        //public DateTime? ShippingEndDate { get; set; }

        ///// <summary>
        ///// 交易完成时间(OrderStatus=7;格式:yyyy-MM-dd HH:mm:ss)(5>>7)
        ///// </summary>
      

        //public DateTime? FinishDate { get; set; }

        ///// <summary>
        ///// 客户交易取消时间(OrderStatus=8;格式:yyyy-MM-dd HH:mm:ss)(1>>8)(0:直接物理删除)
        ///// </summary>
       

        //public DateTime? CancelDate { get; set; }

        ///// <summary>
        ///// 交易关闭时间(OrderStatus=9;格式:yyyy-MM-dd HH:mm:ss)(2/3/4/5/6>>9)(仓库后台可直接处理)
        ///// </summary>
       

        //public DateTime? CloseDate { get; set; }

        ///// <summary>
        ///// 交易关闭原因
        ///// </summary>
      

        //public string CloseReason { get; set; }

        ///// <summary>
        ///// 备注
        ///// </summary>
       

        //public string Remark { get; set; }

        ///// <summary>
        ///// 单品总金额(已包括单品促销金额, =sum(SaleOrderDetails.SubAmt))
        ///// </summary>
       
        //[Required(ErrorMessage = "{0}不能为空")]
        //public decimal TotalProductAmt { get; set; }

        ///// <summary>
        ///// 订单优惠金额(预留,固定为0)
        ///// </summary>
       
        //[Required(ErrorMessage = "{0}不能为空")]
        //public decimal CouponAmt { get; set; }

        ///// <summary>
        ///// 门店合计提点金额sum(SaleOrderDettail.SubAddAmt)
        ///// </summary>
      

        //public decimal? TotalAddAmt { get; set; }

        ///// <summary>
        ///// 最后计算金额/应付金额（=TotalProductAmt-CouponAmt+TotalAddAmt)
        ///// </summary>
      
        //[Required(ErrorMessage = "{0}不能为空")]
        //public decimal PayAmount { get; set; }

        ///// <summary>
        ///// 门店合计总积分(=sum(saleOrderDetails.SubPoint)
        ///// </summary>
       
        //[Required(ErrorMessage = "{0}不能为空")]
        //public decimal TotalPoint { get; set; }

        ///// <summary>
        ///// 合计绩效积分(司机，门店基础=sum(saleOrderDetails.SubBasePoint)
        ///// </summary>
     

        //public decimal? TotalBasePoint { get; set; }

        ///// <summary>
        ///// 用户删除订单标识(0:不显示;1:显示)
        ///// </summary>
        
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int UserShowFlag { get; set; }

        ///// <summary>
        ///// 客户端下单来源(0:android;1:iOS;2:PC;)
        ///// </summary>
    
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int ClientType { get; set; }

        ///// <summary>
        ///// 创建日期
        ///// </summary>
      
        //[Required(ErrorMessage = "{0}不能为空")]
        //public DateTime CreateTime { get; set; }

        ///// <summary>
        ///// 创建用户ID
        ///// </summary>
      

        //public int? CreateUserID { get; set; }

        ///// <summary>
        ///// 创建用户名称
        ///// </summary>
      

        //public string CreateUserName { get; set; }

        ///// <summary>
        ///// 最后修改时间
        ///// </summary>
      
        //[Required(ErrorMessage = "{0}不能为空")]
        //public DateTime ModifyTime { get; set; }

        ///// <summary>
        ///// 最后修改用户ID
        ///// </summary>
       
        //public int? ModifyUserID { get; set; }

        ///// <summary>
        ///// 最后修改用户名称
        ///// </summary>
      

        //public string ModifyUserName { get; set; }




        //#endregion  
    }
}
