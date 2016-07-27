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
    public class WarehouseMessageShopsGetModelActionResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 消息门店组
        /// </summary>
        public Frxs.Erp.ServiceCenter.Promotion.Model.WarehouseMessageShops order { get; set; }

   
    }

}
