
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Platform.Utility.Pager;
/*****************************
* Author:TangFan
*
* Date:2016-03-11
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// BuyOrderPageModel实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class BuyOrderPageModel : BaseModel
    {

        /// <summary>
        /// 合计金额
        /// </summary>
        [DataMember]
        [DisplayName("合计金额")]
        public decimal SubAmt { get; set; }

        /// <summary>
        /// 分页数据
        /// </summary>
        [DataMember]
        [DisplayName("分页数据")]
        public PageListBySql<BuyOrderPre> pageModel { get; set; }

    }
}