using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// Shelf.TableList
    /// </summary>
    public class ShelfTableListRequest : PageListRequestDto
    {
        /// <summary>
        /// 货位编号(同一个仓库不能重复)
        /// </summary>
        public string ShelfCode { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 所属货区ID(ShelfArea.ShelfAreaID)
        /// </summary>            
        public int? ShelfAreaID { get; set; }

        /// <summary>
        /// 状态(0:正常;1:冻结)
        /// </summary>           
        public string Status { get; set; }


    }

    /// <summary>
    /// Shelf.Save
    /// </summary>
    public class ShelfSaveRequest : RequestDtoBase
    {
        /// <summary>
        /// ID(主键)
        /// </summary>            
        public int? ShelfID { get; set; }

        /// <summary>
        /// 货位编号(同一个仓库不能重复)
        /// </summary>
        public string ShelfCode { get; set; }

        /// <summary>
        /// 所属货区ID(ShelfArea.ShelfAreaID)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShelfAreaID { get; set; }

        /// <summary>
        /// 货位类型(0:存储;1:)
        /// </summary>
        public string ShelfType { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 状态(0:正常;1:冻结)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public string Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>    
        public string Remark { get; set; }

    }

    /// <summary>
    /// Shelf.List.Save
    /// </summary>
    public class ShelfListSaveRequest : RequestDtoBase
    {
       

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 货位编号集合
        /// </summary>           
        public IList<Model.Shelf> ShelfList { get; set; }

    }

    /// <summary>
    /// Shelf.Del
    /// </summary>
    public class ShelfDelRequest : RequestDtoBase
    {
        /// <summary>
        /// ID(主键)
        /// </summary>            
        public string ShelfID { get; set; }

    }

    /// <summary>
    /// Shelf.Get
    /// </summary>
    public class ShelfGetRequest : RequestDtoBase
    {
        /// <summary>
        /// ID(主键)
        /// </summary>            
        public int ShelfID { get; set; }

    }

    /// <summary>
    /// Shelf.List
    /// </summary>
    public class ShelfListRequest : RequestDtoBase
    {
        /// <summary>
        /// 货位编号(同一个仓库不能重复)
        /// </summary>
        public string ShelfCodeStart { get; set; }

        /// <summary>
        /// 货位编号(同一个仓库不能重复)
        /// </summary>        
        public string ShelfCodeEnd { get; set; }
        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 所属货区ID(ShelfArea.ShelfAreaID)
        /// </summary>            
        public int? ShelfAreaID { get; set; }

        /// <summary>
        /// 货位编号集合
        /// </summary>           
        public IList<string> ShelfCodeList { get; set; }
    }
}
