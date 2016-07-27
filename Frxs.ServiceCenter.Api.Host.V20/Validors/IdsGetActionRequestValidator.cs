/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/21/2016 3:57:23 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Frxs.ServiceCenter.Api.Core.FluentValidation;

namespace Frxs.ServiceCenter.Api.Host.Validors
{
    /// <summary>
    /// 上送参数校验 基于：FluentValidation 方式，更多的演示配置可以查看
    /// https://github.com/JeremySkinner/FluentValidation/wiki
    /// </summary>
    public class IdsGetActionRequestValidator : RequestDtoFluentValidationBase<Actions.IdsGetAction.IdsGetActionRequest>
    {
        /// <summary>
        /// 
        /// </summary>
        public IdsGetActionRequestValidator()
        {
            this.RuleFor(o => o.Date).GreaterThan(new DateTime(2011, 1, 1)).WithMessage("时间必须大于2011-1-1");
            this.RuleFor(o => o.Y).NotNull().WithMessage("Y参数不能为null");
            this.Custom(x =>
            {
                return x.Date.Year <= 1900 ? new FluentValidation.Results.ValidationFailure("", "") : null;
            });
        }
    }
}