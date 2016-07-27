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
    /// 商品多单位表ProductsUnit实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class ProductsUnit : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        [DisplayName("主键ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ProductsUnitID { get; set; }

        /// <summary>
        /// 即为：Product.ProductID
        /// </summary>
        [DataMember]
        [DisplayName("即为：Product.ProductID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ProductID { get; set; }

        /// <summary>
        /// 单位(同一个商品单位不能重复)
        /// </summary>
        [DataMember]
        [DisplayName("单位(同一个商品单位不能重复)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Unit { get; set; }

        /// <summary>
        /// 包装数
        /// </summary>
        [DataMember]
        [DisplayName("包装数")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal PackingQty { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [DataMember]
        [DisplayName("规格")]

        public string Spec { get; set; }

        /// <summary>
        /// 是否为库存单位(0:不是;1:是;只有一条)
        /// </summary>
        [DataMember]
        [DisplayName("是否为库存单位(0:不是;1:是;只有一条)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsUnit { get; set; }

        /// <summary>
        /// 是否为配送单位(0:不是;1:是)
        /// </summary>
        [DataMember]
        [DisplayName("是否为配送单位(0:不是;1:是)")]

        public int IsSaleUnit { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [DataMember]
        [DisplayName("创建用户ID")]

        public int ModifyUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]

        public string ModifyUserName { get; set; }

        #endregion
    }
}