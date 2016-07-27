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

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.ResponseDto
{
    /// <summary>
    /// WarehouseMessage.GetModel
    /// </summary>
    public class WarehouseMessageGetModelActionResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 仓库消息
        /// </summary>
        public Frxs.Erp.ServiceCenter.Promotion.Model.WarehouseMessage order { get; set; }


        /// <summary>
        /// 采购收货单详情集合
        /// </summary>
        public IList<Frxs.Erp.ServiceCenter.Promotion.Model.WarehouseMessageShops> orderdetails { get; set; }
    }

}
