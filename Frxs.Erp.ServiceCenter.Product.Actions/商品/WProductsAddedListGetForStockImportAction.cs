using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/2 9:13:44
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 盘点商品批量导入 商品查询(盘盈盘亏单批量导入专用接口)
    /// </summary>
    [ActionName("WProducts.Added.List.ForStockImport.Get")]
    public class WProductsAddedListGetForStockImportAction : ActionBase<WProductsAddedListGetForStockImportAction.WProductsListForStockImportActionRequestDto, ActionResultPagerData<Model.WProductsStockCheckModel>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsListForStockImportActionRequestDto : PageListRequestDto
        {

            /// <summary>
            /// 仓库编号，必须传
            /// </summary>
            public int WID { get; set; }


            /// <summary>
            /// erp编码 集合
            /// </summary>
            public IList<string> SKUs { get; set; }


            /// <summary>
            /// 
            /// </summary>
            public override void BeforeValid()
            {
                //if(this.SKUs!=null && this.SKUs.Count>0)
                //{
                //    foreach (var SKU in SKUs)
                //    {
                //        if (!SKU.IsNullOrEmpty())
                //        {
                //            SKU = SKU.Trim();
                //        }
                //    }
                //}

                base.BeforeValid();
            }


            /// <summary>
            /// 自定义校验上送参数是否正确
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
        public class WProductsAddedListGetResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<WProductsStockCheckModel>> Execute()
        {
            //查询
            var srver = DALFactory.GetLazyInstance<IWProductsStockCheckListForStockDAO>();
            srver.PageIndex = this.RequestDto.PageIndex;
            srver.PageSize = this.RequestDto.PageSize;
            srver.SearchParams = new Model.WProductsStockCheckListParams()
            {
                WID = this.RequestDto.WID,
                SKUs = this.RequestDto.SKUs
            };

            //总记录
            int totalCount = srver.GetCount();

            //集合
            var itemList = srver.GetList().ToList();
            //foreach (var item in itemList)
            //{
            //    //获取规格属性
            //    var productsAttributes = ProductsAttributesBLO.ProductsAttributesGet(item.ProductId);
            //    //多规格属性名称列表
            //    item.Attributes = string.Join(",", from o in productsAttributes select o.ValueStr);

            //    ////属性集合
            //    //var attr = LazyControl.LazyDAOObjectCreator.IProductsAttributesDAOObj.GetList(new Dictionary<string, object>().Append("ProductId", item.ProductId));

            //    //属性字段赋值
            //    // item.Attributes = string.Join(",", (from x in productsAttributes select "{0}:{1}".With(x.AttributeName, x.ValueStr).ToList()));
            //}

            //返回结果集
            var resultData = new ActionResultPagerData<Model.WProductsStockCheckModel>()
            {
                TotalRecords = totalCount,
                ItemList = itemList
            };

            //输出
            return this.SuccessActionResult(resultData);
        }

    }
}
