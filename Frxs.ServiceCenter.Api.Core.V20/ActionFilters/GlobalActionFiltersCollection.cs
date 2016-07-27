/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/15 19:15:09
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 接口过滤器集合配置表
    /// </summary>
    public class GlobalActionFiltersCollection : List<IActionFilter>, IGlobalActionFiltersCollection
    {
        /// <summary>
        /// 添加一个新的全局拦截器到管理器里面
        /// </summary>
        /// <param name="actionFilters">全局拦截器</param>
        public void Add(params IActionFilter[] actionFilters)
        {
            //不能为null
            actionFilters.CheckNullThrowArgumentNullException("actionFilters");

            //添加拦截器到集合，排除掉已经添加的
            foreach (var item in from item in actionFilters
                let actionFilter = this.FirstOrDefault(o => o.GetType() == item.GetType())
                where actionFilter.IsNull()
                select item)
            {
                base.Add(item);
            }
        }

        /// <summary>
        /// 获取所有的全局拦截器
        /// </summary>
        public IEnumerable<IActionFilter> GetActionFilters()
        {
            return this;
        }
    }
}
