/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/30/2015 9:09:00 AM
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 客户端提交上来的反序列化后对应的实体类接口
    /// 此接口仅仅是空接口，方便系统框架自动化
    /// </summary>
    public interface IRequestDto
    {
        /// <summary>
        /// 当前操作用户ID
        /// </summary>
        int UserId { get; set; }

        /// <summary>
        /// 当前操作用户名称
        /// </summary>
        string UserName { get; set; }
    }
}
