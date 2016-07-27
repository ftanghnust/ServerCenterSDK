/*********************************************************
 * FRXS 小马哥 2016/4/9 9:37:14
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model.Order
{
    /// <summary>
    /// 正在拣货订单列表基础类
    /// </summary>
    [Serializable]
    public class SaleOrderPre7ShelfArea //: BaseModel
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 门店编号(内置)
        /// </summary>
        public int ShopID { get; set; }

        /// <summary>
        /// 门店编码(显式)
        /// </summary>
        public string ShopCode { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 门店类型(0:加盟店；1：签约店)
        /// </summary>
        public int ShopType { get; set; }

        /// <summary>
        /// 货区编号
        /// </summary>
        public int ShelfAreaID { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public int OrderType { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string WCode { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WName { get; set; }

        /// <summary>
        /// 仓库柜台编码
        /// </summary>
        public string SubWCode { get; set; }

        /// <summary>
        /// 仓库柜台名称
        /// </summary>
        public string SubWName { get; set; }

        /// <summary>
        /// 门店省份ID
        /// </summary>
        public int ProvinceID { get;set; }

        /// <summary>
        /// 门店市ID
        /// </summary>
        public int CityID { get; set; }

        /// <summary>
        /// 门店区ID
        /// </summary>
        public int RegionID { get; set; }

        /// <summary>
        /// 门店省份名称
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 门店市名称
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 门店区名称
        /// </summary>
        public string RegionName { get; set; }

        /// <summary>
        /// 门店所属路线编号
        /// </summary>
        public int LineID { get; set; }
    }
}
