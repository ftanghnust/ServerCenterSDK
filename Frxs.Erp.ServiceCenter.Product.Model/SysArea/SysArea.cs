
/*****************************
* Author:CR
*
* Date:2016-06-20
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
    /// SysArea实体类
    /// </summary>
    [Serializable]
    [DataContract]
    [DbMap(Name = "SysArea")]
    public partial class SysArea : BaseModel
    {

        #region 模型
        private int _AreaID;
        /// <summary>
        /// 主键ID(区域邮政编号)
        /// </summary>
        [DataMember]
        [DisplayName("主键ID(区域邮政编号)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [PrimaryKeyField]

        [DbMap(Name = "AreaID")]
        public int AreaID
        {
            get
            {
                return _AreaID;
            }
            set
            {
                _AreaID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("AreaID", value));
            }
        }

        private string _AreaName;
        /// <summary>
        /// 区域名称
        /// </summary>
        [DataMember]
        [DisplayName("区域名称")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "AreaName")]
        public string AreaName
        {
            get
            {
                return _AreaName;
            }
            set
            {
                _AreaName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("AreaName", value));
            }
        }

        private int _Level;
        /// <summary>
        /// 区域级别(0:全国;1:省;2:市;3:区)
        /// </summary>
        [DataMember]
        [DisplayName("区域级别(0:全国;1:省;2:市;3:区)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "Level")]
        public int Level
        {
            get
            {
                return _Level;
            }
            set
            {
                _Level = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("Level", value));
            }
        }

        private int? _ParentID;
        /// <summary>
        /// 父级ID
        /// </summary>
        [DataMember]
        [DisplayName("父级ID")]

        [DbMap(Name = "ParentID")]
        public int? ParentID
        {
            get
            {
                return _ParentID;
            }
            set
            {
                _ParentID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ParentID", value));
            }
        }

        private DateTime _ModifyTime;
        /// <summary>
        /// 最新修改删除时间
        /// </summary>
        [DataMember]
        [DisplayName("最新修改删除时间")]

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
        /// 最后修改删除用户ID
        /// </summary>
        [DataMember]
        [DisplayName("最后修改删除用户ID")]

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
        /// 最后修改删除用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改删除用户名称")]

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

        private int? _SyncFale;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("")]

        [DbMap(Name = "SyncFale")]
        public int? SyncFale
        {
            get
            {
                return _SyncFale;
            }
            set
            {
                _SyncFale = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SyncFale", value));
            }
        }

        #endregion
    }


    /// <summary>
    /// 系统地区数据查询对象
    /// </summary>
    public partial class SysAreaQuery
    {
        /// <summary>
        /// 区域ID
        /// </summary>
        public int? AreaID { get; set; }
        
        /// <summary>
        /// 父级ID
        /// </summary>
        public int? ParentID { get; set; }

        /// <summary>
        /// 区域级别(0:全国;1:省;2:市;3:区)
        /// </summary>
        public int? Level { get; set; }
    }
}