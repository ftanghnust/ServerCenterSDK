
/*****************************
* Author:CR
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
    /// 仓库货区ShelfArea实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class ShelfArea : BaseModel
    {

        #region 模型
        /// <summary>
        /// ID(主键)
        /// </summary>
        [DataMember]
        [DisplayName("ID(主键)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShelfAreaID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 仓库货区编号(数据字典：ShelfAreaCode)
        /// </summary>
        [DataMember]
        [DisplayName("仓库货区编号(数据字典：ShelfAreaCode)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShelfAreaCode { get; set; }

        /// <summary>
        /// 货区名称
        /// </summary>
        [DataMember]
        [DisplayName("货区名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShelfAreaName { get; set; }

        /// <summary>
        /// 拣货APP最大显示数
        /// </summary>
        [DataMember]
        [DisplayName("拣货APP最大显示数")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int PickingMaxRecord { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        [DisplayName("排序")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SerialNumber { get; set; }

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

        /// <summary>
        /// 最新修改删除时间
        /// </summary>
        [DataMember]
        [DisplayName("最新修改删除时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改删除用户ID
        /// </summary>
        [DataMember]
        [DisplayName("最后修改删除用户ID")]

        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改删除用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改删除用户名称")]

        public string ModifyUserName { get; set; }

        #endregion
    }
}