/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/12/24 8:52:48
 * *******************************************************/
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 系统框架默认RequestDto对象属性校验器，完全兼容：System.ComponentModel.DataAnnotations 命名空间特性验证
    /// </summary>
    public class DefaultRequestDtoValidator : IRequestDtoValidator
    {
        /// <summary>
        /// 验证实体数据正确性，返回RequestDtoValidatorResult对象
        /// </summary>
        public RequestDtoValidatorResult Valid(RequestDtoBase requestDto, ActionDescriptor actionDescriptor)
        {
            //用于保存验证集合
            var validationResultErrors = new List<RequestDtoValidatorResultError>();

            //校验定义在参数对象上的特性校验
            var validationContext = new ValidationContext(requestDto);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(requestDto, validationContext, results, true))
            {
                results.ForEach(o =>
                {
                    validationResultErrors.Add(new RequestDtoValidatorResultError(
                        string.Join(",", o.MemberNames.ToArray()), o.ErrorMessage));
                });
            }

            //返回校验错误集合
            return new RequestDtoValidatorResult(validationResultErrors);
        }
    }
}
