/*********************************************************
 * FRXS 小马哥 2016/5/11 10:03:23
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model.Order
{
    public class PickUserIdAndUserName
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public int EmpID { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string EmpName { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductID { get; set; }
    }
}
