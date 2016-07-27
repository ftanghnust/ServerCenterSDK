/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/31 14:23:03
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using System.ComponentModel.DataAnnotations;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 仓库商品限购主表 列表查询
    /// </summary>
    [ActionName("WProduct.NoSale.List.Get")]
    public class WProductNoSaleListGetAction : ActionBase<WProductNoSaleListGetAction.WProductNoSaleListGetRequestDto, ActionResultPagerData<Model.WProductNoSale>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductNoSaleListGetRequestDto : PageListRequestDto //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 仓库ID 必填
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空!")]
            public int? WID { get; set; }

            /// <summary>
            /// 单据号 主键ID(WID + GUID)
            /// </summary>            
            public string NoSaleID { get; set; }

            /// <summary>
            /// 商品名称
            /// </summary>
            public string ProductName { get; set; }
            /// <summary>
            /// 活动主题
            /// </summary>           
            public string PromotionName { get; set; }

            /// <summary>
            /// 商品条码
            /// </summary>
            public string BarCode { get; set; }

            /// <summary>
            /// ERP编码
            /// </summary>
            public string SKU { get; set; }

            /// <summary>
            /// 单据状态  状态(0:未提交;1:已提交;2:(立即生效)已过帐/已开始;3:已停用)
            /// </summary>
            public int? Status { get; set; }

            /// <summary>
            /// 生效时间 开始时间点(yyyy-MM-dd HH:mm:ss)
            /// </summary>          
            public DateTime? BeginTimeFrom { get; set; }


            /// <summary>
            /// 生效时间 截至时间点(yyyy-MM-dd HH:mm:ss)
            /// </summary>          
            public DateTime? BeginTimeEnd { get; set; }
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
        public class WProductNoSaleListGetResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<Model.WProductNoSale>> Execute()
        {
            if (!RequestDto.WID.HasValue || RequestDto.WID.Value <= 0)
            {
                return ErrorActionResult("上传参数不正确! 请检查仓库ID。");
            }
            var requestDto = this.RequestDto;
            PageListBySql<Model.WProductNoSale> page = new PageListBySql<Model.WProductNoSale>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<Model.WProductNoSale> models = WProductNoSaleBLO.GetPageList(page, requestDtoDict);

            return this.SuccessActionResult(new ActionResultPagerData<Model.WProductNoSale>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }

    }
}
