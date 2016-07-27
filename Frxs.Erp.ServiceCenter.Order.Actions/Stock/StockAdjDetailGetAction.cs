/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/15 20:47:59
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Order.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.BLL;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Stock
{
    /// <summary>
    /// 盘点调整明细表 获取单条记录
    /// </summary>
    [ActionName("StockAdjDetail.Get")]
    public class StockAdjDetailGetAction : ActionBase<StockAdjDetailGetAction.StockAdjDetailGetActionRequestDto, StockAdjDetail>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockAdjDetailGetActionRequestDto : RequestDtoParent   //RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 主键
            /// </summary>
            public string ID { get; set; }
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
        public class StockAdjDetailGetActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<StockAdjDetail> Execute()
        {
            if (this.RequestDto == null || string.IsNullOrWhiteSpace(this.RequestDto.ID))
            {
                return this.ErrorActionResult("上传的参数不正确!");
            }
            StockAdjDetail model = new StockAdjDetail();

            model = StockAdjDetailBLO.GetModel(this.RequestDto.ID, RequestDto.WarehouseId.ToString());

            return this.SuccessActionResult(model);
        }

    }
}
