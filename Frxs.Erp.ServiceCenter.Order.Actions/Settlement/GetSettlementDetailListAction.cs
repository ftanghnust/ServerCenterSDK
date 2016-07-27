/*********************************************************
 * FRXS 小马哥 2016/6/24 11:48:35
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Platform.Utility;
using Frxs.Platform.Utility.Pager;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Settlement
{
    /// <summary>
    /// 货区结算单详细情况
    /// </summary>
    [ActionName("GetSettlementDetailList")]
    public class GetSettlementDetailListAction : ActionBase<Frxs.Erp.ServiceCenter.Order.Actions.Settlement.GetSettlementDetailListAction.GetSettlementDetailListActionRequestDto, Frxs.Erp.ServiceCenter.Order.Actions.Settlement.GetSettlementDetailListAction.GetSettlementDetailListActionResponseDto>
    {
        /// <summary>
        /// 执行接口传入参数
        /// </summary>
        public class GetSettlementDetailListActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 页索引
            /// </summary>
            public int? PageIndex { get; set; }

            /// <summary>
            /// 页尺寸
            /// </summary>
            public int? PageSize { get; set; }

            /// <summary>
            /// 主表编号
            /// </summary>
            [Required]
            public string RefSet_ID { get; set; }

            /// <summary>
            /// 商品编码
            /// </summary>
            public string SKU { get; set; }

            /// <summary>
            /// 商品名称
            /// </summary>
            public string ProductName { get; set; }

            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required]
            public string WID { get; set; }
        }

        /// <summary>
        /// 接口数据输出
        /// </summary>
        public class GetSettlementDetailListActionResponseDto : ResponseDtoBase
        {
            /// <summary>
            /// 总条数
            /// </summary>
            public int PageCount { get; set; }

            /// <summary>
            /// 总页数
            /// </summary>
            public int PageTotal { get; set; }

            /// <summary>
            /// 结算单详细集合
            /// </summary>
            public IList<SettlementDetail> SettDetail { get; set; }
            /// <summary>
            /// 结算单分页当前页集合
            /// </summary>
            public CurrentSum SettCurrentSum { get; set; }
            /// <summary>
            /// 结算单总合计
            /// </summary>
            public TotalSum SettTotalSum { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<GetSettlementDetailListActionResponseDto> Execute()
        {
            int pIndex = RequestDto.PageIndex == null ? 1 : Utils.StrToInt(RequestDto.PageIndex, 0);
            int pSize = RequestDto.PageSize == null ? 10 : Utils.StrToInt(RequestDto.PageSize, 0);
            PageListBySql<SettlementDetail> page = new PageListBySql<SettlementDetail>(pIndex, pSize);
            IDictionary<string, object> dicParam = RequestDto.GetAttributes(false);
            page.OrderFields = "SKU";
            SettlementDetailsList model = SettlementDetailBLO.GetDetailsPageList(page, dicParam, RequestDto.WID);
            GetSettlementDetailListActionResponseDto respDto = new GetSettlementDetailListActionResponseDto();
            respDto.PageCount = model.PageCount;
            respDto.PageTotal = model.PageTotal;
            respDto.SettDetail = model.SettDetail;
            respDto.SettCurrentSum = model.SettCurrentSum;
            respDto.SettTotalSum = model.SettTotalSum;
            return SuccessActionResult(respDto);
        }
    }
}
