/* ----------------------------------------------------
 * Copyright (C) 2013 24040132@qq.com  5/14/2013 3:25:50 PM
 * ---------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.UI {
    /// <summary>
    /// 
    /// </summary>
    public class ListViewEx : ListView {
        public ListViewEx()
            : base() {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}
