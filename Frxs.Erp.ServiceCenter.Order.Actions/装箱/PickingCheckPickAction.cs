/*********************************************************
 * FRXS 小马哥 2016/4/12 18:21:36
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.BLL.Order;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.Model.Order;
using Frxs.Platform.Utility;
using Frxs.Platform.Utility.Pager;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 对货更新相关表数据
    /// </summary>
    [ActionName("CheckPickUpdate")]
    public class PickingCheckPickAction : ActionBase<PickingCheckPickAction.PickingCheckPickActionRequestDto, bool>
    {
        /// <summary>
        /// 传入参数
        /// </summary>
        public class PickingCheckPickActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 主键ID(WID + GUID)
            /// </summary>
            [Required]
            public string ID { get; set; }

            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required]
            public string WID { get; set; }
        }

        /// <summary>
        /// 开始拣货
        /// </summary>
        /// <returns></returns>
        public override ActionResult<bool> Execute()
        {



            SaleOrderPreShelfArea saleOrderPreModel = SaleOrderPreShelfAreaBLO.GetModel(RequestDto.ID, RequestDto.WID);

            saleOrderPreModel.CheckTime = DateTime.Now;
            saleOrderPreModel.CheckUserID = RequestDto.UserId;
            saleOrderPreModel.CheckUserName = RequestDto.UserName;

            var row = SaleOrderPreShelfAreaBLO.Edit(saleOrderPreModel, RequestDto.WID);

            if (row == 0)
            {
                return ErrorActionResult("对货失败");
            }
            else
            {
                return SuccessActionResult(true);
            }


        }
    }
}
