/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/15 20:23:40
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Order.BLL;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Stock
{
    /// <summary>
    /// 盘点调整明细表 列表获取接口
    /// 根据一个确定的盘点调整单号AdjID分页检索出盘点调整详情单列表
    /// 列表包含了StockAdjDetail和StockAdjDetailsExt两张表的信息
    /// </summary>
    [ActionName("StockAdjDetail.List.Get")]
    public class StockAdjDetailListGetAction : ActionBase<StockAdjDetailListGetAction.StockAdjDetailListGetActionRequestDto, ActionResultPagerData<Model.StockAdjDetail>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockAdjDetailListGetActionRequestDto : PageListRequestDto //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 对商品编号、商品名称、商品编码的检索关键字 允许不传值
            /// </summary>
            public string SearchValue { get; set; }
            /// <summary>
            /// 仓库ID 根据该ID决定连接哪个数据库
            /// </summary>
            public int WID { get; set; }
            /// <summary>
            /// 调整ID(WID+ ID服务)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string AdjID { get; set; }
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
        public class StockAdjDetailListGetActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<Model.StockAdjDetail>> Execute()
        {
            var requestDto = this.RequestDto;
            if (requestDto == null || requestDto.WID <= 0)
            {
                return this.ErrorActionResult("上传的参数不正确,请检查WID。");
            }
            PageListBySql<Model.StockAdjDetail> page = new PageListBySql<Model.StockAdjDetail>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false, false);//若检索关键字为空，则不加入参数到字典
            PageListBySql<Model.StockAdjDetail> models = StockAdjDetailBLO.GetPageList(page, requestDtoDict, requestDto.WID.ToString());

            return this.SuccessActionResult(new ActionResultPagerData<Model.StockAdjDetail>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }

    }
}
