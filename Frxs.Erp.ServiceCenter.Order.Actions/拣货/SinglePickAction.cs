/*********************************************************
 * FRXS 小马哥 2016/5/4 9:59:31
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// 拣货-单个商品
    /// </summary>
    [ActionName("SinglePick")]
    public class SinglePickAction : ActionBase<Frxs.Erp.ServiceCenter.Order.Actions.SinglePickAction.SinglePickActionRequestDto, SaleOrderPreWaitPickingList>
    {
        /// <summary>
        /// 调用接口传入参数
        /// </summary>
        public class SinglePickActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 订单编号
            /// </summary>
            [Required]
            public string OrderId { get; set; }

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
        /// 执行操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<SaleOrderPreWaitPickingList> Execute()
        {
            ///根据订单编号和货区编号查询正在拣货列表，如果没有数据，则表名此订单该货区已拣货完成
            PageListBySql<SaleOrderPre7ShelfArea> pager = new PageListBySql<SaleOrderPre7ShelfArea>(1, 1000);
            IDictionary<string, object> dicParam = new Dictionary<string, object>();
            dicParam.Add("OrderId", RequestDto.OrderId);
            dicParam.Add("ShelfAreaID", RequestDto.ShelfAreaID);
            PageListBySql<SaleOrderPre7ShelfArea> modelPage = SaleOrderPreBLO.GetPageAtPickList(pager, dicParam, Utils.StrToInt(RequestDto.WID, 0));
            //判断是否存在该数据，存在则表示正在拣货
            if (modelPage != null && modelPage.ItemList.Count > 0)
            {
                SaleOrderPreWaitPickingList model = SaleOrderPreBLO.GetWaitPickDetails(RequestDto.OrderId, RequestDto.WID, Utils.StrToInt(RequestDto.ShelfAreaID, 0));

                if (model != null && model.ProductData != null)
                {
                    if (model.Status == (int)OrderStatus.Picking)//拣货状态
                    {
                        SaleOrderPre sop = SaleOrderPreShelfAreaBLO.StartPick(RequestDto.OrderId, RequestDto.WID, RequestDto.ShelfAreaID, RequestDto.UserId, RequestDto.UserName, model.StationNumber.ToString(), false);
                        if (sop != null)
                        {
                            model.IsPicked = 1;
                            return SuccessActionResult(model);
                        }
                        else
                        {
                            return ErrorActionResult("该货区商品开始拣货失败");
                        }
                    }
                    else
                    {
                        model.IsPicked = 0;
                        return SuccessActionResult(model);
                    }
                }
                else
                {
                    return ErrorActionResult("未找到相关订单信息");
                }
            }
            return ErrorActionResult("当前订单该货区已拣货完成");
        }
    }
}
