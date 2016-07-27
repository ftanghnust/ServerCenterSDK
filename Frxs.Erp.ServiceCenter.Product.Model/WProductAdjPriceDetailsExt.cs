
/*****************************
* Author:CR
*
* Date:2016-03-25
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class WProductAdjPriceDetailsExt : WProductAdjPriceDetails
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal? PackingQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string BarCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string SKU { get; set; }

    }
}