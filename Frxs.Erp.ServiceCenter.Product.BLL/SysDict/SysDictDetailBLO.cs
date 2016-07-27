using System;
using System.Collections.Generic;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;

namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    public class SysDictDetailBLO
    {
        /// <summary>
        /// 获取分类数据字典
        /// </summary>
        /// <param name="dictCode"></param>
        /// <returns></returns>
        public static IList<SysDictDetail> GetModelListByDictCode(string dictCode)
        {
            return DALFactory.GetLazyInstance<ISysDictDetailDAO>().GetModelListByDictCode(dictCode);
        }
    }
}
