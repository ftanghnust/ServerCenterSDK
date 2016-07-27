/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/15 17:12:16
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Order.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Platform.Utility.Map;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Order.IDAL;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Stock
{
    /// <summary>
    /// 盘点调整明细表 保存接口
    /// </summary>
    [ActionName("StockAdjDetail.Save")]
    public class StockAdjDetailSaveAction : ActionBase<StockAdjDetailSaveAction.StockAdjDetailSaveActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockAdjDetailSaveActionRequestDto : RequestDtoParent//RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 标志位 0表示新增，1表示修改
            /// </summary>
            public int Flag { get; set; }

            #region StockAdjDetail模型
            /// <summary>
            /// 主键(仓库ID+GUID)
            /// </summary>           
            [Required(ErrorMessage = "主键{0}不能为空")]
            public string ID { get; set; }

            /// <summary>
            /// 仓库ID(Warehouse.WID)
            /// </summary>
            [Required(ErrorMessage = "仓库ID{0}不能为空")]
            public int WID { get; set; }

            /// <summary>
            /// 盘亏盘赢调整编号(StockAdj.AdjID)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string AdjID { get; set; }

            /// <summary>
            /// 商品编号(Prouct.ProductID)
            /// </summary>
            [Required(ErrorMessage = "盘亏盘赢调整编号{0}不能为空")]
            public int ProductId { get; set; }

            /// <summary>
            /// 商品SKU(商品编码)
            /// </summary>
            [Required(ErrorMessage = "商品编码{0}不能为空")]
            public string SKU { get; set; }

            /// <summary>
            /// 描述商品名称(Product.ProductName)
            /// </summary>
            [Required(ErrorMessage = "描述商品名称{0}不能为空")]
            public string ProductName { get; set; }

            /// <summary>
            /// 商品的国际条码
            /// </summary>
            public string BarCode { get; set; }

            /// <summary>
            /// 调整单位(j库存单位,预留)
            /// </summary>
            [Required(ErrorMessage = "调整单位{0}不能为空")]
            public string AdjUnit { get; set; }

            /// <summary>
            /// 调整单位包装数(固定为1)  2016-6-20 按照会议要求，类型统一由int改成decimal
            /// </summary>
            [Required(ErrorMessage = "调整单位包装数{0}不能为空")]
            public decimal AdjPackingQty { get; set; }

            /// <summary>
            /// 调整数量
            /// </summary>
            [Required(ErrorMessage = "调整数量{0}不能为空")]
            public decimal AdjQty { get; set; }

            /// <summary>
            /// 库存单位(WProducts.Unit)
            /// </summary>
            [Required(ErrorMessage = "库存单位{0}不能为空")]
            public string Unit { get; set; }

            /// <summary>
            /// 库存单位数量(=AdjQty*AdjPackingQty)
            /// </summary>
            [Required(ErrorMessage = "库存单位数量{0}不能为空")]
            public decimal UnitQty { get; set; }

            /// <summary>
            /// (库存单位)采购单价(=WProducts.SalePrice)
            /// </summary>
            [Required(ErrorMessage = "采购单价{0}不能为空")]
            public decimal BuyPrice { get; set; }

            /// <summary>
            /// (库存单位)配送单价(=WProductsBuy.BuyPrice)
            /// </summary>
            [Required(ErrorMessage = "配送单价{0}不能为空")]
            public decimal SalePrice { get; set; }

            /// <summary>
            /// 调整金额(=UnitQty*BuyPrice)
            /// </summary>
            [Required(ErrorMessage = "调整金额{0}不能为空")]
            public decimal AdjAmt { get; set; }

            /// <summary>
            /// 商品主供应商(=WProductsBuy.VendorID)
            /// </summary>
            [Required(ErrorMessage = "商品主供应商{0}不能为空")]
            public int VendorID { get; set; }

            /// <summary>
            /// 主供应商编号(Vendor.VendorCode)
            /// </summary>
            [Required(ErrorMessage = "主供应商编号{0}不能为空")]
            public string VendorCode { get; set; }

            /// <summary>
            /// 主供应商名称(Vendor.VendorName)
            /// </summary>
            [Required(ErrorMessage = "主供应商名称{0}不能为空")]
            public string VendorName { get; set; }


            /// <summary>
            /// 盘点时该单位时的子机构的库存(StockQty.StockQty)
            /// </summary>
            [Required(ErrorMessage = "子机构的库存{0}不能为空")]
            public decimal StockQty { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            public string Remark { get; set; }

            /// <summary>
            /// 序号(输入的序号,每一个单据从1开始)
            /// </summary>
            [Required(ErrorMessage = "序号{0}不能为空")]
            public int SerialNumber { get; set; }

            /// <summary>
            /// 盘点单号(StockCheck.StockCheckID)
            /// </summary>
            public string StockCheckID { get; set; }

            /// <summary>
            /// 盘点明细ID(StockCheckDetails.ID)
            /// </summary>
            public string StockCheckDetailsID { get; set; }

            /// <summary>
            /// 盘点人员ID
            /// </summary>
            public int? CheckUserID { get; set; }

            /// <summary>
            /// 盘点人员姓名
            /// </summary>

            public string CheckUserName { get; set; }

            /// <summary>
            /// 盘点库存数量(StockCheckDetails.CheckUnitQty)
            /// </summary>
            public decimal? CheckUnitQty { get; set; }

            #endregion

            #region 扩展自 StockAdjDetailsExt 的模型
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

            #endregion

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
        /// 下送的数据
        /// </summary>
        public class StockAdjDetailSaveActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            if (this.RequestDto == null || RequestDto.WID <= 0)
            {
                return this.ErrorActionResult("上传的参数不正确!请确保仓库ID正确!", 0);
            }
            string warehouseId = RequestDto.WID.ToString();
            int result = 0;
            string msg = string.Empty;
            StockAdjDetail model = RequestDto.MapTo<StockAdjDetail>();            //StockAdjDetail model = AutoMapperHelper.MapTo<StockAdjDetail>(this.RequestDto);

            int currentMaxSerialNumber = StockAdjBLO.GetDetailMaxSerialNumber(RequestDto.AdjID, warehouseId);//当前的明细最大序号      
            model.SerialNumber = currentMaxSerialNumber + 1;

            model.ModifyTime = DateTime.Now;
            model.ModifyUserID = RequestDto.UserId;
            model.ModifyUserName = RequestDto.UserName;

            if (RequestDto.Flag == 0)
            {
                //新增 明细之前，要确认表头记录存在且是处于录单状态，否则不能修改
                var currentModel = StockAdjBLO.GetModel(RequestDto.AdjID, warehouseId);
                if (currentModel == null)
                {
                    return ErrorActionResult(string.Format("操作失败,单号[{0}]的盘点调整主表记录不存在!", RequestDto.AdjID), 0);
                }
                else if (currentModel.Status != 0)
                {
                    return ErrorActionResult(string.Format("操作失败,单号[{0}]的盘点调整主表记录不是“录单”状态!", RequestDto.AdjID), 0);
                }
                if (StockAdjDetailBLO.Exists(model, warehouseId))
                {
                    return this.ErrorActionResult(string.Format("有重复的记录! 商品编号{0}", model.SKU), 0);
                }

                #region 2016-4-19 根据胡总的意见，在订单接口中调用ProductSDK 获取商品详情（图片+运营分类+品牌信息）
                //准备调用 产品SDK,获取到 基本资料中心客户端SDK访问对象 （根据2016-3-22 胡勇提供的 “5个服务中心的依赖关系”，订单SDK可以调用基本资料SDK，但不可反向调用）
                var workContext = WorkContext.CreateProductSdkClient();

                //详情扩展表对象 接口只能从请求对象中获取一部分信息，剩下的要自己再调其他接口获取详情表和扩展表的信息
                StockAdjDetailsExt extModel = new StockAdjDetailsExt();

                extModel.ID = RequestDto.ID;
                extModel.AdjID = RequestDto.AdjID;

                extModel.CategoryId1 = RequestDto.CategoryId1;
                extModel.CategoryId2 = RequestDto.CategoryId2;
                extModel.CategoryId3 = RequestDto.CategoryId3;

                extModel.CategoryId1Name = RequestDto.CategoryId1Name;
                extModel.CategoryId2Name = RequestDto.CategoryId2Name;
                extModel.CategoryId3Name = RequestDto.CategoryId3Name;

                extModel.ModifyTime = DateTime.Now;
                extModel.ModifyUserID = RequestDto.UserId;
                extModel.ModifyUserName = RequestDto.UserName;

                #region 详情表信息 获取图片信息
                var imgRequest = new Product.SDK.Request.FrxsErpProductProductsPictureDetailGetRequest() { ProductId = RequestDto.ProductId };
                var imgResp = workContext.Execute(imgRequest);
                //imgResp.Flag == 0 代表成功
                if (imgResp != null && imgResp.Flag == 0 && imgResp.Data != null && imgResp.Data.ProductsPictureDetailList.Count > 0)
                {
                    var imgDetail = imgResp.Data.ProductsPictureDetailList.FirstOrDefault(o => o.IsMaster == 1);
                    if (imgDetail != null)
                    {
                        model.ProductImageUrl200 = imgDetail.ImageUrl200x200;
                        model.ProductImageUrl400 = imgDetail.ImageUrl400x400;
                    }
                }
                else
                {
                    model.ProductImageUrl200 = "";
                    model.ProductImageUrl400 = "";
                    //return ErrorActionResult("获取商品图片信息失败!"); //2016-4-19 找胡总核实，图片允许为空
                }
                #endregion

                #region 扩展表信息 品牌信息 和 商品运营分类ID
                var productRequest = new Product.SDK.Request.FrxsErpProductProductGetRequest() { ProductId = RequestDto.ProductId };
                var productInfo = workContext.Execute(productRequest);
                //roductInfo.Flag == 0 代表查询成功
                if (productInfo != null && productInfo.Flag == 0 && productInfo.Data != null)
                {
                    #region 扩展表信息 品牌信息 和 商品运营分类ID
                    extModel.BrandId1 = productInfo.Data.BaseProduct.BrandId1;
                    extModel.BrandId2 = productInfo.Data.BaseProduct.BrandId2;

                    extModel.BrandId1Name = productInfo.Data.BaseProduct.BrandName1;
                    extModel.BrandId2Name = productInfo.Data.BaseProduct.BrandName2;

                    extModel.ShopCategoryId1 = productInfo.Data.BaseProduct.ShopCategoryId1;
                    extModel.ShopCategoryId2 = productInfo.Data.BaseProduct.ShopCategoryId2;
                    extModel.ShopCategoryId3 = productInfo.Data.BaseProduct.ShopCategoryId3;
                    #endregion

                    #region 获取运营分类名称信息
                    var shopCat = new Product.SDK.Request.FrxsErpProductShopCategoriesParentsGetRequest()
                    {
                        CategoryId = productInfo.Data.BaseProduct.ShopCategoryId3,
                        UserId = this.RequestDto.UserId,
                        UserName = this.RequestDto.UserName
                    };
                    var shopCatResp = workContext.Execute(shopCat, new Product.SDK.CacheOptions()
                    {
                        CacheTime = 30,
                        FromLocalCache = true
                    });
                    if (shopCatResp != null && shopCatResp.Flag == 0 && shopCatResp.Data != null)
                    {
                        var shopCatName1 = shopCatResp.Data.FirstOrDefault(o => o.CategoryId == extModel.ShopCategoryId1);
                        var shopCatName2 = shopCatResp.Data.FirstOrDefault(o => o.CategoryId == extModel.ShopCategoryId2);
                        var shopCatName3 = shopCatResp.Data.FirstOrDefault(o => o.CategoryId == extModel.ShopCategoryId3);
                        if (shopCatName1 == null || shopCatName2 == null || shopCatName3 == null)
                        {
                            return ErrorActionResult(string.Format("获取商品[{0}]运营分类信息失败!", RequestDto.SKU), 0);
                        }
                        extModel.ShopCategoryId1Name = shopCatName1.CategoryName;
                        extModel.ShopCategoryId2Name = shopCatName2.CategoryName;
                        extModel.ShopCategoryId3Name = shopCatName3.CategoryName;
                    }
                    else
                    {
                        return ErrorActionResult(string.Format("获取商品[{0}]运营分类信息失败!", RequestDto.SKU), 0);
                    }
                    #endregion

                }
                else
                {
                    return ErrorActionResult(string.Format("获取商品[{0}]商品详情失败!", RequestDto.SKU), 0);
                }
                #endregion
                #endregion

                #region 新增时要同步保存 详情扩展表的数据 事务处理
                var connection = DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).GetConnection();
                connection.Open();
                var trans = connection.BeginTransaction();
                try
                {
                    result = DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).Save(connection, trans, model);
                    DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(warehouseId).Save(connection, trans, extModel);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    msg = ex.StackTrace;
                    trans.Rollback();
                    return ErrorActionResult(string.Format("操作失败！ {0}", ex.Message), 0);
                }
                finally
                {
                    trans.Dispose();
                    connection.Close();
                    connection.Dispose();
                }
                #endregion

            }
            else
            {
                //修改 明细之前，要确认表头记录存在且是处于录单状态，否则不能修改
                var currentModel = StockAdjBLO.GetModel(RequestDto.AdjID, warehouseId);
                if (currentModel == null)
                {
                    return ErrorActionResult(string.Format("操作失败,单号[{0}]的盘点调整主表记录不存在!", RequestDto.AdjID), 0);
                }
                else if (currentModel.Status != 0)
                {
                    return ErrorActionResult(string.Format("操作失败,单号[{0}]的盘点调整主表记录不是“录单”状态!", RequestDto.AdjID), 0);
                }
                if (StockAdjDetailBLO.Exists(model, warehouseId))
                {//需要重点防止在修改明细时，将商品指向一个已经在同一个单据下已经存在的另一个商品！！
                    return this.ErrorActionResult(string.Format("有重复的记录! 商品编号{0}", model.SKU), 0);
                }
                //修改时只能修改几个字段,按照新的数据库访问的框架方法，只给要修改的字段属性赋值即可，具体该给哪些属性赋值，前端可以控制到
                result = StockAdjDetailBLO.Edit(model, warehouseId);
            }
            if (!string.IsNullOrEmpty(msg))
            {
                return this.ErrorActionResult(string.Format("保存失败! {0}", msg), 0);
            }
            return this.SuccessActionResult("保存成功!", 1);
        }
    }
}
