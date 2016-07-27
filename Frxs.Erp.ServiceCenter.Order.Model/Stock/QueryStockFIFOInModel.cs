using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model.Stock
{
    public class QueryStockFIFOInModel
    {
        #region Model
        private int _wid;
        private int _subwid;
        private int? _productid;
        private string _sku;      
        private int _flag;        
        
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
        /// 商品ID(Products.ProductID)
        /// </summary>
        public int? ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string SKU
        {
            set { _sku = value; }
            get { return _sku; }
        }   
       
        /// <summary>
        /// 已出货标识(0:未出库;1:已出库)
        /// </summary>
        public int Flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
       
       
        #endregion Model
    }
}
