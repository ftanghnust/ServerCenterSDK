
/*****************************
* Author:CR
*
* Date:2016-03-07
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 仓库货架表Shelf实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Shelf : BaseModel
    {

        #region 模型
        /// <summary>
        /// ID(主键)
        /// </summary>
        [DataMember]
        [DisplayName("ID(主键)")]      
        public int ShelfID { get; set; }

        /// <summary>
        /// 货位编号(同一个仓库不能重复)
        /// </summary>
        [DataMember]
        [DisplayName("货位编号(同一个仓库不能重复)")]

        public string ShelfCode { get; set; }

        /// <summary>
        /// 所属货区ID(ShelfArea.ShelfAreaID)
        /// </summary>
        [DataMember]
        [DisplayName("所属货区ID(ShelfArea.ShelfAreaID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShelfAreaID { get; set; }

        /// <summary>
        /// 货位类型(0:存储;1:)
        /// </summary>
        [DataMember]
        [DisplayName("货位类型(0:存储;1:)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShelfType { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 状态(0:正常;1:冻结)
        /// </summary>
        [DataMember]
        [DisplayName("状态(0:正常;1:冻结)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("")]
        public string Remark { get; set; }


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

    /// <summary>
    /// 查询显示实体
    /// </summary>
    public partial class Shelf : BaseModel
    {
        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        [DisplayName("仓库名称")]
        public string WName { get; set; }

        /// <summary>
        /// 货区
        /// </summary>
        [DataMember]
        [DisplayName("货区")]
        public string ShelfAreaName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        [DisplayName("状态")]
        public string StatusStr { get; set; }
    }
}