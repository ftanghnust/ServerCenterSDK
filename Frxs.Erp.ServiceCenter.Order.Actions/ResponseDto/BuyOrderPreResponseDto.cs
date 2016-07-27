/*********************************************************
 * FRXS(ISC) ftanghnust@gmail.com 2016/3/10 15:44:25
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;

namespace Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto
{
    /// <summary>
    /// BuyOrderPre.GetModel
    /// </summary>
    public class BuyOrderPreGetModelActionResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 采购收货单
        /// </summary>
        public Frxs.Erp.ServiceCenter.Order.Model.BuyOrderPre order { get; set; }

        /// <summary>
        /// 采购收货单详情集合
        /// </summary>
        public IList<Frxs.Erp.ServiceCenter.Order.Model.BuyOrderPreDetails> orderdetails { get; set; }


        /// <summary>
        /// 采购收货单详情扩展集合
        /// </summary>
        public IList<Frxs.Erp.ServiceCenter.Order.Model.BuyOrderPreDetailsExt> orderdetailsext { get; set; }
    }


    /// <summary>
    /// BuyOrderPre.GetList
    /// </summary>
    public class BuyOrderPreGetListActionResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// 输出的集合数据，此处对象必须为一个集合类型的对象，比如：数组,列表
        /// </summary>
        public List<Frxs.Erp.ServiceCenter.Order.Model.BuyOrderPre> ItemList { get; set; }

        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal SubAmt { get; set; }
    }

}
