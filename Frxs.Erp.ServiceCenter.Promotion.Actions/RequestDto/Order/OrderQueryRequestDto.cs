﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto
{
    public class OrderQueryRequestDto : RequestDtoParent
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
        /// 门店Code
        /// </summary>
        public string ShopCode { get; set; }

        /// <summary>
        /// 门店类型
        /// </summary>
        public int? ShopType { get; set; }

        /// <summary>
        /// 预计送达时间开始
        /// </summary>
        public DateTime? SendDateBegin { get; set; }

        /// <summary>
        /// 预计送达时间结束
        /// </summary>
        public DateTime? SendDateEnd { get; set; }

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
