
/*****************************
* Author:CR
*
* Date:2016-03-25
******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 促销门店群组表ShopGroup实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class ShopGroup : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        [DisplayName("主键ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int GroupID { get; set; }

        /// <summary>
        /// 群组编号
        /// </summary>
        [DataMember]
        [DisplayName("群组编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string GroupCode { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 群组名称
        /// </summary>
        [DataMember]
        [DisplayName("群组名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string GroupName { get; set; }

        /// <summary>
        /// 是否删除(0:未删除;1: 已删除)
        /// </summary>
        [DataMember]
        [DisplayName("是否删除(0:未删除;1: 已删除)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]

        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [DataMember]
        [DisplayName("创建用户ID")]

        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]

        public string CreateUserName { get; set; }

        #endregion

    }

    public partial class ShopGroup : BaseModel
    {
        /// <summary>
        /// 门店数量
        /// </summary>
        [DataMember]
        [DisplayName("门店数量")]
        public int ShopNum { get; set; }


        /// <summary>
        /// 门店集合
        /// </summary>
        [DataMember]
        public IList<ShopGroupDetails> List { get; set; }

    }
}