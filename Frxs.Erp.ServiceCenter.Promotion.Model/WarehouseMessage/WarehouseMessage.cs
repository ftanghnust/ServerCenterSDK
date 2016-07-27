
/*****************************
* Author:chujl
*
* Date:2016-03-23
******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Promotion.Model
{

    /// <summary>
    /// 仓库消息表WarehouseMessage实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WarehouseMessage : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        [DisplayName("主键ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int? ID { get; set; }

        /// <summary>
        /// 仓库编号(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库编号(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int? WID { get; set; }

        /// <summary>
        /// 消息头
        /// </summary>
        [DataMember]
        [DisplayName("消息头")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Title { get; set; }

        /// <summary>
        /// 消息类型(0：重要消息;1:促销;2:其他)
        /// </summary>
        [DataMember]
        [DisplayName("消息类型(0：重要消息;1:促销;2:其他)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int? MessageType { get; set; }

        /// <summary>
        /// 消息类型(0:全部门店;1:指定群组)
        /// </summary>
        [DataMember]
        [DisplayName("消息类型(0:全部门店;1:指定群组)")]

        public int? RangType { get; set; }

        /// <summary>
        /// 发布时间开始（yyyy-MM-dd hh:mm:ss)
        /// </summary>
        [DataMember]
        [DisplayName("发布时间开始（yyyy-MM-dd hh:mm:ss)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 发布时间结束（yyyy-MM-dd hh:mm:ss)
        /// </summary>
        [DataMember]
        [DisplayName("发布时间结束（yyyy-MM-dd hh:mm:ss)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [DataMember]
        [DisplayName("内容")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Message { get; set; }

        /// <summary>
        /// 状态(0:未发布;1:已发布;2:已停止/已删除)
        /// </summary>
        [DataMember]
        [DisplayName("状态(0:未发布;1:已发布;2:已停止/已删除)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int? Status { get; set; }

        /// <summary>
        /// 确认时间
        /// </summary>
        [DataMember]
        [DisplayName("确认时间")]

        public DateTime? ConfTime { get; set; }

        /// <summary>
        /// 确认人员ID
        /// </summary>
        [DataMember]
        [DisplayName("确认人员ID")]

        public int? ConfUserID { get; set; }

        /// <summary>
        /// 确认人员名称
        /// </summary>
        [DataMember]
        [DisplayName("确认人员名称")]

        public string ConfUserName { get; set; }

        /// <summary>
        /// 置顶显示
        /// </summary>
        [DataMember]
        [DisplayName("置顶显示")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int? IsFirst { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建用户 ID
        /// </summary>
        [DataMember]
        [DisplayName("创建用户 ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int? CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]

        public string CreateUserName { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [DataMember]
        [DisplayName("修改时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime? ModityTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户ID")]

        public int? ModityUserID { get; set; }

        /// <summary>
        /// 最后修改用记名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用记名称")]

        public string ModityUserName { get; set; }

        #endregion


        #region 扩展字段
        /// <summary>
        /// 置顶显示
        /// </summary>
        [DataMember]
        [DisplayName("置顶显示")]
        public string IsFirstStr { get; set; }

        /// <summary>
        /// 消息类型(0：重要消息;1:促销;2:其他)
        /// </summary>
        [DataMember]
        [DisplayName("消息类型(0：重要消息;1:促销;2:其他)")]
        public string MessageTypeStr { get; set; }


        /// <summary>
        /// 消息类型(0:全部门店;1:指定群组)
        /// </summary>
        [DataMember]
        [DisplayName("消息类型(0:全部门店;1:指定群组)")]
        public string RangTypeStr { get; set; }


        /// <summary>
        /// 状态(0:未发布;1:已发布;2:已停止/已删除)
        /// </summary>
        [DataMember]
        [DisplayName("状态(0:未发布;1:已发布;2:已停止/已删除)")]
        public string StatusStr { get; set; }

        #endregion


        /// <summary>
        /// 明细列表
        /// </summary>
        [DataMember]
        public IList<WarehouseMessageShops> detailList;
    }
}