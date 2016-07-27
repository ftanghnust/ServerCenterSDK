using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Platform.Utility.Pager;
using System.Data;
using Frxs.Erp.ServiceCenter.Order.Actions.RequestDto;
using Frxs.Platform.Utility.Json;

namespace Frxs.Erp.ServiceCenter.Order.Actions.报表
{
    /// <summary>
    /// 获取同步报表数据
    /// </summary>
    public class SyncReportGetAction : ActionBase<SyncReportGetAction.SyncReportGetRequestDto, string>
    {
        /// <summary>
        /// SyncReport.SyncReportGet
        /// </summary>
        public class SyncReportGetRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required]
            public int WID { get; set; }

            /// <summary>
            /// 查询日期
            /// </summary>
            [Required]
            public string SarteTime { get; set; }

            /// <summary>
            /// 查询结束日期
            /// </summary>
            [Required]
            public string EndTime { get; set; }

            /// <summary>
            /// 是否出库(0：采购入库、销售出库，1：采购退库、销售退库)
            /// </summary>
            [Required]
            public int fale { get; set; }

            /// <summary>
            /// 表名：（true：销售，false：采购）
            /// </summary>
            [Required]
            public bool SyncTableName { get; set; }

            /// <summary>
            /// 校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }
        }


        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<string> Execute()
        {
            var requestDto = this.RequestDto;

            DataTable dt = SyncReportBLO.GetSyncReport(requestDto.WID, requestDto.SarteTime, requestDto.EndTime, requestDto.fale, requestDto.SyncTableName);

            return new ActionResult<string>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = dt.ToJson()
            };
        }
    }
}
