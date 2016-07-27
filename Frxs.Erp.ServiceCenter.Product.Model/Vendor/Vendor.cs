/*****************************
* Author:叶求
*
* Date:2016-03-09
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Frxs.Erp.ServiceCenter.Product.Model
{

    public partial class Vendor : BaseModel
    {
        /// <summary>
        /// 供应商类型(VendorType.VendorTypeID)
        /// </summary>
        [DataMember]
        [DisplayName("类型")]
        public string VendorTypeName { get; set; }

        /// <summary>
        /// 结算方式( 数据字典: VendorSettleTimeType)
        /// </summary>
        [DataMember]
        [DisplayName("结算方式")]
        public string SettleTimeTypeName { get; set; }

        /// <summary>
        /// 状态(1:正常;0:冻结)
        /// </summary>
        [DataMember]
        [DisplayName("状态")]
        public string StatusName { get; set; }

        [DataMember]
        [DisplayName("等级")]
        public string CreditLevelName { get; set; }

        /// <summary>
        /// 与仓库关联关系数据
        /// </summary>
         [DataMember]
        public string VendorWarehouseDatas { get; set; }

         [DataMember]
         [DisplayName("账期")]
        public string PaymentDateTypeName { get; set; }
    }

    /// <summary>
    /// 供应商表Vendor实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Vendor : BaseModel
    {

        #region 模型
        /// <summary>
        /// 供应商分类ID
        /// </summary>
        [DataMember]
        [DisplayName("供应商分类ID")]
        public int VendorID { get; set; }

        /// <summary>
        /// 供应商编号
        /// </summary>
        [DataMember]
        [DisplayName("供应商编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string VendorCode { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [DataMember]
        [DisplayName("供应商名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string VendorName { get; set; }

        /// <summary>
        /// 供应商简称
        /// </summary>
        [DataMember]
        [DisplayName("供应商简称")]
        public string VendorShortName { get; set; }

        /// <summary>
        /// 供应商类型(VendorType.VendorTypeID)
        /// </summary>
        [DataMember]
        [DisplayName("供应商类型(VendorType.VendorTypeID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int VendorTypeID { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        [DataMember]
        [DisplayName("联系人姓名")]
        public string LinkMan { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [DataMember]
        [DisplayName("联系电话")]
        public string Telephone { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [DataMember]
        [DisplayName("传真")]

        public string Fax { get; set; }

        /// <summary>
        /// 状态(1:正常;0:冻结)
        /// </summary>
        [DataMember]
        [DisplayName("状态(1:正常;0:冻结)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Status { get; set; }

        /// <summary>
        /// 企业法人
        /// </summary>
        [DataMember]
        [DisplayName("企业法人")]

        public string LegalPerson { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [DataMember]
        [DisplayName("电子邮箱")]

        public string Email { get; set; }

        /// <summary>
        /// 公司网址
        /// </summary>
        [DataMember]
        [DisplayName("公司网址")]

        public string WebUrl { get; set; }

        /// <summary>
        /// 行政区域
        /// </summary>
        [DataMember]
        [DisplayName("行政区域")]

        public string Region { get; set; }

        /// <summary>
        /// 结算方式( 数据字典: VendorSettleTimeType)
        /// </summary>
        [DataMember]
        [DisplayName("结算方式( 数据字典: VendorSettleTimeType)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SettleTimeType { get; set; }

        /// <summary>
        /// 供应商级别(数据字典: VendorLevel; A:A级;B:B级;C:C级)
        /// </summary>
        [DataMember]
        [DisplayName("供应商级别(数据字典: VendorLevel; A:A级;B:B级;C:C级)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string CreditLevel { get; set; }

        /// <summary>
        /// 区域负责人
        /// </summary>
        [DataMember]
        [DisplayName("区域负责人")]

        public string AreaPrincipal { get; set; }

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
        public string Address { get; set; }

        /// <summary>
        /// 地址全称
        /// </summary>
        [DataMember]
        [DisplayName("地址全称")]
        public string FullAddress { get; set; }

        /// <summary>
        /// 是否删除(0:未删除;1:已删除);
        /// </summary>
        [DataMember]
        [DisplayName("是否删除(0:未删除;1:已删除);")]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]
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
        /// 最后修改时间
        /// </summary>
        [DataMember]
        [DisplayName("最后修改时间")]
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
        /// 账期
        /// </summary>
        [DataMember]
        [DisplayName("账期")]
        public string PaymentDateType { get; set; }


        /// <summary>
        /// 扩展标识1
        /// </summary>
        [DataMember]
        [DisplayName("扩展标识1")]
        public string VExt1 { get; set; }


        /// <summary>
        /// 扩展标识2
        /// </summary>
        [DataMember]
        [DisplayName("扩展标识2")]
        public string VExt2 { get; set; }

        #endregion
    }

    /// <summary>
    /// 某商品的最后一次进货的供应商信息
    /// </summary>
    public class VendorLastBuy
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        public int VendorID { get; set; }

        /// <summary>
        /// 供应商编号
        /// </summary>
        public string VendorCode { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string VendorName { get; set; }

        /// <summary>
        /// 最新采购入库时间
        /// </summary>
        public DateTime? LastBuyTime { get; set; }
    }
}
