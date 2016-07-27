/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/15 15:36:42
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Actions.RequestDto;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Stock
{
    /// <summary>
    /// 盘点调整主表(盘亏盘盈表) 数据获取接口
    /// </summary>
    [ActionName("StockAdj.Get")]
    public class StockAdjGetAction : ActionBase<StockAdjGetAction.StockAdjGetActionRequestDto, Model.StockAdjModel>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockAdjGetActionRequestDto : RequestDtoParent//RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {

            /// <summary>
            /// 调整ID(WID+ ID服务)
            /// </summary>
            [Required(ErrorMessage = "盘点调整单号{0}不能为空")]
            public string AdjID { get; set; }
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
        public class StockAdjGetActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Model.StockAdjModel> Execute()
        {
            if (this.RequestDto == null || string.IsNullOrWhiteSpace(this.RequestDto.AdjID) || this.RequestDto.WarehouseId <= 0)
            {
                return this.ErrorActionResult("上传的参数不正确!");
            }

            StockAdjModel model = new StockAdjModel();

            model.StockAdjMain = StockAdjBLO.GetModel(this.RequestDto.AdjID, RequestDto.WarehouseId.ToString());

            return this.SuccessActionResult(model);
        }

    }
}
