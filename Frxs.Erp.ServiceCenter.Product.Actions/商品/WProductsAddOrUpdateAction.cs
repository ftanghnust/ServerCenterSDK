using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/1 8:41:39
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 仓库商品添加或者编辑；添加成功后返回仓库商品编号（WProductID）
    /// </summary>
    [ActionName("WProducts.AddOrUpdate"), UnloadCachekeys(WProductsCacheKey.FRXS_WPRODUCTS_PATTERN_KEY, "_sys_")]
    public class WProductsAddOrUpdateAction : ActionBase<WProductsAddOrUpdateAction.WProductsAddActionRequestDto, long?>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsAddActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 编辑或者添加
            /// </summary>
            public enum Flag
            {
                /// <summary>
                /// 添加
                /// </summary>
                Add,
                /// <summary>
                /// 编辑
                /// </summary>
                Edit
            }

            /// <summary>
            /// 编辑或者添加
            /// </summary>
            public Flag AddOrEdit { get; set; }

            /// <summary>
            /// 对应的仓库编号
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 商品编号
            /// </summary>
            public int ProductId { get; set; }

            /// <summary>
            /// 仓库商品标题
            /// </summary>
            [StringLength(400)]
            public string ProductName2 { get; set; }

            /// <summary>
            /// 库存单位采购价格
            /// </summary>
            public decimal? BuyPrice { get; set; }

            /// <summary>
            /// 建议门店零售价
            /// </summary>
            public decimal? MarketPrice { get; set; }

            /// <summary>
            /// 建议零售单位
            /// </summary>
            [StringLength(50)]
            public string MarketUnit { get; set; }

            /// <summary>
            /// 库存单位销售价格
            /// </summary>
            public decimal? SalePrice { get; set; }

            /// <summary>
            /// 库存单位物流费率(供应商) (%) --（物流费率）
            /// </summary>
            public decimal? VendorPerc1 { get; set; }

            /// <summary>
            /// 库存单位仓储费率(供应商)(%) --（仓储费率）
            /// </summary>
            public decimal? VendorPerc2 { get; set; }

            /// <summary>
            /// 门店库存单位提点率(%) (平台费率)
            /// </summary>
            public decimal? ShopAddPerc { get; set; }

            /// <summary>
            /// 门店库存单位积分 （门店积分）
            /// </summary>
            public decimal? ShopPoint { get; set; }

            /// <summary>
            /// 库存单位绩效积分（司机及门店绩效分) （绩效积分） 
            /// </summary>
            public decimal? BasePoint { get; set; }

            /// <summary>
            /// 是否可退
            /// </summary>
            [Required]
            public string SaleBackFlag { get; set; }

            /// <summary>
            /// 货架号（请注意，此编号是货架编号，不是货架内部ID）
            /// </summary>
            [Required]
            public string ShelfCode { get; set; }

            /// <summary>
            /// 配送单位
            /// </summary>
            public int DeliveryUnitID { get; set; }

            /// <summary>
            /// 商品状态；仓库商品状态(0:已移除1:正常;2:淘汰;3:冻结;) ;淘汰商品和冻结商品不能销售;加入或重新加入时为正常；移除后再加入时为正常
            /// </summary>
            public int WStatus { get; set; }

            /// <summary>
            /// 主供应商
            /// </summary>
            public int VendorID { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public override void BeforeValid()
            {
                if (this.MarketUnit.IsNull())
                {
                    this.MarketUnit = string.Empty;
                }
            }

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                //添加的时候判断下是否传了必须的值
                if (this.AddOrEdit == Flag.Add)
                {
                    if (!this.BuyPrice.HasValue || this.BuyPrice.Value < 0)
                    {
                        yield return new RequestDtoValidatorResultError("BuyPrice");
                    }
                    if (!this.MarketPrice.HasValue || this.MarketPrice.Value < 0)
                    {
                        yield return new RequestDtoValidatorResultError("MarketPrice");
                    }
                    if (!this.SalePrice.HasValue || this.SalePrice.Value < 0)
                    {
                        yield return new RequestDtoValidatorResultError("SalePrice");
                    }
                    if (!this.VendorPerc1.HasValue || this.VendorPerc1.Value < 0)
                    {
                        yield return new RequestDtoValidatorResultError("VendorPerc1");
                    }
                    if (!this.VendorPerc2.HasValue || this.VendorPerc2.Value < 0)
                    {
                        yield return new RequestDtoValidatorResultError("VendorPerc2");
                    }
                    if (!this.ShopAddPerc.HasValue || this.ShopAddPerc.Value < 0)
                    {
                        yield return new RequestDtoValidatorResultError("ShopAddPerc");
                    }
                    if (!this.ShopPoint.HasValue || this.ShopPoint.Value < 0)
                    {
                        yield return new RequestDtoValidatorResultError("ShopPoint");
                    }
                    if (!this.BasePoint.HasValue || this.BasePoint.Value < 0)
                    {
                        yield return new RequestDtoValidatorResultError("BasePoint");
                    }
                }
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<long?> Execute()
        {
            //获取仓库商品信息
            var wproduct = DALFactory.GetLazyInstance<IWProductsDAO>().GetModel(new Dictionary<string, object>()
                .Append("WID", this.RequestDto.WID)
                .Append("ProductId", this.RequestDto.ProductId));

            //检索出货架编号
            var shelf = DALFactory.GetLazyInstance<IShelfDAO>().GetModel(new Dictionary<string, object>()
                .Append("WID", this.RequestDto.WID)
                .Append("ShelfCode", this.RequestDto.ShelfCode));

            //货位不存在
            if (shelf.IsNull())
            {
                return this.ErrorActionResult("货位在仓库不存在");
            }

            //获取商品所有包装单位
            var productUnits = DALFactory.GetLazyInstance<IProductsUnitDAO>().GetList(new Dictionary<string, object>()
                .Append("ProductID", this.RequestDto.ProductId));

            //库存单位不存在
            if (productUnits.IsNull() || productUnits.IsEmpty())
            {
                return this.ErrorActionResult("库存单位不存在");
            }

            //获取配送单位
            var deliveryUnit = productUnits.FirstOrDefault(o => o.ProductsUnitID == this.RequestDto.DeliveryUnitID);
            if (deliveryUnit.IsNull())
            {
                return this.ErrorActionResult("配送单位不存在");
            }

            //最小库存单位
            var minStockUnit = productUnits.FirstOrDefault(o => o.IsUnit == 1);
            if (minStockUnit.IsNull())
            {
                return this.ErrorActionResult("最小库存单位不存在");
            }

            //获取仓库商品供应商集合
            IProductsVendorDAO iProductsVendorDao = DALFactory.GetLazyInstance<IProductsVendorDAO>();
            var productsVendors = iProductsVendorDao.GetList(new Dictionary<string, object>()
                .Append("WID", this.RequestDto.WID)
                .Append("ProductId", this.RequestDto.ProductId));

            //商品供应商里不存在，直接添加
            if (productsVendors.FirstOrDefault(o => o.VendorID == this.RequestDto.VendorID).IsNull())
            {
                iProductsVendorDao.Save(new ProductsVendor()
                {
                    ProductId = this.RequestDto.ProductId,
                    WID = this.RequestDto.WID,
                    VendorID = this.RequestDto.VendorID,
                    Unit = this.RequestDto.MarketUnit,
                    BuyPrice = (double)this.RequestDto.BuyPrice.Value,
                    IsMaster = 1,
                    LastBuyPrice = (double)this.RequestDto.BuyPrice.Value,
                    LastBuyTime = DateTime.Now,
                    CreateTime = DateTime.Now,
                    CreateUserID = this.RequestDto.UserId,
                    CreateUserName = this.RequestDto.UserName,
                    ModifyTime = DateTime.Now,
                    ModifyUserID = 0,
                    ModifyUserName = null
                });
            }
            //循环修改
            foreach (var productsVendor in productsVendors)
            {
                iProductsVendorDao.IsMasterUpdate(productsVendor.ID, productsVendor.VendorID == this.RequestDto.VendorID ? 1 : 0);
            }

            switch (this.RequestDto.AddOrEdit)
            {
                //添加
                case WProductsAddActionRequestDto.Flag.Add:

                    //在仓库已经存在了
                    if (!wproduct.IsNull())
                    {
                        return this.ErrorActionResult("商品已经添加");
                    }

                    //构造一个对象
                    var _wproduct = new Model.WProducts()
                    {
                        WID = this.RequestDto.WID,
                        ProductId = this.RequestDto.ProductId,
                        WStatus = this.RequestDto.WStatus,//正常
                        BackDays = 60,

                        BigProductsUnitID = this.RequestDto.DeliveryUnitID,
                        BigPackingQty = deliveryUnit.PackingQty,
                        BigUnit = deliveryUnit.Unit,
                        MarketUnit = this.RequestDto.MarketUnit,

                        BasePoint = this.RequestDto.BasePoint.Value,
                        MarketPrice = this.RequestDto.MarketPrice.Value,
                        ProductName2 = this.RequestDto.ProductName2,
                        SaleBackFlag = this.RequestDto.SaleBackFlag,
                        SalePrice = this.RequestDto.SalePrice.Value,
                        ShelfID = shelf.ShelfID,
                        ShopAddPerc = this.RequestDto.ShopAddPerc.Value,
                        ShopPoint = this.RequestDto.ShopPoint.Value,
                        Unit = minStockUnit.Unit,
                        VendorPerc1 = this.RequestDto.VendorPerc1.Value,
                        VendorPerc2 = this.RequestDto.VendorPerc2.Value,
                        CreateTime = DateTime.Now,
                        CreateUserID = this.RequestDto.UserId,
                        CreateUserName = this.RequestDto.UserName,
                        ModifyTime = DateTime.Now,
                        ModifyUserID = this.RequestDto.UserId,
                        ModifyUserName = this.RequestDto.UserName,
                        WProductID = 0
                    };

                    //添加到商品库
                    _wproduct.WProductID = DALFactory.GetLazyInstance<IWProductsDAO>().Save(_wproduct);

                    //采购价对象
                    var _productBuy = new Model.WProductsBuy()
                    {
                        WProductID = _wproduct.WProductID,
                        WID = this.RequestDto.WID,
                        BigProductsUnitID = this.RequestDto.DeliveryUnitID,
                        BigPackingQty = deliveryUnit.PackingQty,
                        BigUnit = deliveryUnit.Unit,
                        BuyPrice = this.RequestDto.BuyPrice.Value,
                        ModifyTime = DateTime.Now,
                        ModifyUserID = this.RequestDto.UserId,
                        ModifyUserName = this.RequestDto.UserName,
                        ProductId = this.RequestDto.ProductId,
                        VendorID = this.RequestDto.VendorID
                    };

                    //添加到采购价表
                    DALFactory.GetLazyInstance<IWProductsBuyDAO>().Save(_productBuy);

                    //成功
                    return this.SuccessActionResult(_wproduct.WProductID);

                //编辑
                case WProductsAddActionRequestDto.Flag.Edit:

                    //在仓库已经存在了
                    if (wproduct.IsNull())
                    {
                        return this.ErrorActionResult("商品不存在");
                    }

                    //获取到采购价信息
                    var wproductBuy = DALFactory.GetLazyInstance<IWProductsBuyDAO>().GetModel(wproduct.WProductID);
                    if (wproductBuy.IsNull())
                    {
                        return this.ErrorActionResult("采购价信息不存在");
                    }

                    //仓库商品
                    wproduct.ProductName2 = this.RequestDto.ProductName2;
                    wproduct.BigProductsUnitID = this.RequestDto.DeliveryUnitID;
                    wproduct.BigPackingQty = deliveryUnit.PackingQty;
                    wproduct.BigUnit = deliveryUnit.Unit;
                    wproduct.ShelfID = shelf.ShelfID;
                    wproduct.MarketUnit = this.RequestDto.MarketUnit;
                    wproduct.SaleBackFlag = this.RequestDto.SaleBackFlag;
                    wproduct.MarketPrice = this.RequestDto.MarketPrice.Value;
                    wproduct.WStatus = this.RequestDto.WStatus;
                    wproduct.ModifyTime = DateTime.Now;
                    wproduct.ModifyUserID = this.RequestDto.UserId;
                    wproduct.ModifyUserName = this.RequestDto.UserName;

                    wproduct.SalePrice = this.RequestDto.SalePrice.Value;
                    wproduct.ShopAddPerc = this.RequestDto.ShopAddPerc.Value;
                    wproduct.ShopPoint = this.RequestDto.ShopPoint.Value;
                    wproduct.VendorPerc1 = this.RequestDto.VendorPerc1.Value;
                    wproduct.VendorPerc2 = this.RequestDto.VendorPerc2.Value;
                    wproduct.BasePoint = this.RequestDto.BasePoint.Value;

                    DALFactory.GetLazyInstance<IWProductsDAO>().Edit(wproduct);

                    //采购价
                    wproductBuy.BigProductsUnitID = this.RequestDto.DeliveryUnitID;
                    wproductBuy.BigPackingQty = deliveryUnit.PackingQty;
                    wproductBuy.BigUnit = deliveryUnit.Unit;
                    wproductBuy.ModifyTime = DateTime.Now;
                    wproductBuy.ModifyUserID = this.RequestDto.UserId;
                    wproductBuy.ModifyUserName = this.RequestDto.UserName;
                    wproductBuy.VendorID = this.RequestDto.VendorID;
                    wproductBuy.BuyPrice = this.RequestDto.BuyPrice.Value;

                    DALFactory.GetLazyInstance<IWProductsBuyDAO>().Edit(wproductBuy);

                    //成功
                    return this.SuccessActionResult(wproduct.WProductID);
            }

            //返回值
            return this.ErrorActionResult("操作失败");
        }

        /// <summary>
        /// 删除匹配到的缓存键
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            this.CacheManager.RemoveByPattern(WProductsCacheKey.FRXS_WPRODUCTS_PATTERN_KEY);
        }
    }
}
