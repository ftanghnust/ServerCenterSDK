/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/21/2016 11:17:05 AM
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 上送对象RequestDto对象验证接口，注意此接口为多实现协作接口
    /// </summary>
    public interface IRequestDtoValidator
    {
        /// <summary>
        /// 验证实体数据正确性，返回RequestDtoValidatorResult对象
        /// </summary>
        /// <param name="requestDto">上送业务参数对象</param>
        /// <param name="actionDescriptor">当前接口描述</param>
        /// <returns></returns>
        RequestDtoValidatorResult Valid(RequestDtoBase requestDto, ActionDescriptor actionDescriptor);
    }
}
