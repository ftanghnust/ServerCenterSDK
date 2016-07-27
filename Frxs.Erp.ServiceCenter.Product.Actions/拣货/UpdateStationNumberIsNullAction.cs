/*********************************************************
 * FRXS 小马哥 2016/4/15 20:51:49
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Platform.Utility;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 还原待装区数据
    /// </summary>
    [ActionName("UpdateStationNumberIsNull")]
    public class UpdateStationNumberIsNullAction : ActionBase<Frxs.Erp.ServiceCenter.Product.Actions.UpdateStationNumberIsNullAction.UpdateStationNumberIsNullActionRequestDto, bool?>
    {
        /// <summary>
        /// 接口调用传入参数
        /// </summary>
        public class UpdateStationNumberIsNullActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 订单编号
            /// </summary>
            [Required]
            public string OrderId { get; set; }

            /// <summary>
            /// 状态
            /// </summary>
            [Required]
            public string Status { get; set; }

            /// <summary>
            /// 订单状态
            /// </summary>
            [Required]
            public string OrderStatus { get; set; }

        }

        /// <summary>
        /// 执行逻辑业务
        /// </summary>
        /// <returns></returns>
        public override ActionResult<bool?> Execute()
        {
            bool result = WStationNumberBLO.UpdateStationNumberIsNull(Utils.StrToInt(RequestDto.Status, 0), Utils.StrToInt(RequestDto.OrderStatus, 0), RequestDto.UserId, RequestDto.UserName, RequestDto.OrderId);
            return SuccessActionResult(result);
        }
    }
}
