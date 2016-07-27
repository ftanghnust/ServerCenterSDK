/*****************************
* Author:luojing
*
* Date:2016-03-09
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// SKU编号服务表ProductsSKUNumberService实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class ProductsSKUNumberService : BaseModel
    {
        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        [DisplayName("主键ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ID { get; set; }

        /// <summary>
        /// 取值状态固定0;
        /// </summary>
        [DataMember]
        [DisplayName("取值状态固定0;")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int States { get; set; }

        #endregion
    }
}