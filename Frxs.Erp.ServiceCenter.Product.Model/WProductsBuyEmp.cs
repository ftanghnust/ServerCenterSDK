using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Frxs.Platform.Utility.Filter;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    [Serializable]
    [DataContract]
    [DbMap(Name = "WProductsBuyEmp")]
    public partial class WProductsBuyEmp : BaseModel
    {

        #region 模型

        private int _ID;
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        [DisplayName("主键ID")]

        [Required(ErrorMessage = "{0}不能为空")]

        [PrimaryKeyField]

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


        private long _WProductID;
        /// <summary>
        /// WProducts.WProductID
        /// </summary>
        [DataMember]
        [DisplayName("WProducts.WProductID")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "WProductID")]
        public long WProductID
        {
            get
            {
                return _WProductID;
            }
            set
            {
                _WProductID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("WProductID", value));
            }
        }


        private int _WID;
        /// <summary>
        /// 仓库ID(一级)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(一级)")]

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


        private int _EmpID;
        /// <summary>
        /// 员工编号(WarehouseEmp.EmpID)
        /// </summary>
        [DataMember]
        [DisplayName("员工编号(WarehouseEmp.EmpID)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "EmpID")]
        public int EmpID
        {
            get
            {
                return _EmpID;
            }
            set
            {
                _EmpID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("EmpID", value));
            }
        }


        private int _SerialNumber;
        /// <summary>
        /// 排序(固定从1开始;1就是主条码)
        /// </summary>
        [DataMember]
        [DisplayName("排序(固定从1开始;1就是主条码)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "SerialNumber")]
        public int SerialNumber
        {
            get
            {
                return _SerialNumber;
            }
            set
            {
                _SerialNumber = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SerialNumber", value));
            }
        }


        private DateTime _CreateTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]

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


        #endregion
    }
}
