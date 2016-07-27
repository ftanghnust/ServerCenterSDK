/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 值绑定器
    /// </summary>
    public interface IModelBinder
    {
        /// <summary>
        /// 根据值提供器，生成对象，并且对模板对象属性赋值
        /// </summary>
        /// <param name="valueProvidersManager">值提供器管理器</param>
        /// <returns></returns>
        T Bind<T>(IValueProvidersManager valueProvidersManager);

    }
}