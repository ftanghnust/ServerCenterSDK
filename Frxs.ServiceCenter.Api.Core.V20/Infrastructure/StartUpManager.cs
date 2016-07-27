/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/19 8:54:06
 * *******************************************************/
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 系统启动项管理器
    /// </summary>
    internal class StartUpManager
    {
        /// <summary>
        /// 启动实现了IStartUp接口的所有类
        /// </summary>
        /// <param name="typeFinder">类型查找器</param>
        public static void Start(ITypeFinder typeFinder)
        {
            using (var scope = ServicesContainer.Current.Scope())
            {
                typeFinder.CheckNullThrowArgumentNullException("typeFinder");
                typeFinder.FindClassesOfType<IStartUp>().ToList().ForEach(type =>
                {
                    ((IStartUp)ServicesContainer.Current.ResolverUnregistered(type, scope)).Init();
                });
            }
        }
    }
}
