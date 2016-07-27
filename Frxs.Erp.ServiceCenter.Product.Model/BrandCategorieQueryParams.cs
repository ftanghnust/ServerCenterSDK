using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 查询已添加商品参数
    /// </summary>
    public class BrandCategorieQueryParams
    {
        /// <summary>
        /// 品牌ID集合；
        /// 1.如果此参数设置为null，则查询出所有的品牌分类集合
        /// 2.如果指定了参数，那么值查询出指定的品牌分类集合
        /// </summary>
        public List<int> BrandIds { get; set; }

        /// <summary>
        /// 品牌名称(允许输入关键词)
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 是否含有LOGO（可空，不指定查询出所有的）
        /// </summary>
        public bool? HasLogo { get; set; }
    }
}
