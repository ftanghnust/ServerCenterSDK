/*********************************************************
 * FRXS 小马哥 2016/5/3 15:44:40
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model.Order
{
    public class PickTimeModel
    {
        /// <summary>
        /// 订单表开始拣货时间
        /// </summary>
        public DateTime? PickingBeginDate { get; set; }

        /// <summary>
        /// 待拣货区表开始拣货时间
        /// </summary>
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 货区编号
        /// </summary>
        public int StationNumber { get; set; }

        /// <summary>
        /// 门店编号
        /// </summary>
        public int ShopID { get; set; }

        /// <summary>
        /// 配送时间
        /// </summary>
        public DateTime? SendDate { get; set; }

        /// <summary>
        /// 线路编号
        /// </summary>
        public int LineID { get; set; }
    }
}
