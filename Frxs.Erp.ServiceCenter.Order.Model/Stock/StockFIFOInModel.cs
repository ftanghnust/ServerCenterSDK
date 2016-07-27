
using System;
namespace Frxs.Erp.ServiceCenter.Order.Model.Stock
{
	/// <summary>
	/// 库存先出算法入表
	/// </summary>
	[Serializable]
	public partial class StockFIFOInModel
	{
        public StockFIFOInModel()
		{}
		#region Model
		private long _inid;
		private string _batchno;
		private int _wid;
		private string _wcode;
		private string _wname;
		private int _subwid;
		private string _subwname;
		private int _productid;
		private string _sku;
		private string _productname;
		private decimal _stockqty;
		private int _billtype;
		private string _billid;
		private string _billdetailid;
		private string _unit;
		private decimal _qty;
		private decimal _totaloutqty;
		private int _flag;
		private int _vendorid;
		private string _vendorcode;
		private string _vendorname;
		private decimal _inprice;
        private DateTime _stocktime;
		private DateTime _modifytime;
		/// <summary>
		/// 主键
		/// </summary>
		public long InID
		{
			set{ _inid=value;}
			get{return _inid;}
		}
		/// <summary>
		/// 批次号(批次号)(ID_SERVICE_BATCHNO.ID)
		/// </summary>
		public string BatchNO
		{
			set{ _batchno=value;}
			get{return _batchno;}
		}
		/// <summary>
		/// 仓库ID(Warehouse.WID)
		/// </summary>
		public int WID
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 仓库编号
		/// </summary>
		public string WCode
		{
			set{ _wcode=value;}
			get{return _wcode;}
		}
		/// <summary>
		/// 仓库名称
		/// </summary>
		public string WName
		{
			set{ _wname=value;}
			get{return _wname;}
		}
		/// <summary>
		/// 仓库柜台ID(Warehouse.WID)
		/// </summary>
		public int SubWID
		{
			set{ _subwid=value;}
			get{return _subwid;}
		}
		/// <summary>
		/// 柜台名称
		/// </summary>
		public string SubWName
		{
			set{ _subwname=value;}
			get{return _subwname;}
		}
		/// <summary>
		/// 商品ID(Products.ProductID)
		/// </summary>
		public int ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 商品编码
		/// </summary>
		public string SKU
		{
			set{ _sku=value;}
			get{return _sku;}
		}
		/// <summary>
		/// 商品名称
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 库存原型数量表
		/// </summary>
		public decimal StockQty
		{
			set{ _stockqty=value;}
			get{return _stockqty;}
		}
		/// <summary>
		/// 单据类型(0：采购入库;1:销售退货;2:盘盈)
		/// </summary>
		public int BillType
		{
			set{ _billtype=value;}
			get{return _billtype;}
		}
		/// <summary>
		/// 单据ID
		/// </summary>
		public string BillID
		{
			set{ _billid=value;}
			get{return _billid;}
		}
		/// <summary>
		/// 单据ID明细ID
		/// </summary>
		public string BillDetailID
		{
			set{ _billdetailid=value;}
			get{return _billdetailid;}
		}
		/// <summary>
		/// 库存单位
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 入库库存单位商品数量
		/// </summary>
		public decimal Qty
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		/// <summary>
		/// 已出库库存单位商品数量
		/// </summary>
		public decimal TotalOutQty
		{
			set{ _totaloutqty=value;}
			get{return _totaloutqty;}
		}
		/// <summary>
		/// 已出货标识(0:未出库;1:已出库)
		/// </summary>
		public int Flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		/// <summary>
		/// 供应商ID
		/// </summary>
		public int VendorID
		{
			set{ _vendorid=value;}
			get{return _vendorid;}
		}
		/// <summary>
		/// 供应商编号
		/// </summary>
		public string VendorCode
		{
			set{ _vendorcode=value;}
			get{return _vendorcode;}
		}
		/// <summary>
		/// 供应商名称
		/// </summary>
		public string VendorName
		{
			set{ _vendorname=value;}
			get{return _vendorname;}
		}
		/// <summary>
		/// 入库价格
		/// </summary>
		public decimal InPrice
		{
			set{ _inprice=value;}
			get{return _inprice;}
		}
		/// <summary>
		/// 入库时间
		/// </summary>
        public DateTime StockTime
		{
			set{ _stocktime=value;}
			get{return _stocktime;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime ModifyTime
		{
			set{ _modifytime=value;}
			get{return _modifytime;}
		}
		#endregion Model

	}
}

