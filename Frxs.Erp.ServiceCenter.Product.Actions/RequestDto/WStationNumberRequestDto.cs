using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    class WStationNumberRequestDto
    {
    }

     /// <summary>
    /// WStationNumber.Add
    /// </summary>
    [Serializable]
    public class WStationNumberAddRequestDto : RequestDtoBase
    {
        #region 模型
        /// <summary>
        /// 开始编号
        /// </summary>        
        [DisplayName("开始编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int StartID { get; set; }

        /// <summary>
        /// 结束编号
        /// </summary>        
        [DisplayName("结束编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int EndID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>        
        [DisplayName("仓库ID(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        #endregion
 
    }

    /// <summary>
    /// WStationNumber.TableList
    /// </summary>
    public class WStationNumberListRequest : PageListRequestDto
    {
        /// <summary>
        /// 门店编号
        /// </summary>        
        [DisplayName("门店编号")]
        public string ShopCode { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>        
        [DisplayName("门店名称")]
        public string ShopName { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 订单状态(status=1时才有值; 值：3:正在拣货;4:拣货完成;5:打印完成;6:正在配送中)
        /// </summary>        
        [DisplayName("订单状态(status=1时才有值; 值：3:正在拣货;4:拣货完成;5:打印完成;6:正在配送中)")]
        public string OrderStatus { get; set; }

        /// <summary>
        /// 状态(0:正常;1:冻结)
        /// </summary>           
        public string Status { get; set; }

        /// <summary>
        /// 待装区编号(同一个仓库不能重复)
        /// </summary>       
        [DisplayName("待装区编号(同一个仓库不能重复)")]        
        public string StationNumber { get; set; }

    }

    /// <summary>
    /// WStationNumber.Del
    /// </summary>
    public class WStationNumberDelRequest : RequestDtoBase
    {
        /// <summary>
        /// ID(主键)
        /// </summary>            
        public IList<int> ID { get; set; }

    }

    /// <summary>
    /// WStationNumber.IsFrozen
    /// </summary>
    public class WStationNumberIsFrozenRequest : RequestDtoBase
    {
        /// <summary>
        /// ID(主键)
        /// </summary>            
        public IList<int> ID { get; set; }

        /// <summary>
        /// 状态(0:空闲;1:正在使用;2:冻结; 可以物理删除)
        /// </summary>        
        [DisplayName("状态(0:空闲;1:正在使用;2:冻结; 可以物理删除)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Status { get; set; }

    }

    /// <summary>
    /// WStationNumber.Reset
    /// </summary>
    public class WStationNumberResetRequest : RequestDtoBase
    {
        /// <summary>
        /// ID(主键)
        /// </summary>            
        public IList<int> ID { get; set; }

    }
    
    /// <summary>
    /// WStationNumber.Reset
    /// </summary>
    public class WStationNumberResetExtRequest : RequestDtoBase
    {
        /// <summary>
        ///orderId
        /// </summary>            
        public string OrderId { get; set; }

    }

    
}
