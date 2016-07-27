using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    /// <summary>
    /// 简单的代客订单基础访问模型
    /// </summary>
    public class SaleOrderPreBaseRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 订单时间-开始范围
        /// </summary>
        public DateTime? OrderDateBegin { get; set; }

        /// <summary>
        /// 订单时间-结束范围
        /// </summary>
        public DateTime? OrderDateEnd { get; set; }

        /// <summary>
        /// 结算单编号
        /// </summary>
        public string SettleID { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        public int? ShopId { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public int? WID { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 订单路线
        /// </summary>
        public int? LineID { get; set; }

        /// <summary>
        /// 订单路线名称
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// 门店Code
        /// </summary>
        public string ShopCode { get; set; }

        /// <summary>
        /// 门店类型
        /// </summary>
        public int? ShopType { get; set; }

        /// <summary>
        /// 确认时间开始
        /// </summary>
        public DateTime? ConfDateBegin { get; set; }

        /// <summary>
        /// 确认时间结束
        /// </summary>
        public DateTime? ConfDateEnd { get; set; }

        /// <summary>
        /// 配送时间开始
        /// </summary>
        public DateTime? ShippingBeginDateBegin { get; set; }

        /// <summary>
        /// 配送时间结束
        /// </summary>
        public DateTime? ShippingBeginDateEnd { get; set; }

        /// <summary>
        /// 预计送达时间开始
        /// </summary>
        public DateTime? SendDateBegin { get; set; }

        /// <summary>
        /// 预计送达时间结束
        /// </summary>
        public DateTime? SendDateEnd { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public int? OrderType { get; set; }

        /// <summary>
        /// 待装区编号
        /// </summary>
        public int? StationNumber { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortBy { get; set; }


        /// <summary>
        /// 子仓库ID
        /// </summary>
        public int? SubID { get; set; }


        /// <summary>
        /// 是否打印
        /// </summary>
        public int? IsPrinted { get; set; }

        /// <summary>
        /// 需要过滤掉的状态
        /// </summary>
        public IList<int> FilterStatus { get; set; }

        /// <summary>
        /// 商品编吗
        /// </summary>
        public string SKU { get; set; }


        /// <summary>
        /// 先整理下当前页码和页容量
        /// </summary>
        public override void BeforeValid()
        {
            if (this.PageIndex <= 0) this.PageIndex = 1;
            if (this.PageSize <= 0) this.PageSize = 10;
        }

        /// <summary>
        /// 校验下参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            if (this.PageIndex <= 0)
            {
                yield return new RequestDtoValidatorResultError("PageIndex", "参数错误");
            }
            if (this.PageSize <= 0)
            {
                yield return new RequestDtoValidatorResultError("PageSize", "参数错误");
            }
        }
    }
}
