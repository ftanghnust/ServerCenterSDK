using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto
{
    /// <summary>
    /// FeeSale.GetModel
    /// </summary>
    public class SaleSettleGetModelActionResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 结算主表
        /// </summary>
        public Frxs.Erp.ServiceCenter.Order.Model.SaleSettle SaleSettle { get; set; }     

        /// <summary>
        /// 结算明细
        /// </summary>
        public IList<Frxs.Erp.ServiceCenter.Order.Model.SaleSettleDetail> SaleSettleDetailList { get; set; }

        ///// <summary>
        ///// 销售退货单
        ///// </summary>
        //public IList<Frxs.Erp.ServiceCenter.Order.Model.SaleBackPre> BackOrder { get; set; }

        /// <summary>
        /// 销售退货单详情集合
        /// </summary>
        public IList<Frxs.Erp.ServiceCenter.Order.Model.SaleBackPreDetails> BackOrderDetails { get; set; }
    }


    /// <summary>
    /// SaleSettle.GetList
    /// </summary>
    public class SaleSettleGetListActionResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// 输出的集合数据，此处对象必须为一个集合类型的对象，比如：数组,列表
        /// </summary>
        public List<Frxs.Erp.ServiceCenter.Order.Model.SaleSettle> ItemList { get; set; }

        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal SubAmt { get; set; }
    }
}
