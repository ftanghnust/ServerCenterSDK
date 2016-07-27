using System;
namespace Frxs.Erp.ServiceCenter.Order.Model.Stock
{
	/// <summary>
	/// 库存先出算法出表
	/// </summary>
	[Serializable]
	public partial class StockFIFOOutModel
	{
		public StockFIFOOutModel()
		{}
		#region Model
		private long _outid;
		private long _inid;
		private int _wid;
		private int _subwid;
		private int _productid;
		private decimal _stockqty;
		private int _billtype;
		private string _billid;
		private string _billdetailid;
		private decimal _outqty;
		private int _vendorid;
		private DateTime _stocktime;
		/// <summary>
		/// 主键(仓库ID+GUID)
		/// </summary>
		public long OutID
		{
			set{ _outid=value;}
			get{return _outid;}
		}
		/// <summary>
		/// 主键(批次号 StockFIFOIn.InID)
		/// </summary>
		public long InID
		{
			set{ _inid=value;}
			get{return _inid;}
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
		/// 仓库柜台ID(Warehouse.WID)
		/// </summary>
		public int SubWID
		{
			set{ _subwid=value;}
			get{return _subwid;}
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
		/// 库存单位数量表
		/// </summary>
		public decimal StockQty
		{
			set{ _stockqty=value;}
			get{return _stockqty;}
		}
		/// <summary>
		/// 单据类型(3：采购退库;4:销售出货;5:盘亏)
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
		/// 出库库存单位商品数量
		/// </summary>
		public decimal OutQty
		{
			set{ _outqty=value;}
			get{return _outqty;}
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
		/// 出库时间
		/// </summary>
		public DateTime StockTime
		{
			set{ _stocktime=value;}
			get{return _stocktime;}
		}
		#endregion Model

	}
}

