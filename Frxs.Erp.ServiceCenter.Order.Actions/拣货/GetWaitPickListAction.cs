/*********************************************************
 * FRXS 小马哥 2016/4/11 8:58:56
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.Model.Order;
using Frxs.Platform.Utility;
using Frxs.Platform.Utility.Pager;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 拣货接口-待拣货订单列表-分页
    /// </summary>
    [ActionName("GetWaitPickList")]
    public class GetWaitPickListAction : ActionBase<GetWaitPickListAction.GetWaitPickListActionRequestDto, GetWaitPickListAction.GetWaitPickListActionResponseDto>
    {
        /// <summary>
        /// 接口调用传入参数
        /// </summary>
        public class GetWaitPickListActionRequestDto : RequestDtoBase
        {
            #region 查询参数
            /// <summary>
            /// 仓库ID
            /// </summary>
            [Required]
            public string WID { get; set; }

            /// <summary>
            /// 货区编号
            /// </summary>
            [Required]
            public int? ShelfAreaID { get; set; }

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
        public class GetWaitPickListActionResponseDto : ResponseDtoBase
        {
            /// <summary>
            /// 数据总条数
            /// </summary>
            public int TotalCount { get; set; }

            /// <summary>
            /// 等待拣货订单商品列表
            /// </summary>
            public List<SaleOrderPreWaitPickingList> WaitPickData { get; set; }
        }

        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<GetWaitPickListActionResponseDto> Execute()
        {
            GetWaitPickListActionRequestDto reqDto = RequestDto;
            int pi = Utils.StrToInt(RequestDto.PageIndex, 1);
            int ps = Utils.StrToInt(RequestDto.PageSize, 1000);
            int intWID = Utils.StrToInt(RequestDto.WID, 0);
            PageListBySql<SaleOrderPreWaitPickingList> pager = new PageListBySql<SaleOrderPreWaitPickingList>(pi, ps);
            pager.OrderFields = "lineSerialNumber,ShopSerialNumber";
            IDictionary<string, object> dic = new Dictionary<string, object>();
            var requestDtoDic = RequestDto.GetAttributes(false);
            PageListBySql<SaleOrderPreWaitPickingList> models = SaleOrderPreBLO.GetPageWaitPickList(pager, requestDtoDic, intWID);
            GetWaitPickListActionResponseDto respDto = new GetWaitPickListActionResponseDto();
            respDto.TotalCount = models.TotalRecords;
            respDto.WaitPickData = models.ItemList.ToList();
            return SuccessActionResult(respDto);
        }
    }
}
