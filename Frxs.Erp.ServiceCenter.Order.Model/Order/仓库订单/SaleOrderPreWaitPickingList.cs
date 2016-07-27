/*********************************************************
 * FRXS 小马哥 2016/4/9 16:41:33
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// 获取待拣货订单列表
    /// </summary>
    [Serializable]
    public class SaleOrderPreWaitPickingList
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 结算ID
        /// </summary>
        public string SettleID { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 订单类型(0:客户;1:客服代客)
        /// </summary>
        public int OrderType { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public string WCode { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WName { get; set; }

        /// <summary>
        /// 下单门店编号
        /// </summary>
        public int ShopID { get; set; }

        /// <summary>
        /// 下单门店人员ID
        /// </summary>
        public int XSUserID { get; set; }

        /// <summary>
        /// 下单门店类型(0:加盟店;1:签约店)
        /// </summary>
        public int ShopType { get; set; }

        /// <summary>
        /// 下单门店编码
        /// </summary>
        public string ShopCode { get; set; }

        /// <summary>
        /// 下单门店名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 门店地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 门店省ID
        /// </summary>
        public int ProvinceID { get; set; }

        /// <summary>
        /// 门店市ID
        /// </summary>
        public int CityID { get; set; }

        /// <summary>
        /// 门店区ID
        /// </summary>
        public int RegionID { get; set; }

        /// <summary>
        /// 门店地址全称
        /// </summary>
        public string FullAddress { get; set; }

        /// <summary>
        /// 门店收货人名称
        /// </summary>
        public string RevLinkMan { get; set; }

        /// <summary>
        /// 门店收货人电话
        /// </summary>
        public string RevTelephone { get; set; }

        /// <summary>
        /// 门店所属线路
        /// </summary>
        public int LineID { get; set; }

        /// <summary>
        /// 门店所属路线编号
        /// </summary>
        public string LineCode { get; set; }

        /// <summary>
        /// 门店所属线路名称
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// 门店每日订单流水号
        /// </summary>
        public int StationNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否拣货完成(0:拣货完成；1：正在拣货)
        /// </summary>
        public int IsPicked { get; set; }

        /// <summary>
        /// 商品详细数据
        /// </summary>
        public IList<SaleOrderPreDetailsPick> ProductData { get; set; }
    }
}
