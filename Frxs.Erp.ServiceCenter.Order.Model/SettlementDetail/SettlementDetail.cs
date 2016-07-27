/*****************************
* Author:罗靖
*
* Date:2016-06-17
******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Frxs.Platform.Utility.Filter;

namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// 结算单明细表SettlementDetail实体类
    /// </summary>
    [Serializable]
    [DataContract]
    [DbMap(Name = "SettlementDetail")]
    public partial class SettlementDetail : BaseModel
    {

        #region 模型
        private int _ID;
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        [DisplayName("ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        [PrimaryKeyField(IsIdentity = true)]
        [DbMap(Name = "ID")]
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ID", value));
            }
        }

        private string _RefSet_ID;
        /// <summary>
        /// ID(GUID)结算单主表ID
        /// </summary>
        [DataMember]
        [DisplayName("ID(GUID)结算单主表ID")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "RefSet_ID")]
        public string RefSet_ID
        {
            get
            {
                return _RefSet_ID;
            }
            set
            {
                _RefSet_ID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("RefSet_ID", value));
            }
        }

        private string _SKU;
        /// <summary>
        /// 商品SKU(ERP编码)
        /// </summary>
        [DataMember]
        [DisplayName("商品SKU(ERP编码)")]

        [DbMap(Name = "SKU")]
        public string SKU
        {
            get
            {
                return _SKU;
            }
            set
            {
                _SKU = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SKU", value));
            }
        }

        private int _ProductId;
        /// <summary>
        /// 商品编号(Prouct.ProductID)
        /// </summary>
        [DataMember]
        [DisplayName("商品编号(Prouct.ProductID)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "ProductId")]
        public int ProductId
        {
            get
            {
                return _ProductId;
            }
            set
            {
                _ProductId = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ProductId", value));
            }
        }

        private string _ProductName;
        /// <summary>
        /// 描述商品名称(Product.ProductName)
        /// </summary>
        [DataMember]
        [DisplayName("描述商品名称(Product.ProductName)")]

        [DbMap(Name = "ProductName")]
        public string ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                _ProductName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ProductName", value));
            }
        }

        private string _BarCode;
        /// <summary>
        /// 商品的国际条码
        /// </summary>
        [DataMember]
        [DisplayName("商品的国际条码")]

        [DbMap(Name = "BarCode")]
        public string BarCode
        {
            get
            {
                return _BarCode;
            }
            set
            {
                _BarCode = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("BarCode", value));
            }
        }

        private string _Unit;
        /// <summary>
        /// 库存单位(WProducts.Unit)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位(WProducts.Unit)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "Unit")]
        public string Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                _Unit = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("Unit", value));
            }
        }

        private decimal _BuyPrice;
        /// <summary>
        /// 采购价格
        /// </summary>
        [DataMember]
        [DisplayName("采购价格")]

        [DbMap(Name = "BuyPrice")]
        public decimal BuyPrice
        {
            get
            {
                return _BuyPrice;
            }
            set
            {
                _BuyPrice = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("BuyPrice", value));
            }
        }

        private decimal _SalePrice;
        /// <summary>
        /// 销售价格
        /// </summary>
        [DataMember]
        [DisplayName("销售价格")]

        [DbMap(Name = "SalePrice")]
        public decimal SalePrice
        {
            get
            {
                return _SalePrice;
            }
            set
            {
                _SalePrice = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SalePrice", value));
            }
        }

        private decimal _BeginQty;
        /// <summary>
        /// 期初库存数量
        /// </summary>
        [DataMember]
        [DisplayName("期初库存数量")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "BeginQty")]
        public decimal BeginQty
        {
            get
            {
                return _BeginQty;
            }
            set
            {
                _BeginQty = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("BeginQty", value));
            }
        }

        private decimal _BeginAmt;
        /// <summary>
        /// 期初库存金额
        /// </summary>
        [DataMember]
        [DisplayName("期初库存金额")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "BeginAmt")]
        public decimal BeginAmt
        {
            get
            {
                return _BeginAmt;
            }
            set
            {
                _BeginAmt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("BeginAmt", value));
            }
        }

        private decimal _BuyQty;
        /// <summary>
        /// 采购数量
        /// </summary>
        [DataMember]
        [DisplayName("采购数量")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "BuyQty")]
        public decimal BuyQty
        {
            get
            {
                return _BuyQty;
            }
            set
            {
                _BuyQty = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("BuyQty", value));
            }
        }

        private decimal _BuyAmt;
        /// <summary>
        /// 采购金额
        /// </summary>
        [DataMember]
        [DisplayName("采购金额")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "BuyAmt")]
        public decimal BuyAmt
        {
            get
            {
                return _BuyAmt;
            }
            set
            {
                _BuyAmt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("BuyAmt", value));
            }
        }

        private decimal _BuyBackQty;
        /// <summary>
        /// 采购退货数量
        /// </summary>
        [DataMember]
        [DisplayName("采购退货数量")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "BuyBackQty")]
        public decimal BuyBackQty
        {
            get
            {
                return _BuyBackQty;
            }
            set
            {
                _BuyBackQty = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("BuyBackQty", value));
            }
        }

        private decimal _BuyBackAmt;
        /// <summary>
        /// 采购退货金额
        /// </summary>
        [DataMember]
        [DisplayName("采购退货金额")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "BuyBackAmt")]
        public decimal BuyBackAmt
        {
            get
            {
                return _BuyBackAmt;
            }
            set
            {
                _BuyBackAmt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("BuyBackAmt", value));
            }
        }

        private decimal _SaleQty;
        /// <summary>
        /// 销售数量
        /// </summary>
        [DataMember]
        [DisplayName("销售数量")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "SaleQty")]
        public decimal SaleQty
        {
            get
            {
                return _SaleQty;
            }
            set
            {
                _SaleQty = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SaleQty", value));
            }
        }

        private decimal _SaleAmt;
        /// <summary>
        /// 销售金额
        /// </summary>
        [DataMember]
        [DisplayName("销售金额")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "SaleAmt")]
        public decimal SaleAmt
        {
            get
            {
                return _SaleAmt;
            }
            set
            {
                _SaleAmt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SaleAmt", value));
            }
        }

        private decimal _SaleBackQty;
        /// <summary>
        /// 销售退货数量
        /// </summary>
        [DataMember]
        [DisplayName("销售退货数量")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "SaleBackQty")]
        public decimal SaleBackQty
        {
            get
            {
                return _SaleBackQty;
            }
            set
            {
                _SaleBackQty = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SaleBackQty", value));
            }
        }

        private decimal _SaleBackAmt;
        /// <summary>
        /// 销售退货金额
        /// </summary>
        [DataMember]
        [DisplayName("销售退货金额")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "SaleBackAmt")]
        public decimal SaleBackAmt
        {
            get
            {
                return _SaleBackAmt;
            }
            set
            {
                _SaleBackAmt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SaleBackAmt", value));
            }
        }

        private decimal _AdjGainQty;
        /// <summary>
        /// 盘盈数量
        /// </summary>
        [DataMember]
        [DisplayName("盘盈数量")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "AdjGainQty")]
        public decimal AdjGainQty
        {
            get
            {
                return _AdjGainQty;
            }
            set
            {
                _AdjGainQty = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("AdjGainQty", value));
            }
        }

        private decimal _AjgGginAmt;
        /// <summary>
        /// 盘盈金额
        /// </summary>
        [DataMember]
        [DisplayName("盘盈金额")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "AjgGginAmt")]
        public decimal AjgGginAmt
        {
            get
            {
                return _AjgGginAmt;
            }
            set
            {
                _AjgGginAmt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("AjgGginAmt", value));
            }
        }

        private decimal _AdjLossQty;
        /// <summary>
        /// 盘亏数量
        /// </summary>
        [DataMember]
        [DisplayName("盘亏数量")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "AdjLossQty")]
        public decimal AdjLossQty
        {
            get
            {
                return _AdjLossQty;
            }
            set
            {
                _AdjLossQty = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("AdjLossQty", value));
            }
        }

        private decimal _AjgLosssAmt;
        /// <summary>
        /// 盘亏金额
        /// </summary>
        [DataMember]
        [DisplayName("盘亏金额")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "AjgLosssAmt")]
        public decimal AjgLosssAmt
        {
            get
            {
                return _AjgLosssAmt;
            }
            set
            {
                _AjgLosssAmt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("AjgLosssAmt", value));
            }
        }

        private decimal _StockQty;
        /// <summary>
        /// 库存数量
        /// </summary>
        [DataMember]
        [DisplayName("库存数量")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "StockQty")]
        public decimal StockQty
        {
            get
            {
                return _StockQty;
            }
            set
            {
                _StockQty = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("StockQty", value));
            }
        }

        private decimal _StockAmt;
        /// <summary>
        /// 库存金额
        /// </summary>
        [DataMember]
        [DisplayName("库存金额")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "StockAmt")]
        public decimal StockAmt
        {
            get
            {
                return _StockAmt;
            }
            set
            {
                _StockAmt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("StockAmt", value));
            }
        }

        private decimal _EndQty;
        /// <summary>
        /// 期末库存数量
        /// </summary>
        [DataMember]
        [DisplayName("期末库存数量")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "EndQty")]
        public decimal EndQty
        {
            get
            {
                return _EndQty;
            }
            set
            {
                _EndQty = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("EndQty", value));
            }
        }

        private decimal _EndStockAmt;
        /// <summary>
        /// 期末库存金额
        /// </summary>
        [DataMember]
        [DisplayName("期末库存金额")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "EndStockAmt")]
        public decimal EndStockAmt
        {
            get
            {
                return _EndStockAmt;
            }
            set
            {
                _EndStockAmt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("EndStockAmt", value));
            }
        }

        private decimal _EndDiffQty;
        /// <summary>
        /// 差异数量(库存数量-期末库存数量)
        /// </summary>
        [DataMember]
        [DisplayName("差异数量(库存数量-期末库存数量)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "EndDiffQty")]
        public decimal EndDiffQty
        {
            get
            {
                return _EndDiffQty;
            }
            set
            {
                _EndDiffQty = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("EndDiffQty", value));
            }
        }

        private decimal _EndDiffStockAmt;
        /// <summary>
        /// 差异金额(库存金额-期末库存金额)
        /// </summary>
        [DataMember]
        [DisplayName("差异金额(库存金额-期末库存金额)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "EndDiffStockAmt")]
        public decimal EndDiffStockAmt
        {
            get
            {
                return _EndDiffStockAmt;
            }
            set
            {
                _EndDiffStockAmt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("EndDiffStockAmt", value));
            }
        }

        private decimal _SaleSubBasePoint;
        /// <summary>
        /// 销售绩效积分
        /// </summary>
        [DataMember]
        [DisplayName("销售绩效积分")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "SaleSubBasePoint")]
        public decimal SaleSubBasePoint
        {
            get
            {
                return _SaleSubBasePoint;
            }
            set
            {
                _SaleSubBasePoint = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SaleSubBasePoint", value));
            }
        }

        private decimal _SaleSubPoint;
        /// <summary>
        /// 销售门店积分
        /// </summary>
        [DataMember]
        [DisplayName("销售门店积分")]

        [DbMap(Name = "SaleSubPoint")]
        public decimal SaleSubPoint
        {
            get
            {
                return _SaleSubPoint;
            }
            set
            {
                _SaleSubPoint = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SaleSubPoint", value));
            }
        }

        private decimal _SaleSubAddAmt;
        /// <summary>
        /// 销售平台费用
        /// </summary>
        [DataMember]
        [DisplayName("销售平台费用")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "SaleSubAddAmt")]
        public decimal SaleSubAddAmt
        {
            get
            {
                return _SaleSubAddAmt;
            }
            set
            {
                _SaleSubAddAmt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SaleSubAddAmt", value));
            }
        }

        private decimal _SaleSubVendor1Amt;
        /// <summary>
        /// 销售供应商物流费
        /// </summary>
        [DataMember]
        [DisplayName("销售供应商物流费")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "SaleSubVendor1Amt")]
        public decimal SaleSubVendor1Amt
        {
            get
            {
                return _SaleSubVendor1Amt;
            }
            set
            {
                _SaleSubVendor1Amt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SaleSubVendor1Amt", value));
            }
        }

        private decimal _SaleSubVendor2Amt;
        /// <summary>
        /// 销售供应商仓储费
        /// </summary>
        [DataMember]
        [DisplayName("销售供应商仓储费")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "SaleSubVendor2Amt")]
        public decimal SaleSubVendor2Amt
        {
            get
            {
                return _SaleSubVendor2Amt;
            }
            set
            {
                _SaleSubVendor2Amt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SaleSubVendor2Amt", value));
            }
        }

        private decimal _BackSubAddAmt;
        /// <summary>
        /// 退货平台费用
        /// </summary>
        [DataMember]
        [DisplayName("退货平台费用")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "BackSubAddAmt")]
        public decimal BackSubAddAmt
        {
            get
            {
                return _BackSubAddAmt;
            }
            set
            {
                _BackSubAddAmt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("BackSubAddAmt", value));
            }
        }

        private decimal _BackSubVendor1Amt;
        /// <summary>
        /// 退货供应商物流费
        /// </summary>
        [DataMember]
        [DisplayName("退货供应商物流费")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "BackSubVendor1Amt")]
        public decimal BackSubVendor1Amt
        {
            get
            {
                return _BackSubVendor1Amt;
            }
            set
            {
                _BackSubVendor1Amt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("BackSubVendor1Amt", value));
            }
        }

        private decimal _BackSubVendor2Amt;
        /// <summary>
        /// 退货供应商仓储费
        /// </summary>
        [DataMember]
        [DisplayName("退货供应商仓储费")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "BackSubVendor2Amt")]
        public decimal BackSubVendor2Amt
        {
            get
            {
                return _BackSubVendor2Amt;
            }
            set
            {
                _BackSubVendor2Amt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("BackSubVendor2Amt", value));
            }
        }

        private int _CategoryId1;
        /// <summary>
        /// 基本分类一级分类ID(Category.CategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("基本分类一级分类ID(Category.CategoryId)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "CategoryId1")]
        public int CategoryId1
        {
            get
            {
                return _CategoryId1;
            }
            set
            {
                _CategoryId1 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("CategoryId1", value));
            }
        }

        private string _CategoryId1Name;
        /// <summary>
        /// 基本分类一级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("基本分类一级分类名称")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "CategoryId1Name")]
        public string CategoryId1Name
        {
            get
            {
                return _CategoryId1Name;
            }
            set
            {
                _CategoryId1Name = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("CategoryId1Name", value));
            }
        }

        private int _CategoryId2;
        /// <summary>
        /// 基本分类二级分类ID(Category.CategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("基本分类二级分类ID(Category.CategoryId)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "CategoryId2")]
        public int CategoryId2
        {
            get
            {
                return _CategoryId2;
            }
            set
            {
                _CategoryId2 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("CategoryId2", value));
            }
        }

        private string _CategoryId2Name;
        /// <summary>
        /// 基本分类二级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("基本分类二级分类名称")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "CategoryId2Name")]
        public string CategoryId2Name
        {
            get
            {
                return _CategoryId2Name;
            }
            set
            {
                _CategoryId2Name = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("CategoryId2Name", value));
            }
        }

        private int _CategoryId3;
        /// <summary>
        /// 基本分类三级分类ID(Category.CategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("基本分类三级分类ID(Category.CategoryId)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "CategoryId3")]
        public int CategoryId3
        {
            get
            {
                return _CategoryId3;
            }
            set
            {
                _CategoryId3 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("CategoryId3", value));
            }
        }

        private string _CategoryId3Name;
        /// <summary>
        /// 基本分类三级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("基本分类三级分类名称")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "CategoryId3Name")]
        public string CategoryId3Name
        {
            get
            {
                return _CategoryId3Name;
            }
            set
            {
                _CategoryId3Name = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("CategoryId3Name", value));
            }
        }

        private int _ShopCategoryId1;
        /// <summary>
        /// 运营一级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("运营一级分类ID(ShopCategory.ShopCategoryId)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "ShopCategoryId1")]
        public int ShopCategoryId1
        {
            get
            {
                return _ShopCategoryId1;
            }
            set
            {
                _ShopCategoryId1 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ShopCategoryId1", value));
            }
        }

        private string _ShopCategoryId1Name;
        /// <summary>
        /// 运营一级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("运营一级分类名称")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "ShopCategoryId1Name")]
        public string ShopCategoryId1Name
        {
            get
            {
                return _ShopCategoryId1Name;
            }
            set
            {
                _ShopCategoryId1Name = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ShopCategoryId1Name", value));
            }
        }

        private int _ShopCategoryId2;
        /// <summary>
        /// 运营二级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("运营二级分类ID(ShopCategory.ShopCategoryId)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "ShopCategoryId2")]
        public int ShopCategoryId2
        {
            get
            {
                return _ShopCategoryId2;
            }
            set
            {
                _ShopCategoryId2 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ShopCategoryId2", value));
            }
        }

        private string _ShopCategoryId2Name;
        /// <summary>
        /// 运营二级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("运营二级分类名称")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "ShopCategoryId2Name")]
        public string ShopCategoryId2Name
        {
            get
            {
                return _ShopCategoryId2Name;
            }
            set
            {
                _ShopCategoryId2Name = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ShopCategoryId2Name", value));
            }
        }

        private int _ShopCategoryId3;
        /// <summary>
        /// 运营三级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("运营三级分类ID(ShopCategory.ShopCategoryId)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "ShopCategoryId3")]
        public int ShopCategoryId3
        {
            get
            {
                return _ShopCategoryId3;
            }
            set
            {
                _ShopCategoryId3 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ShopCategoryId3", value));
            }
        }

        private string _ShopCategoryId3Name;
        /// <summary>
        /// 运营三级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("运营三级分类名称")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "ShopCategoryId3Name")]
        public string ShopCategoryId3Name
        {
            get
            {
                return _ShopCategoryId3Name;
            }
            set
            {
                _ShopCategoryId3Name = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ShopCategoryId3Name", value));
            }
        }

        private int? _BrandId1;
        /// <summary>
        /// 品牌ID
        /// </summary>
        [DataMember]
        [DisplayName("品牌ID")]

        [DbMap(Name = "BrandId1")]
        public int? BrandId1
        {
            get
            {
                return _BrandId1;
            }
            set
            {
                _BrandId1 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("BrandId1", value));
            }
        }

        private string _BrandId1Name;
        /// <summary>
        /// 品牌ID名称
        /// </summary>
        [DataMember]
        [DisplayName("品牌ID名称")]

        [DbMap(Name = "BrandId1Name")]
        public string BrandId1Name
        {
            get
            {
                return _BrandId1Name;
            }
            set
            {
                _BrandId1Name = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("BrandId1Name", value));
            }
        }

        private int? _BrandId2;
        /// <summary>
        /// 子品牌ID
        /// </summary>
        [DataMember]
        [DisplayName("子品牌ID")]

        [DbMap(Name = "BrandId2")]
        public int? BrandId2
        {
            get
            {
                return _BrandId2;
            }
            set
            {
                _BrandId2 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("BrandId2", value));
            }
        }

        private string _BrandId2Name;
        /// <summary>
        /// 子品牌名称
        /// </summary>
        [DataMember]
        [DisplayName("子品牌名称")]

        [DbMap(Name = "BrandId2Name")]
        public string BrandId2Name
        {
            get
            {
                return _BrandId2Name;
            }
            set
            {
                _BrandId2Name = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("BrandId2Name", value));
            }
        }

        private DateTime _ModifyTime;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        [DisplayName("最后修改时间")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "ModifyTime")]
        public DateTime ModifyTime
        {
            get
            {
                return _ModifyTime;
            }
            set
            {
                _ModifyTime = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ModifyTime", value));
            }
        }

        private int? _ModifyUserID;
        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户ID")]

        [DbMap(Name = "ModifyUserID")]
        public int? ModifyUserID
        {
            get
            {
                return _ModifyUserID;
            }
            set
            {
                _ModifyUserID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ModifyUserID", value));
            }
        }

        private string _ModifyUserName;
        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户名称")]

        [DbMap(Name = "ModifyUserName")]
        public string ModifyUserName
        {
            get
            {
                return _ModifyUserName;
            }
            set
            {
                _ModifyUserName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ModifyUserName", value));
            }
        }

        #endregion
    }

    /// <summary>
    /// 明细查询对象
    /// </summary>
    public class SettlementDetailQuery
    {

    }

    /// <summary>
    /// 存储过程P_GETProductStockData的传入参数（内部参数)
    /// </summary>
    public class GetProductStockQuery
    {
        ///<summary>
        /// 仓库编号
        /// </summary>
        public int Wid { get; set; }

        /// <summary>
        /// 子仓库编号
        /// </summary>
        public int SubWid { get; set; }

        /// <summary>
        /// 日结开始时间
        /// </summary>
        public string SettleStartTime { get; set; }

        /// <summary>
        /// 日结结束时间
        /// </summary>
        public string SettleEndTime { get; set; }

    }


    /// <summary>
    /// 存储过程P_GETProductStockData的传入参数（内部参数)
    /// </summary>
    public class GetUpdateBillQuery
    {
        ///<summary>
        /// 仓库编号
        /// </summary>
        public int Wid { get; set; }

        /// <summary>
        /// 子仓库编号
        /// </summary>
        public int SubWid { get; set; }

        /// <summary>
        /// 日结编号
        /// </summary>
        public string SettID { get; set; }

    }
}