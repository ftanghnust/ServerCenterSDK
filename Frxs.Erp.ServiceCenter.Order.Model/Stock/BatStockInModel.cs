using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model.Stock
{
    //批次入库
    [Serializable]
    public class BatStockInModel
    {
        /// <summary>
        /// 批次入库商品ID
        /// </summary>
        public IList<StockFIFOInModel> InPList { get; set; }

        private string _batchno;
        private int _wid;
        private string _wcode;
        private string _wname;
        private int _subwid;
        private string _subwname;
        private int? _createuserid;
        private string _createusername;

        /// <summary>
        /// 批次号(批次号)(ID_SERVICE_BATCHNO.ID)
        /// </summary>
        public string BatchNO
        {
            set { _batchno = value; }
            get { return _batchno; }
        }
        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        public int WID
        {
            set { _wid = value; }
            get { return _wid; }
        }
        /// <summary>
        /// 仓库编号
        /// </summary>
        public string WCode
        {
            set { _wcode = value; }
            get { return _wcode; }
        }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WName
        {
            set { _wname = value; }
            get { return _wname; }
        }
        /// <summary>
        /// 仓库柜台ID(Warehouse.WID)
        /// </summary>
        public int SubWID
        {
            set { _subwid = value; }
            get { return _subwid; }
        }
        /// <summary>
        /// 柜台名称
        /// </summary>
        public string SubWName
        {
            set { _subwname = value; }
            get { return _subwname; }
        }
        /// <summary>
        /// 创建用户ID
        /// </summary>
        public int? CreateUserID
        {
            set { _createuserid = value; }
            get { return _createuserid; }
        }
        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string CreateUserName
        {
            set { _createusername = value; }
            get { return _createusername; }
        }
    }
}
