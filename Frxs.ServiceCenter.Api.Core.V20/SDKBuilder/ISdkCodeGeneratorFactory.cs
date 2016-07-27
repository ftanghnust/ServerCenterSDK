/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/12 12:42:51
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISdkCodeGeneratorFactory
    {
        /// <summary>
        /// 创建客户端SDK输出器工厂
        /// </summary>
        /// <param name="language">语言(CSharp,JAVA,PHP,Android)</param>
        /// <returns></returns>
        SdkCodeGeneratorBase Create(string language);
    }
}
