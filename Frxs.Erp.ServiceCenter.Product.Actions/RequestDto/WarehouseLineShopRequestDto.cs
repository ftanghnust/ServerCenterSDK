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
    /// WarehouseLineShop.TableList
    /// </summary>
    public class WarehouseLineShopTableListRequest : PageListRequestDto
    {

        /// <summary>
        /// 线路ID(WarehouseLine.LineID)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int LineID { get; set; }       

    }

    /// <summary>
    /// WarehouseLineShop.Save
    /// </summary>
    public class WarehouseLineShopSaveRequest : RequestDtoBase
    {

        /// <summary>
        /// 线路ID(WarehouseLine.LineID)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int LineID { get; set; }  

        /// <summary>
        /// 门店编号
        /// </summary>
        public string idList { get; set; }       

    }
}
