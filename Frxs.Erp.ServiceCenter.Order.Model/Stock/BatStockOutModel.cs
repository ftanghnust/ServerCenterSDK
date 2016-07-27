using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model.Stock
{
    //批次入库
    [Serializable]
    public class BatStockOutModel
    {
        /// <summary>
        /// 批次入库商品ID
        /// </summary>
        public IList<StockOutInPutInModel> OutPList { get; set; }

        #region Model
        private int _wid;
        private int _subwid;
        private int _billtype;
        private string _billid;
        private int _vendorid;
       
        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        public int WID
        {
            set { _wid = value; }
            get { return _wid; }
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
        /// 单据类型(3：采购退库;4:销售出货;5:盘亏)
        /// </summary>
        public int BillType
        {
            set { _billtype = value; }
            get { return _billtype; }
        }
        /// <summary>
        /// 单据ID
        /// </summary>
        public string BillID
        {
            set { _billid = value; }
            get { return _billid; }
        }
               
        /// <summary>
        /// 供应商ID
        /// </summary>
        public int VendorID
        {
            set { _vendorid = value; }
            get { return _vendorid; }
        }

        private int? _createuserid;
        private string _createusername;

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

        #endregion Model


        private string _WCode;
        /// <summary>
        /// 仓库编号(Warehouse.WCode)
        /// </summary>       
        public string WCode
        {
            get
            {
                return _WCode;
            }
            set
            {
                _WCode = value;
            }
        }

        private string _WName;
        /// <summary>
        /// 仓库名称(Warehouse.WarehouseName)
        /// </summary>       
        public string WName
        {
            get
            {
                return _WName;
            }
            set
            {
                _WName = value;
            }
        }

        private string _SubWCode;
        /// <summary>
        /// 仓库子机构编号(Warehouse.WCode)
        /// </summary>
       
        public string SubWCode
        {
            get
            {
                return _SubWCode;
            }
            set
            {
                _SubWCode = value;
            }
        }

        private string _SubWName;
        /// <summary>
        /// 仓库柜台名称(Warehouse.WarehouseName)
        /// </summary>     
        public string SubWName
        {
            get
            {
                return _SubWName;
            }
            set
            {
                _SubWName = value;
            }
        }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
    }
}
