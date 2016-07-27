using Frxs.Erp.ServiceCenter.ID.IDAL;
using Frxs.Erp.ServiceCenter.ID.Model;
using Frxs.Platform.IOCFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.ID.BLL
{
    public class IDFactoryBLO
    {
        #region 根据主键验证Vendor是否存在
        /// <summary>
        /// 根据主键验证Vendor是否存在
        /// </summary>
        /// <param name="model">Vendor对象</param>
        /// <returns>是否存在</returns>
        public static string GetID(IDTypes idType, int wid)
        {
            return DALFactory.GetLazyInstance<IIDFactoryDAO>().GetID(idType, wid);
        }
        #endregion
    }
}