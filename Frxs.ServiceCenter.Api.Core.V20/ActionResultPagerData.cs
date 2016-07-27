/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/2/17 15:41:12
 * *******************************************************/
using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 需要分页输出的地方（此类为建议类，实际使用中可以依据情况使用）
    /// 此类没有定义成泛型类是让在数据组装数据的时候方便
    /// </summary>
    [Serializable]
    public class ActionResultPagerData<T>
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// 输出的集合数据，此处对象必须为一个集合类型的对象，比如：数组,列表
        /// </summary>
        public List<T> ItemList { get; set; }
    }
}
