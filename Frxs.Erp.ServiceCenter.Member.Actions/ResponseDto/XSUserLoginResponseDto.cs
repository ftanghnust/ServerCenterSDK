using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;

namespace Frxs.Erp.ServiceCenter.Member.Actions.ResponseDto
{
    public class XSUserLoginResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 用户表
        /// </summary>
        public Frxs.Erp.ServiceCenter.Member.Model.XSUser model { get; set; }

        /// <summary>
        /// 门店集合
        /// </summary>
        public IList<Frxs.Erp.ServiceCenter.Member.Model.XSUserShop> shops { get; set; }
    }
}
