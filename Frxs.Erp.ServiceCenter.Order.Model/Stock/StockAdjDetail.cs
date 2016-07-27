
/*****************************
* Author:CR
*
* Date:2016-04-15
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
    /// StockAdjDetail实体类
    /// </summary>
    [Serializable]
    [DataContract]
    [DbMap(Name = "StockAdjDetail")]
    public partial class StockAdjDetail : BaseModel
    {

        #region 模型
        private string _ID;
        /// <summary>
        /// 主键(仓库ID+GUID)
        /// </summary>
        [DataMember]
        [DisplayName("主键(仓库ID+GUID)")]

        [Required(ErrorMessage = "ID{0}不能为空")]

        [PrimaryKeyField]

        [DbMap(Name = "ID")]
        public string ID
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

        private int _WID;
        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID)")]

        [Required(ErrorMessage = "仓库ID{0}不能为空")]

        [DbMap(Name = "WID")]
        public int WID
        {
            get
            {
                return _WID;
            }
            set
            {
                _WID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("WID", value));
            }
        }

        private string _AdjID;
        /// <summary>
        /// 盘亏盘赢调整编号(StockAdj.AdjID)
        /// </summary>
        [DataMember]
        [DisplayName("盘亏盘赢调整编号(StockAdj.AdjID)")]

        [Required(ErrorMessage = "盘亏盘赢调整编号{0}不能为空")]

        [DbMap(Name = "AdjID")]
        public string AdjID
        {
            get
            {
                return _AdjID;
            }
            set
            {
                _AdjID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("AdjID", value));
            }
        }

        private int _ProductId;
        /// <summary>
        /// 商品编号(Prouct.ProductID)
        /// </summary>
        [DataMember]
        [DisplayName("商品编号(Prouct.ProductID)")]

        [Required(ErrorMessage = "商品编号{0}不能为空")]

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

        private string _SKU;
        /// <summary>
        /// 商品SKU(商品编码)
        /// </summary>
        [DataMember]
        [DisplayName("商品SKU(商品编码)")]

        [Required(ErrorMessage = "商品编码{0}不能为空")]

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

        private string _ProductName;
        /// <summary>
        /// 描述商品名称(Product.ProductName)
        /// </summary>
        [DataMember]
        [DisplayName("描述商品名称(Product.ProductName)")]

        [Required(ErrorMessage = "{0}不能为空")]

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

        private string _ProductImageUrl200;
        /// <summary>
        /// 商品图片用于移动端(Products.ImageUrl200*200)
        /// </summary>
        [DataMember]
        [DisplayName("商品图片用于移动端(Products.ImageUrl200*200)")]

        [DbMap(Name = "ProductImageUrl200")]
        public string ProductImageUrl200
        {
            get
            {
                return _ProductImageUrl200;
            }
            set
            {
                _ProductImageUrl200 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ProductImageUrl200", value));
            }
        }

        private string _ProductImageUrl400;
        /// <summary>
        /// 商品图片用于PC端(Products.ImageUrl400*400)
        /// </summary>
        [DataMember]
        [DisplayName("商品图片用于PC端(Products.ImageUrl400*400)")]

        [DbMap(Name = "ProductImageUrl400")]
        public string ProductImageUrl400
        {
            get
            {
                return _ProductImageUrl400;
            }
            set
            {
                _ProductImageUrl400 = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ProductImageUrl400", value));
            }
        }

        private string _AdjUnit;
        /// <summary>
        /// 调整单位(j库存单位,预留)
        /// </summary>
        [DataMember]
        [DisplayName("调整单位(j库存单位,预留)")]

        [Required(ErrorMessage = "调整单位{0}不能为空")]

        [DbMap(Name = "AdjUnit")]
        public string AdjUnit
        {
            get
            {
                return _AdjUnit;
            }
            set
            {
                _AdjUnit = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("AdjUnit", value));
            }
        }

        private decimal _AdjPackingQty;
        /// <summary>
        /// 调整单位包装数(固定为1) 2016-6-20 按照会议要求，类型统一由int改成decimal
        /// </summary>
        [DataMember]
        [DisplayName("调整单位包装数(固定为1)")]

        [Required(ErrorMessage = "调整单位包装数{0}不能为空")]

        [DbMap(Name = "AdjPackingQty")]
        public decimal AdjPackingQty
        {
            get
            {
                return _AdjPackingQty;
            }
            set
            {
                _AdjPackingQty = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("AdjPackingQty", value));
            }
        }

        private decimal _AdjQty;
        /// <summary>
        /// 调整数量
        /// </summary>
        [DataMember]
        [DisplayName("调整数量")]

        [Required(ErrorMessage = "调整数量{0}不能为空")]

        [DbMap(Name = "AdjQty")]
        public decimal AdjQty
        {
            get
            {
                return _AdjQty;
            }
            set
            {
                _AdjQty = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("AdjQty", value));
            }
        }

        private string _Unit;
        /// <summary>
        /// 库存单位(WProducts.Unit)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位(WProducts.Unit)")]

        [Required(ErrorMessage = "库存单位{0}不能为空")]

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

        private decimal _UnitQty;
        /// <summary>
        /// 库存单位数量(=AdjQty*AdjPackingQty)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位数量(=AdjQty*AdjPackingQty)")]

        [Required(ErrorMessage = "库存单位数量{0}不能为空")]

        [DbMap(Name = "UnitQty")]
        public decimal UnitQty
        {
            get
            {
                return _UnitQty;
            }
            set
            {
                _UnitQty = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("UnitQty", value));
            }
        }

        private decimal _BuyPrice;
        /// <summary>
        /// (库存单位)采购单价(=WProducts.SalePrice)
        /// </summary>
        [DataMember]
        [DisplayName("(库存单位)采购单价(=WProducts.SalePrice)")]

        [Required(ErrorMessage = "采购单价{0}不能为空")]

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
        /// (库存单位)配送单价(=WProductsBuy.BuyPrice)
        /// </summary>
        [DataMember]
        [DisplayName("(库存单位)配送单价(=WProductsBuy.BuyPrice)")]

        [Required(ErrorMessage = "采购单价{0}不能为空")]

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

        private decimal _AdjAmt;
        /// <summary>
        /// 调整金额(=UnitQty*BuyPrice)
        /// </summary>
        [DataMember]
        [DisplayName("调整金额(=UnitQty*BuyPrice)")]

        [Required(ErrorMessage = "调整金额{0}不能为空")]

        [DbMap(Name = "AdjAmt")]
        public decimal AdjAmt
        {
            get
            {
                return _AdjAmt;
            }
            set
            {
                _AdjAmt = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("AdjAmt", value));
            }
        }

        private int _VendorID;
        /// <summary>
        /// 商品主供应商(=WProductsBuy.VendorID)
        /// </summary>
        [DataMember]
        [DisplayName("商品主供应商(=WProductsBuy.VendorID)")]

        [Required(ErrorMessage = "商品主供应商{0}不能为空")]

        [DbMap(Name = "VendorID")]
        public int VendorID
        {
            get
            {
                return _VendorID;
            }
            set
            {
                _VendorID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("VendorID", value));
            }
        }

        private string _VendorCode;
        /// <summary>
        /// 主供应商编号(Vendor.VendorCode)
        /// </summary>
        [DataMember]
        [DisplayName("主供应商编号(Vendor.VendorCode)")]

        [Required(ErrorMessage = "主供应商编号{0}不能为空")]

        [DbMap(Name = "VendorCode")]
        public string VendorCode
        {
            get
            {
                return _VendorCode;
            }
            set
            {
                _VendorCode = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("VendorCode", value));
            }
        }

        private string _VendorName;
        /// <summary>
        /// 主供应商名称(Vendor.VendorName)
        /// </summary>
        [DataMember]
        [DisplayName("主供应商名称(Vendor.VendorName)")]

        [Required(ErrorMessage = "主供应商名称{0}不能为空")]

        [DbMap(Name = "VendorName")]
        public string VendorName
        {
            get
            {
                return _VendorName;
            }
            set
            {
                _VendorName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("VendorName", value));
            }
        }

        private decimal _StockQty;
        /// <summary>
        /// 盘点时该单位时的子机构的库存(StockQty.StockQty)
        /// </summary>
        [DataMember]
        [DisplayName("盘点时该单位时的子机构的库存(StockQty.StockQty)")]

        [Required(ErrorMessage = "库存{0}不能为空")]

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

        private string _Remark;
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]

        [DbMap(Name = "Remark")]
        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("Remark", value));
            }
        }

        private int _SerialNumber;
        /// <summary>
        /// 序号(输入的序号,每一个单据从1开始)
        /// </summary>
        [DataMember]
        [DisplayName("序号(输入的序号,每一个单据从1开始)")]

        [Required(ErrorMessage = "序号{0}不能为空")]

        [DbMap(Name = "SerialNumber")]
        public int SerialNumber
        {
            get
            {
                return _SerialNumber;
            }
            set
            {
                _SerialNumber = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SerialNumber", value));
            }
        }

        private string _StockCheckID;
        /// <summary>
        /// 盘点单号(StockCheck.StockCheckID)
        /// </summary>
        [DataMember]
        [DisplayName("盘点单号(StockCheck.StockCheckID)")]

        [DbMap(Name = "StockCheckID")]
        public string StockCheckID
        {
            get
            {
                return _StockCheckID;
            }
            set
            {
                _StockCheckID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("StockCheckID", value));
            }
        }

        private string _StockCheckDetailsID;
        /// <summary>
        /// 盘点明细ID(StockCheckDetails.ID)
        /// </summary>
        [DataMember]
        [DisplayName("盘点明细ID(StockCheckDetails.ID)")]

        [DbMap(Name = "StockCheckDetailsID")]
        public string StockCheckDetailsID
        {
            get
            {
                return _StockCheckDetailsID;
            }
            set
            {
                _StockCheckDetailsID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("StockCheckDetailsID", value));
            }
        }

        private int? _CheckUserID;
        /// <summary>
        /// 盘点人员ID
        /// </summary>
        [DataMember]
        [DisplayName("盘点人员ID")]

        [DbMap(Name = "CheckUserID")]
        public int? CheckUserID
        {
            get
            {
                return _CheckUserID;
            }
            set
            {
                _CheckUserID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("CheckUserID", value));
            }
        }

        private string _CheckUserName;
        /// <summary>
        /// 盘点人员姓名
        /// </summary>
        [DataMember]
        [DisplayName("盘点人员姓名")]

        [DbMap(Name = "CheckUserName")]
        public string CheckUserName
        {
            get
            {
                return _CheckUserName;
            }
            set
            {
                _CheckUserName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("CheckUserName", value));
            }
        }

        private decimal? _CheckUnitQty;
        /// <summary>
        /// 盘点库存数量(StockCheckDetails.CheckUnitQty)
        /// </summary>
        [DataMember]
        [DisplayName("盘点库存数量(StockCheckDetails.CheckUnitQty)")]

        [DbMap(Name = "CheckUnitQty")]
        public decimal? CheckUnitQty
        {
            get
            {
                return _CheckUnitQty;
            }
            set
            {
                _CheckUnitQty = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("CheckUnitQty", value));
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

    public partial class StockAdjDetail : BaseModel
    {
        #region 扩展自 StockAdjDetailsExt 的模型
        /// <summary>
        /// 基本分类一级分类ID(Category.CategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("基本分类一级分类ID(Category.CategoryId)")]
        public int? CategoryId1 { get; set; }

        /// <summary>
        /// 基本分类一级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("基本分类一级分类名称")]
        public string CategoryId1Name { get; set; }

        /// <summary>
        /// 基本分类二级分类ID(Category.CategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("基本分类二级分类ID(Category.CategoryId)")]
        public int? CategoryId2 { get; set; }

        /// <summary>
        /// 基本分类二级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("基本分类二级分类名称")]
        public string CategoryId2Name { get; set; }

        /// <summary>
        /// 基本分类三级分类ID(Category.CategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("基本分类三级分类ID(Category.CategoryId)")]
        public int? CategoryId3 { get; set; }

        /// <summary>
        /// 基本分类三级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("基本分类三级分类名称")]
        public string CategoryId3Name { get; set; }

        /// <summary>
        /// 运营一级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("运营一级分类ID(ShopCategory.ShopCategoryId)")]
        public int? ShopCategoryId1 { get; set; }

        /// <summary>
        /// 运营一级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("运营一级分类名称")]
        public string ShopCategoryId1Name { get; set; }

        /// <summary>
        /// 运营二级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("运营二级分类ID(ShopCategory.ShopCategoryId)")]
        public int? ShopCategoryId2 { get; set; }

        /// <summary>
        /// 运营二级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("运营二级分类名称")]
        public string ShopCategoryId2Name { get; set; }

        /// <summary>
        /// 运营三级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("运营三级分类ID(ShopCategory.ShopCategoryId)")]
        public int? ShopCategoryId3 { get; set; }

        /// <summary>
        /// 运营三级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("运营三级分类名称")]
        public string ShopCategoryId3Name { get; set; }

        /// <summary>
        /// 品牌ID
        /// </summary>
        [DataMember]
        [DisplayName("品牌ID")]

        public int? BrandId1 { get; set; }

        /// <summary>
        /// 品牌ID名称
        /// </summary>
        [DataMember]
        [DisplayName("品牌ID名称")]

        public string BrandId1Name { get; set; }

        /// <summary>
        /// 子品牌ID
        /// </summary>
        [DataMember]
        [DisplayName("子品牌ID")]

        public int? BrandId2 { get; set; }

        /// <summary>
        /// 子品牌名称
        /// </summary>
        [DataMember]
        [DisplayName("子品牌名称")]

        public string BrandId2Name { get; set; }

        #endregion
    }

    /// <summary>
    /// 盘点详情表 查询对象
    /// </summary>
    public class StockAdjDetailQuery
    {
        /// <summary>
        /// 盘亏盘赢调整编号(StockAdj.AdjID)
        /// </summary>
        public string AdjID { get; set; }
    }

    /// <summary>
    /// 盘点调整明细表 导入模型
    /// </summary>
    public class StockAdjDetailImportModel
    {
        /// <summary>
        /// 明细表和扩展表 主键(仓库ID+GUID)
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "明细表和扩展表ID{0}不能为空")]
        public string ID { get; set; }
        /// <summary>
        /// Erp编码/商品编码(手工输入)
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "商品编码{0}不能为空")]
        public string SKU { get; set; }
        /// <summary>
        /// 调整数量
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "调整数量{0}不能为空")]
        public decimal AdjQty { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
    }

    /// <summary>
    /// 包含明细表和扩展表的对象，用于盘点调整Excel数据批量导入
    /// </summary>
    [Serializable]
    public class StockAdjDetailWithExt
    {
        /// <summary>
        /// 盘点调整明细表
        /// </summary>
        public StockAdjDetail detail { get; set; }

        /// <summary>
        /// 盘点调整明细扩展表
        /// </summary>
        public StockAdjDetailsExt ext { get; set; }
    }
}