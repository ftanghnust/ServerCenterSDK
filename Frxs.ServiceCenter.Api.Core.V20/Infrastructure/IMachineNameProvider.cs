/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/6/13 9:50:22
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 获取当前运行实例信息
    /// </summary>
    public interface IMachineNameProvider
    {
        /// <summary>
        /// 获取应用程序运行的实例名称
        /// </summary>
        string GetMachineName();
    }
}
