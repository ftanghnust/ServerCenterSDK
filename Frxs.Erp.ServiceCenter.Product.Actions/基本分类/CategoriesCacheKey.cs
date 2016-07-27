/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/12 16:58:16
 * *******************************************************/
using System;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 基本分类缓存key
    /// </summary>
    internal class CategoriesCacheKey
    {
        /// <summary>
        /// 此缓存键用户匹配所有相关联的缓存键（用于匹配删除所有相关缓存）
        /// </summary>
        public const string FRXS_CATEGORIES_PATTERN_KEY = "Frxs.Categories";
    }
}
