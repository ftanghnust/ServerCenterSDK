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
    public class MessageStoreCreateActionRequestDtoValidator :
        RequestDtoFluentValidationBase<MessageStoreCreateAction.MessageStoreCreateActionRequestDto>
    {
        /// <summary>
        /// 
        /// </summary>
        public MessageStoreCreateActionRequestDtoValidator()
        {
            this.RuleFor(o => o.WID).GreaterThan(0);
        }
    }
}