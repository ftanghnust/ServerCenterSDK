/*****************************
* Author:罗涛
*
* Date:2016/6/14 9:21:38
******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// SaleSettle.AddOrEdit
    /// </summary>
    public class ReportGetRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 仓库编号
        /// </summary>
        [Required]
        public int WID { get; set; }

        /// <summary>
        /// 存储过程名称
        /// </summary>
        [Required]
        public string Procedure_Name { get; set; }


        /// <summary>
        /// 参数，按照s1，s2...sn添加
        /// </summary>
        public IList<parameter> parameters { get; set; }


        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }
    }

    public class parameter
    {
        public string key { get; set; }

        public string value { get; set; }
    }
}
