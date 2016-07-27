/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/13/2016 4:16:30 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// JSON序列化接口，交给外部调用系统去实现，解耦下框架直接依赖于某个组件
    /// </summary>
    public interface IJosnSerializer
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="value">JSON字符串</param>
        /// <param name="type">反序列的类型</param>
        /// <returns>返回对象，如果反序列失败，请返回null</returns>
        object Deserialize(string value, Type type);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">待反序列化的类型</typeparam>
        /// <param name="value">JSON字符串</param>
        /// <returns>返回对象，如果反序列失败，请返回null</returns>
        T Deserialize<T>(string value);

        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="value">待序列化的对象</param>
        /// <returns>返回JSON字符串</returns>
        string Serialize(object value);
    }
}
