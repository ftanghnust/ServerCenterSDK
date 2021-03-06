﻿/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/21/2016 11:16:36 AM
 * *******************************************************/
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 系统RequestDto验证管理类，因为系统框架可能会注册多个验证实现
    /// </summary>
    internal interface IRequestDtoValidatorManager
    {
        /// <summary>
        /// 获取所有的RequestDto验证管理器
        /// </summary>
        IEnumerable<IRequestDtoValidator> RequestDtoValidators { get; }

        /// <summary>
        /// 针对多个RequestDto校验器进行校验
        /// </summary>
        /// <param name="requestDto">上送业务参数对象</param>
        /// <param name="actionDescriptor">当前接口描述</param>
        /// <returns></returns>
        RequestDtoValidatorResult Valid(RequestDtoBase requestDto, ActionDescriptor actionDescriptor);
    }
}
