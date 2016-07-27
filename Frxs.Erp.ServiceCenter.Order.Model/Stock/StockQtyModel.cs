using System;
namespace Frxs.Erp.ServiceCenter.Order.Model.Stock
{
	/// <summary>
	/// 仓库商品库存记录表
	/// </summary>
	[Serializable]
	public partial class StockQtyModel
	{
		public StockQtyModel()
		{}		
		#region Model
		private int _id;
		private int _wid;
		private int _productid;
		private string _sku;
		private string _productname;
		private long? _wproductid;
		private int _subwid;
		private decimal _stockqty;
		private decimal _saletranqty;
		private decimal _buytranqty;
		private DateTime _updatestocktime;
		private decimal? _lastcheckqty;
		private DateTime? _lastchecktime;
		private DateTime _createtime;
		private int? _createuserid;
		private string _createusername;
		private DateTime? _modifytime;
		private int? _modifyuserid;
		private string _modifyusername;
		/// <summary>
		/// 主键ID(WID+GUID)
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 仓库ID
		/// </summary>
		public int WID
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 商品ID(product.ProductID)
		/// </summary>
		public int ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SKU
		{
			set{ _sku=value;}
			get{return _sku;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 仓库商品ID（WProducts.ID）
		/// </summary>
		public long? WProductID
		{
			set{ _wproductid=value;}
			get{return _wproductid;}
		}
		/// <summary>
		/// 仓库子机构ID
		/// </summary>
		public int SubWID
		{
			set{ _subwid=value;}
			get{return _subwid;}
		}
		/// <summary>
		/// 库存单位库存数量
		/// </summary>
		public decimal StockQty
		{
			set{ _stockqty=value;}
			get{return _stockqty;}
		}
		/// <summary>
		/// 库存单位销售在途数量(订单确认后,更新销售在途数量)
		/// </summary>
		public decimal SaleTranQty
		{
			set{ _saletranqty=value;}
			get{return _saletranqty;}
		}
		/// <summary>
		/// 库存单位采购在途数量(预留)
		/// </summary>
		public decimal BuyTranQty
		{
			set{ _buytranqty=value;}
			get{return _buytranqty;}
		}
		/// <summary>
		/// 最后更新库存时间
		/// </summary>
		public DateTime UpdateStockTime
		{
			set{ _updatestocktime=value;}
			get{return _updatestocktime;}
		}
		/// <summary>
		/// 最后盘点数量(盘点更新库存时更新)
		/// </summary>
		public decimal? LastCheckQty
		{
			set{ _lastcheckqty=value;}
			get{return _lastcheckqty;}
		}
		/// <summary>
		/// 最后盘点确认时间(盘点更新库存时更新)
		/// </summary>
		public DateTime? LastCheckTime
		{
			set{ _lastchecktime=value;}
			get{return _lastchecktime;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 创建用户ID
		/// </summary>
		public int? CreateUserID
		{
			set{ _createuserid=value;}
			get{return _createuserid;}
		}
		/// <summary>
		/// 创建用户名称
		/// </summary>
		public string CreateUserName
		{
			set{ _createusername=value;}
			get{return _createusername;}
		}
		/// <summary>
		/// 最新修改删除时间
		/// </summary>
		public DateTime? ModifyTime
		{
			set{ _modifytime=value;}
			get{return _modifytime;}
		}
		/// <summary>
		/// 最后修改删除用户ID
		/// </summary>
		public int? ModifyUserID
		{
			set{ _modifyuserid=value;}
			get{return _modifyuserid;}
		}
		/// <summary>
		/// 最后修改删除用户名称
		/// </summary>
		public string ModifyUserName
		{
			set{ _modifyusername=value;}
			get{return _modifyusername;}
		}
		#endregion Model
	}
}

