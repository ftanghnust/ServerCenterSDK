using Frxs.Erp.ServiceCenter.Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.IDAL.Warehouse
{
    /// <summary>
    /// 仓库子机构单据信息数据访问接口类
    /// 为判断仓库子机构是否可以被安全删除，需要查询相关订单信息，特增加此类
    /// </summary>
    public partial interface IWarehouseBillExtDAO
    {
        #region 获取仓库子机构单据信息集合
        /// <summary>
        /// 获取仓库子机构单据信息集合
        /// </summary>
        ///<param name="subWID">仓库子机构ID</param>
        /// <returns>数据集合</returns>
        IList<WarehouseBillExt> GetList(int subWID);
        #endregion
    }
}
