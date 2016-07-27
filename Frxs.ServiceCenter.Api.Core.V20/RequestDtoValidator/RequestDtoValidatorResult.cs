/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/2/17 15:26:10
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 验证返回结果对象
    /// </summary>
    public class RequestDtoValidatorResult
    {
        /// <summary>
        /// 验证成功
        /// </summary>
        public static RequestDtoValidatorResult Success
        {
            get
            {
                return new RequestDtoValidatorResult(null);
            }
        }

        /// <summary>
        /// 初始化验证结果对象
        /// </summary>
        /// <param name="errors">验证错误集合</param>
        public RequestDtoValidatorResult(IEnumerable<RequestDtoValidatorResultError> errors = null)
        {
            this.Errors = errors ?? new List<RequestDtoValidatorResultError>();
        }

        /// <summary>
        /// 错误信息集合;如果为没有错误，则返回一个空的错误信息集合
        /// </summary>
        public IEnumerable<RequestDtoValidatorResultError> Errors { get; private set; }

        /// <summary>
        /// 是否验证成功
        /// </summary>
        public bool IsValid
        {
            get
            {
                return !this.Errors.Any();
            }
        }

    }
}
