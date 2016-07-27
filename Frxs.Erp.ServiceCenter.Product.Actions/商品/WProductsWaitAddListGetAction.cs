using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/1 15:08:28
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Platform.IOCFactory;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 还未加入到仓库后台的商品列表
    /// </summary>
    [ActionName("WProducts.WaitAdd.List.Get")]
    public class WProductsWaitAddListGetAction : ActionBase<WProductsWaitAddListGetAction.WProductsWaitAddListGetActionRequestDto, ActionResultPagerData<Model.WProductsWaitAddListModel>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsWaitAddListGetActionRequestDto : PageListRequestDto
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
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<Model.WProductsWaitAddListModel>> Execute()
        {
            //查询
            var srver = DALFactory.GetLazyInstance<IWProductsWaitAddListDAO>();
            srver.PageIndex = this.RequestDto.PageIndex;
            srver.PageSize = this.RequestDto.PageSize;
            srver.SearchParams = new Model.WProductsWaitAddListParams()
            {
                BarCode = this.RequestDto.BarCode,
                WID = this.RequestDto.WID,
                ProductName = this.RequestDto.ProductName,
                SKU = this.RequestDto.SKU,
                CategoryId1 = this.RequestDto.CategoryId1,
                CategoryId2 = this.RequestDto.CategoryId2,
                CategoryId3 = this.RequestDto.CategoryId3
            };

            //总记录
            int totalCount = srver.GetCount();

            //集合
            var itemList = srver.GetList().ToList();
            foreach (var item in itemList)
            {
                //获取分类名称
                ICategoriesDAO iCategories = DALFactory.GetLazyInstance<ICategoriesDAO>();
                var category = iCategories.GetModel(item.CategoryId1);
                if (!category.IsNull())
                {
                    item.CategoryName1 = category.Name;
                }

                category = iCategories.GetModel(item.CategoryId2);
                if (!category.IsNull())
                {
                    item.CategoryName2 = category.Name;
                }

                category = iCategories.GetModel(item.CategoryId3);
                if (!category.IsNull())
                {
                    item.CategoryName3 = category.Name;
                }

                //属性集合
                var attr = DALFactory.GetLazyInstance<IProductsAttributesDAO>().GetList(new Dictionary<string, object>().Append("ProductId", item.ProductId));

                //属性字段赋值
                item.Attributes = string.Join(",", (from x in attr select "{0}:{1}".With(x.AttributeName, x.ValueStr).ToArray()));
            }

            //返回结果集
            var resultData = new ActionResultPagerData<Model.WProductsWaitAddListModel>()
            {
                TotalRecords = totalCount,
                ItemList = itemList
            };

            //输出
            return this.SuccessActionResult(resultData);
        }

    }
}
