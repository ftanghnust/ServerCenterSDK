using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto
{
    public partial class SaleEditOrderResponseDto : ResponseDtoBase
    {
        #region 模型
        /// <summary>
        /// 主键ID(WID+GUID)
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 改单ID（GUID)
        /// </summary>
        public string EditID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        public int ShopID { get; set; }

        /// <summary>
        /// 门店编号
        /// </summary>
        public string ShopCode { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        public int CreateUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        public string CreateUserName { get; set; }

        #endregion
    }

    //Extend
    public partial class SaleEditOrderResponseDto : ResponseDtoBase
    {
        public DateTime? SendDate { get; set; }

        public decimal? PayAmount { get; set; }

        public string LineName { get; set; }

        public int? LineID { get; set; }

        public int? Status { get; set; }

        public string StatusName { get; set; }

        public string ShopTypeName { get; set; }
    }
}

