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
    /// BuyBackPre.AddOrEdit
    /// </summary>
    public class BuyBackPreAddOrEditActionRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 添加或者编辑
        /// </summary>
        public string Flag { get; set; }

        /// <summary>
        /// 采购退货单
        /// </summary>
        [Required]
        public BuyBackPreRequestDto order { get; set; }

        /// <summary>
        /// 采购退货单详情集合
        /// </summary>
        [Required]
        public IList<BuyBackPreDetailsRequestDto> orderdetails { get; set; }

        /// <summary>
        /// 采购退货单详情扩展集合
        /// </summary>
        [Required]
        public IList<BuyBackPreDetailsExtRequestDto> orderdetailsext { get; set; }

        /// <summary>
        /// 采购退货单(待处理)RequestDto
        /// </summary>
        public class BuyBackPreRequestDto
        {
            /// <summary>
            /// 采购退货单编号
            /// </summary>
            [Required]
            public string BackID { get; set; }

            /// <summary>
            /// 仓库ID(Warehouse.WID)
            /// </summary>
            [Required]
            public int WID { get; set; }

            /// <summary>
            /// 仓库柜台
            /// </summary>
            [Required]
            public int SubWID { get; set; }

            /// <summary>
            /// 预定订单编号(预留)
            /// </summary>
            public string PreBuyID { get; set; }

            /// <summary>
            /// 采购入库时间(OrderStatus=1;格式:yyyy-MM-dd HH:mm:ss)
            /// </summary>
            [Required]
            public DateTime OrderDate { get; set; }

            /// <summary>
            /// 仓库编号(Warehouse.WCode)
            /// </summary>
            [Required]
            public string WCode { get; set; }

            /// <summary>
            /// 仓库名称(Warehouse.WName)
            /// </summary>
            [Required]
            public string WName { get; set; }

            /// <summary>
            /// 仓库子机构编号(Warehouse.WCode)
            /// </summary>
            [Required]
            public string SubWCode { get; set; }

            /// <summary>
            /// 仓库子机构名称(Warehouse.WName)
            /// </summary>
            [Required]
            public string SubWName { get; set; }

            /// <summary>
            /// 采购员ID(WarehouseEmp.EmpID and UserType=4)
            /// </summary>
            public int BuyEmpID { get; set; }

            /// <summary>
            /// 采购员名称(WarehouseEmp.EmpName and UserType=4)
            /// </summary>
            public string BuyEmpName { get; set; }

            /// <summary>
            /// 供应商分类ID
            /// </summary>
            [Required]
            public int VendorID { get; set; }

            /// <summary>
            /// 供应商编号
            /// </summary>
            [Required]
            public string VendorCode { get; set; }

            /// <summary>
            /// 供应商名称
            /// </summary>
            [Required]
            public string VendorName { get; set; }

            /// <summary>
            /// 采购总金额(BuyOrderDetails.SubBuyAmt)
            /// </summary>
            [Required]
            public double TotalAmt { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            public string Remark { get; set; }
        }

        /// <summary>
        /// 采购退货单详情(待处理)RequestDto
        /// </summary>
        public class BuyBackPreDetailsRequestDto
        {
            /// <summary>
            /// 编号（仓库ID+GUID)
            /// </summary>
            [Required]
            public string ID { get; set; }

            /// <summary>
            /// 仓库ID(Warehouse.WID)
            /// </summary>
            [Required]
            public int WID { get; set; }

            /// <summary>
            /// 采购退货编号(BuyOrderPre.OrderID)
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
            /// 采购单位
            /// </summary>
            [Required]
            public string BackUnit { get; set; }

            /// <summary>
            /// 采购单位包装数(固定为库存单位)
            /// </summary>
            [Required]
            public decimal BackPackingQty { get; set; }

            /// <summary>
            /// 采购单位数量
            /// </summary>
            [Required]
            public decimal BackQty { get; set; }

            /// <summary>
            /// 采购单位价格
            /// </summary>
            [Required]
            public double BackPrice { get; set; }

            /// <summary>
            /// 库存单位
            /// </summary>
            [Required]
            public string Unit { get; set; }

            /// <summary>
            /// 库存单位数量=(BuyPackingQty*BuyQty)
            /// </summary>
            [Required]
            public decimal UnitQty { get; set; }

            /// <summary>
            /// 库存单位价格
            /// </summary>
            [Required]
            public double UnitPrice { get; set; }

            /// <summary>
            /// 采购的总金额(=UnitQty*UnitPrice)
            /// </summary>
            [Required]
            public double SubAmt { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            [Required]
            public string Remark { get; set; }

            /// <summary>
            /// 配送价 库存单位
            /// </summary>
            [Required]
            public decimal SalePrice { get; set; }

        }

        /// <summary>
        /// 采购退货单详情扩展(待处理)RequestDto
        /// </summary>
        public class BuyBackPreDetailsExtRequestDto
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
    /// BuyBackPre.Del
    /// </summary>
    public class BuyBackPreDelActionRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 采购退货单编号(批量)
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
    /// BuyBackPre.GetList
    /// </summary>
    public class BuyBackPreGetListActionRequestDto : PageListRequestDto
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
        /// 供应商Code或者供应商名称
        /// </summary>
        public string VendorCodeOrName { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 描述商品名称(Product.ProductName)
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 状态(0:未提交;1:已提交;2:已过帐;3:已结算)
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 退货时间 开始
        /// </summary>
        public string OrderDateBegin { get; set; }

        /// <summary>
        /// 退货时间 结束
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
    /// BuyBackPre.ChangeStatus
    /// </summary>
    public class BuyBackPreChangeStatusActionRequestDto : RequestDtoParent
    {

        /// <summary>
        /// 采购退货单编号 批量
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
    /// BuyBackPre.GetModel
    /// </summary>
    public class BuyBackPreGetModelActionRequestDto : RequestDtoParent
    {

        /// <summary>
        /// 采购退货单编号
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
