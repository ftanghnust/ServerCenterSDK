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

namespace Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto
{
    /// <summary>
    /// FeeSale.GetModel
    /// </summary>
    public class SaleFeeGetModelActionResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 门店消息 
        /// </summary>
        public Frxs.Erp.ServiceCenter.Order.Model.SaleFee saleFee { get; set; }

        /// <summary>
        /// 门店消息明细
        /// </summary>
        public Frxs.Erp.ServiceCenter.Order.Model.SaleFeeDetails saleFeeDetails { get; set; }

        /// <summary>
        /// 门店消息(待处理)
        /// </summary>
        public Frxs.Erp.ServiceCenter.Order.Model.SaleFeePre saleFeePre { get; set; }
        
        /// <summary>
        /// 门店消息明细（待处理明细）
        /// </summary>
        public Frxs.Erp.ServiceCenter.Order.Model.SaleFeePreDetails saleFeePreDetails { get; set; }

        /// <summary>
        /// 门店消息明细（待处理明细）
        /// </summary>
        public IList<Frxs.Erp.ServiceCenter.Order.Model.SaleFeeDetails> saleFeePreDetailsList { get; set; }

  
    }


    /// <summary>
    /// SaleFee.GetList
    /// </summary>
    public class SaleFeeGetListActionResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// 输出的集合数据，此处对象必须为一个集合类型的对象，比如：数组,列表
        /// </summary>
        public List<Frxs.Erp.ServiceCenter.Order.Model.SaleFee> ItemList { get; set; }

        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal SubAmt { get; set; }
    }

}
