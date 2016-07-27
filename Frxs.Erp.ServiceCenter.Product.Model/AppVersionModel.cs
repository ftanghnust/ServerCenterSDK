using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    
        /// <summary>
        /// APP版本号
        /// </summary>
        [Serializable]
        public partial class AppVersionModel
        {
            public AppVersionModel()
            { }
            #region Model
            private int _id;
            private int _systype;
            private int _apptype;
            private string _curversion;
            private string _downurl;
            private int _updateflag;
            private string _updateremark;
            private DateTime? _modifytime;
            private int? _modifyuserid;
            private string _modifyusername;

            private int _curCode;

            public int CurCode
            {
                get { return _curCode; }
                set { _curCode = value; }
            }
            /// <summary>
            /// 主键(每次取ID最大的一条记录)
            /// </summary>
            public int ID
            {
                set { _id = value; }
                get { return _id; }
            }
            /// <summary>
            /// app操作系统类型(0:android;1:ios)
            /// </summary>
            public int SysType
            {
                set { _systype = value; }
                get { return _systype; }
            }
            /// <summary>
            /// 软件类型 AppType:(0:订货平台；1:拣货APP;2:配送APP;3:装箱APP;4:采购APP)
            /// </summary>
            public int AppType
            {
                set { _apptype = value; }
                get { return _apptype; }
            }
            /// <summary>
            /// 当前版本号
            /// </summary>
            public string CurVersion
            {
                set { _curversion = value; }
                get { return _curversion; }
            }
            /// <summary>
            /// 下载路径
            /// </summary>
            public string DownUrl
            {
                set { _downurl = value; }
                get { return _downurl; }
            }
            /// <summary>
            /// 是否强制升级(0:不需要;1:需要)
            /// </summary>
            public int UpdateFlag
            {
                set { _updateflag = value; }
                get { return _updateflag; }
            }
            /// <summary>
            /// 更新提示消息
            /// </summary>
            public string UpdateRemark
            {
                set { _updateremark = value; }
                get { return _updateremark; }
            }
            /// <summary>
            /// 最新修改时间
            /// </summary>
            public DateTime? ModifyTime
            {
                set { _modifytime = value; }
                get { return _modifytime; }
            }
            /// <summary>
            /// 最新修改用户ID
            /// </summary>
            public int? ModifyUserID
            {
                set { _modifyuserid = value; }
                get { return _modifyuserid; }
            }
            /// <summary>
            /// 最新修改用户名称
            /// </summary>
            public string ModifyUserName
            {
                set { _modifyusername = value; }
                get { return _modifyusername; }
            }
            #endregion Model

        }
   
}
