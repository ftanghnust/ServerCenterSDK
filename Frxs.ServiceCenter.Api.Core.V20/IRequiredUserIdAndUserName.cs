/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/12/24 9:31:54
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// RequestDto如果继承了此接口，那么就要校验请求包Data里是否包含了userId和UserName参数
    /// 此接口仅仅是个空接口，仅做标识，用于框架判断上送参数用
    /// </summary>
    public interface IRequiredUserIdAndUserName
    {
    }
}
