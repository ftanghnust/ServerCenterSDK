
/*****************************
* Author:CR
*
* Date:2016-04-06
******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Promotion.Model
{
    /// <summary>
    /// WProductPromotion实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WProductPromotion : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID(WID+ID服务表)
        /// </summary>
        [DataMember]
        [DisplayName("主键ID(WID+ID服务表)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string PromotionID { get; set; }

        /// <summary>
        /// 促销类型(1:门店积分促销;2:平台费率促销)
        /// </summary>
        [DataMember]
        [DisplayName("促销类型(1:门店积分促销;2:平台费率促销)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int PromotionType { get; set; }

        /// <summary>
        /// 仓库ID(WarehouseID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(WarehouseID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        [DataMember]
        [DisplayName("仓库编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string WCode { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        [DisplayName("仓库名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string WName { get; set; }

        /// <summary>
        /// 活动主题
        /// </summary>
        [DataMember]
        [DisplayName("活动主题")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string PromotionName { get; set; }

        /// <summary>
        /// 生效开始时间(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [DataMember]
        [DisplayName("生效开始时间(yyyy-MM-dd HH:mm:ss)")]

        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 生效结束时间(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [DataMember]
        [DisplayName("生效结束时间(yyyy-MM-dd HH:mm:ss)")]

        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 状态(0:录单;1:已确认;2:已生效;3:已停用)
        /// </summary>
        [DataMember]
        [DisplayName("状态(0:录单;1:已确认;2:已生效;3:已停用)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Status { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        [DataMember]
        [DisplayName("提交时间")]

        public DateTime? ConfTime { get; set; }

        /// <summary>
        /// 提交用户ID
        /// </summary>
        [DataMember]
        [DisplayName("提交用户ID")]

        public int? ConfUserID { get; set; }

        /// <summary>
        /// 提交用户名称
        /// </summary>
        [DataMember]
        [DisplayName("提交用户名称")]

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
        [Required(ErrorMessage = "{0}不能为空")]
        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]

        public string CreateUserName { get; set; }

        /// <summary>
        /// 最后修改时间(停用时也更新该字段)
        /// </summary>
        [DataMember]
        [DisplayName("最后修改时间(停用时也更新该字段)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户ID(停用时也更新该字段)
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户ID(停用时也更新该字段)")]

        public int? ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称(停用时也更新该字段)
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户名称(停用时也更新该字段)")]

        public string ModifyUserName { get; set; }

        #endregion


    }

    /// <summary>
    /// 单条积分促销详情对象 主表+商品详情+门店列表
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WProductPromotionInfo
    {
        /// <summary>
        /// 积分促销主表
        /// </summary>
        [DataMember]
        public WProductPromotion wProductPromotion { get; set; }

        /// <summary>
        /// 促销商品详情列表
        /// </summary>
        [DataMember]
        public IList<WProductPromotionDetails> detailsList { get; set; }

        /// <summary>
        /// 促销门店列表
        /// </summary>
        [DataMember]
        public IList<WProductPromotionShops> shopList { get; set; }
    }

    /// <summary>
    /// 判断 积分促销/平台费率调整单 互斥规则的对象
    /// </summary>
    [Serializable]
    [DataContract]
    public class RepeatPromotionInfo
    {
        /// <summary>
        /// 是否存在重复记录
        /// </summary>
        [DataMember]
        public bool Exist { get; set; }
        /// <summary>
        /// 重复的促销单号
        /// </summary>
        [DataMember]
        public string PromotionID { get; set; }

        /// <summary>
        /// 重复的门店编号
        /// </summary>
        [DataMember]
        public string ShopCode { get; set; }

        /// <summary>
        /// 重复的商品编号
        /// </summary>
        [DataMember]
        public string Sku { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [DataMember]
        public int ProductID { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        [DataMember]
        public int ShopID { get; set; }

    }
}