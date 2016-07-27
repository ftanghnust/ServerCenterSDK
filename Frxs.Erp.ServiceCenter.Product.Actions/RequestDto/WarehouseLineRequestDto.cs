using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// WarehouseLine.TableList
    /// </summary>
    public class WarehouseLineTableListRequest : PageListRequestDto
    {
        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 配送线路名称
        /// </summary>       
        public string LineName { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string EmpName { get; set; }

        /// <summary>
        /// 负责人电话
        /// </summary>       
        public string UserMobile { get; set; }       
        
        /// <summary>
        /// 配送周期
        /// </summary>
        public string SendW { get; set; }

        
    }

    /// <summary>
    /// WarehouseLine.Get
    /// </summary>
    public class WarehouseLineGetRequest : RequestDtoBase
    {
        /// <summary>
        /// ID(主键)
        /// </summary>            
        public int LineID { get; set; }

    }

    /// <summary>
    /// WarehouseLine.Get
    /// </summary>
    public class WarehouseLineShopGetRequest : RequestDtoBase
    {
        /// <summary>
        /// ID(主键)
        /// </summary>            
        public int ShopID { get; set; }

    }

     /// <summary>
    /// Shelf.Save
    /// </summary>
    public class WarehouseLineSaveRequest : RequestDtoBase
    {
        #region 模型
        /// <summary>
        /// 主键(ID)
        /// </summary>
       
        [DisplayName("主键(ID)")]        
        public int LineID { get; set; }

        /// <summary>
        /// 配送线路编号(不能重复,不包括已删除的)
        /// </summary>       
        [DisplayName("配送线路编号(不能重复,不包括已删除的)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string LineCode { get; set; }

        /// <summary>
        /// 所属仓库(Warehouse.WID)
        /// </summary>       
        [DisplayName("所属仓库(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 配送线路名称
        /// </summary>       
        [DisplayName("配送线路名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string LineName { get; set; }

        /// <summary>
        /// 用户编号(WarehouseEmp.EmpID and EmpType=2)
        /// </summary>       
        [DisplayName("用户编号(WarehouseEmp.EmpID and EmpType=2)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int EmpID { get; set; }

        /// <summary>
        /// 配送周期周1(0:不送;1:送)
        /// </summary>       
        [DisplayName("配送周期周1(0:不送;1:送)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SendW1 { get; set; }

        /// <summary>
        /// 配送周期周2(0:不送;1:送)
        /// </summary>       
        [DisplayName("配送周期周2(0:不送;1:送)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SendW2 { get; set; }

        /// <summary>
        /// 配送周期周3(0:不送;1:送)
        /// </summary>       
        [DisplayName("配送周期周3(0:不送;1:送)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SendW6 { get; set; }

        /// <summary>
        /// 配送周期周4(0:不送;1:送)
        /// </summary>       
        [DisplayName("配送周期周4(0:不送;1:送)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SendW5 { get; set; }

        /// <summary>
        /// 配送周期周5(0:不送;1:送)
        /// </summary>       
        [DisplayName("配送周期周5(0:不送;1:送)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SendW4 { get; set; }

        /// <summary>
        /// 配送周期周6(0:不送;1:送)
        /// </summary>       
        [DisplayName("配送周期周6(0:不送;1:送)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SendW3 { get; set; }

        /// <summary>
        /// 配送周期周7(0:不送;1:送)
        /// </summary>       
        [DisplayName("配送周期周7(0:不送;1:送)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SendW7 { get; set; }

        /// <summary>
        /// 门店下单截止时间(hh:mm:ss)
        /// </summary>       
        [DisplayName("门店下单截止时间(hh:mm:ss)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public TimeSpan OrderEndTime { get; set; }

        /// <summary>
        /// 配送距离KM
        /// </summary>       
        [DisplayName("配送距离KM")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Distance { get; set; }

        /// <summary>
        /// 发货所要的时间(小时）
        /// </summary>       
        [DisplayName("发货所要的时间(小时）")]
        public int SendNeedTime { get; set; }

        /// <summary>
        /// 发货排序
        /// </summary>       
        [DisplayName("发货排序")]
        public int SerialNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>       
        [DisplayName("备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
       
        [DisplayName("创建用户ID")]        
        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>       
        [DisplayName("创建用户名称")]
        public string CreateUserName { get; set; }       

        /// <summary>
        /// 最后修改用户ID
        /// </summary>       
        [DisplayName("最后修改用户ID")]
        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>       
        [DisplayName("最后修改用户名称")]
        public string ModifyUserName { get; set; }

        public List<WarehouseLineShop> ShopList { get; set; }
        #endregion
    }

    /// <summary>
    /// Shelf.Del
    /// </summary>
    public class WarehouseLineDelRequest : RequestDtoBase
    {
        /// <summary>
        /// ID(主键)
        /// </summary>            
        public string LineID { get; set; }

    }
}
