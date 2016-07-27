/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/12/24 8:52:48
 * *******************************************************/
using System.Linq;
using FluentValidation;

namespace Frxs.ServiceCenter.Api.Core.FluentValidation
{
    /// <summary>
    /// 
    /// </summary>
    public class FluentRequestDtoValidator : IRequestDtoValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestDto"></param>
        /// <param name="actionDescriptor"></param>
        /// <returns></returns>
        public RequestDtoValidatorResult Valid(RequestDtoBase requestDto, ActionDescriptor actionDescriptor)
        {
            //判断当前RequestDto对象是否映射了验证
            if (!FluentValidationManager.Configs.Keys.Contains(requestDto.GetType()))
            {
                return RequestDtoValidatorResult.Success;
            }

            //获取验证类型
            var fluentValidationType = FluentValidationManager.Configs[requestDto.GetType()];

            //创建验证
            var fluentValidationInstance = (IValidator)ServicesContainer.Current.ResolverUnregistered(fluentValidationType);

            //校验开始
            var validResult = fluentValidationInstance.Validate(requestDto);

            //校验成功
            if (validResult.IsValid)
            {
                return RequestDtoValidatorResult.Success;
            }

            //失败返回错误消息
            return new RequestDtoValidatorResult(from item in validResult.Errors
                                                 select new RequestDtoValidatorResultError(item.PropertyName, item.ErrorMessage));
        }
    }
}
