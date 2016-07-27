/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/25 17:57:44
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.Api.Core.SdkBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public static class ActionConfigCollectionExtensions
    {
        /// <summary>
        /// 禁用所有的系统框架接口
        /// </summary>
        /// <param name="actionConfigCollection">接口配置表对象</param>
        /// <returns></returns>
        public static IActionConfigCollection ObsoleteSdkBuilderActions(this IActionConfigCollection actionConfigCollection)
        {
            var actionNames = new[] { "Api.Doc", "Api.Doc.Builder", "API.TestTool", "API.BuildSdk" };
            foreach (var current in actionNames)
            {
                actionConfigCollection.Register(current, new ActionConfigItem() { Obsolete = true });
            }
            return actionConfigCollection;
        }
    }
}
