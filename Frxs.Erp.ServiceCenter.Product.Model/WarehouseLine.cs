
/*****************************
* Author:CR
*
* Date:2016-03-15
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 仓库配送线路表WarehouseLine实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WarehouseLine : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键(ID)
        /// </summary>
        [DataMember]
        [DisplayName("主键(ID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int LineID { get; set; }

        /// <summary>
        /// 配送线路编号(不能重复,不包括已删除的)
        /// </summary>
        [DataMember]
        [DisplayName("配送线路编号(不能重复,不包括已删除的)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string LineCode { get; set; }

        /// <summary>
        /// 所属仓库(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("所属仓库(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 配送线路名称
        /// </summary>
        [DataMember]
        [DisplayName("配送线路名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string LineName { get; set; }

        /// <summary>
        /// 用户编号(WarehouseEmp.EmpID and EmpType=2)
        /// </summary>
        [DataMember]
        [DisplayName("用户编号(WarehouseEmp.EmpID and EmpType=2)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int EmpID { get; set; }

        /// <summary>
        /// 配送周期周1(0:不送;1:送)
        /// </summary>
        [DataMember]
        [DisplayName("配送周期周1(0:不送;1:送)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SendW1 { get; set; }

        /// <summary>
        /// 配送周期周2(0:不送;1:送)
        /// </summary>
        [DataMember]
        [DisplayName("配送周期周2(0:不送;1:送)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SendW2 { get; set; }

        /// <summary>
        /// 配送周期周3(0:不送;1:送)
        /// </summary>
        [DataMember]
        [DisplayName("配送周期周3(0:不送;1:送)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SendW6 { get; set; }

        /// <summary>
        /// 配送周期周4(0:不送;1:送)
        /// </summary>
        [DataMember]
        [DisplayName("配送周期周4(0:不送;1:送)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SendW5 { get; set; }

        /// <summary>
        /// 配送周期周5(0:不送;1:送)
        /// </summary>
        [DataMember]
        [DisplayName("配送周期周5(0:不送;1:送)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SendW4 { get; set; }

        /// <summary>
        /// 配送周期周6(0:不送;1:送)
        /// </summary>
        [DataMember]
        [DisplayName("配送周期周6(0:不送;1:送)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SendW3 { get; set; }

        /// <summary>
        /// 配送周期周7(0:不送;1:送)
        /// </summary>
        [DataMember]
        [DisplayName("配送周期周7(0:不送;1:送)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SendW7 { get; set; }

        /// <summary>
        /// 门店下单截止时间(hh:mm:ss)
        /// </summary>
        [DataMember]
        [DisplayName("门店下单截止时间(hh:mm:ss)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public TimeSpan OrderEndTime { get; set; }

        /// <summary>
        /// 配送距离KM
        /// </summary>
        [DataMember]
        [DisplayName("配送距离KM")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Distance { get; set; }

        /// <summary>
        /// 发货所要的时间(小时）
        /// </summary>
        [DataMember]
        [DisplayName("发货所要的时间(小时）")]

        public int SendNeedTime { get; set; }

        /// <summary>
        /// 发货排序
        /// </summary>
        [DataMember]
        [DisplayName("发货排序")]

        public int SerialNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]

        public string Remark { get; set; }

        /// <summary>
        /// 是否暂停发货(0:未暂停发货;1暂停发货:;暂停的路线暂停发货)
        /// </summary>
        [DataMember]
        [DisplayName("是否暂停发货(0:未暂停发货;1暂停发货:;暂停的路线暂停发货)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsLocked { get; set; }

        /// <summary>
        /// 是否删除(0:未删除;1:已删除)
        /// </summary>
        [DataMember]
        [DisplayName("是否删除(0:未删除;1:已删除)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [DataMember]
        [DisplayName("创建日期")]
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

        #endregion
    }    
    public partial class WarehouseLine : BaseModel
    {

        #region 模型
        /// <summary>
        /// 用户名称
        /// </summary>
        [DataMember]
        public string EmpName { get; set; }

        /// <summary>
        /// 配送周期
        /// </summary>
        [DataMember]
        public string SendW { get; set; }

        /// <summary>
        /// 负责人电话
        /// </summary>
        [DataMember]
        [DisplayName("负责人电话")]
        public string UserMobile { get; set; }

        /// <summary>
        /// 配送门店数
        /// </summary>
        [DataMember]
        [DisplayName("配送门店数")]
        public int ShopNum { get; set; }

        #endregion
    }
}