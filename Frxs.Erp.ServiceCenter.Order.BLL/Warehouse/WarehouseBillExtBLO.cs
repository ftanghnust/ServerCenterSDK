using Frxs.Erp.ServiceCenter.Order.IDAL.Warehouse;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Platform.IOCFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    /// <summary>
    /// 仓库子机构单据信息数据 业务类
    /// 为判断仓库子机构是否可以被安全删除，需要查询相关订单信息，特增加此类
    /// </summary>
    public class WarehouseBillExtBLO
    {
        /// <summary>
        /// 获取仓库子机构订单信息列表
        /// </summary>
        /// <param name="wid">仓库ID</param>
        /// <param name="subWID">仓库子机构ID</param>
        /// <returns>门店订单信息列表</returns>
        public static IList<WarehouseBillExt> GetList(int wid, int subWID)
        {
            return DALFactory.GetLazyInstance<IWarehouseBillExtDAO>(wid.ToString()).GetList(subWID);
        }
    }
}
