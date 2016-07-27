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

namespace Frxs.Erp.ServiceCenter.ID.Actions.RequestDto
{
    /// <summary>
    /// Ids.Get
    /// </summary>
    public class IdsGetRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        [Required]
        public int WID { get; set; }

        /// <summary>
        /// 请求的ID类型；空的数据类型为
        /// </summary>
        [Required]
        public IDTypes Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            if (WID <= 0)
            {
                yield return new RequestDtoValidatorResultError("WID");
            }
        }
    }
}
