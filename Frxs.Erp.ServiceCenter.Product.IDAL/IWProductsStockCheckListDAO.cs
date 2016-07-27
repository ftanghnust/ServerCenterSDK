﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// 盘点商品查询 接口定义
    /// </summary>
    public interface IWProductsStockCheckListForStockDAO : IBaseDAO, IPager<WProductsStockCheckModel>
    {
        /// <summary>
        /// 查询参数
        /// </summary>
        WProductsStockCheckListParams SearchParams { get; set; }
    }
}
