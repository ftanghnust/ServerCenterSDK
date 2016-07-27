
/*****************************
* Author:leidong
*
* Date:2016-04-06
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Promotion.Model
{
    /// <summary>
    /// 销售购物车表SaleCart实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SaleCart : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        [DisplayName("主键ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long ID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 下单门店ID
        /// </summary>
        [DataMember]
        [DisplayName("下单门店ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopID { get; set; }

        /// <summary>
        /// 下单门店人员ID
        /// </summary>
        [DataMember]
        [DisplayName("下单门店人员ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int XSUserID { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [DataMember]
        [DisplayName("商品ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ProductID { get; set; }

        /// <summary>
        /// 预订数量
        /// </summary>
        [DataMember]
        [DisplayName("预订数量")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal PreQty { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        [DisplayName("最后修改时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户ID")]

        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户名称")]

        public string ModifyUserName { get; set; }



        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]
        public string Remark { get; set; }
        #endregion
    }
}