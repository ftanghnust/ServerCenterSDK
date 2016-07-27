
/*****************************
* Author:CR
*
* Date:2016-04-14
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
    /// StockAdj实体类
    /// </summary>
    [Serializable]
    [DataContract]
    [DbMap(Name = "StockAdj")]
    public partial class StockAdj : BaseModel
    {

        #region 模型
        private string _AdjID;
        /// <summary>
        /// 调整ID(WID+ ID服务)
        /// </summary>
        [DataMember]
        [DisplayName("调整ID(WID+ ID服务)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [PrimaryKeyField]

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

        private DateTime _AdjDate;
        /// <summary>
        /// 开单日期
        /// </summary>
        [DataMember]
        [DisplayName("开单日期")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "AdjDate")]
        public DateTime AdjDate
        {
            get
            {
                return _AdjDate;
            }
            set
            {
                _AdjDate = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("AdjDate", value));
            }
        }

        private string _PlanID;
        /// <summary>
        /// 盘点计划ID
        /// </summary>
        [DataMember]
        [DisplayName("盘点计划ID")]

        [DbMap(Name = "PlanID")]
        public string PlanID
        {
            get
            {
                return _PlanID;
            }
            set
            {
                _PlanID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("PlanID", value));
            }
        }

        private int _WID;
        /// <summary>
        /// 仓库ID(WarehouseID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(WarehouseID)")]

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
        /// 仓库编号(Warehouse.WCode)
        /// </summary>
        [DataMember]
        [DisplayName("仓库编号(Warehouse.WCode)")]

        [Required(ErrorMessage = "{0}不能为空")]

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
        /// 仓库名称(Warehouse.WarehouseName)
        /// </summary>
        [DataMember]
        [DisplayName("仓库名称(Warehouse.WarehouseName)")]

        [Required(ErrorMessage = "{0}不能为空")]

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
        /// 仓库子机构ID(WarehouseID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库子机构ID(WarehouseID)")]

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
        /// 仓库子机构编号(Warehouse.WCode)
        /// </summary>
        [DataMember]
        [DisplayName("仓库子机构编号(Warehouse.WCode)")]

        [Required(ErrorMessage = "{0}不能为空")]

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
        /// 仓库柜台名称(Warehouse.WarehouseName)
        /// </summary>
        [DataMember]
        [DisplayName("仓库柜台名称(Warehouse.WarehouseName)")]

        [Required(ErrorMessage = "{0}不能为空")]

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

        private int _Status;
        /// <summary>
        /// 状态(0:未提交;1:已提交;2:已过帐;3:作废) 0>1 1->2 1>0; 1>3; 0 删除时物理删除;
        /// </summary>
        [DataMember]
        [DisplayName("状态(0:未提交;1:已提交;2:已过帐;3:作废) 0>1 1->2 1>0; 1>3; 0 删除时物理删除;")]

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

        private int _AdjType;
        /// <summary>
        /// 调整类型(0:调增库存;1:调减库存)
        /// </summary>
        [DataMember]
        [DisplayName("调整类型(0:调增库存;1:调减库存)")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "AdjType")]
        public int AdjType
        {
            get
            {
                return _AdjType;
            }
            set
            {
                _AdjType = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("AdjType", value));
            }
        }

        private int? _CreateFlag;
        /// <summary>
        /// 单据创建标识：0：手动创建　1：销售单自动盘盈
        /// </summary>
        [DataMember]
        [DisplayName("单据创建标识：0：手动创建　1：销售单自动盘盈")]

        [DbMap(Name = "CreateFlag")]
        public int? CreateFlag
        {
            get
            {
                return _CreateFlag;
            }
            set
            {
                _CreateFlag = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("CreateFlag", value));
            }
        }

        private int? _IsDispose;
        /// <summary>
        /// 自动盘盈是否盘亏　0：没有盘亏　1：已盘亏并过账 2： 已盘亏录单但未过账
        /// </summary>
        [DataMember]
        [DisplayName("自动盘盈是否盘亏　1：已盘亏并过账 2： 已盘亏录单但未过账")]

        [DbMap(Name = "IsDispose")]
        public int? IsDispose
        {
            get
            {
                return _IsDispose;
            }
            set
            {
                _IsDispose = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("IsDispose", value));
            }
        }

        private string _RefBID;
        /// <summary>
        /// 自动盘盈订单编号
        /// </summary>
        [DataMember]
        [DisplayName("自动盘盈订单编号")]

        [DbMap(Name = "RefBID")]
        public string RefBID
        {
            get
            {
                return _RefBID;
            }
            set
            {
                _RefBID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("RefBID", value));
            }
        }

        private string _RefAdjID;
        /// <summary>
        /// 自动盘盈，盘亏单号
        /// </summary>
        [DataMember]
        [DisplayName("自动盘盈，盘亏单号")]

        [DbMap(Name = "RefAdjID")]
        public string RefAdjID
        {
            get
            {
                return _RefAdjID;
            }
            set
            {
                _RefAdjID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("RefAdjID", value));
            }
        }

        private DateTime? _ConfTime;
        /// <summary>
        /// 提交时间
        /// </summary>
        [DataMember]
        [DisplayName("提交时间")]

        [DbMap(Name = "ConfTime")]
        public DateTime? ConfTime
        {
            get
            {
                return _ConfTime;
            }
            set
            {
                _ConfTime = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ConfTime", value));
            }
        }

        private int? _ConfUserID;
        /// <summary>
        /// 提交用户ID
        /// </summary>
        [DataMember]
        [DisplayName("提交用户ID")]

        [DbMap(Name = "ConfUserID")]
        public int? ConfUserID
        {
            get
            {
                return _ConfUserID;
            }
            set
            {
                _ConfUserID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ConfUserID", value));
            }
        }

        private string _ConfUserName;
        /// <summary>
        /// 提交用户名称
        /// </summary>
        [DataMember]
        [DisplayName("提交用户名称")]

        [DbMap(Name = "ConfUserName")]
        public string ConfUserName
        {
            get
            {
                return _ConfUserName;
            }
            set
            {
                _ConfUserName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("ConfUserName", value));
            }
        }

        private DateTime? _PostingTime;
        /// <summary>
        /// 过帐时间
        /// </summary>
        [DataMember]
        [DisplayName("过帐时间")]

        [DbMap(Name = "PostingTime")]
        public DateTime? PostingTime
        {
            get
            {
                return _PostingTime;
            }
            set
            {
                _PostingTime = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("PostingTime", value));
            }
        }

        private int? _PostingUserID;
        /// <summary>
        /// 过帐用户ID
        /// </summary>
        [DataMember]
        [DisplayName("过帐用户ID")]

        [DbMap(Name = "PostingUserID")]
        public int? PostingUserID
        {
            get
            {
                return _PostingUserID;
            }
            set
            {
                _PostingUserID = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("PostingUserID", value));
            }
        }

        private string _PostingUserName;
        /// <summary>
        /// 过帐用户名称
        /// </summary>
        [DataMember]
        [DisplayName("过帐用户名称")]

        [DbMap(Name = "PostingUserName")]
        public string PostingUserName
        {
            get
            {
                return _PostingUserName;
            }
            set
            {
                _PostingUserName = value;
                base.SetChangedProperties(new KeyValuePair<string, object>("PostingUserName", value));
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

        private int _CreateUserID;
        /// <summary>
        /// 创建用户ID
        /// </summary>
        [DataMember]
        [DisplayName("创建用户ID")]

        [Required(ErrorMessage = "{0}不能为空")]

        [DbMap(Name = "CreateUserID")]
        public int CreateUserID
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
    /// StockAdj 盘点调整主表 列表查询对象
    /// </summary>
    public class StockAdjQuery
    {
        /// <summary>
        /// 单号
        /// </summary>
        [DataMember]
        public string AdjID { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        [DataMember]
        public string SKU { get; set; }

        /// <summary>
        /// 单据状态(0:未提交;1:已提交;2:已过帐;3:作废) 0>1 1->2 1>0; 1>3; 0 删除时物理删除)
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 仓库子机构ID
        /// </summary>
        public int? SubWID { get; set; }

        /// <summary>
        /// 开单日期 起始时间点
        /// </summary>
        public DateTime? AdjDateBegin { get; set; }

        /// <summary>
        /// 开单日期 截止时间点
        /// </summary>
        public DateTime? AdjDateEnd { get; set; }

        /// <summary>
        /// 创建类型
        /// </summary>
        public int? CreateFlag { get; set; }

        /// <summary>
        /// 自动盘盈是否盘亏
        /// </summary>
        public int? IsDispose { get; set; }

        /// <summary>
        /// 对应的订单号
        /// </summary>
        public string RefBID { get; set; }

        /// <summary>
        /// 自动盘盈对应的盘亏单号
        /// </summary>
        public string RefAdjID { get; set; }

    }

    /// <summary>
    /// 包装盘点调整信息的对象
    /// </summary>
    public class StockAdjModel
    {
        /// <summary>
        /// 盘点调整表主表对象
        /// </summary>
        public StockAdj StockAdjMain { get; set; }

        /// <summary>
        /// 盘点调整明细表集合
        /// </summary>
        public IList<StockAdjDetail> DetailList { get; set; }

        /// <summary>
        /// 库存明细表_待处理单据扩展 集合
        /// </summary>
        public IList<StockAdjDetailsExt> DetailsExtList { get; set; }
    }

    /// <summary>
    /// 盘点调整单下的总计对象(总数、总金额)
    /// </summary>
    public class StockAdjSum
    {
        /// <summary>
        /// 总数--现阶段要求对应 UnitQty
        /// </summary>
        public decimal AdjQtySum { get; set; }

        /// <summary>
        /// 调整总金额
        /// </summary>
        public decimal AdjAmtSum { get; set; }
    }

    /// <summary>
    /// 盘点差额对象
    /// 为了方便找出某个盘亏单下的库存单位调整数量小于当前实际库存数量的明细
    /// </summary>
    public class StockAdjDif
    {
        /// <summary>
        /// 商品编码
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 库存单位数量(=AdjQty*AdjPackingQty)
        /// </summary>
        public decimal UnitQty { get; set; }

        /// <summary>
        /// 盘点时该单位时的子机构的库存(StockQty.StockQty)
        /// </summary>
        public decimal StockQty { get; set; }

        /// <summary>
        /// 库存调整数量和库存数量差额
        /// </summary>
        public decimal Dif { get; set; }
    }

    /// <summary>
    /// 盘点调整工具类
    /// </summary>
    public class StockAdjTool
    {
        /// <summary>
        /// 分割List
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="list">集合</param>
        /// <param name="pageSize">分隔大小</param>
        /// <returns></returns>
        public List<List<T>> SplitList<T>(List<T> list, int pageSize)
        {
            int listSize = list.Count; // list的大小  
            int page = (listSize + (pageSize - 1)) / pageSize;// 页数  
            List<List<T>> listArray = new List<List<T>>();// 创建list数组,用来保存分割后的list  
            for (int i = 0; i < page; i++)
            {
                // 按照数组大小遍历  
                List<T> subList = new List<T>(); // 数组每一位放入一个分割后的list  
                for (int j = 0; j < listSize; j++)
                {
                    // 遍历待分割的list  
                    int pageIndex = ((j + 1) + (pageSize - 1)) / pageSize;// 当前记录的页码(第几页)  
                    if (pageIndex == (i + 1))
                    {
                        // 当前记录的页码等于要放入的页码时  
                        subList.Add(list[j]); // 放入list中的元素到分割后的list(subList)  
                    }
                    if ((j + 1) == ((j + 1) * pageSize))
                    {// 当放满一页时退出当前循环  
                        break;
                    }
                }
                listArray.Add(subList);// 将分割后的list放入对应的数组的位中  
            }
            return listArray;
        }
    }

}