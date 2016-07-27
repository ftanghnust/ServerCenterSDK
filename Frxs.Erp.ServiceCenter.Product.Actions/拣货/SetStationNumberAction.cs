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
    /// 设置待装区接口
    /// </summary>
    [ActionName("SetStationNumberAction")]
    public class SetStationNumberAction : ActionBase<Frxs.Erp.ServiceCenter.Product.Actions.SetStationNumberAction.SetStationNumberActionRequestDto, bool?>
    {
        /// <summary>
        /// 传入参数
        /// </summary>
        public class SetStationNumberActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 主键编号
            /// </summary>
            [Required]
            public int? ID { get; set; }

            /// <summary>
            /// 状态
            /// </summary>
            [Required]
            public int? Status { get; set; }

            /// <summary>
            /// 门店编号
            /// </summary>
            [Required]
            public int? ShopID { get; set; }

            /// <summary>
            /// 订单编号
            /// </summary>
            [Required]
            public string OrderID { get; set; }

            /// <summary>
            /// 配送日期
            /// </summary>
            [Required]
            public DateTime? OrderConfDate { get; set; }

            /// <summary>
            /// 线路编号
            /// </summary>
            [Required]
            public string LineID { get; set; }

            /// <summary>
            /// 订单状态
            /// </summary>
            [Required]
            public int? OrderStatus { get; set; }
        }

        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<bool?> Execute()
        {
            WStationNumber stationNumberModel = WStationNumberBLO.GetModel(Utils.StrToInt(RequestDto.ID, 0));
            stationNumberModel.Status = Utils.StrToInt(RequestDto.Status, 0);
            stationNumberModel.ShopID = Utils.StrToInt(RequestDto.ShopID, 0);
            stationNumberModel.OrderID = RequestDto.OrderID;
            stationNumberModel.OrderConfDate = RequestDto.OrderConfDate;
            stationNumberModel.LineID = Utils.StrToInt(RequestDto.LineID, 0);
            stationNumberModel.OrderStatus = Utils.StrToInt(RequestDto.OrderStatus, 0);
            bool isResult = WStationNumberBLO.Edit(stationNumberModel) > 0;
            if (isResult)
            {
                return SuccessActionResult(isResult);
            }
            else
            {
                return ErrorActionResult("更新待装区信息失败");
            }
        }
    }
}
