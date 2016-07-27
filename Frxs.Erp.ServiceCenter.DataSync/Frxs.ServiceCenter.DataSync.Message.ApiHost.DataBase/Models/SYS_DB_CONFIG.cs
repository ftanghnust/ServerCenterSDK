/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models
{
    public partial class SYS_DB_CONFIG : BaseEntity
    {
        public string CON_KEY { get; set; }
        public string DB_NAME { get; set; }
        public string DB_USER { get; set; }
        public string DB_PWD { get; set; }
        public string DB_SERVER { get; set; }
        public string REMARK { get; set; }
    }
}
