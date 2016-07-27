/*********************************************************
 * FRXS(ISC) chujl 2016/3/23  
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Order.BLL;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 补货，返配申请单 分页查询
    /// </summary>
    [ActionName("BuyPreApp.GetList")]
    public class BuyPreAppGetListAction : ActionBase<BuyPreAppGetListAction.BuyPreAppGetListActionRequestDto, ActionResultPagerData<BuyPreApp>>
    {

        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class BuyPreAppGetListActionRequestDto : PageListRequestDto
        {
            /// <summary>
            /// 仓库编号，必须填写
            /// </summary>
            [Required]
            public int WID { get; set; }

            /// <summary>
            /// 申请单
            /// </summary>
            public string AppID { get; set; }

            /// <summary>
            /// 申请类型(0:返配;1:补货)
            /// </summary>
            [Required]
            public int AppType { get; set; }

            /// <summary>
            /// Status
            /// </summary>
            public int? Status { get; set; }

            /// <summary>
            /// 所属子仓库ID
            /// </summary>
            public int? SubWID { get; set; }

            /// <summary>
            /// 开单时间
            /// </summary>
            public DateTime? AppDateStart { get; set; }

            /// <summary>
            /// 开单时间I
            /// </summary>
            public DateTime? AppDateEnd { get; set; }

            /// <summary>
            /// 对账时间
            /// </summary>
            public DateTime? PostingTimeStart { get; set; }

            /// <summary>
            /// 对账时间
            /// </summary>
            public DateTime? PostingTimeEnd { get; set; }



            /// <summary>
            /// 自定义校验上送参数是否正确
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
        public override ActionResult<ActionResultPagerData<BuyPreApp>> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<BuyPreApp> page = new PageListBySql<BuyPreApp>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<BuyPreApp> models = BuyPreAppBLO.GetPageList(requestDto.WID,page, requestDtoDict);

            return this.SuccessActionResult(new ActionResultPagerData<BuyPreApp>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }

    }
}
