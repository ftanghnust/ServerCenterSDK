
/*****************************
* Author:CR
*
* Date:2016-04-22
******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Frxs.Platform.Utility.Filter;


namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// SaleEditOrders实体类
    /// </summary>
    [Serializable]
    [DataContract]
    [DbMap(Name = "SaleEditOrders")]
    public partial class SaleEditOrders : BaseModel
    {

        #region 模型
        private string _ID;
        /// <summary>
        /// 主键ID(WID+GUID)
        /// </summary>
        [DataMember]
        [DisplayName("主键ID(WID+GUID)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [PrimaryKeyField]

        [DbMap(Name = "ID")]
        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ID", value));
            }
        }

        private string _EditID;
        /// <summary>
        /// 改单ID（GUID)
        /// </summary>
        [DataMember]
        [DisplayName("改单ID（GUID)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "EditID")]
        public string EditID
        {
            get
            {
                return _EditID;
            }
            set
            {
                _EditID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("EditID", value));
            }
        }

        private int _WID;
        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "WID")]
        public int WID
        {
            get
            {
                return _WID;
            }
            set
            {
                _WID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("WID", value));
            }
        }

        private string _OrderID;
        /// <summary>
        /// 订单编号(SaleOrderPre.OrderID)
        /// </summary>
        [DataMember]
        [DisplayName("订单编号(SaleOrderPre.OrderID)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "OrderID")]
        public string OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                _OrderID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("OrderID", value));
            }
        }

        private DateTime _OrderDate;
        /// <summary>
        /// 订单下单时间 (SaleOrderPre.OrderDate)
        /// </summary>
        [DataMember]
        [DisplayName("订单下单时间 (SaleOrderPre.OrderDate)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "OrderDate")]
        public DateTime OrderDate
        {
            get
            {
                return _OrderDate;
            }
            set
            {
                _OrderDate = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("OrderDate", value));
            }
        }

        private DateTime _SendDate;
        /// <summary>
        /// 订单预计发货时间 (SaleOrderPre.SendDate)
        /// </summary>
        [DataMember]
        [DisplayName("订单预计发货时间 (SaleOrderPre.SendDate)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "SendDate")]
        public DateTime SendDate
        {
            get
            {
                return _SendDate;
            }
            set
            {
                _SendDate = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SendDate", value));
            }
        }

        private int _ShopID;
        /// <summary>
        /// 门店ID(SaleOrderPre.ShopID)
        /// </summary>
        [DataMember]
        [DisplayName("门店ID(SaleOrderPre.ShopID)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "ShopID")]
        public int ShopID
        {
            get
            {
                return _ShopID;
            }
            set
            {
                _ShopID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ShopID", value));
            }
        }

        private string _ShopCode;
        /// <summary>
        /// 门店编号(SaleOrderPre.ShopCode)
        /// </summary>
        [DataMember]
        [DisplayName("门店编号(SaleOrderPre.ShopCode)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "ShopCode")]
        public string ShopCode
        {
            get
            {
                return _ShopCode;
            }
            set
            {
                _ShopCode = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ShopCode", value));
            }
        }

        private string _ShopName;
        /// <summary>
        /// 门店名称(SaleOrderPre.ShopName)
        /// </summary>
        [DataMember]
        [DisplayName("门店名称(SaleOrderPre.ShopName)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "ShopName")]
        public string ShopName
        {
            get
            {
                return _ShopName;
            }
            set
            {
                _ShopName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ShopName", value));
            }
        }

        private int _ProcFlag;
        /// <summary>
        /// 处理标识(0:未处理;1:已处理;3:中断处理)
        /// </summary>
        [DataMember]
        [DisplayName("处理标识(0:未处理;1:已处理;3:中断处理)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "ProcFlag")]
        public int ProcFlag
        {
            get
            {
                return _ProcFlag;
            }
            set
            {
                _ProcFlag = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ProcFlag", value));
            }
        }

        private string _ProcRemark;
        /// <summary>
        /// 处理备注
        /// </summary>
        [DataMember]
        [DisplayName("处理备注")]

        [DbMap(Name = "ProcRemark")]
        public string ProcRemark
        {
            get
            {
                return _ProcRemark;
            }
            set
            {
                _ProcRemark = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ProcRemark", value));
            }
        }

        private DateTime _CreateTime;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        [DisplayName("最后修改时间")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "CreateTime")]
        public DateTime CreateTime
        {
            get
            {
                return _CreateTime;
            }
            set
            {
                _CreateTime = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("CreateTime", value));
            }
        }

        private int? _CreateUserID;
        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户ID")]

        [DbMap(Name = "CreateUserID")]
        public int? CreateUserID
        {
            get
            {
                return _CreateUserID;
            }
            set
            {
                _CreateUserID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("CreateUserID", value));
            }
        }

        private string _CreateUserName;
        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户名称")]

        [DbMap(Name = "CreateUserName")]
        public string CreateUserName
        {
            get
            {
                return _CreateUserName;
            }
            set
            {
                _CreateUserName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("CreateUserName", value));
            }
        }

        #endregion
    }
}