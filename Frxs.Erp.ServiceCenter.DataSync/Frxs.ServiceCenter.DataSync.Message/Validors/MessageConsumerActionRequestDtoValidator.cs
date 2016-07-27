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
    public class MessageConsumerActionRequestDtoValidator :
        RequestDtoFluentValidationBase<MessageConsumerAction.MessageConsumerActionRequestDto>
    {
        /// <summary>
        /// 
        /// </summary>
        public MessageConsumerActionRequestDtoValidator()
        {
            this.RuleFor(o => o.WID).GreaterThanOrEqualTo(0);
            //this.RuleFor(o => o.StartMessageId).NotNull().NotEmpty();
            this.RuleFor(o => o.Number).GreaterThanOrEqualTo(1);
            this.RuleFor(o => o.Number).LessThanOrEqualTo(1000);
        }
    }
}