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
    /// WarehouseEmpShelf.TableList
    /// </summary>
    public class WarehouseEmpShelfTableListRequest : PageListRequestDto
    {
        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>       
        public string EmpName { get; set; }        

        /// <summary>
        /// 用户登录帐户(手机号码;员工编号;唯一[不包括删除的])
        /// </summary>       
        public string UserAccount { get; set; }

        /// <summary>
        /// 所属货区ID(ShelfArea.ShelfAreaID)
        /// </summary>            
        public string ShelfAreaID { get; set; }

        /// <summary>
        /// 是否冻结(0:未冻结;1:已冻结)
        /// </summary>        
        public string IsFrozen { get; set; }
    }

    /// <summary>
    /// WarehouseEmpShelf.Get
    /// </summary>
    public class WarehouseEmpShelfGetRequest : RequestDtoBase
    {
        /// <summary>
        /// ID(主键)
        /// </summary>            
        public int ID { get; set; }

    }

    /// <summary>
    /// WarehouseEmpShelf.Get
    /// </summary>
    public class WarehouseEmpShelfListGetRequest : RequestDtoBase
    {
        /// <summary>
        /// ID(主键)
        /// </summary>            
        public string EmpID { get; set; }

    }

    /// <summary>
    /// WarehouseEmpShelf.Get
    /// </summary>
    public class WarehouseEmpShelfSaveRequest : RequestDtoBase
    {
        /// <summary>
        /// ID(主键)
        /// </summary>            
        public string EmpID { get; set; }

        /// <summary>
        /// 所属货区ID(ShelfArea.ShelfAreaID)
        /// </summary>            
        public string ShelfAreaID { get; set; }

        public string ShelfIDs { get; set; }

    }
}
