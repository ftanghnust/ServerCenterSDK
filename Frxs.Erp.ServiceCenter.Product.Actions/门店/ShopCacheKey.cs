using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 门店相关的缓存key
    /// </summary>
    internal class ShopCacheKey
    {
        /// <summary>
        /// 此缓存键用于匹配所有门店实体相关联的缓存键（用于匹配删除所有相关缓存）
        /// </summary>
        public const string FRXS_SHOP_PATTERN_KEY = "Frxs.Shop";

        /// <summary>
        /// 此缓存键用于匹配所有门店群组实体相关联的缓存键（用于匹配删除所有相关缓存）
        /// </summary>
        public const string FRXS_SHOP_GROUP_PATTERN_KEY = "Frxs.ShopGroup";
    }
}
