/*****************************
* Author:周进
*
* Date:2016-04-26
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Order.Model
{
    [Serializable]
    [DataContract]
    public class SaleOrderSendNumberLine : BaseModel
    {
        #region 模型
        public int LineID { get; set; }

        /// <summary>
        /// 线路顺序
        /// </summary>
        public int LineSerialNumber { get; set; }

        /// <summary>
        /// 线路编号
        /// </summary>
        public string LineCode { get; set; }

        /// <summary>
        /// 线路名称
        /// </summary>
        public string LineName { get; set; }
        #endregion
    }
}
