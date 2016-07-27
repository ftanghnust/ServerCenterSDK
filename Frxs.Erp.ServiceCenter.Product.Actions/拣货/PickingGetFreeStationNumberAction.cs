/*********************************************************
 * FRXS 小马哥 2016/4/9 15:53:38
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Utility;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 拣货接口-获取空闲待装区
    /// </summary>
    [ActionName("GetFreeStationNumber")]
    public class PickingGetFreeStationNumberAction : ActionBase<PickingGetFreeStationNumberAction.PickingGetFreeStationNumberActionRequestDto, PickingGetFreeStationNumberAction.PickingGetFreeStationNumberActionResponseDto>
    {
        /// <summary>
        /// 调用接口传入参数
        /// </summary>
        public class PickingGetFreeStationNumberActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required]
            public string WID { get; set; }
        }

        /// <summary>
        /// 调用接口输出
        /// </summary>
        public class PickingGetFreeStationNumberActionResponseDto : ResponseDtoBase
        {
            /// <summary>
            /// 编号(主键)
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// 仓库编号
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 待装区编码
            /// </summary>
            public int StationNumber { get; set; }
        }

        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<PickingGetFreeStationNumberActionResponseDto> Execute()
        {
            WStationNumber model = WStationNumberBLO.GetFreeStationNumber(Utils.StrToInt(RequestDto.WID, 0));
            if (model == null)
            {
                return ErrorActionResult("未查询到空闲待装区");
            }
            return SuccessActionResult(new PickingGetFreeStationNumberActionResponseDto()
            {
                ID = model.ID,
                WID = model.WID,
                StationNumber = model.StationNumber
            });
        }
    }
}
