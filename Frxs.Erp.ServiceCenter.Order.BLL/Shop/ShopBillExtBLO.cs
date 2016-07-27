using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Platform.IOCFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.BLL.Shop
{
    /// <summary>
    /// 门店单据信息数据 业务类  为判断门店是否可以被安全删除，需要查询相关订单信息，特增加此类
    /// </summary>
    public class ShopBillExtBLO
    {
        /// <summary>
        /// 获取门店订单信息列表
        /// </summary>
        /// <param name="wid">仓库ID</param>
        /// <param name="shopID">门店ID</param>
        /// <returns>门店订单信息列表</returns>
        public static IList<ShopBillExt> GetList(int wid,int shopID)
        {
            return DALFactory.GetLazyInstance<IShopBillExtDAO>(wid.ToString()).GetList(wid,shopID);
        }
    }
}
