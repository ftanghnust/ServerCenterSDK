
/*****************************
* Author:TangFan
*
* Date:2016-06-24
******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Frxs.Platform.Utility.Filter;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 系统字符串配置表SysAppSettings实体类
    /// </summary>
    [Serializable]
    [DataContract]
    [DbMap(Name = "SysAppSettings")]
    public partial class SysAppSettings : BaseModel
    {

        #region 模型
        private int _ID;
        /// <summary>
        /// ID主键
        /// </summary>
        [DataMember]
        [DisplayName("ID主键")]

        [Required(ErrorMessage = "{0}不能为空")]

        [PrimaryKeyField(IsIdentity = true)]

        [DbMap(Name = "ID")]
        public int ID
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

        private int _WID;
        /// <summary>
        /// 仓库ID
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID")]

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

        private string _SKey;
        /// <summary>
        /// 配置唯一标识
        /// </summary>
        [DataMember]
        [DisplayName("配置唯一标识")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "SKey")]
        public string SKey
        {
            get
            {
                return _SKey;
            }
            set
            {
                _SKey = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SKey", value));
            }
        }

        private string _SVal1;
        /// <summary>
        /// 配置信息1
        /// </summary>
        [DataMember]
        [DisplayName("配置信息1")]

        [DbMap(Name = "SVal1")]
        public string SVal1
        {
            get
            {
                return _SVal1;
            }
            set
            {
                _SVal1 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SVal1", value));
            }
        }

        private string _SVal2;
        /// <summary>
        /// 配置信息2
        /// </summary>
        [DataMember]
        [DisplayName("配置信息2")]

        [DbMap(Name = "SVal2")]
        public string SVal2
        {
            get
            {
                return _SVal2;
            }
            set
            {
                _SVal2 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SVal2", value));
            }
        }

        private string _SVal3;
        /// <summary>
        /// 配置信息3
        /// </summary>
        [DataMember]
        [DisplayName("配置信息3")]

        [DbMap(Name = "SVal3")]
        public string SVal3
        {
            get
            {
                return _SVal3;
            }
            set
            {
                _SVal3 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SVal3", value));
            }
        }

        private string _SVal4;
        /// <summary>
        /// 配置信息4
        /// </summary>
        [DataMember]
        [DisplayName("配置信息4")]

        [DbMap(Name = "SVal4")]
        public string SVal4
        {
            get
            {
                return _SVal4;
            }
            set
            {
                _SVal4 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SVal4", value));
            }
        }

        private string _SVal5;
        /// <summary>
        /// 配置信息5
        /// </summary>
        [DataMember]
        [DisplayName("配置信息5")]

        [DbMap(Name = "SVal5")]
        public string SVal5
        {
            get
            {
                return _SVal5;
            }
            set
            {
                _SVal5 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SVal5", value));
            }
        }

        private string _SVal6;
        /// <summary>
        /// 配置信息6
        /// </summary>
        [DataMember]
        [DisplayName("配置信息6")]

        [DbMap(Name = "SVal6")]
        public string SVal6
        {
            get
            {
                return _SVal6;
            }
            set
            {
                _SVal6 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SVal6", value));
            }
        }

        private string _SVal7;
        /// <summary>
        /// 配置信息7
        /// </summary>
        [DataMember]
        [DisplayName("配置信息7")]

        [DbMap(Name = "SVal7")]
        public string SVal7
        {
            get
            {
                return _SVal7;
            }
            set
            {
                _SVal7 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SVal7", value));
            }
        }

        private string _SVal8;
        /// <summary>
        /// 配置信息8
        /// </summary>
        [DataMember]
        [DisplayName("配置信息8")]

        [DbMap(Name = "SVal8")]
        public string SVal8
        {
            get
            {
                return _SVal8;
            }
            set
            {
                _SVal8 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SVal8", value));
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
}