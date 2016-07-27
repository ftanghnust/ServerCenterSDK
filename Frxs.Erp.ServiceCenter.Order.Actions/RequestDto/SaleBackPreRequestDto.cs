/*********************************************************
 * FRXS(ISC) ftanghnust@gmail.com 2016/3/10 15:44:25
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    /// <summary>
    /// SaleBackPre.AddOrEdit
    /// </summary>
    public class SaleBackPreAddOrEditActionRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 添加或者编辑
        /// </summary>
        public string Flag { get; set; }

        /// <summary>
        /// 销售退货单
        /// </summary>
        [Required]
        public SaleBackPreRequestDto order { get; set; }

        /// <summary>
        /// 销售退货单详情集合
        /// </summary>
        [Required]
        public IList<SaleBackPreDetailsRequestDto> orderdetails { get; set; }

        /// <summary>
        /// 销售退货单详情扩展集合
        /// </summary>
        [Required]
        public IList<SaleBackPreDetailsExtRequestDto> orderdetailsext { get; set; }

        /// <summary>
        /// 销售退货单(待处理)RequestDto
        /// </summary>
        public class SaleBackPreRequestDto
        {
            /// <summary>
            /// 退货单编号
            /// </summary>
            [Required]
            public string BackID { get; set; }

            /// <summary>
            /// 仓库ID(Warehouse.WID)
            /// </summary>
            [Required]
            public int WID { get; set; }

            /// <summary>
            /// 仓库编号(Warehouse.WCode)
            /// </summary>
            public string WCode { get; set; }

            /// <summary>
            /// 仓库名称(Warehouse.WName)
            /// </summary>
            public string WName { get; set; }

            /// <summary>
            /// 仓库柜台ID
            /// </summary>
            [Required]
            public int SubWID { get; set; }

            /// <summary>
            /// 仓库柜台编号(Warehouse.WCode)
            /// </summary>
            [Required]
            public string SubWCode { get; set; }

            /// <summary>
            /// 仓库柜台名称(Warehouse.WName)
            /// </summary>
            [Required]
            public string SubWName { get; set; }

            /// <summary>
            /// 退货日期(格式:yyyy-MM-dd)
            /// </summary>
            [Required]
            public DateTime BackDate { get; set; }

            /// <summary>
            /// 兴盛用户ID(预留)
            /// </summary>
            public long XSUserID { get; set; }

            /// <summary>
            /// 下单门店ID
            /// </summary>
            [Required]
            public int ShopID { get; set; }

            /// <summary>
            /// 下单门店编号
            /// </summary>
            [Required]
            public string ShopCode { get; set; }

            /// <summary>
            /// 下单门店名称
            /// </summary>
            [Required]
            public string ShopName { get; set; }

            /// <summary>
            /// 状态(0:未提交;1:已确认;2:已过帐;3:已结算)
            /// </summary>
            [Required]
            public int Status { get; set; }

            /// <summary>
            /// 退货金额(SaleBackDetails.BackAmt)
            /// </summary>
            [Required]
            public decimal TotalBackAmt { get; set; }

            /// <summary>
            /// 积分(SaleBackDetails.SubPoint)
            /// </summary>
            [Required]
            public decimal TotalBasePoint { get; set; }

            public decimal TotalBackQty { get; set; }

            public decimal TotalAddAmt { get; set; }

            public decimal PayAmount { get; set; }

            /// <summary>
            /// 提交时间
            /// </summary>
            public DateTime? ConfTime { get; set; }

            /// <summary>
            /// 提交用户ID
            /// </summary>
            public int ConfUserID { get; set; }

            /// <summary>
            /// 提交用户名称
            /// </summary>
            public string ConfUserName { get; set; }

            /// <summary>
            /// 过帐时间
            /// </summary>
            public DateTime? PostingTime { get; set; }

            /// <summary>
            /// 过帐用户ID
            /// </summary>
            public int PostingUserID { get; set; }

            /// <summary>
            /// 过帐用户名称
            /// </summary>
            public string PostingUserName { get; set; }

            /// <summary>
            /// 结算时间
            /// </summary>
            public DateTime? SettleTime { get; set; }

            /// <summary>
            /// 结算用户ID
            /// </summary>
            public int SettleUserID { get; set; }

            /// <summary>
            /// 结算用户名称
            /// </summary>
            public string SettleUserName { get; set; }

            /// <summary>
            /// 结算ID(SaleSettle.SettleID)
            /// </summary>
            public string SettleID { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            public string Remark { get; set; }

            /// <summary>
            /// 创建日期
            /// </summary>
            public DateTime CreateTime { get; set; }

            /// <summary>
            /// 创建用户ID
            /// </summary>
            public int CreateUserID { get; set; }

            /// <summary>
            /// 创建用户名称
            /// </summary>
            public string CreateUserName { get; set; }

            /// <summary>
            /// 最后修改时间
            /// </summary>
            [Required]
            public DateTime ModifyTime { get; set; }

            /// <summary>
            /// 最后修改用户ID
            /// </summary>
            public int ModifyUserID { get; set; }

            /// <summary>
            /// 最后修改用户名称
            /// </summary>
            public string ModifyUserName { get; set; }
        }

        /// <summary>
        /// 销售退货单详情(待处理)RequestDto
        /// </summary>
        public class SaleBackPreDetailsRequestDto
        {
            /// <summary>
            /// 编号(GUID)
            /// </summary>
            [Required]
            public string ID { get; set; }

            /// <summary>
            /// 仓库ID(Warehouse.WID)
            /// </summary>
            [Required]
            public int WID { get; set; }

            /// <summary>
            /// 退货编号(SaleOrders.OrderID)
            /// </summary>
            [Required]
            public string BackID { get; set; }

            /// <summary>
            /// 商品编号(Prouct.ProductID)
            /// </summary>
            [Required]
            public int ProductId { get; set; }

            /// <summary>
            /// 商品SKU(ERP编码)
            /// </summary>
            [Required]
            public string SKU { get; set; }

            /// <summary>
            /// 描述商品名称(Product.ProductName)
            /// </summary>
            [Required]
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
            /// 退货单位
            /// </summary>
            public string BackUnit { get; set; }

            /// <summary>
            /// 退货单位包装数(固定为库存单位)
            /// </summary>
            public decimal BackPackingQty { get; set; }

            /// <summary>
            /// 退货单位数量
            /// </summary>
            [Required]
            public decimal BackQty { get; set; }

            /// <summary>
            /// 退货单位价格
            /// </summary>
            public decimal BackPrice { get; set; }

            /// <summary>
            /// 库存单位
            /// </summary>
            public string Unit { get; set; }

            /// <summary>
            /// 库存单位数量(=BackPackingQty*BackQty)
            /// </summary>
            public decimal UnitQty { get; set; }

            /// <summary>
            /// 库存单位价格
            /// </summary>
            public decimal UnitPrice { get; set; }

            /// <summary>
            /// 调整后的金额(=UnitQty*UnitPrice)
            /// </summary>
            public decimal SubAmt { get; set; }

            /// <summary>
            /// 最小单位积分
            /// </summary>
            public decimal BasePoint { get; set; }

            /// <summary>
            /// 小计积分(=ShopPoint*UnitQty)
            /// </summary>
            public decimal SubBasePoint { get; set; }


            /// <summary>
            /// 门店库存单位平台率(%)(=WProducts.ShopAddPerc)
            /// </summary>
            public decimal ShopAddPerc { get; set; }

            /// <summary>
            /// 库存单位物流费率(=WProducts.VendorPerc1)
            /// </summary>
            public decimal VendorPerc1 { get; set; }

            /// <summary>
            /// 库存单位仓储费率(=WProducts.VendorPerc2)
            /// </summary>
            public decimal VendorPerc2 { get; set; }

            /// <summary>
            /// 小计门店提点金额,平台费用(=ShopAddPerc*SubAmt)
            /// </summary>
            public decimal SubAddAmt { get; set; }

            /// <summary>
            /// 小计供应商物流费(=VendorPerc1*SubAmt)
            /// </summary>
            public decimal SubVendor1Amt { get; set; }

            /// <summary>
            /// 小计供应商仓储费(=VendorPerc2*SubAmt)
            /// </summary>
            public decimal SubVendor2Amt { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            public string Remark { get; set; }

            /// <summary>
            /// 序号(输入的序号,每一个单据从1开始)
            /// </summary>
            [Required]
            public int SerialNumber { get; set; }

            /// <summary>
            /// 最后修改时间
            /// </summary>
            [Required]
            public DateTime ModifyTime { get; set; }

            /// <summary>
            /// 最后修改用户ID
            /// </summary>
            public int ModifyUserID { get; set; }

            /// <summary>
            /// 最后修改用户名称
            /// </summary>
            public string ModifyUserName { get; set; }
        }

        /// <summary>
        /// 销售退货单详情扩展(待处理)RequestDto
        /// </summary>
        public class SaleBackPreDetailsExtRequestDto
        {
            /// <summary>
            /// 编号(BuyOrderPreDetails.ID)
            /// </summary>
            [Required]
            public string ID { get; set; }

            /// <summary>
            /// 基本分类一级分类ID(Category.CategoryId)
            /// </summary>
            [Required]
            public int CategoryId1 { get; set; }

            /// <summary>
            /// 基本分类一级分类名称
            /// </summary>
            [Required]
            public string CategoryId1Name { get; set; }

            /// <summary>
            /// 基本分类二级分类ID(Category.CategoryId)
            /// </summary>
            [Required]
            public int CategoryId2 { get; set; }

            /// <summary>
            /// 基本分类二级分类名称
            /// </summary>
            [Required]
            public string CategoryId2Name { get; set; }

            /// <summary>
            /// 基本分类三级分类ID(Category.CategoryId)
            /// </summary>
            [Required]
            public int CategoryId3 { get; set; }

            /// <summary>
            /// 基本分类三级分类名称
            /// </summary>
            [Required]
            public string CategoryId3Name { get; set; }

            /// <summary>
            /// 运营一级分类ID(ShopCategory.ShopCategoryId)
            /// </summary>
            [Required]
            public int ShopCategoryId1 { get; set; }

            /// <summary>
            /// 运营一级分类名称
            /// </summary>
            [Required]
            public string ShopCategoryId1Name { get; set; }

            /// <summary>
            /// 运营二级分类ID(ShopCategory.ShopCategoryId)
            /// </summary>
            [Required]
            public int ShopCategoryId2 { get; set; }

            /// <summary>
            /// 运营二级分类名称
            /// </summary>
            [Required]
            public string ShopCategoryId2Name { get; set; }

            /// <summary>
            /// 运营三级分类ID(ShopCategory.ShopCategoryId)
            /// </summary>
            [Required]
            public int ShopCategoryId3 { get; set; }

            /// <summary>
            /// 运营三级分类名称
            /// </summary>
            [Required]
            public string ShopCategoryId3Name { get; set; }

            /// <summary>
            /// 品牌ID
            /// </summary>
            [Required]
            public int BrandId1 { get; set; }

            /// <summary>
            /// 品牌ID名称
            /// </summary>
            [Required]
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
            [Required]
            public DateTime ModifyTime { get; set; }

            /// <summary>
            /// 最后修改用户ID
            /// </summary>
            public int ModifyUserID { get; set; }

            /// <summary>
            /// 最后修改用户名称
            /// </summary>
            public string ModifyUserName { get; set; }
        }

        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }
    }

    /// <summary>
    /// SaleBackPre.Del
    /// </summary>
    public class SaleBackPreDelActionRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 销售退货单编号(批量)
        /// </summary>
        [Required]
        public string BackIDs { get; set; }

        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }
    }

    /// <summary>
    /// SaleBackPre.GetList
    /// </summary>
    public class SaleBackPreGetListActionRequestDto : PageListRequestDto
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        [Required]
        public int WID { get; set; }

        /// <summary>
        /// 仓库子机构编号
        /// </summary>
        public int? SubWID { get; set; }

        /// <summary>
        /// 采购退货单编号
        /// </summary>
        public string BackID { get; set; }

        /// <summary>
        /// 门店Code
        /// </summary>
        public string ShopCode { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 状态(0:未提交;1:已提交;2:已过帐;3:已结算)
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 入库时间 开始
        /// </summary>
        public string OrderDateBegin { get; set; }

        /// <summary>
        /// 入库时间 结束
        /// </summary>
        public string OrderDateEnd { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }


        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            if (WID <= 0)
            {
                yield return new RequestDtoValidatorResultError("WID");
            }
        }

    }

    /// <summary>
    /// SaleBackPre.ChangeStatus
    /// </summary>
    public class SaleBackPreChangeStatusActionRequestDto : RequestDtoParent
    {

        /// <summary>
        /// 销售退货单编号 批量
        /// </summary>
        [Required]
        public string BackIDs { get; set; }

        /// <summary>
        /// 状态(0:录单;1:确认;2:已过帐;3:已结算)
        /// </summary>
        [Required]
        public int Status { get; set; }

        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }

    }


    /// <summary>
    /// SaleBackPre.GetModel
    /// </summary>
    public class SaleBackPreGetModelActionRequestDto : RequestDtoParent
    {

        /// <summary>
        /// 销售退货单编号
        /// </summary>
        [Required]
        public string BackID { get; set; }

        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }

    }
}
