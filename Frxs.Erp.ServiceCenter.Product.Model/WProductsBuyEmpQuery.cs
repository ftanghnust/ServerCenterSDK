using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    public class WProductsBuyEmpQuery
    {
        #region 模型

        private int _ID;
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }


        private long _WProductID;
        /// <summary>
        /// WProducts.WProductID
        /// </summary>
        public long WProductID
        {
            get
            {
                return _WProductID;
            }
            set
            {
                _WProductID = value;
            }
        }


        private int _WID;
        /// <summary>
        /// 仓库ID(一级)
        /// </summary>
        public int WID
        {
            get
            {
                return _WID;
            }
            set
            {
                _WID = value;
            }
        }


        private int _EmpID;
        /// <summary>
        /// 员工编号(WarehouseEmp.EmpID)
        /// </summary>
        public int EmpID
        {
            get
            {
                return _EmpID;
            }
            set
            {
                _EmpID = value;
            }
        }


        private int _SerialNumber;
        /// <summary>
        /// 排序(固定从1开始;1就是主条码)
        /// </summary>
        public int SerialNumber
        {
            get
            {
                return _SerialNumber;
            }
            set
            {
                _SerialNumber = value;
            }
        }


        private DateTime _CreateTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get
            {
                return _CreateTime;
            }
            set
            {
                _CreateTime = value;
            }
        }


        private int? _CreateUserID;
        /// <summary>
        /// 创建用户ID
        /// </summary>
        public int? CreateUserID
        {
            get
            {
                return _CreateUserID;
            }
            set
            {
                _CreateUserID = value;
            }
        }


        private string _CreateUserName;
        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string CreateUserName
        {
            get
            {
                return _CreateUserName;
            }
            set
            {
                _CreateUserName = value;
            }
        }


        #endregion
    }
}
