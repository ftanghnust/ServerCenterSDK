using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class SYS_DB_CONFIG
    {
        public string CON_KEY { get; set; }
        public string DB_NAME { get; set; }
        public string DB_USER { get; set; }
        public string DB_PWD { get; set; }
        public string DB_SERVER { get; set; }
        public string REMARK { get; set; }
    }
}
