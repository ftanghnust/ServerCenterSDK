/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/21/2016 10:43:08 AM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 系统框架默认实现的验证器管理类
    /// </summary>
    internal class DefaultRequestDtoValidatorManager : IRequestDtoValidatorManager
    {
        /// <summary>
        /// 
        /// </summary>
        private IEnumerable<IRequestDtoValidator> _requestDtoValidators;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestDtoValidators">系统框架注册的所有验证器，可以为null，为null表示满意校验器</param>
        public DefaultRequestDtoValidatorManager(IEnumerable<IRequestDtoValidator> requestDtoValidators)
        {
            this._requestDtoValidators = requestDtoValidators;
        }

        /// <summary>
        /// 获取所有的RequestDto验证管理器
        /// </summary>
        public IEnumerable<IRequestDtoValidator> RequestDtoValidators
        {
            get
            {
                return this._requestDtoValidators;
            }
        }

        /// <summary>
        /// 校验上送参数
        /// </summary>
        /// <returns></returns>
        public RequestDtoValidatorResult Valid(RequestDtoBase requestDto, ActionDescriptor actionDescriptor)
        {
            //如果实现了验证接口，就先在执行校验前，先执行下手工修改参数的方法
            var validatableObject = requestDto as IRequestDtoValidatable;
            if (!validatableObject.IsNull())
            {
                validatableObject.BeforeValid();
            }

            //检测是否实现了IRequiredUserIdAndUserName接口,校验用户名和用户ID或者在接口定义了需要校验的特性
            if (requestDto is IRequiredUserIdAndUserName || actionDescriptor.RequiredUserIdAndUserName)
            {
                //验证用户ID和用户名称的委托为空弹出消息
                if (SystemOptionsManager.Current.ValidUserIdAndUserNameFun.IsNull())
                {
                    return new RequestDtoValidatorResult(new[] { new RequestDtoValidatorResultError("ValidUserIdAndUserNameFun",
                        Resource.CoreResource.ActionBase_ValidUserIdAndUserNameFun_Null_Error) });
                }

                //检测用户ID和用户名称是否提交
                if (!SystemOptionsManager.Current.ValidUserIdAndUserNameFun(requestDto))
                {
                    return new RequestDtoValidatorResult(new[] { new RequestDtoValidatorResultError("UserId,UserName",
                        Resource.CoreResource.ActionBase_RequiredUserIdAndUserName_Error) });
                }
            }

            //实现了IRequestDtoValidatable接口，就先触发手工验证
            if (!validatableObject.IsNull())
            {
                var validResult = validatableObject.Valid();
                //手工校验未通过，直接返回校验错误
                if (!validResult.IsNull() && validResult.Any())
                {
                    return new RequestDtoValidatorResult(validResult);
                }
            }

            //没有定义验证器
            if (this._requestDtoValidators.IsNull() || this._requestDtoValidators.IsEmpty())
            {
                return RequestDtoValidatorResult.Success;
            }

            //多个验证器循环验证
            foreach (var item in this._requestDtoValidators)
            {
                var validResult = item.Valid(requestDto, actionDescriptor);

                //一旦某个验证器验证不通过，就直接返回了
                if (!validResult.IsValid)
                {
                    return validResult;
                }
            }

            //全部验证通过
            return RequestDtoValidatorResult.Success;
        }
    }
}
