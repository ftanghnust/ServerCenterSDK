/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/17/2016 12:46:13 PM
 * *******************************************************/
using System.Text;

namespace Frxs.ServiceCenter.Api.Core.ViewEngine
{
    /// <summary>
    /// 系统框架视图引擎接口，注意此接口为多实现协作接口，即：外部多个实现系统框架都会认为合法，并且会依次循环所有实现
    /// </summary>
    public interface IViewEngine
    {
        /// <summary>
        /// 支持的后缀，格式必须如：.cshtml或者.aspx或者 .xxx
        /// </summary>
        string SupportedExtension { get; }

        /// <summary>
        /// 编译视图文件并执行视图
        /// </summary>
        /// <param name="viewPath">视图文件路径，请输入绝对路径比如：g:\\temp\t.aspx</param>
        /// <param name="parameters">视图定义的参数集合</param>
        /// <param name="encode">视图文件文件编码</param>
        /// <returns>返回视图执行结果字符串</returns>
        string CompileByViewPath(string viewPath, ViewParameterCollection parameters, Encoding encode);

        /// <summary>
        /// 编译视图文件并执行视图
        /// </summary>
        /// <param name="viewSource">视图文件源码</param>
        /// <param name="parameters">视图定义的参数集合</param>
        /// <param name="encode">视图文件文件编码</param>
        /// <returns>编译视图源代码，并将视图执行结果返回</returns>
        string CompileByViewSource(string viewSource, ViewParameterCollection parameters, Encoding encode);
    }
}
