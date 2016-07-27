/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/20 16:04:54
 * *******************************************************/
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// SDK生成器抽象基类
    /// </summary>
    public abstract class SdkCodeGeneratorBase : CodeGeneratorBase
    {
        /// <summary>
        /// 针对那种语言
        /// </summary>
        public abstract string Language { get; }

        /// <summary>
        /// 获取上送参数客户端请求类
        /// </summary>
        /// <param name="actionDescriptor">接口描述对象</param>
        /// <returns>key：客户端请求调用类名称，也是生成文件的名称，value:源代码</returns>
        public abstract KeyValuePair<string, string> GeneratorRequest(IActionDescriptor actionDescriptor);

        /// <summary>
        /// 获取下送数据客户端输出类
        /// </summary>
        /// <param name="actionDescriptor">接口描述对象</param>
        /// <returns>key：客户端请求调用类名称，也是生成文件的名称，value:源代码</returns>
        public abstract KeyValuePair<string, string> GeneratorResponse(IActionDescriptor actionDescriptor);
    }
}
