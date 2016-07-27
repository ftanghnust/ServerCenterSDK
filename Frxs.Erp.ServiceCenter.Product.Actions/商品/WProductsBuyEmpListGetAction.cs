using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    [ActionName("WProductsBuyEmp.List.Get")]
    public class WProductsBuyEmpListGetAction : ActionBase<WProductsBuyEmpListGetAction.WProductsBuyEmpListGetActionRequestDto, ActionResultPagerData<Model.WProductsBuyEmpListModel>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsBuyEmpListGetActionRequestDto : PageListRequestDto
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

            /// <summary>
            /// 采购员
            /// </summary>
            public string BuyEmpName { get; set; }

            /// <summary>
            /// 是否设置采购员
            /// </summary>
            public int? HasBuyEmp { get; set; }


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
        /// 下送的数据
        /// </summary>
        public class WProductsBuyEmpListGetGetResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<WProductsBuyEmpListModel>> Execute()
        {
            //查询
            var srver = DALFactory.GetLazyInstance<IWProductsBuyEmpListDAO>();
            srver.PageIndex = this.RequestDto.PageIndex;
            srver.PageSize = this.RequestDto.PageSize;
            srver.SearchParams = new Model.WProductsBuyEmpListParams()
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
                WStatus = this.RequestDto.WStatus,
                BuyEmpName = this.RequestDto.BuyEmpName,
                HasBuyEmp = this.RequestDto.HasBuyEmp
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

                item.StockQty = 0;
            }



            //返回结果集
            var resultData = new ActionResultPagerData<Model.WProductsBuyEmpListModel>()
            {
                TotalRecords = totalCount,
                ItemList = itemList
            };

            //输出
            return this.SuccessActionResult(resultData);
        }

    }
}
