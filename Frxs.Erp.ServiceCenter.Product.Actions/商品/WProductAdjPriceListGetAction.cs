/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/29 16:19:24
 * *******************************************************/
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Platform.IOCFactory;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 仓库商品价格调整单列表查询
    /// </summary>
    [ActionName("WProduct.AdjustPrice.List.Get")]
    public class WProductAdjPriceListGetAction : ActionBase<WProductAdjPriceListGetAction.WProductAdjPriceListGetActionRequestDto, ActionResultPagerData<Model.WProductAdjPrice>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductAdjPriceListGetActionRequestDto : PageListRequestDto
        {
            /// <summary>
            /// 仓库编号（必填）
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 调价单类型（必填）,调整类型( 0:采购(进货)价; 1:配送(批发)价; 3:费率及积分)
            /// </summary>
            public int AdjType { get; set; }

            /// <summary>
            /// 调整单单号
            /// </summary>
            public int? AdjID { get; set; }

            /// <summary>
            /// 商品名称
            /// </summary>
            [StringLength(50)]
            public string ProductName { get; set; }

            /// <summary>
            /// 商品（以前叫ERP编码）
            /// </summary>
            [StringLength(50)]
            public string SKU { get; set; }

            /// <summary>
            /// 商品条形码
            /// </summary>
            [StringLength(50)]
            public string BarCode { get; set; }

            /// <summary>
            /// 状态(0:未提交;1:已确认;2:已过帐;)
            /// </summary>
            public int? Status { get; set; }

            /// <summary>
            /// 创建时间检索区间开始
            /// </summary>
            public DateTime? CreateTime1 { get; set; }

            /// <summary>
            /// 创建时间检索区间结束
            /// </summary>
            public DateTime? CreateTime2 { get; set; }

            /// <summary>
            /// 确认时间检索区间开始
            /// </summary>
            public DateTime? ConfTime1 { get; set; }

            /// <summary>
            /// 确认时间检索区间结束
            /// </summary>
            public DateTime? ConfTime2 { get; set; }

            /// <summary>
            /// 过账时间检索区间开始
            /// </summary>
            public DateTime? PostingTime1 { get; set; }
            /// <summary>
            /// 过账时间检索区间结束
            /// </summary>
            public DateTime? PostingTime2 { get; set; }

            /// <summary>
            /// 生效时间检索区间开始
            /// </summary>
            public DateTime? BeginTime1 { get; set; }
            /// <summary>
            /// 生效时间检索区间结束
            /// </summary>
            public DateTime? BeginTime2 { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<Model.WProductAdjPrice>> Execute()
        {
            var srver = DALFactory.GetLazyInstance<IWProductAdjPriceQueryDAO>();
            srver.PageIndex = this.RequestDto.PageIndex;
            srver.PageSize = this.RequestDto.PageSize;
            srver.SearchParams = new Model.WProductAdjPriceQuerySearchParams()
            {
                WID = this.RequestDto.WID,
                AdjType = this.RequestDto.AdjType,
                AdjID = this.RequestDto.AdjID,
                BarCode = this.RequestDto.BarCode,
                Status = this.RequestDto.Status,
                SKU = this.RequestDto.SKU,
                ProductName = this.RequestDto.ProductName,
                BeginTime1 = this.RequestDto.BeginTime1,
                BeginTime2 = this.RequestDto.BeginTime2,
                ConfTime1 = this.RequestDto.ConfTime1,
                ConfTime2 = this.RequestDto.ConfTime2,
                CreateTime1 = this.RequestDto.CreateTime1,
                CreateTime2 = this.RequestDto.CreateTime2,
                PostingTime1 = this.RequestDto.PostingTime1,
                PostingTime2 = this.RequestDto.PostingTime2
            };

            var model = new ActionResultPagerData<Model.WProductAdjPrice>()
            {
                TotalRecords = srver.GetCount(),
                ItemList = srver.GetList().ToList()
            };

            //返回数据
            return this.SuccessActionResult(model);
        }
    }
}
