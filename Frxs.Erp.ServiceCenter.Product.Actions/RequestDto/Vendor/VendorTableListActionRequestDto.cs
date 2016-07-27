using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto.Vendor
{
    public class VendorTableListActionRequestDto : PageListRequestDto
    {

        #region 模型

        /// <summary>
        /// 供应商编号
        /// </summary>
        [DisplayName("编号")]
        public string VendorCode { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [DisplayName("名称")]
        public string VendorName { get; set; }

        /// <summary>
        /// 供应商简称
        /// </summary>
        [DisplayName("简称")]
        public string VendorShortName { get; set; }

        /// <summary>
        /// 供应商类型(VendorType.VendorTypeID)
        /// </summary>
        [DisplayName("类型")]
        public string VendorTypeID { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        [DisplayName("联系人")]
        public string LinkMan { get; set; }


        /// <summary>
        /// 状态(1:正常;0:冻结)
        /// </summary>
        [DisplayName("状态")]
        public int? Status { get; set; }

        /// <summary>
        /// 行政区域
        /// </summary>
        [DisplayName("行政区域")]
        public string Region { get; set; }

        /// <summary>
        /// 结算方式( 数据字典: VendorSettleTimeType)
        /// </summary>
        [DisplayName("结算方式")]
        public string SettleTimeType { get; set; }

        /// <summary>
        /// 供应商级别(数据字典: VendorLevel; A:A级;B:B级;C:C级)
        /// </summary>
        [DisplayName("供应商级别")]
        public string CreditLevel { get; set; }

        /// <summary>
        /// 仓库编号(指定了仓库编号的，只查询对应的仓库供应商)
        /// </summary>
        [DisplayName("仓库编号")]
        public int? WID { get; set; }

        /// <summary>
        /// 账期
        /// </summary>
        [DisplayName("账期")]
        public string PaymentDateType { get; set; }
        #endregion

    }
}
