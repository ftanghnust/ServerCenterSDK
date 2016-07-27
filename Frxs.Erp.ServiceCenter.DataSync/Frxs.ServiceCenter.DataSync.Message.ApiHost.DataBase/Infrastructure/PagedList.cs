/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/20/2016 7:33:37 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase
{
    /// <summary>
    /// 
    /// </summary>
    public class PagedList<T>
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get;  set; }

        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int PageSize { get;  set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get;  set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get;  set; }

        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }

        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<T> Items { get; set; }
    }
}
