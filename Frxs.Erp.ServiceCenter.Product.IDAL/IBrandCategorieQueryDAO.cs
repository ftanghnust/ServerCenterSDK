/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/5 14:27:21
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBrandCategorieQueryDAO : IBaseDAO, IPager<Model.BrandCategories>
    {
        /// <summary>
        /// 查询参数
        /// </summary>
        BrandCategorieQueryParams SearchParams { get; set; }
    }
}
