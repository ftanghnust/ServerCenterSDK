/*********************************************************
 * FRXS 小马哥 2016/6/13 9:07:49
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model.Deliver;
using Frxs.Platform.Utility;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 对货接口
    /// </summary>
    [ActionName("CheckedGoods")]
    public class CheckedGoodsAction : ActionBase<Frxs.Erp.ServiceCenter.Order.Actions.CheckedGoodsAction.CheckedGoodsActionRequestDto, bool>
    {
        /// <summary>
        /// 对货接口传入参数
        /// </summary>
        public class CheckedGoodsActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required]
            public string WID { get; set; }

            /// <summary>
            /// 货区编号
            /// </summary>
            public int? ShelfAreaId { get; set; }

            /// <summary>
            /// 订单编号
            /// </summary>
            [Required]
            public string OrderId { get; set; }

            /// <summary>
            /// 对货修改商品数量信息
            /// </summary>
            [Required]
            public List<CheckedGoodsNumInfo> GoodsInfo { get; set; }
        }

        /// <summary>
        /// 对货接口返回参数
        /// </summary>
        public class CheckedGoodsActionResponseDto : ResponseDtoBase
        {

        }

        /// <summary>
        /// 执行对货逻辑处理
        /// </summary>
        /// <returns></returns>
        public override ActionResult<bool> Execute()
        {
            int shelfAreaId = Utils.StrToInt(RequestDto.ShelfAreaId, 0);
            string warehouseId = RequestDto.WID;
            string orderId = RequestDto.OrderId;
            int checkedUserId = RequestDto.UserId;
            string checkUserName = RequestDto.UserName;
            List<CheckedGoodsNumInfo> model = RequestDto.GoodsInfo;
            try
            {
                string isResult = SaleOrderPreBLO.SubmitCheckedGoods(shelfAreaId, warehouseId, checkedUserId, checkUserName, orderId, model);
                if (isResult == "SUCCESS")
                {
                    return SuccessActionResult(true);
                }
                else
                {
                    return ErrorActionResult(isResult);
                }
            }
            catch (Exception ex)
            {
                return ErrorActionResult(ex.Message);
            }
        }
    }
}
