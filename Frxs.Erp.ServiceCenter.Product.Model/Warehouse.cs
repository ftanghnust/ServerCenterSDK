
/*****************************
* Author:CR
*
* Date:2016-03-10
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 仓库主表Warehouse实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Warehouse : BaseModel
    {

        #region 模型
        /// <summary>
        /// 仓库ID(从1000开始编号)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(从1000开始编号)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int? WID { get; set; }

        /// <summary>
        /// 仓库编号(唯一)
        /// </summary>
        [DataMember]
        [DisplayName("仓库编号(唯一)")]
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
        /// 仓库级别(0:总部[预留];1:仓库;2:仓库子机构物流/退货])
        /// </summary>
        [DataMember]
        [DisplayName("仓库级别(0:总部[预留];1:仓库;2:仓库子机构物流/退货])")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int? WLevel { get; set; }

        /// <summary>
        /// 子机构类型(0:退货;1:物流库;)
        /// </summary>
        [DataMember]
        [DisplayName("子机构类型(0:退货;1:物流库;)")]

        public int? WSubType { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        [DataMember]
        [DisplayName("父级ID")]

        public int? ParentWID { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [DataMember]
        [DisplayName("联系电话")]

        public string WTel { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        [DataMember]
        [DisplayName("联系人姓名")]

        public string WContact { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [DataMember]
        [DisplayName("省")]

        public int? ProvinceID { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [DataMember]
        [DisplayName("市")]

        public int? CityID { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        [DataMember]
        [DisplayName("区")]

        public int? RegionID { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [DataMember]
        [DisplayName("地址")]

        public string WAddress { get; set; }

        /// <summary>
        /// 全称地址
        /// </summary>
        [DataMember]
        [DisplayName("全称地址")]

        public string WFullAddress { get; set; }

        /// <summary>
        /// 400客服电话
        /// </summary>
        [DataMember]
        [DisplayName("400客服电话")]

        public string WCustomerServiceTel { get; set; }

        /// <summary>
        /// 退货部电话
        /// </summary>
        [DataMember]
        [DisplayName("退货部电话")]

        public string THBTel { get; set; }

        /// <summary>
        /// 财务室电话
        /// </summary>
        [DataMember]
        [DisplayName("财务室电话")]

        public string CWTel { get; set; }

        /// <summary>
        /// 业务咨询电话1
        /// </summary>
        [DataMember]
        [DisplayName("业务咨询电话1")]

        public string YW1Tel { get; set; }

        /// <summary>
        /// 业务咨询电话2
        /// </summary>
        [DataMember]
        [DisplayName("业务咨询电话2")]

        public string YW2Tel { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]

        public string Remark { get; set; }

        /// <summary>
        /// 是否已被冻结(0:未冻结;1、已冻结)
        /// </summary>
        [DataMember]
        [DisplayName("是否已被冻结(0:未冻结;1、已冻结)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int? IsFreeze { get; set; }

        /// <summary>
        /// 是否已被删除(0:未删除;1、已删除)
        /// </summary>
        [DataMember]
        [DisplayName("是否已被删除(0:未删除;1、已删除)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int? IsDeleted { get; set; }

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

    public partial class Warehouse : BaseModel
    {
        /// <summary>
        /// 冻结状态(0:未冻结;1、已冻结)
        /// </summary>
        [DataMember]
        [DisplayName("状态")]
        public string FreezeStatus { get; set; }

        /// <summary>
        /// 管辖的仓库子机构的数量
        /// </summary>
        [DataMember]
        [DisplayName("仓库子机构)")]
        public int SubNum { get; set; }

        /// <summary>
        /// 管辖门店数量
        /// </summary>
        [DataMember]
        [DisplayName("仓库子机构)")]
        public int ShopNum { get; set; }
    }


    /// <summary>
    /// 仓库子机构相关信息 供其他板块(如订单)使用 
    /// </summary>
    public class SubWName
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WName { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public string WCode { get; set; }

        /// <summary>
        /// 子机构ID
        /// </summary>
        public int SubWID { get; set; }

        /// <summary>
        /// 子机构编号
        /// </summary>
        public string SubWCode { get; set; }

        /// <summary>
        /// 子机构名称
        /// </summary>
        public string SUBWName { get; set; }
    }

}

