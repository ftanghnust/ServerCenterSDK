/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/2/2016 2:46:51 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 标注事件是否是全局事件，如果定义了此特性就是全局事件，那么WID就不需要传
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GlobalEventAttribute : Attribute { }
}