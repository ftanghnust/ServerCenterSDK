using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    public class SimpleProduct
    {
        #region 模型
        /// <summary>
        /// 商品编号
        /// </summary>
        public int? ProductId { get; set; }


        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }
        #endregion
    }
}
