/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/24 14:48:23
 * *******************************************************/
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Data.Core
{
    /// <summary>
    /// Paged list interface
    /// </summary>
    public interface IPagedList<T> : IList<T>
    {
        /// <summary>
        /// 当前页
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// 每页显示多少条
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// 总记录数
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// 总页数
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// 是否有上一页
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// 是否有下一页
        /// </summary>
        bool HasNextPage { get; }
    }
}
