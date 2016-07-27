/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/15 10:43:55
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Order.BLL;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Stock
{
    /// <summary>
    /// 盘点调整主表(盘亏盘盈表) 列表查询
    /// </summary>
    [ActionName("StockAdj.List.Get")]
    public class StockAdjListGetAction : ActionBase<StockAdjListGetAction.StockAdjListGetActionRequestDto, ActionResultPagerData<Model.StockAdj>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockAdjListGetActionRequestDto : PageListRequestDto//(分页列表继承基类)
        {
            /// <summary>
            /// 仓库ID 根据该ID决定连接哪个数据库
            /// </summary>
            public int WID { get; set; }
            /// <summary>
            /// 单号
            /// </summary>
            public string AdjID { get; set; }

            /// <summary>
            /// 调整类型(0:调增库存;1:调减库存)
            /// </summary>
            public int AdjType { get; set; }
            /// <summary>
            /// 商品名称
            /// </summary>
            public string ProductName { get; set; }

            /// <summary>
            /// 商品编码
            /// </summary>
            public string SKU { get; set; }

            /// <summary>
            /// 单据状态(0:未提交;1:已提交;2:已过帐;3:作废) 0>1 1->2 1>0; 1>3; 0 删除时物理删除)
            /// </summary>
            public int? Status { get; set; }

            /// <summary>
            /// 仓库子机构ID
            /// </summary>
            public int? SubWID { get; set; }

            /// <summary>
            /// 开单日期 起始时间点
            /// </summary>
            public DateTime? AdjDateBegin { get; set; }

            /// <summary>
            /// 开单日期 截止时间点
            /// </summary>
            public DateTime? AdjDateEnd { get; set; }

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
        /// 下送的数据
        /// </summary>
        public class StockAdjListGetActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<StockAdj>> Execute()
        {
            var requestDto = this.RequestDto;
            if (requestDto == null || requestDto.WID <= 0)
            {
                return this.ErrorActionResult("上传的参数不正确");
            }
            PageListBySql<Model.StockAdj> page = new PageListBySql<Model.StockAdj>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<Model.StockAdj> models = StockAdjBLO.GetPageList(page, requestDtoDict, requestDto.WID.ToString());

            return this.SuccessActionResult(new ActionResultPagerData<Model.StockAdj>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }
    }
}
