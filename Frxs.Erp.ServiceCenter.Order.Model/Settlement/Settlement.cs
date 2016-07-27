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
    /// Settlement实体类
    /// </summary>
    [Serializable]
    [DataContract]
    [DbMap(Name = "Settlement")]
    public partial class Settlement : BaseModel
    {

        #region 模型
        private string _ID;
        /// <summary>
        /// ID(GUID)
        /// </summary>
        [DataMember]
        [DisplayName("ID(GUID)")]

        [Required(ErrorMessage = "{0}不能为空")]

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

        private string _SettleNo;
        /// <summary>
        /// 结算单号(仓库编码+yyyyMMdd)
        /// </summary>
        [DataMember]
        [DisplayName("结算单号(仓库编码+yyyyMMdd)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "SettleNo")]
        public string SettleNo
        {
            get
            {
                return _SettleNo;
            }
            set
            {
                _SettleNo = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SettleNo", value));
            }
        }

        private int _Status;
        /// <summary>
        /// 状态(默认)
        /// </summary>
        [DataMember]
        [DisplayName("状态(默认)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "Status")]
        public int Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("Status", value));
            }
        }

        private int _WID;
        /// <summary>
        /// 仓库ID
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID")]

        [Required(ErrorMessage = "{0}不能为空")]

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

        private string _WCode;
        /// <summary>
        /// 仓库编号
        /// </summary>
        [DataMember]
        [DisplayName("仓库编号")]

        [DbMap(Name = "WCode")]
        public string WCode
        {
            get
            {
                return _WCode;
            }
            set
            {
                _WCode = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("WCode", value));
            }
        }

        private string _WName;
        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        [DisplayName("仓库名称")]
        [DbMap(Name = "WName")]
        public string WName
        {
            get
            {
                return _WName;
            }
            set
            {
                _WName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("WName", value));
            }
        }

        private int _SubWID;
        /// <summary>
        /// 子机构ID
        /// </summary>
        [DataMember]
        [DisplayName("子机构ID")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "SubWID")]
        public int SubWID
        {
            get
            {
                return _SubWID;
            }
            set
            {
                _SubWID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SubWID", value));
            }
        }

        private string _SubWCode;
        /// <summary>
        /// 子机构编号
        /// </summary>
        [DataMember]
        [DisplayName("子机构编号")]

        [DbMap(Name = "SubWCode")]
        public string SubWCode
        {
            get
            {
                return _SubWCode;
            }
            set
            {
                _SubWCode = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SubWCode", value));
            }
        }

        private string _SubWName;
        /// <summary>
        /// 子机构名称
        /// </summary>
        [DataMember]
        [DisplayName("子机构名称")]

        [DbMap(Name = "SubWName")]
        public string SubWName
        {
            get
            {
                return _SubWName;
            }
            set
            {
                _SubWName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SubWName", value));
            }
        }

        private DateTime _SettleDate;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "SettleDate")]
        public DateTime SettleDate
        {
            get
            {
                return _SettleDate;
            }
            set
            {
                _SettleDate = value;
                base.SetChangedProperties("SettleDate", value);
            }
        }

        private DateTime _SettleStartTime;
        /// <summary>
        /// 结算开始时间
        /// </summary>
        [DataMember]
        [DisplayName("结算开始时间")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "SettleStartTime")]
        public DateTime SettleStartTime
        {
            get
            {
                return _SettleStartTime;
            }
            set
            {
                _SettleStartTime = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SettleStartTime", value));
            }
        }

        private DateTime _SettleEndTime;
        /// <summary>
        /// 结算结束时间
        /// </summary>
        [DataMember]
        [DisplayName("结算结束时间")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "SettleEndTime")]
        public DateTime SettleEndTime
        {
            get
            {
                return _SettleEndTime;
            }
            set
            {
                _SettleEndTime = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("SettleEndTime", value));
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

        [Required(ErrorMessage = "{0}不能为空")]

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

        private DateTime _CreateTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "CreateTime")]
        public DateTime CreateTime
        {
            get
            {
                return _CreateTime;
            }
            set
            {
                _CreateTime = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("CreateTime", value));
            }
        }

        private int? _CreateUserID;
        /// <summary>
        /// 创建用户ID
        /// </summary>
        [DataMember]
        [DisplayName("创建用户ID")]

        [DbMap(Name = "CreateUserID")]
        public int? CreateUserID
        {
            get
            {
                return _CreateUserID;
            }
            set
            {
                _CreateUserID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("CreateUserID", value));
            }
        }

        private string _CreateUserName;
        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]

        [DbMap(Name = "CreateUserName")]
        public string CreateUserName
        {
            get
            {
                return _CreateUserName;
            }
            set
            {
                _CreateUserName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("CreateUserName", value));
            }
        }

        private DateTime? _ModifyTime;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        [DisplayName("最后修改时间")]

        [DbMap(Name = "ModifyTime")]
        public DateTime? ModifyTime
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

        #endregion
    }

    /// <summary>
    /// Settlement 实体 龙武
    /// </summary>
    public partial class Settlement
    {
        /// <summary>
        /// 执行仓库
        /// </summary>
        [DataMember]
        public string WorkStockName { get; set; }

        /// <summary>
        /// 是否执行
        /// </summary>
        [DataMember]
        public string IsWork { get; set; }

        /// <summary>
        /// 执行方式
        /// </summary>
        [DataMember]
        public string StatusName { get; set; }
    }

    /// <summary>
    /// 查询对象
    /// </summary>
    public class SettlementQuery
    {
        /// <summary>
        /// 仓库编号
        /// </summary>
        public int Wid { get; set; }


        /// <summary>
        /// 子仓库编号
        /// </summary>
        public int SubWid { get; set; }


        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime SettleDate { get; set; }

    }
}

