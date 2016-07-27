using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/24 16:06:12
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 根据条件查询网仓里的商品采购价格列表信息
    /// </summary>
    [ActionName("WProducts.Buy.List.Get"), ActionResultCache("_sys_", 5)]
    public class WProductsBuyListGetAction :
        ActionBase
            <WProductsBuyListGetAction.WProductsBuyListGetActionRequestDto, ActionResultPagerData<WProductsQueryModel>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsBuyListGetActionRequestDto : PageListRequestDto
        {
            /// <summary>
            /// 对应的仓库ID编号；此参数必须传入
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 供应商编号，必须填写
            /// </summary>
            public int? VendorID { get; set; }

            /// <summary>
            /// SKU信息
            /// </summary>
            public string SKU { get; set; }

            /// <summary>
            /// 是否对入参：SKU参数进行模糊搜索；系统默认true，进行模糊搜索
            /// </summary>
            public bool? SKULikeSearch { get; set; }

            /// <summary>
            /// 商品关键词
            /// </summary>
            public string ProductName { get; set; }

            /// <summary>
            /// 国际条码
            /// </summary>
            public string BarCode { get; set; }

            /// <summary>
            /// 商品ID，可以是部分ID，但是必须以开头(必须全部是数字)
            /// </summary>
            public string ProductId { get; set; }

            /// <summary>
            /// 是否查询所有状态-默认查询有限状态 也就是 WState=1
            /// </summary>
            public bool? AllWState { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public override void BeforeValid()
            {
                if (this.PageIndex <= 0)
                {
                    this.PageIndex = 1;
                }
                if (this.PageSize <= 0)
                {
                    this.PageSize = 10;
                }
                if (!this.SKULikeSearch.HasValue)
                {
                    this.SKULikeSearch = true;
                }
            }

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (!this.ProductId.IsNullOrEmpty() && !this.ProductId.IsInt())
                {
                    yield return new RequestDtoValidatorResultError("ProductId");
                }
            }

            public IList<int> ProductIds { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<WProductsQueryModel>> Execute()
        {
            // 查询数据
            var productQueryServices = DALFactory.GetLazyInstance<IWProductsQueryDAO>();

            productQueryServices.PageIndex = this.RequestDto.PageIndex;
            productQueryServices.PageSize = this.RequestDto.PageSize;

            productQueryServices.SearchParams = new WProductsQuerySearchParams()
            {
                WID = this.RequestDto.WID,
                VendorID = this.RequestDto.VendorID,
                SKU = this.RequestDto.SKU,
                SKULikeSearch = this.RequestDto.SKULikeSearch.Value,
                BarCode = this.RequestDto.BarCode,
                ProductId = this.RequestDto.ProductId,
                ProductIds = this.RequestDto.ProductIds,
                ProductName = this.RequestDto.ProductName,
                AllWState = this.RequestDto.AllWState
            };

            var responseDto = new ActionResultPagerData<WProductsQueryModel>()
            {
                TotalRecords = productQueryServices.GetCount(),
                ItemList = productQueryServices.GetList().ToList()
            };

            return this.SuccessActionResult(responseDto);
        }
    }
}
