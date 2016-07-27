/*********************************************************
 * FRXS 小马哥 2016/4/16 15:39:03
 * *******************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.BLL.Order;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 等待装箱订单列表
    /// </summary>
    [ActionName("GetModelByOrderId")]
    public class GetModelByOrderIdAction : ActionBase<Frxs.Erp.ServiceCenter.Order.Actions.GetModelByOrderIdAction.GetModelByOrderIdActionRequestDto, IList<SaleOrderPreShelfArea>>
    {
        /// <summary>
        /// 调用接口传入参数
        /// </summary>
        public class GetModelByOrderIdActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required]
            public string WID { get; set; }

            /// <summary>
            /// 订单编号
            /// </summary>
            [Required]
            public string OrderId { get; set; }
        }

        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<SaleOrderPreShelfArea>> Execute()
        {
            var dto = this.RequestDto;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            conditionDict.Add("OrderId", dto.OrderId);
            IList<SaleOrderPreShelfArea> list = SaleOrderPreShelfAreaBLO.GetList(conditionDict, dto.WID);
            if (list.Count>0)
            {
                return SuccessActionResult(list);
            }
            else
            {
                return ErrorActionResult("未查询到信息");
            }
        }
    }
}
