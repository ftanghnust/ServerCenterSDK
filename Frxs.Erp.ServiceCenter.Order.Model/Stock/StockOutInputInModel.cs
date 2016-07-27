using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model.Stock
{
    public class StockOutInPutInModel
    {
        public StockOutInPutInModel()
		{}
		#region Model
		private int _productid;

        private string _sKU;

        public string SKU
        {
            get { return _sKU; }
            set { _sKU = value; }
        }

		private decimal _outqty;
        private string _billdetailid;
        /// <summary>
        /// 单据ID明细ID
        /// </summary>
        public string BillDetailID
        {
            set { _billdetailid = value; }
            get { return _billdetailid; }
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
		/// 出库库存单位商品数量
		/// </summary>
		public decimal OutQty
		{
			set{ _outqty=value;}
			get{return _outqty;}
		}
		#endregion Model

        private StockOutInPutInModelOther baseData;

        public StockOutInPutInModelOther BaseData
        {
            get { return baseData; }
            set { baseData = value; }
        }
    }

    public class StockOutInPutInModelOther
    {
        #region 模型      

        public string ItemID { get; set; }

        /// <summary>
        /// 描述商品名称(Product.ProductName)
        /// </summary>       
        public string ProductName { get; set; }

        /// <summary>
        /// 商品的国际条码
        /// </summary>      
        public string BarCode { get; set; }

        /// <summary>
        /// 商品图片用于移动端(Products.ImageUrl200*200)
        /// </summary>
        public string ProductImageUrl200 { get; set; }

        /// <summary>
        /// 商品图片用于PC端(Products.ImageUrl400*400)
        /// </summary>
        public string ProductImageUrl400 { get; set; }

        /// <summary>
        /// 仓库商品主键ID（WCProduct.WCProductID）
        /// </summary>
        public int WCProductID { get; set; }
     
        /// <summary>
        /// 配送(销售)单位
        /// </summary>    
        public string SaleUnit { get; set; }

        /// <summary>
        /// 配送(销售)单位包装数
        /// </summary>
        public decimal SalePackingQty { get; set; }

        /// <summary>
        /// 配送(销售)单位价格(=ifnull(PromotionPrice,UnitPrice) *SalePackingQty)
        /// </summary>
        public decimal SalePrice { get; set; }

      
        /// <summary>
        /// 库存单位(WProducts.Unit)
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 库存单位价格(SalePrice/SalePackingQty,四舍五入到4位小数)
        /// </summary>
        public decimal UnitPrice { get; set; }       
        #endregion
    }
}
