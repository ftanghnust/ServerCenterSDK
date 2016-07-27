using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    /// <summary>
    /// 日结功能生成请求参数
    /// </summary>
    public class SettlementAddRequsetDto : RequestDtoBase
    {

        /// <summary>
        /// 仓库编号
        /// </summary>
        [Required]
        public int Wid { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string WCode { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WName { get; set; }

        /// <summary>
        /// 子仓库编号
        /// </summary>
        [Required]
        public int SubWid { get; set; }


        /// <summary>
        /// 子仓库编码
        /// </summary>
        public string SubWCode { get; set; }



        /// <summary>
        /// 子仓库名称
        /// </summary>
        public string SubWName { get; set; }


        /// <summary>
        /// 0表示自动执行,1表示手动执行
        /// </summary>
        public int Status { get; set; }


        /// <summary>
        /// 日结日期
        /// </summary>
        public string SettleDate { get; set; }


        public override void BeforeValid()
        {
            base.BeforeValid();
        }


        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }
    }


    /// <summary>
    ///日结功能重新生成前删除请求参数
    /// </summary>
    public class SettlementDelRequestDto : RequestDtoBase
    {

        /// <summary>
        /// 仓库编号
        /// </summary>
        [Required]
        public int Wid { get; set; }


        /// <summary>
        /// 子仓库编号
        /// </summary>
        [Required]
        public int SubWid { get; set; }


        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime SettleDate { get; set; }


        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }
    }
}
