/*********************************************************
 * FRXS 小马哥 2016/4/13 11:49:21
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
    /// 设置待装区接口 中的线路信息
    /// </summary>
    [ActionName("SetStationNumberLineInfoAction")]
    public class SetStationNumberLineInfoAction : ActionBase<Frxs.Erp.ServiceCenter.Product.Actions.SetStationNumberLineInfoAction.SetStationNumberLineInfoActionRequestDto, bool?>
    {
        /// <summary>
        /// 传入参数
        /// </summary>
        public class SetStationNumberLineInfoActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 主键编号
            /// </summary>
            [Required]
            public int StationNumber { get; set; }

            /// <summary>
            /// 线路编号
            /// </summary>
            [Required]
            public string LineID { get; set; }

            /// <summary>
            /// 仓库ID
            /// </summary>
            [Required]
            public int WID { get; set; }
        }

        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<bool?> Execute()
        {
            WStationNumber stationNumberModel = new WStationNumber();
            stationNumberModel.WID = Utils.StrToInt(RequestDto.WID, 0);
            stationNumberModel.LineID = Utils.StrToInt(RequestDto.LineID, 0);
            stationNumberModel.StationNumber = Utils.StrToInt(RequestDto.StationNumber, 0);
            stationNumberModel.ModifyUserID = RequestDto.UserId;
            stationNumberModel.ModifyUserName = RequestDto.UserName;
            bool isResult = WStationNumberBLO.EditLineInfo(stationNumberModel) > 0;
            if (isResult)
            {
                return SuccessActionResult(isResult);
            }
            else
            {
                return ErrorActionResult("更新线路信息失败");
            }
        }
    }
}
