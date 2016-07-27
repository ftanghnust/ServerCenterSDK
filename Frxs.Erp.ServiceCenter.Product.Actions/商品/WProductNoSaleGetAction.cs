/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/5 17:18:33
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取商品限购信息 包含限购商品信息和门店群组信息
    /// </summary>
    [ActionName("WProduct.NoSale.Get")]
    public class WProductNoSaleGetAction : ActionBase<WProductNoSaleGetAction.WProductNoSaleGetActionRequestDto, WProductNoSaleInfo>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductNoSaleGetActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 限购单号
            /// </summary>
            public string NoSaleID { get; set; }
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
        public class WProductNoSaleGetActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<WProductNoSaleInfo> Execute()
        {
            if (this.RequestDto != null && !string.IsNullOrWhiteSpace(this.RequestDto.NoSaleID))
            {
                string noSaleID = this.RequestDto.NoSaleID.Trim();
                WProductNoSaleInfo model = WProductNoSaleBLO.GetModelInfo(this.RequestDto.NoSaleID);
                return this.SuccessActionResult(model);
            }
            else
            {
                return this.ErrorActionResult("上送的参数不正确!");
            }
        }
    }
}
