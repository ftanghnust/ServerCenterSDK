/*********************************************************
 * FRXS 小马哥 2016/4/9 9:54:11
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model.Order;
using Frxs.Platform.Utility;
using Frxs.Platform.Utility.Pager;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 拣货接口-正在拣货订单列表-分页
    /// </summary>
    [ActionName("GetAtPickingOrderList")]
    public class GetAtPickingOrderListAction : ActionBase<GetAtPickingOrderListAction.GetAtPickingOrderListActionRequestDto, GetAtPickingOrderListAction.GetAtPickingOrderListActionResponseDto>
    {
        /// <summary>
        /// 接口调用传入参数
        /// </summary>
        public class GetAtPickingOrderListActionRequestDto : RequestDtoBase
        {
            #region 查询参数
            /// <summary>
            /// 订单编号
            /// </summary>
            public string OrderId { get; set; }

            /// <summary>
            /// 货区编号
            /// </summary>
            [Required]
            public int? ShelfAreaID { get; set; }

            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required]
            public string WID { get; set; }

            /// <summary>
            /// 门店编号
            /// </summary>
            public string ShopCode { get; set; }
            #endregion
            #region 分页参数
            /// <summary>
            /// 页索引
            /// </summary>
            public int? PageIndex { get; set; }

            /// <summary>
            /// 页尺寸
            /// </summary>
            public int? PageSize { get; set; }

            #endregion
        }

        /// <summary>
        /// 接口调用输出
        /// </summary>
        public class GetAtPickingOrderListActionResponseDto : ResponseDtoBase
        {
            /// <summary>
            /// 总记录数
            /// </summary>
            public int TotalCount { get; set; }

            /// <summary>
            /// 数据
            /// </summary>
            public List<SaleOrderPre7ShelfArea> ListData { get; set; }
        }

        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<GetAtPickingOrderListActionResponseDto> Execute()
        {
            GetAtPickingOrderListActionRequestDto atPickListReq = RequestDto;
            int pi = Utils.StrToInt(RequestDto.PageIndex, 1);
            int ps = Utils.StrToInt(RequestDto.PageSize, 1000);
            int intWID = Utils.StrToInt(RequestDto.WID, 0);
            PageListBySql<SaleOrderPre7ShelfArea> pager = new PageListBySql<SaleOrderPre7ShelfArea>(pi, ps);
            pager.OrderFields = RequestDto.OrderId;
            IDictionary<string, object> dic = new Dictionary<string, object>();
            var requestDtoDic = RequestDto.GetAttributes(false);
            PageListBySql<SaleOrderPre7ShelfArea> models = SaleOrderPreBLO.GetPageAtPickList(pager, requestDtoDic, intWID);
            GetAtPickingOrderListActionResponseDto respDto = new GetAtPickingOrderListActionResponseDto();
            respDto.TotalCount = models.TotalRecords;
            respDto.ListData = models.ItemList.ToList();
            return SuccessActionResult(respDto);
        }
    }
}
