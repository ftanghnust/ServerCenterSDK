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
    /// ShelAreaf.Del
    /// </summary>
    public class ShelAreafDelRequest : RequestDtoBase
    {
        /// <summary>
        /// ID(主键)
        /// </summary>            
        public string ShelfAreaID { get; set; }

    }

    /// <summary>
    /// ShelfArea.Get
    /// </summary>
    public class ShelfAreaGetRequest : RequestDtoBase
    {
        /// <summary>
        /// ID(主键)
        /// </summary>            
        public int ShelfAreaID { get; set; }

    }

    /// <summary>
    /// ShelfArea.Save
    /// </summary>
    public class ShelfAreaSaveRequest : RequestDtoBase
    {
        #region 模型
        /// <summary>
        /// ID(主键)
        /// </summary>           
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShelfAreaID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>            
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 仓库货区编号(数据字典：ShelfAreaCode)
        /// </summary>            
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShelfAreaCode { get; set; }

        /// <summary>
        /// 货区名称
        /// </summary>            
        public string ShelfAreaName { get; set; }

        /// <summary>
        /// 拣货APP最大显示数
        /// </summary>            
        [Required(ErrorMessage = "{0}不能为空")]
        public int PickingMaxRecord { get; set; }

        /// <summary>
        /// 排序
        /// </summary>            
        [Required(ErrorMessage = "{0}不能为空")]
        public int SerialNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>            
        public string Remark { get; set; }


        /// <summary>
        /// 创建用户ID
        /// </summary>           
        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>  
        public string CreateUserName { get; set; }


        /// <summary>
        /// 最后修改删除用户ID
        /// </summary>            
        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改删除用户名称
        /// </summary>            
        public string ModifyUserName { get; set; }

        #endregion
    }

    /// <summary>
    /// ShelfArea.TableList
    /// </summary>
    public class ShelfAreaTableListRequest : PageListRequestDto
    {
        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }
    }
}
