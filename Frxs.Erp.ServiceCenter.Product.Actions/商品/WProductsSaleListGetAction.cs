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
    /// 获取仓库配送价格列表
    /// </summary>
    [ActionName("WProducts.Sale.List.Get"), ActionResultCache("_sys_",5)]
    public class WProductsSaleListGetAction : ActionBase<WProductsSaleListGetAction.WProductsSaleListGetActionRequestDto, ActionResultPagerData<WProductsSaleQueryModel>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsSaleListGetActionRequestDto : PageListRequestDto
        {
            /// <summary>
            /// 对应的仓库ID编号；此参数必须传入
            /// </summary>
            [GreaterThan(-1)]
            public int WID { get; set; }

            /// <summary>
            /// SKU信息
            /// </summary>
            public string SKU { get; set; }

            /// <summary>
            /// 是否对入参：SKU参数进行模糊搜索
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
            /// 是否可退标注; true 可退，false不可退
            /// </summary>
            public bool? SaleBackFlag { get; set; }

            /// <summary>
            /// 是否查询所有状态-默认查询有限状态 也就是 WState=1
            /// </summary>
            public bool? AllWState { get; set; }
            

            /// <summary>
            /// 
            /// </summary>
            public override void BeforeValid()
            {
                if (!this.SKULikeSearch.HasValue)
                {
                    this.SKULikeSearch = true;
                }
                base.BeforeValid();
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
        public override ActionResult<ActionResultPagerData<WProductsSaleQueryModel>> Execute()
        {
            // 查询数据
            var productQueryServices = DALFactory.GetLazyInstance<IWProductsSaleQueryDAO>();

            productQueryServices.PageIndex = this.RequestDto.PageIndex;
            productQueryServices.PageSize = this.RequestDto.PageSize;

            productQueryServices.SearchParams = new WProductsSaleQuerySearchParams()
            {
                WID = this.RequestDto.WID,
                SKU = this.RequestDto.SKU,
                ProductIds = this.RequestDto.ProductIds,
                SKULikeSearch = this.RequestDto.SKULikeSearch.Value,
                BarCode = this.RequestDto.BarCode,
                ProductId = this.RequestDto.ProductId,
                ProductName = this.RequestDto.ProductName,
                SaleBackFlag = this.RequestDto.SaleBackFlag,
                AllWState = this.RequestDto.AllWState
            };

            var responseDto = new ActionResultPagerData<WProductsSaleQueryModel>()
            {
                TotalRecords = productQueryServices.GetCount(),
                ItemList = productQueryServices.GetList().ToList()
            };

            return this.SuccessActionResult(responseDto);
        }
    }
}
