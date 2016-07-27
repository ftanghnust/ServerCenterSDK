
/*****************************
* Author:CR
*
* Date:2016-04-07
******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 仓库商品货架调整表WProductAdjShelf实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WProductAdjShelf : BaseModel
    {

        #region 模型
        /// <summary>
        /// 调整ID
        /// </summary>
        [DataMember]
        [DisplayName("调整单据号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string AdjID { get; set; }

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

        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户名称")]

        public string ModifyUserName { get; set; }

        /// <summary>
        /// 调整类型(0:货架[固定])
        /// </summary>
        [DataMember]
        [DisplayName("调整类型(0:货架[固定])")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int AdjType { get; set; }


        /// <summary>
        /// Remark
        /// </summary>
        [DataMember]
        [DisplayName("Remark")]
        public string Remark { get; set; }


        #endregion  

        #region 扩展
        
        /// <summary>
        /// 总货位调整数
        /// </summary>
        [DataMember]
        [DisplayName("总货位调整数")]
        public int TotalShelfCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("")]
        public string StatusToStr { get; set; }
        
        #endregion

        /// <summary>
        /// 
        /// </summary>
      public  IList<WProductAdjShelfDetails> wProductAdjShelfDetailsList { get; set; }
    }
}