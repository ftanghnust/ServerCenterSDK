/*********************************************************
 * FRXS(ISC) ftanghnust@gmail.com 2016/3/11 9:28:42
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.ID.Model;

namespace Frxs.Erp.ServiceCenter.ID.Actions.ResponseDto
{
    public class XSOperatorLogGetMenuResponseDto : ResponseDtoBase
    {
        public IList<XSOperatorLogMenu> menus { get; set; }
    }
}
