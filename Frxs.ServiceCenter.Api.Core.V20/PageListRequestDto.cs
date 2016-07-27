/*********************************************************
 * FRXS zhangliang@frxs.com 03/07/2016 14:48:17 PM
 * *******************************************************/
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 列表页请求参数基类，基于列表页的请求DTO，请继承此基类（非强制性）
    /// 此分页请求基类，默认上送的PageSize=10,PageIndex=1，在实现类里可以
    /// 重写BeforeValid()方法来更改框架默认设置的值
    /// </summary>
    public class PageListRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// 给个机会在Valid()方法调用前，先整理下当前页码和页容量
        /// </summary>
        public override void BeforeValid()
        {
            if (this.PageIndex <= 0) this.PageIndex = 1;
            if (this.PageSize <= 0) this.PageSize = 10;
        }

        /// <summary>
        /// 校验下参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            if (this.PageIndex <= 0)
            {
                yield return new RequestDtoValidatorResultError("PageIndex", "参数错误");
            }
            if (this.PageSize <= 0)
            {
                yield return new RequestDtoValidatorResultError("PageSize", "参数错误");
            }

            //基类校验（如果继承链上面存在校验，而且确认基类的校验是需要的，那么就需要使用怎样来调用基类的校验，否则基类的校验将会被完全覆盖掉）
            foreach (var item in base.Valid())
            {
                yield return item;
            }
        }
    }
}
