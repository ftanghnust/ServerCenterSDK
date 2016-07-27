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
    /// SaleBackPre.GetModel
    /// </summary>
    public class SaleBackPreGetModelActionResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 销售退货单
        /// </summary>
        public Frxs.Erp.ServiceCenter.Order.Model.SaleBackPre order { get; set; }

        /// <summary>
        /// 销售退货单详情集合
        /// </summary>
        public IList<Frxs.Erp.ServiceCenter.Order.Model.SaleBackPreDetails> orderdetails { get; set; }

        /// <summary>
        /// 销售退货单详情扩展集合
        /// </summary>
        public IList<Frxs.Erp.ServiceCenter.Order.Model.SaleBackPreDetailsExt> orderdetailsext { get; set; }
    }

}
