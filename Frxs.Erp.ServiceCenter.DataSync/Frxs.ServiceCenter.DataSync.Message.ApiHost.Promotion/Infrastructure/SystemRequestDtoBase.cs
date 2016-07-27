/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/5/2016 3:38:17 PM
 * *******************************************************/
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Promotion
{
    /// <summary>
    /// 促销中心的所有接口上送参数需要继承此类
    /// </summary>
    public class SystemRequestDtoBase : RequestDtoBase
    {
        /// <summary>
        /// 仓库编号
        /// </summary>
        [GreaterThan(0)]
        public int WID { get; set; }

        /// <summary>
        /// 重写，供依赖注入使用
        /// </summary>
        public override void BeforeValid()
        {
            if (!HttpContext.Current.IsNull())
                HttpContext.Current.Items["WID"] = WID;
        }
    }
}
