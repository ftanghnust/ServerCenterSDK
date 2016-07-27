using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/3 9:55:14
 * *******************************************************/

namespace Frxs.ServiceCenter.DataSync.Message.Server.Actions
{
    /// <summary>
    /// 消息消费客户端代码生成器接口
    /// </summary>
    [DisablePackageSdk]
    public class ConsumerEventArgsItemCodeGeneratorAction : ActionBase<
        ConsumerEventArgsItemCodeGeneratorAction.ConsumerEventArgsItemCodeGeneratorActionRequestDto,
        IEvenSelector>
    {
        /// <summary>
        /// 上送参数
        /// </summary>
        public class ConsumerEventArgsItemCodeGeneratorActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 事件名称
            /// </summary>
            [Required]
            public string EventName { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IEvenSelector _eventMessageBodyMapManager;
        private readonly IMediaTypeFormatterFactory _mediaTypeFormatterFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventMessageBodyMapManager">时间消息摘要映射管理类</param>
        /// <param name="mediaTypeFormatterFactory">格式化器创建器</param>
        public ConsumerEventArgsItemCodeGeneratorAction(
            IEvenSelector eventMessageBodyMapManager,
            IMediaTypeFormatterFactory mediaTypeFormatterFactory)
        {
            this._eventMessageBodyMapManager = eventMessageBodyMapManager;
            this._mediaTypeFormatterFactory = mediaTypeFormatterFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IEvenSelector> Execute()
        {
            return this.SuccessActionResult(this._eventMessageBodyMapManager);
        }
    }
}