/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/5/2016 4:26:59 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order
{
    /// <summary>
    /// 多数据库连接配置
    /// </summary>
    public class DbConfig
    {
        /// <summary>
        /// 数据库配置KEY,如：Order_104
        /// </summary>
        public string CON_KEY { get; set; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DB_NAME { get; set; }

        /// <summary>
        /// 登录用户账户
        /// </summary>
        public string DB_USER { get; set; }

        /// <summary>
        /// 登录用户密码
        /// </summary>
        public string DB_PWD { get; set; }

        /// <summary>
        /// 数据库服务器地址
        /// </summary>
        public string DB_SERVER { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK { get; set; }
    }
}
