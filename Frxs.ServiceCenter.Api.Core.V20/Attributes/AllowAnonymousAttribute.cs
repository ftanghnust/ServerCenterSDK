/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/30 19:49:39
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 是否允许匿名访问，添加了此特性的接口类，将【不会校验全局，即实现了IAuthentication全局接口校验】，
    /// 但是如果接口指定了单独的特性校验（即继承了AuthenticationBaseAttribute特性的校验类），特性校验器会起作用进行校验
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class AllowAnonymousAttribute : Attribute
    {
    }
}
