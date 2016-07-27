/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 11/2/2015 8:32:16 PM
 * *******************************************************/
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// SDK接口访问入口接口
    /// </summary>
    public interface IApiClient
    {
        /// <summary>
        /// 请注意返回有可能未null，需要判断
        /// </summary>
        /// <typeparam name="T">返回格式化字符串（JSON/XML）对应的输出实体类型，需要继承TopRespBase抽象基类</typeparam>
        /// <param name="request"><![CDATA[请求参数类，需继承：RequestBase<>抽象基类]]></param>
        /// <returns>返回一个继承自：TopRespBase的数据对象</returns>
        /// <param name="cacheOptions">
        /// <![CDATA[
        /// 如果不启用SDK本地缓存，设置null即可
        /// 是否进行SDK本地缓存，如果设置为true(默认false)，返回对象将直接从本地SDK缓存里获取，
        /// 第一次访问不存在的时候，会自动将获取到的输出值压入本地缓存，下次调用同样接口参数相同的情况下
        /// 不会请求接口API，而是会直接获取本地缓存返回，建议将变化很不频繁的字典，配置对象数据可以缓存下，提高访问效率(默认过期时间60分钟)
        /// ]]>
        /// </param>
        T Execute<T>(RequestBase<T> request, CacheOptions cacheOptions = null) where T : ResponseBase;

        /// <summary>
        /// 是否开启日志记录
        /// </summary>
        /// <param name="disableTrace"></param>
        void SetDisableTrace(bool disableTrace);

        /// <summary>
        /// 远程连接的超时时间
        /// </summary>
        /// <param name="timeout"></param>
        void SetTimeout(int timeout);

        /// <summary>
        /// 设置日志记录器
        /// </summary>
        /// <param name="topLogger"></param>
        void SetTopLogger(IApiLogger topLogger);

        /// <summary>
        /// 设置新的缓存器
        /// </summary>
        /// <param name="cacheManager"></param>
        void SetCacheManager(ICacheManager cacheManager);

        /// <summary>
        /// 获取SDK本地缓存的所有缓存键
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetAllCacheKeys();

        /// <summary>
        /// 设置反序列化方式
        /// </summary>
        /// <param name="responseFormat"></param>
        void SetResponseFormat(ResponseFormat responseFormat);
    }
}