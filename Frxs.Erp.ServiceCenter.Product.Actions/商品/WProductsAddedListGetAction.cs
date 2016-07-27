using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.ServiceCenter.Api.Core;
using System.Collections.Generic;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/2 9:13:44
 * *******************************************************/
using System.Linq;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 查询已添加的商品
    /// </summary>
    [ActionName("WProducts.Added.List.Get")]
    public class WProductsAddedListGetAction : ActionBase<WProductsAddedListGetAction.WProductsAddedListGetActionRequestDto, ActionResultPagerData<Model.WProductsAddedListModel>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsAddedListGetActionRequestDto : PageListRequestDto
        {
            /// <summary>
            /// 仓库编号，必须传
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 商品名称关键词
            /// </summary>
            public string ProductName { get; set; }

            /// <summary>
            /// 商品条码
            /// </summary>
            public string BarCode { get; set; }

            /// <summary>
            /// erp编码
            /// </summary>
            public string SKU { get; set; }

            /// <summary>
            /// 基本分类1级
            /// </summary>
            public int? CategoryId1 { get; set; }

            /// <summary>
            /// 基本分类2级
            /// </summary>
            public int? CategoryId2 { get; set; }

            /// <summary>
            /// 基本分类3级
            /// </summary>
            public int? CategoryId3 { get; set; }

            /// <summary>
            /// 商品主供应商
            /// </summary>
            public string VendorName { get; set; }

            /// <summary>
            /// 是否添加供应商 1为是 0为否 空表示全部
            /// </summary>
            public int? AddedVendor { get; set; }

            /// <summary>
            /// 仓库商品状态(0:已移除1:正常;2:淘汰;3:冻结;) ;淘汰商品和冻结商品不能销售;加入或重新加入时为正常；移除后再加入时为正常
            /// </summary>      
            public int? WStatus { get; set; }

            public IList<int> ProductIds { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public override void BeforeValid()
            {
                if (!this.SKU.IsNullOrEmpty())
                {
                    this.SKU = this.SKU.Trim();
                }

                base.BeforeValid();
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<WProductsAddedListModel>> Execute()
        {
            //查询
            var srver = DALFactory.GetLazyInstance<IWProductsAddedListDAO>();
            srver.PageIndex = this.RequestDto.PageIndex;
            srver.PageSize = this.RequestDto.PageSize;
            srver.SearchParams = new Model.WProductsAddedListParams()
            {
                BarCode = this.RequestDto.BarCode,
                WID = this.RequestDto.WID,
                ProductName = this.RequestDto.ProductName,
                SKU = this.RequestDto.SKU,
                CategoryId1 = this.RequestDto.CategoryId1,
                CategoryId2 = this.RequestDto.CategoryId2,
                CategoryId3 = this.RequestDto.CategoryId3,
                VendorName = this.RequestDto.VendorName,
                AddedVendor = this.RequestDto.AddedVendor,
                ProductIds = this.RequestDto.ProductIds,
                WStatus = this.RequestDto.WStatus
            };

            //总记录
            int totalCount = srver.GetCount();

            //集合
            var itemList = srver.GetList().ToList();
            foreach (var item in itemList)
            {
                //获取规格属性
                var productsAttributes = ProductsAttributesBLO.ProductsAttributesGet(item.ProductId);
                //多规格属性名称列表
                item.Attributes = string.Join(",", from o in productsAttributes select o.ValueStr);
                //库存数
                item.StockQty = 0;
            }

            //返回结果集
            var model = new ActionResultPagerData<Model.WProductsAddedListModel>()
            {
                TotalRecords = totalCount,
                ItemList = itemList
            };

            //输出
            return this.SuccessActionResult(model);
        }

    }
}
