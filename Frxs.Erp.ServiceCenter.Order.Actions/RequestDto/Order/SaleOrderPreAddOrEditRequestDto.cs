using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    public class SaleOrderPreAddOrEditRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 操作标志 0：新增 1:修改 2:确认仅修改拣货和货架信息
        /// </summary>
        public int Flag { get; set; }

        /// <summary>
        /// 订单录入信息
        /// </summary>
        public SaleOrderPreRequestDto SaleOrderPre { get; set; }

        /// <summary>
        /// 订单录入商品明细列表
        /// </summary>
        public IList<SaleOrderPreDetailRequestDto> SaleOrderPreDetailList { get; set; }

        /// <summary>
        /// 订单录入商品明细扩展列表
        /// </summary>
        public IList<SaleOrderPreDetailExtsRequestDto> SaleOrderPreDetailExtsList { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public SaleOrderSendNumberRequestDto SendNumber { get; set; }

        /// <summary>
        /// 拣货分配信息
        /// </summary>
        public IList<SaleOrderPreDetailsPickRequestDto> Picks { get; set; }


        public IList<SaleOrderPreShelfAreaRequestDto> ShelfAreas { get; set; }
    }


    /// <summary>
    /// 订单排序
    /// </summary>
    public  class SaleOrderSendNumberRequestDto : RequestDtoParent
    {

        #region 模型
        /// <summary>
        /// 订单编号(SaleOrder.OrderID)
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 线路顺序(WarehouseLine.SerialNumber)
        /// </summary>
        public int LineSerialNumber { get; set; }

        /// <summary>
        /// 门店顺序(WarehouseLineShop.SerialNumber)
        /// </summary>
        public int ShopSerialNumber { get; set; }

        /// <summary>
        /// 手动调整顺序(置顶为1;置底为9999; 订单确认时默认值为999);
        /// </summary>
        public int SendNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public int? Remark { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        public int? ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        public string ModifyUserName { get; set; }

        #endregion
    }

    /// <summary>
    /// 新增代客下单
    /// </summary>
    public class SaleOrderPreRequestDto : RequestDtoParent
    {
        #region 模型
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 结算ID
        /// </summary>
        public string SettleID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 仓库柜台ID
        /// </summary>
        public int? SubWID { get; set; }

        /// <summary>
        /// 下单时间(OrderStatus=1;格式:yyyy-MM-dd HH:mm:ss)
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 下单类型(0:客户;1:客服代客)
        /// </summary>
        public int OrderType { get; set; }

        /// <summary>
        /// 仓库编号(Warehouse.WCode)
        /// </summary>
        public string WCode { get; set; }

        /// <summary>
        /// 仓库名称(Warehouse.WName)
        /// </summary>
        public string WName { get; set; }

        /// <summary>
        /// 仓库柜台编号(Warehouse.WCode)
        /// </summary>
        public string SubWCode { get; set; }

        /// <summary>
        /// 仓库柜台名称(Warehouse.WName)
        /// </summary>
        public string SubWName { get; set; }

        /// <summary>
        /// 下单门店ID
        /// </summary>
        public int ShopID { get; set; }

        /// <summary>
        /// 下单门店人员ID
        /// </summary>
        public int? XSUserID { get; set; }

        /// <summary>
        /// 门店类型(0:加盟店;1:签约店;)
        /// </summary>
        public int ShopType { get; set; }

        /// <summary>
        /// 下单门店编号
        /// </summary>
        public string ShopCode { get; set; }

        /// <summary>
        /// 下单门店名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 订单状态(0:草稿(代客下单才有);1:等待确认;2:等待拣货;3:正在拣货;4:拣货完成;5:打印完成;6:正在配送中;7:交易完成;8:客户交易取消;9:客服交易关闭）
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 门店省ID(Shop.ProvinceID)
        /// </summary>
        public int? ProvinceID { get; set; }

        /// <summary>
        /// 门店市ID(Shop.CityID)
        /// </summary>
        public int? CityID { get; set; }

        /// <summary>
        /// 门店区ID(Shop.RegionID)
        /// </summary>
        public int? RegionID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 
        /// </summary>

       public string RegionName { get; set; }

        /// <summary>
        /// 门店地址(Shop.Address)
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 门店地址全称(Shop.FullAddress)
        /// </summary>
        public string FullAddress { get; set; }

        /// <summary>
        /// 门店收货人名称(Shop.LinkMan)
        /// </summary>
        public string RevLinkMan { get; set; }

        /// <summary>
        /// 门店收货人电话(Shop.Telephone)
        /// </summary>
        public string RevTelephone { get; set; }

        /// <summary>
        /// 确认时间(OrderStatus=2;格式:yyyy-MM-dd HH:mm:ss)(1>>2)(0>>2)
        /// </summary>
        public DateTime? ConfDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime SendDate { get; set; }

        /// <summary>
        /// 门店所属线路
        /// </summary>
        public int? LineID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// 门店每日订单流水号(打印二维码时生成)
        /// </summary>
        public int? StationNumber { get; set; }

        /// <summary>
        /// 拣货开始时间(OrderStatus=3;格式:yyyy-MM-dd HH:mm:ss;)(2>>3)
        /// </summary>
        public DateTime? PickingBeginDate { get; set; }

        /// <summary>
        /// 拣货完成时间(OrderStatus=4;格式:yyyy-MM-dd HH:mm:ss;完成对货才有值)(3>>4)
        /// </summary>
        public DateTime? PickingEndDate { get; set; }

        /// <summary>
        /// 缺货率SUM(Case when SaleOrderPreDetails.SaleQty>SaleOrderPreDetails.PreQty then 0 else SaleOrderPreDetails.PreQty-SaleOrderPreDetails.SaleQty end)/SUM(SaleOrderPreDetails.PreQty)
        /// </summary>
        public decimal? StockOutRate { get; set; }

        /// <summary>
        /// 装箱人员ID
        /// </summary>
        public int? PackingEmpID { get; set; }

        /// <summary>
        /// 装箱人员名称
        /// </summary>
        public string PackingEmpName { get; set; }

        /// <summary>
        /// 装箱完成时间
        /// </summary>
        public DateTime? PackingTime { get; set; }

        /// <summary>
        /// 打印标识(0:未打印;1:已打印)
        /// </summary>
        public int IsPrinted { get; set; }

        /// <summary>
        /// 打印完成时间(OrderStatus=5;格式:yyyy-MM-dd HH:mm:ss)(4>>5;3>>5)
        /// </summary>
        public DateTime? PrintDate { get; set; }

        /// <summary>
        /// 打印人员ID
        /// </summary>
        public int? PrintUserID { get; set; }

        /// <summary>
        /// 打印人员名称
        /// </summary>
        public string PrintUserName { get; set; }

        /// <summary>
        /// 配送开始时间(OrderStatus=6;格式:yyyy-MM-dd HH:mm:ss)(5>>6)
        /// </summary>
        public DateTime? ShippingBeginDate { get; set; }

        /// <summary>
        /// 配送人员ID(司机)
        /// </summary>
        public int? ShippingUserID { get; set; }

        /// <summary>
        /// 配送人员名称(司机)
        /// </summary>
        public string ShippingUserName { get; set; }

        /// <summary>
        /// 配送完成时间(OrderStatus=6;格式:yyyy-MM-dd HH:mm:ss)
        /// </summary>
        public DateTime? ShippingEndDate { get; set; }

        /// <summary>
        /// 交易完成时间(OrderStatus=7;格式:yyyy-MM-dd HH:mm:ss)(5>>7)
        /// </summary>
        public DateTime? FinishDate { get; set; }

        /// <summary>
        /// 客户交易取消时间(OrderStatus=8;格式:yyyy-MM-dd HH:mm:ss)(1>>8)(0:直接物理删除)
        /// </summary>
        public DateTime? CancelDate { get; set; }

        /// <summary>
        /// 交易关闭时间(OrderStatus=9;格式:yyyy-MM-dd HH:mm:ss)(2/3/4/5/6>>9)(仓库后台可直接处理)
        /// </summary>
        public DateTime? CloseDate { get; set; }

        /// <summary>
        /// 交易关闭原因
        /// </summary>
        public string CloseReason { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 单品总金额(已包括单品促销金额, =sum(SaleOrderDetails.SubAmt))
        /// </summary>
        public decimal TotalProductAmt { get; set; }

        /// <summary>
        /// 订单优惠金额(预留,固定为0)
        /// </summary>
        public decimal CouponAmt { get; set; }

        /// <summary>
        /// 门店合计提点金额sum(SaleOrderDettail.SubAddAmt)
        /// </summary>
        public decimal? TotalAddAmt { get; set; }

        /// <summary>
        /// 最后计算金额/应付金额（=TotalProductAmt-CouponAmt+TotalAddAmt)
        /// </summary>
        public decimal PayAmount { get; set; }

        /// <summary>
        /// 门店合计总积分(=sum(saleOrderDetails.SubPoint)
        /// </summary>
        public decimal TotalPoint { get; set; }

        /// <summary>
        /// 合计绩效积分(司机，门店基础=sum(saleOrderDetails.SubBasePoint)
        /// </summary>
        public decimal? TotalBasePoint { get; set; }

        /// <summary>
        /// 用户删除订单标识(0:不显示;1:显示)
        /// </summary>
        public int UserShowFlag { get; set; }

        /// <summary>
        /// 客户端下单来源(0:android;1:iOS;2:PC;)
        /// </summary>
        public int ClientType { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        public int? CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        public int? ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        public string ModifyUserName { get; set; }

        #endregion

    }

    /// <summary>
    /// 商品明细
    /// </summary>
    public class SaleOrderPreDetailRequestDto : RequestDtoParent
    {
        #region 模型
        /// <summary>
        /// 编号(仓库ID+GUID)
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 订单编号(SaleOrder.OrderID)
        /// </summary>

        public string OrderID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 商品编号(Prouct.ProductID)
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 商品SKU(ERP编码)
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
        /// 商品图片用于移动端(Products.ImageUrl200*200)
        /// </summary>
        public string ProductImageUrl200 { get; set; }

        /// <summary>
        /// 商品图片用于PC端(Products.ImageUrl400*400)
        /// </summary>
        public string ProductImageUrl400 { get; set; }

        /// <summary>
        /// 仓库商品主键ID（WCProduct.WCProductID）
        /// </summary>
        public int WCProductID { get; set; }

        /// <summary>
        /// 配送(销售)预定数量
        /// </summary>
        public decimal PreQty { get; set; }

        /// <summary>
        /// 配送(销售)单位
        /// </summary>
        public string SaleUnit { get; set; }

        /// <summary>
        /// 配送(销售)单位包装数
        /// </summary>
        public decimal SalePackingQty { get; set; }

        /// <summary>
        /// 配送(销售)单位价格(=ifnull(PromotionPrice,UnitPrice) *SalePackingQty)
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 实发数量(拣货完成写入)预设为PreQty
        /// </summary>
        public decimal? SaleQty { get; set; }

        /// <summary>
        /// 库存单位(WProducts.Unit)
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 库存单位实发数量=SalePackingQty*SaleQty
        /// </summary>
        public decimal UnitQty { get; set; }

        /// <summary>
        /// 库存单位价格(SalePrice/SalePackingQty,四舍五入到4位小数)
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 库存单位促销价格(WProductPromotionDetails.PromotionPrice)
        /// </summary>
        public decimal? PromotionUnitPrice { get; set; }

        /// <summary>
        /// 调整后的最终金额(=ifnull(PromotionPrice,UnitPrice) *UnitQty)
        /// </summary>
        public decimal? SubAmt { get; set; }

        /// <summary>
        /// 门店库存单位平台率(%)(=WProducts.ShopAddPerc)
        /// </summary>
        public decimal? ShopAddPerc { get; set; }

        /// <summary>
        /// 门店库存单位积分(=WProducts.ShopPoint)
        /// </summary>
        public decimal? ShopPoint { get; set; }

        /// <summary>
        /// 门店库存单位促销积分(=WProductPromotionDetails.PromotionShopPoint)
        /// </summary>
        public decimal? PromotionShopPoint { get; set; }

        /// <summary>
        /// 库存单位绩效积分(=WProducts.BasePoint)
        /// </summary>
        public decimal? BasePoint { get; set; }

        /// <summary>
        /// 库存单位物流费率(=WProducts.VendorPerc1)
        /// </summary>
        public decimal? VendorPerc1 { get; set; }

        /// <summary>
        /// 库存单位仓储费率(=WProducts.VendorPerc2)
        /// </summary>
        public decimal? VendorPerc2 { get; set; }

        /// <summary>
        /// 小计门店提点金额,平台费用(=ShopAddPerc*SubAmt*0.01)
        /// </summary>
        public decimal? SubAddAmt { get; set; }

        /// <summary>
        /// 小计门店积分(=ifnull(PromotionShopPoint,ShopPoint)*UnitQty)
        /// </summary>
        public decimal? SubPoint { get; set; }

        /// <summary>
        /// 小计绩效积分(=BasePoint*UnitQty)
        /// </summary>
        public decimal? SubBasePoint { get; set; }

        /// <summary>
        /// 小计供应商物流费(=VendorPerc1*SubAmt*0.01)
        /// </summary>
        public decimal? SubVendor1Amt { get; set; }

        /// <summary>
        /// 小计供应商仓储费(=VendorPerc2*SubAmt*0.01)
        /// </summary>
        public decimal? SubVendor2Amt { get; set; }

        /// <summary>
        /// 是否为后来录单员添加商品(0:不是;1:是的)
        /// </summary>
        public int IsAppend { get; set; }

        /// <summary>
        /// 追加的ID(SaleEdit.Edit)
        /// </summary>
        public string EditID { get; set; }

        /// <summary>
        /// 是否缺货(1:缺货;0/null:不缺货)
        /// </summary>
        public int IsStockOut { get; set; }

        /// <summary>
        /// 应用的单品促销编号(WProductPromotion.PromotionID)
        /// </summary>
        public string PromotionID { get; set; }

        /// <summary>
        /// 应用的单品促销名称(WProductPromotion.PromotionName)
        /// </summary>
        public string PromotionName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 序号(输入的序号,每一个单据从1开始)
        /// </summary>
        public int SerialNumber { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        public int? ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        public string ModifyUserName { get; set; }

        #endregion

    }

    /// <summary>
    /// 商品明细扩展
    /// </summary>
    public class SaleOrderPreDetailExtsRequestDto : RequestDtoParent
    {
        #region 模型
        /// <summary>
        /// 编号(SaleOrderDetails.ID)
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 订单编号(SaleOrder.OrderID)
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 基本分类一级分类ID(Category.CategoryId)
        /// </summary>
        public int CategoryId1 { get; set; }

        /// <summary>
        /// 基本分类一级分类名称
        /// </summary>
        public string CategoryId1Name { get; set; }

        /// <summary>
        /// 基本分类二级分类ID(Category.CategoryId)
        /// </summary>
        public int CategoryId2 { get; set; }

        /// <summary>
        /// 基本分类二级分类名称
        /// </summary>
        public string CategoryId2Name { get; set; }

        /// <summary>
        /// 基本分类三级分类ID(Category.CategoryId)
        /// </summary>
        public int CategoryId3 { get; set; }

        /// <summary>
        /// 基本分类三级分类名称
        /// </summary>
        public string CategoryId3Name { get; set; }

        /// <summary>
        /// 运营一级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        public int ShopCategoryId1 { get; set; }

        /// <summary>
        /// 运营一级分类名称
        /// </summary>
        public string ShopCategoryId1Name { get; set; }

        /// <summary>
        /// 运营二级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        public int ShopCategoryId2 { get; set; }

        /// <summary>
        /// 运营二级分类名称
        /// </summary>
        public string ShopCategoryId2Name { get; set; }

        /// <summary>
        /// 运营三级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        public int ShopCategoryId3 { get; set; }

        /// <summary>
        /// 运营三级分类名称
        /// </summary>
        public string ShopCategoryId3Name { get; set; }

        /// <summary>
        /// 品牌ID
        /// </summary>
        public int BrandId1 { get; set; }

        /// <summary>
        /// 品牌ID名称
        /// </summary>
        public string BrandId1Name { get; set; }

        /// <summary>
        /// 子品牌ID
        /// </summary>
        public int BrandId2 { get; set; }

        /// <summary>
        /// 子品牌名称
        /// </summary>
        public string BrandId2Name { get; set; }

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

        #endregion
    }
}
