/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 3:30:45 PM
 * *******************************************************/
using FluentValidation;
using Frxs.ServiceCenter.Api.Core.FluentValidation;
using Frxs.ServiceCenter.DataSync.Message.Server.Actions;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Validors
{
    /// <summary>
    /// 参数校验
    /// </summary>
    public class MessagePublisherActionRequestDtoValidator :
        RequestDtoFluentValidationBase<MessagePublisherAction.MessagePublisherActionRequestDto>
    {
        /// <summary>
        /// 
        /// </summary>
        public MessagePublisherActionRequestDtoValidator()
        {
            this.RuleFor(o => o.WID).GreaterThanOrEqualTo(0);
            this.RuleFor(o => o.Topic).NotNull();
            this.RuleFor(o => o.Body).NotNull();
        }
    }
}