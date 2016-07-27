/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/24 16:01:31
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core.AccessRecorder.Domain
{
    /// <summary>
    /// 领域实体对象
    /// </summary>
    public class Response : BaseEntity
    {
        /// <summary>
        /// 上送的数据包
        /// </summary>
        public string RequestData { get; set; }

        /// <summary>
        /// 下发的数据包
        /// </summary>
        public string ResponseData { get; set; }
    }
}
