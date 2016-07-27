using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto.Order
{
    public class SaleOrderTracksGetResponseDto:ResponseDtoBase
    {
        /// <summary>
        /// 订单跟踪消息列表
        /// </summary>
        public IList<OrderTrackGetResponseDto> Tracks { get; set; }
    }
     public class OrderTrackGetResponseDto : ResponseDtoBase
    {
        #region 模型
        /// <summary>
        /// 编号(仓库ID+GUID)
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>

        public int WID { get; set; }

        /// <summary>
        /// 操作内容
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 在用户端是否显示(0:不显示;1:显示)
        /// </summary>
     
        public int? IsDisplayUser { get; set; }

        /// <summary>
        /// 状态编号(对于Order.OrderStatus)
        /// </summary>
 
        public int? OrderStatus { get; set; }

        /// <summary>
        /// 状态编号名称(对于Order.OrderStatus)
        /// </summary>
   
        public string OrderStatusName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>

        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>

        public int? CreateUserID { get; set; }
        /// <summary>
        /// 创建用户名称
        /// </summary>

        public string CreateUserName { get; set; }

        #endregion
    }
}
