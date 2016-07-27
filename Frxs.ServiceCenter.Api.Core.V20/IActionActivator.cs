/*********************************************************
 * FFRXS(ISC) zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// action激活器
    /// </summary>
    public interface IActionActivator
    {
        /// <summary>
        /// 通过action类型，激活action
        /// </summary>
        /// <param name="actionType">IAction类型信息</param>
        /// <returns>Action对象实例</returns>
        IAction Create(Type actionType);
    }
}