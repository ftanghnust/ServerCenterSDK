/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/30/2015 12:55:19 PM
 * *******************************************************/
namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// Action接口执行器（Action代理封装），方便对action执行方法进行AOP横切
    /// </summary>
    public interface IActionInvoker
    {
        /// <summary>
        /// Action执行器，通过当前action对象，调用IAction.Execute()方法进行接口执行
        /// </summary>
        /// <param name="action">IAction接口实例</param>
        /// <returns>ActionResult对象</returns>
        ActionResult Execute(IAction action);
    }
}