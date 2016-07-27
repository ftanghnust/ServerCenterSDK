
/*****************************
* Author:chujl
*
* Date:2016-04-02
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Promotion.Model
{
    /// <summary>
    /// 仓库消息所属群组表WarehouseMessageShops实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WarehouseMessageShops : BaseModel
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
        /// 消息主表ID(WarehouseMessage.ID)
        /// </summary>
        [DataMember]
        [DisplayName("消息主表ID(WarehouseMessage.ID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WarehouseMessageID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID 二级)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID 二级)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 门店群组ID(ShopGroup.GroupID)
        /// </summary>
        [DataMember]
        [DisplayName("门店群组ID(ShopGroup.GroupID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int GroupID { get; set; }

        /// <summary>
        /// 门店群组名称
        /// </summary>
        [DataMember]
        [DisplayName("门店群组名称")]

        public string GroupName { get; set; }
        /// <summary>
        /// 门店群组编码
        /// </summary>
        [DataMember]
        [DisplayName("门店群组编码")]

        public string GroupCode { get; set; }

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
}