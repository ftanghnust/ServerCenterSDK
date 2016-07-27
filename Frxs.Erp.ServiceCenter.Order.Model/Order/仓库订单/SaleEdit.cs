
/*****************************
* Author:leidong
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
    /// SaleEdit实体类
    /// </summary>
    [Serializable]
    [DataContract]
    [DbMap(Name = "SaleEdit")]
    public partial class SaleEdit : BaseModel
    {

        #region 模型
        private string _EditID;
        /// <summary>
        /// 改单ID
        /// </summary>
        [DataMember]
        [DisplayName("改单ID")]

        [Required(ErrorMessage = "{0}不能为空")]

        [PrimaryKeyField]

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

        private string _WCode;
        /// <summary>
        /// 仓库编号(Warehouse.WCode)
        /// </summary>
        [DataMember]
        [DisplayName("仓库编号(Warehouse.WCode)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "WCode")]
        public string WCode
        {
            get
            {
                return _WCode;
            }
            set
            {
                _WCode = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("WCode", value));
            }
        }

        private string _WName;
        /// <summary>
        /// 仓库名称(Warehouse.WName)
        /// </summary>
        [DataMember]
        [DisplayName("仓库名称(Warehouse.WName)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "WName")]
        public string WName
        {
            get
            {
                return _WName;
            }
            set
            {
                _WName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("WName", value));
            }
        }

        private int? _SubWID;
        /// <summary>
        /// 仓库子机构ID
        /// </summary>
        [DataMember]
        [DisplayName("仓库子机构ID")]

        [DbMap(Name = "SubWID")]
        public int? SubWID
        {
            get
            {
                return _SubWID;
            }
            set
            {
                _SubWID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SubWID", value));
            }
        }

        private string _SubWCode;
        /// <summary>
        /// 仓库子机构编号(Warehouse.WCode)
        /// </summary>
        [DataMember]
        [DisplayName("仓库子机构编号(Warehouse.WCode)")]

        [DbMap(Name = "SubWCode")]
        public string SubWCode
        {
            get
            {
                return _SubWCode;
            }
            set
            {
                _SubWCode = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SubWCode", value));
            }
        }

        private string _SubWName;
        /// <summary>
        /// 仓库子机构名称(Warehouse.WName)
        /// </summary>
        [DataMember]
        [DisplayName("仓库子机构名称(Warehouse.WName)")]

        [DbMap(Name = "SubWName")]
        public string SubWName
        {
            get
            {
                return _SubWName;
            }
            set
            {
                _SubWName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SubWName", value));
            }
        }

        private DateTime _EditDate;
        /// <summary>
        /// 改单日期(格式:yyyy-MM-dd)
        /// </summary>
        [DataMember]
        [DisplayName("改单日期(格式:yyyy-MM-dd)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "EditDate")]
        public DateTime EditDate
        {
            get
            {
                return _EditDate;
            }
            set
            {
                _EditDate = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("EditDate", value));
            }
        }

        private int _Status;
        /// <summary>
        /// 状态(0:未提交;1:已确认;2:已过帐;)
        /// </summary>
        [DataMember]
        [DisplayName("状态(0:未提交;1:已确认;2:已过帐;)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "Status")]
        public int Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("Status", value));
            }
        }

        private DateTime? _ConfTime;
        /// <summary>
        /// 提交时间
        /// </summary>
        [DataMember]
        [DisplayName("提交时间")]

        [DbMap(Name = "ConfTime")]
        public DateTime? ConfTime
        {
            get
            {
                return _ConfTime;
            }
            set
            {
                _ConfTime = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ConfTime", value));
            }
        }

        private int? _ConfUserID;
        /// <summary>
        /// 提交用户ID
        /// </summary>
        [DataMember]
        [DisplayName("提交用户ID")]

        [DbMap(Name = "ConfUserID")]
        public int? ConfUserID
        {
            get
            {
                return _ConfUserID;
            }
            set
            {
                _ConfUserID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ConfUserID", value));
            }
        }

        private string _ConfUserName;
        /// <summary>
        /// 提交用户名称
        /// </summary>
        [DataMember]
        [DisplayName("提交用户名称")]

        [DbMap(Name = "ConfUserName")]
        public string ConfUserName
        {
            get
            {
                return _ConfUserName;
            }
            set
            {
                _ConfUserName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ConfUserName", value));
            }
        }

        private DateTime? _PostingTime;
        /// <summary>
        /// 过帐时间
        /// </summary>
        [DataMember]
        [DisplayName("过帐时间")]

        [DbMap(Name = "PostingTime")]
        public DateTime? PostingTime
        {
            get
            {
                return _PostingTime;
            }
            set
            {
                _PostingTime = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("PostingTime", value));
            }
        }

        private int? _PostingUserID;
        /// <summary>
        /// 过帐用户ID
        /// </summary>
        [DataMember]
        [DisplayName("过帐用户ID")]

        [DbMap(Name = "PostingUserID")]
        public int? PostingUserID
        {
            get
            {
                return _PostingUserID;
            }
            set
            {
                _PostingUserID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("PostingUserID", value));
            }
        }

        private string _PostingUserName;
        /// <summary>
        /// 过帐用户名称
        /// </summary>
        [DataMember]
        [DisplayName("过帐用户名称")]

        [DbMap(Name = "PostingUserName")]
        public string PostingUserName
        {
            get
            {
                return _PostingUserName;
            }
            set
            {
                _PostingUserName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("PostingUserName", value));
            }
        }

        private string _Remark;
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]

        [DbMap(Name = "Remark")]
        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("Remark", value));
            }
        }

        private DateTime _CreateTime;
        /// <summary>
        /// 创建日期
        /// </summary>
        [DataMember]
        [DisplayName("创建日期")]

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
        /// 创建用户ID
        /// </summary>
        [DataMember]
        [DisplayName("创建用户ID")]

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
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]

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

        private DateTime _ModifyTime;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        [DisplayName("最后修改时间")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "ModifyTime")]
        public DateTime ModifyTime
        {
            get
            {
                return _ModifyTime;
            }
            set
            {
                _ModifyTime = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ModifyTime", value));
            }
        }

        private int? _ModifyUserID;
        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户ID")]

        [DbMap(Name = "ModifyUserID")]
        public int? ModifyUserID
        {
            get
            {
                return _ModifyUserID;
            }
            set
            {
                _ModifyUserID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ModifyUserID", value));
            }
        }

        private string _ModifyUserName;
        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户名称")]

        [DbMap(Name = "ModifyUserName")]
        public string ModifyUserName
        {
            get
            {
                return _ModifyUserName;
            }
            set
            {
                _ModifyUserName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ModifyUserName", value));
            }
        }



        
        #endregion
    }

    public partial class SaleEdit : BaseModel
    {
        public int OrderCount { get; set; }
    }
}