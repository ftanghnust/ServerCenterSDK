
/*****************************
* Author:CR
*
* Date:2016-03-21
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 门店资料表Shop实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Shop : BaseModel
    {

        #region 模型
        /// <summary>
        /// 门店ID
        /// </summary>
        [DataMember]
        [DisplayName("门店ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopID { get; set; }

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        [DisplayName("门店编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopCode { get; set; }

        /// <summary>
        /// 门店类型(0:加盟店;1:签约店;)
        /// </summary>
        [DataMember]
        [DisplayName("门店类型(0:加盟店;1:签约店;)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopType { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        [DataMember]
        [DisplayName("门店名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopName { get; set; }

        /// <summary>
        /// 门店帐号(XSUser.Account)
        /// </summary>
        [DataMember]
        [DisplayName("门店帐号")]

        public string ShopAccount { get; set; }

        /// <summary>
        /// 结帐方式(0:现金 + 数据字典: ShopSettleType)
        /// </summary>
        [DataMember]
        [DisplayName("结帐方式(0:现金 + 数据字典: ShopSettleType)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SettleType { get; set; }

        /// <summary>
        /// 配送仓库ID(WarehouseInfo.WID)
        /// </summary>
        [DataMember]
        [DisplayName("配送仓库ID(WarehouseInfo.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 门店联系人姓名
        /// </summary>
        [DataMember]
        [DisplayName("门店联系人姓名")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string LinkMan { get; set; }

        /// <summary>
        /// 门店联系电话
        /// </summary>
        [DataMember]
        [DisplayName("门店联系电话")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Telephone { get; set; }

        /// <summary>
        /// 状态(1:正常;0:冻结)
        /// </summary>
        [DataMember]
        [DisplayName("状态(1:正常;0:冻结)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Status { get; set; }

        /// <summary>
        /// 法人
        /// </summary>
        [DataMember]
        [DisplayName("法人")]

        public string LegalPerson { get; set; }

        /// <summary>
        /// 结算方式( 数据字典: ShopSettleTimeType)
        /// </summary>
        [DataMember]
        [DisplayName("结算方式( 数据字典: ShopSettleTimeType)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SettleTimeType { get; set; }

        /// <summary>
        /// 门店级别(数据字典: ShopLevel; A:A级;B:B级;C:C级)
        /// </summary>
        [DataMember]
        [DisplayName("门店级别(数据字典: ShopLevel; A:A级;B:B级;C:C级)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string CreditLevel { get; set; }

        /// <summary>
        /// 信用额度
        /// </summary>
        [DataMember]
        [DisplayName("信用额度")]
        [Required(ErrorMessage = "{0}不能为空")]
        public double CreditAmt { get; set; }

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
        [Required(ErrorMessage = "{0}不能为空")]
        public int ProvinceID { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [DataMember]
        [DisplayName("市")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int CityID { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        [DataMember]
        [DisplayName("区")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int RegionID { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [DataMember]
        [DisplayName("地址")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Address { get; set; }

        /// <summary>
        /// 地址全称
        /// </summary>
        [DataMember]
        [DisplayName("地址全称")]

        public string FullAddress { get; set; }

        /// <summary>
        /// 门店面积(平方米)
        /// </summary>
        [DataMember]
        [DisplayName("门店面积(平方米)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal ShopArea { get; set; }

        /// <summary>
        /// 是否删除(0:未删除;1:已删除)
        /// </summary>
        [DataMember]
        [DisplayName("是否删除(0:未删除;1:已删除)")]

        public int IsDeleted { get; set; }

        /// <summary>
        /// 纬度（百度座标)
        /// </summary>
        [DataMember]
        [DisplayName("纬度（百度座标)")]

        public string Latitude { get; set; }

        /// <summary>
        /// 经度（百度座标)
        /// </summary>
        [DataMember]
        [DisplayName("经度（百度座标)")]

        public string Longitude { get; set; }

        /// <summary>
        /// 门店累计积分
        /// </summary>
        [DataMember]
        [DisplayName("门店累计积分")]
        [Required(ErrorMessage = "{0}不能为空")]
        public double TotalPoint { get; set; }

        /// <summary>
        /// 银行帐号
        /// </summary>
        [DataMember]
        [DisplayName("银行帐号")]

        public string BankAccount { get; set; }

        /// <summary>
        /// 银行开户名称
        /// </summary>
        [DataMember]
        [DisplayName("银行开户名称")]

        public string BankAccountName { get; set; }

        /// <summary>
        /// 银行类型
        /// </summary>
        [DataMember]
        [DisplayName("银行类型")]

        public string BankType { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [DataMember]
        [DisplayName("身份证号码")]

        public string CardID { get; set; }

        /// <summary>
        /// 区域负责人
        /// </summary>
        [DataMember]
        [DisplayName("区域负责人")]

        public string RegionMaster { get; set; }

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

        public string CreateUserName { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [DataMember]
        [DisplayName("修改时间")]
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

        #endregion
    }

    public partial class Shop : BaseModel
    {
        /// <summary>
        /// 状态(1:正常;0:冻结)
        /// </summary>
        [DataMember]
        [DisplayName("状态")]        
        public string StatusStr { get; set; }


        #region 仓库后台使用的属性
        /// <summary>
        /// 线路ID WarehouseLine.LineID
        /// </summary>
        [DataMember]
        [DisplayName("线路ID")]
        public int LineID { get; set; }

        /// <summary>
        /// 线路名称 WarehouseLine.LineName
        /// </summary>
        [DataMember]
        [DisplayName("线路名称")]
        public string LineName { get; set; }


        /// <summary>
        /// 发货排序 WarehouseLine.SerialNumber 
        /// </summary>
        [DataMember]
        [DisplayName("发货排序")]
        public int SerialNumber { get; set; }

        /// <summary>
        /// 发货排序 WarehouseLine.SerialNumber 
        /// </summary>
        [DataMember]
        [DisplayName("发货排序")]
        public string SerialNumberStr { get; set; }

        #endregion
    }

    /// <summary>
    /// 用于门店排单
    /// </summary>
    public partial class ShopExt :BaseModel
    {

        /// <summary>
        /// 门店级别(数据字典: ShopLevel; A:A级;B:B级;C:C级)
        /// </summary>
        [DataMember]
        [DisplayName("门店级别(数据字典: ShopLevel; A:A级;B:B级;C:C级)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string CreditLevel { get; set; }
        /// <summary>
        /// 门店ID
        /// </summary>
        [DataMember]
        [DisplayName("门店ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopID { get; set; }

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        [DisplayName("门店编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopCode { get; set; }
        
        /// <summary>
        /// 门店类型(0:加盟店;1:签约店;)
        /// </summary>
        [DataMember]
        [DisplayName("门店类型(0:加盟店;1:签约店;)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopType { get; set; }

        /// <summary>
        /// 门店类型(0:加盟店;1:签约店;)
        /// </summary>
        [DataMember]
        [DisplayName("门店类型(0:加盟店;1:签约店;)")]
        public string ShopTypeStr { get; set; }
        
        /// <summary>
        /// 门店名称
        /// </summary>
        [DataMember]
        [DisplayName("门店名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopName { get; set; }

        /// <summary>
        /// 门店帐号(XSUser.Account)
        /// </summary>
        [DataMember]
        [DisplayName("门店帐号")]
        public string ShopAccount { get; set; }


        /// <summary>
        /// 配送仓库ID(WarehouseInfo.WID)
        /// </summary>
        [DataMember]
        [DisplayName("配送仓库ID(WarehouseInfo.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 门店联系人姓名
        /// </summary>
        [DataMember]
        [DisplayName("门店联系人姓名")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string LinkMan { get; set; }

        /// <summary>
        /// 门店联系电话
        /// </summary>
        [DataMember]
        [DisplayName("门店联系电话")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Telephone { get; set; }

        /// <summary>
        /// 状态(1:正常;0:冻结)
        /// </summary>
        [DataMember]
        [DisplayName("状态(1:正常;0:冻结)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Status { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [DataMember]
        [DisplayName("地址")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Address { get; set; }

        /// <summary>
        /// 地址全称
        /// </summary>
        [DataMember]
        [DisplayName("地址全称")]

        public string FullAddress { get; set; }

        /// <summary>
        /// 状态(1:正常;0:冻结)
        /// </summary>
        [DataMember]
        [DisplayName("状态")]
        public string StatusStr { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [DataMember]
        [DisplayName("订单号")]
        public string OrderId { get; set; }


        /// <summary>
        /// 线路ID WarehouseLine.LineID
        /// </summary>
        [DataMember]
        [DisplayName("线路ID")]
        public int LineID { get; set; }

        /// <summary>
        /// 线路名称 WarehouseLine.LineName
        /// </summary>
        [DataMember]
        [DisplayName("线路名称")]
        public string LineName { get; set; }

        /// <summary>
        /// 线路编号
        /// </summary>
        [DataMember]
        [DisplayName("线路编号")]
        public string LineCode { get; set; }

        /// <summary>
        /// 线路编号
        /// </summary>
        [DataMember]
        [DisplayName("线路编号")]
        public string DeliverWeek { get; set; }

        /// <summary>
        ///  配送周期1
        /// </summary>
        [DataMember]
        [DisplayName("配送周期1")]
        public int SendW1 { get; set; }

        /// <summary>
        ///  配送周期2
        /// </summary>
        [DataMember]
        [DisplayName("配送周期2")]
        public int SendW2 { get; set; }

        /// <summary>
        ///  配送周期3
        /// </summary>
        [DataMember]
        [DisplayName("配送周期3")]
        public int SendW3 { get; set; }

        /// <summary>
        ///  配送周期4
        /// </summary>
        [DataMember]
        [DisplayName("配送周期4")]
        public int SendW4 { get; set; }

        /// <summary>
        ///  配送周期5
        /// </summary>
        [DataMember]
        [DisplayName("配送周期5")]
        public int SendW5 { get; set; }

        /// <summary>
        ///  配送周期6
        /// </summary>
        [DataMember]
        [DisplayName("配送周期6")]
        public int SendW6 { get; set; }

        /// <summary>
        ///  配送周期7
        /// </summary>
        [DataMember]
        [DisplayName("配送周期7")]
        public int SendW7 { get; set; }
    }

    

}