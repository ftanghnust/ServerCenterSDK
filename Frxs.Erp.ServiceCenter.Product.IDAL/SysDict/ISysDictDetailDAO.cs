/*****************************
* Author:叶求
*
* Date:2016-03-09
******************************/

using System;
using System.Collections.Generic;
using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    public interface ISysDictDetailDAO : IBaseDAO
    {
        /// <summary>
        /// 获取分类数据字典
        /// </summary>
        /// <param name="dictCode"></param>
        /// <returns></returns>
        IList<SysDictDetail> GetModelListByDictCode(string dictCode);
    }
}
