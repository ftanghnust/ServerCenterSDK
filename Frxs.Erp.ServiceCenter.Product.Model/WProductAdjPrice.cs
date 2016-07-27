
/*****************************
* Author:CR
*
* Date:2016-04-09
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 仓库商品价格调整表WProductAdjPrice实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WProductAdjPrice : BaseModel
    {

        #region 模型
        /// <summary>
        /// 调整ID
        /// </summary>
        [DataMember]
        [DisplayName("调整ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int AdjID { get; set; }

        /// <summary>
        /// 仓库ID(WarehouseID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(WarehouseID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 状态(0:未提交;1:已确认;2:已过帐;)
        /// </summary>
        [DataMember]
        [DisplayName("状态(0:未提交;1:已确认;2:已过帐;)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Status { get; set; }

        /// <summary>
        /// 调整类型(0:采购(进货)价;1:配送(批发)价;2:费率及积分)
        /// </summary>
        [DataMember]
        [DisplayName("调整类型(0:采购(进货)价;1:配送(批发)价;2:费率及积分)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int AdjType { get; set; }

        /// <summary>
        /// 调整生效时间(由系统自动确认生效 格式:yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [DataMember]
        [DisplayName("调整生效时间(由系统自动确认生效 格式:yyyy-MM-dd HH:mm:ss)")]

        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 确认时间
        /// </summary>
        [DataMember]
        [DisplayName("确认时间")]

        public DateTime? ConfTime { get; set; }

        /// <summary>
        /// 确认用户ID
        /// </summary>
        [DataMember]
        [DisplayName("确认用户ID")]

        public int? ConfUserID { get; set; }

        /// <summary>
        /// 确认用户名称
        /// </summary>
        [DataMember]
        [DisplayName("确认用户名称")]

        public string ConfUserName { get; set; }

        /// <summary>
        /// 过帐时间
        /// </summary>
        [DataMember]
        [DisplayName("过帐时间")]

        public DateTime? PostingTime { get; set; }

        /// <summary>
        /// 过帐用户ID
        /// </summary>
        [DataMember]
        [DisplayName("过帐用户ID")]

        public int? PostingUserID { get; set; }

        /// <summary>
        /// 过帐用户名称
        /// </summary>
        [DataMember]
        [DisplayName("过帐用户名称")]

        public string PostingUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("")]

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
        [Required(ErrorMessage = "{0}不能为空")]
        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]

        public string CreateUserName { get; set; }

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

        public int? ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户名称")]

        public string ModifyUserName { get; set; }


        #endregion
    }
}