using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model
{
    public class BaseUserModel
    {
        /// <summary>
        /// 基础构造
        /// </summary>
        public BaseUserModel()
        {

        }

        /// <summary>
        /// 含参构造
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="userName">用户姓名</param>
        public BaseUserModel(int userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }


        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
    }
}
