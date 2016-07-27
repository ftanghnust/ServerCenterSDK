
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
    /// StockAdjDetailsExt实体类
    /// </summary>
    [Serializable]
    [DataContract]
    [DbMap(Name = "StockAdjDetailsExt")]
    public partial class StockAdjDetailsExt : BaseModel
    {

        #region 模型
        private string _ID;
        /// <summary>
        /// 编号(StockAdjDetails.ID)
        /// </summary>
        [DataMember]
        [DisplayName("编号(StockAdjDetails.ID)")]

        [Required(ErrorMessage = "编号{0}不能为空")]

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

        private string _AdjID;
        /// <summary>
        /// 调整ID(WID+ ID服务)
        /// </summary>
        [DataMember]
        [DisplayName("调整ID(WID+ ID服务)")]

        [Required(ErrorMessage = "调整单号{0}不能为空")]

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

        private int _CategoryId1;
        /// <summary>
        /// 基本分类一级分类ID(Category.CategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("基本分类一级分类ID(Category.CategoryId)")]

        [Required(ErrorMessage = "基本分类一级分类ID{0}不能为空")]

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

        [Required(ErrorMessage = "基本分类一级分类名称{0}不能为空")]

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

        [Required(ErrorMessage = "基本分类二级分类ID{0}不能为空")]

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

        [Required(ErrorMessage = "基本分类二级分类名称{0}不能为空")]

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

        [Required(ErrorMessage = "基本分类三级分类ID{0}不能为空")]

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

        [Required(ErrorMessage = "基本分类三级分类名称{0}不能为空")]

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

        [Required(ErrorMessage = "运营一级分类ID{0}不能为空")]

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

        [Required(ErrorMessage = "运营一级分类名称{0}不能为空")]

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

        [Required(ErrorMessage = "运营二级分类ID{0}不能为空")]

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

        [Required(ErrorMessage = "运营二级分类名称{0}不能为空")]

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

        [Required(ErrorMessage = "运营三级分类ID{0}不能为空")]

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

        [Required(ErrorMessage = "运营三级分类名称{0}不能为空")]

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

        [Required(ErrorMessage = "最后修改时间{0}不能为空")]

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
    /// StockAdjDetailsExt 查询对象
    /// </summary>
    public class StockAdjDetailsExtQuery
    {
        /// <summary>
        /// 盘盈/亏单号
        /// </summary>
        public string AdjID { get; set; }
    }
}