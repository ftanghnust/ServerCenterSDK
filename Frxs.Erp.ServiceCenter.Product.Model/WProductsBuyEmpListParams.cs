using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    public class WProductsBuyEmpListParams
    {
        /// <summary>
        /// 对应的仓库ID
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 商品名称关键词
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// ERP条码
        /// </summary>
        public string SKU
        {
            get;
            set;
        }

        /// <summary>
        /// 条码
        /// </summary>
        public string BarCode
        {
            get;
            set;
        }

        /// <summary>
        /// 分类1
        /// </summary>
        public int? CategoryId1
        {
            get;
            set;
        }

        /// <summary>
        /// 分类2
        /// </summary>
        public int? CategoryId2
        {
            get;
            set;
        }

        /// <summary>
        /// 分类3
        /// </summary>
        public int? CategoryId3
        {
            get;
            set;
        }

        /// <summary>
        /// 商品主供应商
        /// </summary>
        public string VendorName { get; set; }

        /// <summary>
        /// 是否添加供应商 1为是 0为否 空表示全部
        /// </summary>
        public int? AddedVendor { get; set; }

        /// <summary>
        /// 仓库商品状态(0:已移除1:正常;2:淘汰;3:冻结;) ;淘汰商品和冻结商品不能销售;加入或重新加入时为正常；移除后再加入时为正常
        /// </summary>      
        public int? WStatus { get; set; }

        /// <summary>
        /// 采购员
        /// </summary>
        public string BuyEmpName { get; set; }

        /// <summary>
        /// 是否设置采购员
        /// </summary>
        public int? HasBuyEmp { get; set; }
    }
}
