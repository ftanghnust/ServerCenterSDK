using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model.Stock
{
    /// <summary>
    /// 查询库存信息条件定义
    /// </summary>
    public partial class StockQtyQueryModel
    {
        public StockQtyQueryModel()
        { }
        #region Model
        private int? _id;
        private int? _wid;
        private int? _productid;
        private long? _wproductid;
        private int? _subwid;
        private decimal? _stockqty;

        /// <summary>
        /// 主键ID
        /// </summary>
        public int? ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public int? WID
        {
            set { _wid = value; }
            get { return _wid; }
        }
        /// <summary>
        /// 商品ID(product.ProductID)
        /// </summary>
        public int? ProductId
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 仓库商品ID（WProducts.ID）
        /// </summary>
        public long? WProductID
        {
            set { _wproductid = value; }
            get { return _wproductid; }
        }
        /// <summary>
        /// 仓库子机构ID
        /// </summary>
        public int? SubWID
        {
            set { _subwid = value; }
            get { return _subwid; }
        }
        /// <summary>
        /// 库存单位库存数量
        /// </summary>
        public decimal? StockQty
        {
            set { _stockqty = value; }
            get { return _stockqty; }
        }
        #endregion Model

        /// <summary>
        /// 商品ID列表
        /// </summary>
        public List<int> ProductList { get; set; }
    }

}
