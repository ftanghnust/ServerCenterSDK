/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 默认的输出接口创建器
    /// </summary>
    internal class DefaultMediaTypeFormatterFactory : IMediaTypeFormatterFactory
    {
        /// <summary>
        /// 根据指定的格式化枚举，创建对应的格式化输出器
        /// </summary>
        /// <param name="format">格式化枚举</param>
        /// <returns>格式化输出器</returns>
        public IMediaTypeFormatter Create(ResponseFormat format)
        {
            switch (format)
            {
                case ResponseFormat.XML:
                    return ServicesContainer.Current.ResolverAll<IMediaTypeFormatter>("Xml_MediaTypeFormatter")[0];
                case ResponseFormat.JSON:
                    return ServicesContainer.Current.ResolverAll<IMediaTypeFormatter>("Json_MediaTypeFormatter")[0];
                case ResponseFormat.VIEW:
                    return ServicesContainer.Current.ResolverAll<IMediaTypeFormatter>("View_MediaTypeFormatter")[0];
                default:
                    return ServicesContainer.Current.ResolverAll<IMediaTypeFormatter>("Json_MediaTypeFormatter")[0];
            }
        }
    }
}