/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/13 15:38:37
 * *******************************************************/

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 仓库商品缓存键配置
    /// </summary>
    internal class WProductsCacheKey
    {
        /// <summary>
        /// 此缓存键用户匹配所有相关联的缓存键（用于匹配删除所有相关缓存）
        /// </summary>
        public const string FRXS_WPRODUCTS_PATTERN_KEY = "Frxs.WProducts";
    }
}
