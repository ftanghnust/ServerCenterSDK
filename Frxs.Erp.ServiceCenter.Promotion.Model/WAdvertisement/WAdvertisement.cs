
/*****************************
* Author:zhoujin
*
* Date:2016-03-29
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Promotion.Model
{
    /// <summary>
    /// 仓库--广告、橱窗信息表WAdvertisement实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WAdvertisement : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        [DisplayName("主键ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int AdvertisementID { get; set; }

        /// <summary>
        /// 仓库编号(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库编号(Warehouse.WID)")]

        public int WID { get; set; }

        /// <summary>
        /// 广告位置（1、轮播广告，2、底部广告，3、橱窗）
        /// </summary>
        [DataMember]
        [DisplayName("广告位置（1、轮播广告，2、底部广告，3、橱窗）")]

        public int AdvertisementPosition { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        [DisplayName("名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string AdvertisementName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        [DisplayName("排序")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Sort { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        [DataMember]
        [DisplayName("图片地址")]

        public string ImagesSrc { get; set; }

        /// <summary>
        /// 选中后的图标
        /// </summary>
        [DataMember]
        [DisplayName("选中后的图标")]

        public string SelectImagesSrc { get; set; }

        /// <summary>
        /// 广告类型（1、促销，2、分类，3、商品）注：橱窗与此字段无关
        /// </summary>
        [DataMember]
        [DisplayName("广告类型（1、促销，2、分类，3、商品）注：橱窗与此字段无关")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int AdvertisementType { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [DataMember]
        [DisplayName("是否删除")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsDelete { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        [DataMember]
        [DisplayName("是否锁定")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsLocked { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMember]
        [DisplayName("开始时间")]

        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember]
        [DisplayName("结束时间")]

        public DateTime EndTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户 ID
        /// </summary>
        [DataMember]
        [DisplayName("创建用户 ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string CreateUserName { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [DataMember]
        [DisplayName("修改时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ModityTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ModityUserID { get; set; }

        /// <summary>
        /// 最后修改用记名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用记名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ModityUserName { get; set; }

        #endregion
    }
}