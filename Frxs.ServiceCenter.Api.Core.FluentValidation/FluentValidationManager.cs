/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/21/2016 10:09:38 AM
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core.FluentValidation
{
    /// <summary>
    /// 配置管理器
    /// </summary>
    internal class FluentValidationManager
    {
        /// <summary>
        /// 
        /// </summary>
        private static FluentValidationCollection _instance = new FluentValidationCollection();

        /// <summary>
        /// 返回所有的验证配置信息
        /// </summary>
        public static FluentValidationCollection Configs
        {
            get
            {
                return _instance;
            }
        }
    }
}
