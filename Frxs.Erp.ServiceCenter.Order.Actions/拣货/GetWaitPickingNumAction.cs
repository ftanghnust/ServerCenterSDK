/*********************************************************
 * FRXS 小马哥 2016/4/8 19:11:47
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Platform.Utility;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 拣货接口-获取待拣货数量
    /// </summary>
    [ActionName("GetWaitPickingNum")]
    public class GetWaitPickingNumAction : ActionBase<GetWaitPickingNumAction.GetWaitPickingNumActionRequestDto, int?>
    {
        /// <summary>
        /// 接口传入参数
        /// </summary>
        public class GetWaitPickingNumActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 货区编号
            /// </summary>
            [Required]
            public string ShelfAreaID { get; set; }

            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required]
            public string WID { get; set; }
        }

        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int?> Execute()
        {
            int shelfAreaID = DataTypeHelper.GetInt(RequestDto.ShelfAreaID);
            string strWID = RequestDto.WID;
            int? resultNum = SaleOrderPreBLO.GetWaitPickingNum(shelfAreaID, strWID);
            return SuccessActionResult(resultNum);
        }
    }
}
