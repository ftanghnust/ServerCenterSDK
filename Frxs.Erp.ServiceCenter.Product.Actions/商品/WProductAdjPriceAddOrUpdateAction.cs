using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/7 17:17:44
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 新增或者编辑调价单：调整类型(0:采购(进货)价;1:配送(批发)价;3:费率及积分)
    /// </summary>
    [ActionName("WProduct.AdjPrice.AddOrUpdate")]
    public class WProductAdjPriceAddOrUpdateAction : ActionBase<WProductAdjPriceAddOrUpdateAction.WProductAdjPriceAddActionRequestDto, int?>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductAdjPriceAddActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 调价单编号：注意：如果上送了此参数则为修改，不传送则为添加
            /// </summary>
            public int? AdjID { get; set; }

            /// <summary>
            /// 仓库编号
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 调价单类型，调整类型(0:采购(进货)价;1:配送(批发)价;2:费率及积分)
            /// </summary>
            public int AdjType { get; set; }

            /// <summary>
            /// 生效时间
            /// </summary>
            public DateTime? BeginTime { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            [StringLength(500)]
            public string Remark { get; set; }

            /// <summary>
            /// 调价单明细
            /// </summary>
            [Required]
            public List<ItemDetail> Items { get; set; }

            /// <summary>
            /// 明细对象
            /// </summary>
            public class ItemDetail
            {
                /// <summary>
                /// 商品ID(product.ProductID)
                /// </summary>
                public int ProductId { get; set; }

                /// <summary>
                /// 库存单位新批发价格/新进货价
                /// </summary>
                public decimal? Price { get; set; }

                /// <summary>
                /// 库存单位建议门店零售价
                /// </summary>
                public decimal? MarketPrice { get; set; }

                /// <summary>
                /// 门店库存单位积分
                /// </summary>
                public decimal? ShopPoint { get; set; }

                /// <summary>
                /// 门店库存单位提点率(%)
                /// </summary>
                public decimal? ShopPerc { get; set; }

                /// <summary>
                /// 库存单位绩效积分(司机及门店共用)
                /// </summary>
                public decimal? BasePoint { get; set; }

                /// <summary>
                /// 库存单位物流费率(供应商) (%)
                /// </summary>
                public decimal? VendorPerc1 { get; set; }

                /// <summary>
                /// 库存单位仓储费率(供应商)(%)
                /// </summary>
                public decimal? VendorPerc2 { get; set; }
            }

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (this.WID <= 0)
                {
                    yield return new RequestDtoValidatorResultError("WID");
                }

                if (!new int[] { 0, 1, 2 }.Any(o => o == this.AdjType))
                {
                    yield return new RequestDtoValidatorResultError("AdjType", "可选值为：0,1,2");
                }
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int?> Execute()
        {
            //仓库数据访问
            var wproductDal = DALFactory.GetLazyInstance<IWProductsDAO>();
            //仓库购买价数据访问
            var wproductBuyDal = DALFactory.GetLazyInstance<IWProductsBuyDAO>();
            //条件单头
            var wproductAdjPriceDao = DALFactory.GetLazyInstance<IWProductAdjPriceDAO>();
            //调价单明细
            var wproductAdjPriceDetailsDao = DALFactory.GetLazyInstance<IWProductAdjPriceDetailsDAO>();

            //添加单信息
            Model.WProductAdjPrice adjPrice = null;

            //添加
            if (!this.RequestDto.AdjID.HasValue)
            {
                //调价单头
                adjPrice = new Model.WProductAdjPrice()
               {
                   AdjID = 0,

                   AdjType = this.RequestDto.AdjType,
                   BeginTime = this.RequestDto.BeginTime,

                   ConfTime = null,
                   ConfUserID = null,
                   ConfUserName = null,

                   PostingTime = null,
                   PostingUserID = null,
                   PostingUserName = null,

                   CreateTime = DateTime.Now,
                   CreateUserID = this.RequestDto.UserId,
                   CreateUserName = this.RequestDto.UserName,

                   ModifyTime = DateTime.Now,
                   ModifyUserID = this.RequestDto.UserId,
                   ModifyUserName = this.RequestDto.UserName,

                   Remark = this.RequestDto.Remark,

                   Status = 0,
                   WID = this.RequestDto.WID
               };

                //调价单头部
                adjPrice.AdjID = wproductAdjPriceDao.Save(adjPrice);

            }
            //编辑
            else
            {
                //获取单据信息
                adjPrice = wproductAdjPriceDao.GetModel(this.RequestDto.AdjID.Value);

                //单据不存在
                if (adjPrice.IsNull() || adjPrice.WID != this.RequestDto.WID)
                {
                    return this.ErrorActionResult("单据不存在");
                }

                //只有未提交状态才能修改
                if (adjPrice.Status != 0)
                {
                    return this.ErrorActionResult("单据状态错误，只能待确认的单据才能修改");
                }

                adjPrice.ModifyTime = DateTime.Now;
                adjPrice.ModifyUserID = this.RequestDto.UserId;
                adjPrice.ModifyUserName = this.RequestDto.UserName;
                adjPrice.BeginTime = this.RequestDto.BeginTime;
                adjPrice.Remark = this.RequestDto.Remark;

                //编辑保存
                wproductAdjPriceDao.Edit(adjPrice);

                //清空明细
                wproductAdjPriceDetailsDao.DeleteByAdjId(adjPrice.AdjID);
            }

            //重新添加明细
            foreach (var item in this.RequestDto.Items)
            {
                //仓库商品信息
                var wproduct = wproductDal.GetModel(new Dictionary<string, object>().Append("WID", this.RequestDto.WID).Append("ProductId", item.ProductId));

                //配送价
                decimal price = wproduct.SalePrice.Value;

                //采购调价单
                if (this.RequestDto.AdjType == 0)
                {
                    price = wproductBuyDal.GetModel(new Dictionary<string, object>().Append("WID", this.RequestDto.WID).Append("ProductId", item.ProductId)).BuyPrice;
                }

                //添加信息明细
                var detail = new Model.WProductAdjPriceDetails()
                    {
                        AdjID = adjPrice.AdjID,

                        OldBasePoint = wproduct.BasePoint,
                        OldMarketPrice = wproduct.MarketPrice,
                        OldPrice = price,
                        OldShopAddPerc = wproduct.ShopAddPerc,
                        OldShopPoint = wproduct.ShopPoint,
                        OldVendorPerc1 = wproduct.VendorPerc1,
                        OldVendorPerc2 = wproduct.VendorPerc2,
                        Unit = wproduct.Unit,

                        MarketPrice = item.MarketPrice,
                        Price = item.Price,

                        ProductID = item.ProductId,

                        ShopPerc = item.ShopPerc,
                        ShopPoint = item.ShopPoint,
                        BasePoint = item.BasePoint,

                        VendorPerc1 = item.VendorPerc1,
                        VendorPerc2 = item.VendorPerc2,

                        WID = this.RequestDto.WID,
                        WProductID = (int)wproduct.WProductID,

                        CreateTime = DateTime.Now,
                        CreateUserID = this.RequestDto.UserId,
                        CreateUserName = this.RequestDto.UserName
                    };

                wproductAdjPriceDetailsDao.Save(detail);
            }

            //返回
            return this.SuccessActionResult(adjPrice.AdjID);
        }

        /// <summary>
        /// 删除匹配到的缓存键
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            this.CacheManager.RemoveByPattern(WProductAdjPriceCacheKey.FRXS_WPRODUCT_ADJPRICE_PATTERN_KEY);
            this.CacheManager.RemoveByPattern(WProductsCacheKey.FRXS_WPRODUCTS_PATTERN_KEY);
        }
    }
}
