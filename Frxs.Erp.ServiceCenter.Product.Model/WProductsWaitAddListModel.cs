
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 等待加入商品查询对象
    /// </summary>
    public class WProductsWaitAddListModel 
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// ERP编码
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public int CategoryId1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CategoryName1 { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public int CategoryId2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CategoryName2 { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public int CategoryId3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CategoryName3 { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName2 { get; set; }

        /// <summary>
        /// 规格属性
        /// </summary>
        public string Attributes { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// 库存单位
        /// </summary>
        public string Unit { get; set; }

    }
}
