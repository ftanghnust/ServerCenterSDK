using Frxs.Erp.ServiceCenter.Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// 门店单据信息数据访问接口类  为判断门店是否可以被安全删除，需要查询相关订单信息，特增加此类
    /// </summary>
    public partial interface IShopBillExtDAO
    {
        #region 获取门店单据信息集合
        /// <summary>
        /// 获取门店单据信息集合
        /// </summary>
        ///<param name="wid">仓库ID</param>
        ///<param name="shopID">门店ID</param>
        /// <returns>数据集合</returns>
        IList<ShopBillExt> GetList(int wid, int shopID);
        #endregion
    }
}
