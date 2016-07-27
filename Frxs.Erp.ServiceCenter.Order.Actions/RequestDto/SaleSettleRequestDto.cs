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
using Frxs.Erp.ServiceCenter.Order.Model;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    /// <summary>
    /// SaleSettle.AddOrEdit
    /// </summary>
    public class SaleSettleAddOrEditActionRequestDto : RequestDtoBase
    {

        /// <summary>
        /// 仓库编号
        /// </summary>
        [Required]
        public int WID { get; set; }

        /// <summary>
        /// 装箱表
        /// </summary>
        public SaleOrderPrePacking packingmodel { set; get; }
         
        /// <summary>
        /// 结算单
        /// </summary>
        
        public SaleSettle order { get; set; }

        /// <summary>
        /// 装箱员ID
        /// </summary>
        public int? PackingEmpID { get; set; }

        /// <summary>
        /// 装箱员姓名
        /// </summary>
        public string PackingEmpName { get; set; }

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
    /// SaleSettle.Add
    /// </summary>
    public class SaleSettleAddOrEditRequestDto : RequestDtoBase
    {

        /// <summary>
        /// 仓库编号
        /// </summary>
        [Required]
        public int WID { get; set; }

        /// <summary>
        /// 结算单
        /// </summary>
        public SaleSettle Salesettle { get; set; }

        /// <summary>
        /// 结算单明细
        /// </summary>
        public IList<SaleSettleDetail> Details { get; set; }

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
    /// SaleSettle.Del
    /// </summary>
    public class SaleSettleDelRequestDto : RequestDtoBase
    {

        /// <summary>
        /// 仓库编号
        /// </summary>
        [Required]
        public int WID { get; set; }

        /// <summary>
        /// 结算单
        /// </summary>
        public string SettleID { get; set; }      

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
    /// SaleSettle.Del
    /// </summary>
    public class SaleSettlePostRequestDto : RequestDtoBase
    {

        /// <summary>
        /// 仓库编号
        /// </summary>
        [Required]
        public int WID { get; set; }

        /// <summary>
        /// 结算单
        /// </summary>
        public string SettleID { get; set; }

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
    /// SaleSettle.Del
    /// </summary>
    public class SaleSettleSureOrNoRequestDto : RequestDtoBase
    {

        /// <summary>
        /// 仓库编号
        /// </summary>
        [Required]
        public int WID { get; set; }

        /// <summary>
        /// 结算单
        /// </summary>
        public string SettleID { get; set; }

        /// <summary>
        /// True:确认,False:反确认
        /// </summary>
        public bool Sure { get; set; }

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
