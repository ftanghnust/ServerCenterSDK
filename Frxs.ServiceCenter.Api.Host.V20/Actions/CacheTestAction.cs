using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/30 14:05:09
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Host.Actions
{
    /// <summary>
    /// 缓存演示
    /// </summary>
    [UnloadCachekeys("Frxs.Cats", "Frxs.Product", "Frxs.WProduct", "API.Logs")]
    [Route("api/getcache")]
    public class CacheTestAction : ActionBase<NullRequestDto, object>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ICacheManager _cacheManager;
        private readonly IMachineNameProvider _machineNameProvider;

        /// <summary>
        /// 接口单独使用指定的缓存器，比如：全局使用Redis但是，
        /// 这个接口需要单独使用Memcached缓存，可以这样配置，然后注册此接口既可
        /// </summary>
        /// <param name="cacheManager">缓存器</param>
        /// <param name="machineNameProvider"></param>
        public CacheTestAction(ICacheManager cacheManager, IMachineNameProvider machineNameProvider)
        {
            this._cacheManager = cacheManager;
            this._machineNameProvider = machineNameProvider;
        }

        /// <summary>
        /// 属性值对象
        /// </summary>
        public class AttributeValue : IEquatable<AttributeValue>
        {
            /// <summary>
            /// 属性值编号
            /// </summary>
            public int ValuesId { get; set; }

            /// <summary>
            /// 属性值
            /// </summary>
            public string ValueStr { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            public bool Equals(AttributeValue other)
            {
                return this.ValuesId == other.ValuesId && this.ValueStr == other.ValueStr;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                return this.ValuesId.GetHashCode() ^ this.ValueStr.GetHashCode();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<object> Execute()
        {

            List<AttributeValue> attributeValues = new List<AttributeValue>();
            attributeValues.Add(new AttributeValue() { ValuesId = 1, ValueStr = "s" });
            attributeValues.Add(new AttributeValue() { ValuesId = 1, ValueStr = "s" });

            var s = attributeValues.Distinct().ToList();

            this.Logger.Information("构造注入的缓存实现：{0}".With(this._cacheManager.ToString()));

            this.Logger.Information("全局使用的缓存实现：{0}".With(this.CacheManager.ToString()));

            //全局缓存
            var ss = this.CacheManager.Get(this.GetRequestCacheKey(), () => new Data.Domain.Warehouse()
            {
                Parent = null,
                WHID = "12",
                WHName = "xs"
            });

            var s0 = this.CacheManager.Get("x", () => attributeValues);

            //foreach (string item in RequestContext.HttpContext.Request.ServerVariables.Keys)
            //{
            //    this.RequestContext.HttpContext.Response.Write("\r\n"+item+"-->"+RequestContext.HttpContext.Request.ServerVariables[item]);
            //}

            return this.SuccessActionResult(this._machineNameProvider.GetMachineName() + this.RequestContext.HttpContext.ApplicationInstance + this.RequestContext.HttpContext.Handler);
        }
    }
}