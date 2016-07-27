/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/21/2016 9:19:46 AM
 * *******************************************************/
using FluentValidation;

namespace Frxs.ServiceCenter.Api.Core.FluentValidation
{
    /// <summary>
    /// FluentValidation 验证模式基类，使用需要使用FluentValidation的验证类，需要继承此抽象基类
    /// </summary>
    public abstract class RequestDtoFluentValidationBase<T> : AbstractValidator<T> where T : RequestDtoBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected RequestDtoFluentValidationBase()
        {
            this.Initialize();
        }

        /// <summary>
        /// 让子类有机会先做一些初始化的工作
        /// </summary>
        protected virtual void Initialize()
        {
        }
    }
}
