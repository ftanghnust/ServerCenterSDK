using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.IDAL.Order;
using Frxs.Platform.IOCFactory;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Stock
{
    /// <summary>
    /// 获取当前仓库或子仓库的开档日
    /// </summary>
    [ActionName("StockQty.MinDate")]
    public class StockQtyMinDateAction : ActionBase<StockQtyMinDateAction.StockQtyMinDateRequestDto, StockQtyMinDateAction.StockQtyMinDateResponseDto>
    {

        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockQtyMinDateRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {

            /// <summary>
            /// 仓库ID(WarehouseID) 该数据决定了访问哪个数据库
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public int WID { get; set; }

            /// <summary>
            /// 仓库子机构ID(WarehouseID)
            /// </summary>
            public int SubWID { get; set; }


            /// <summary>
            /// 校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (this.WID <= 0) yield return new RequestDtoValidatorResultError("WID");
            }

        }

        /// <summary>
        /// 下送的数据
        /// </summary>
        public class StockQtyMinDateResponseDto
        {
            /// <summary>
            /// 单据的开档日
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public DateTime CreateMinDate { get; set; }
        }


        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<StockQtyMinDateAction.StockQtyMinDateResponseDto> Execute()
        {
            DateTime createMinDate = DALFactory.GetLazyInstance<IStockQueryDAO>(this.RequestDto.WID.ToString()).
                GetStockQtyCreateMinDate(this.RequestDto.WID, this.RequestDto.SubWID);
            StockQtyMinDateResponseDto repdto = new StockQtyMinDateResponseDto
                                                    {
                                                        CreateMinDate = createMinDate
                                                    };
            return SuccessActionResult(repdto);

        }


    }
}
