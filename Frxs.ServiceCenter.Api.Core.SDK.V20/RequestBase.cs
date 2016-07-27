/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 11/4/2015 8:32:48 AM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// 使用默认基类；
    /// 使用了一些默认的约定
    /// 1.GetRequestJsonData 方法会自动查找基础类是否了Data属性，如果有Data属性会指定将此对象转化成JSON对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RequestBase<T> : IApiRequest<T> where T : ResponseBase
    {
        /// <summary>
        /// SDK客户端调用者ID（在一些添加，修改接口中后台服务需要）
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// SDK客户端调用者名称（在一些添加，修改接口中后台服务需要）
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 方法名称，对应于接口
        /// </summary>
        /// <returns></returns>
        public abstract string GetApiName();

        /// <summary>
        /// 接口版本号，默认不指定版本号
        /// </summary>
        /// <returns></returns>
        public virtual string GetVersion()
        {
            return string.Empty;
        }

        /// <summary>
        /// 默认使用http-POST提交，需要改成GET的，请在实现类里重写
        /// </summary>
        /// <returns></returns>
        public virtual HttpMethod GetHttpMethod()
        {
            return HttpMethod.POST;
        }

        /// <summary>
        /// 需要替换的一些东西，默认为空
        /// </summary>
        /// <returns></returns>
        public virtual IDictionary<string, string> GetReplaces()
        {
            return new ApiDictionary();
        }

        /// <summary>
        /// 继承的请求类型，在定义Data参数的时候会有2种方式，Data类型是一个可变类型
        /// 1.Data参数如果不属于string类型，那么框架将会进行序列化操作，格式化成JSON数据进行提交
        /// 2.如果Data参数定义成了string类型，那么系统将会直接使用字符串，而不会进行序列化，请注意设置的字符串为正确的JSON格式
        /// </summary>
        /// <returns></returns>
        public virtual string GetRequestJsonData()
        {
            try
            {
                //搜索当前对象是否定义了Data属性
                var p = this.GetType().GetPropertyInfo("Data");
                //没有定义Data属性，直接返回"{}"
                if (null == p)
                {
                    return "{}";
                }

                //获取参数值
                var requestData = p.GetValue(this);

                //获取到定义的参数数据包类型
                Type requestDataType = requestData.GetType();

                //如果指定的是JSON的字符串，那么直接使用字符串
                if (typeof(string).Equals(requestDataType))
                {
                    return requestData.ToString();
                }

                //object的，序列化成JSON字符串进行提交
                string requestDataJsonString = requestData.ToJson().Substring(1);
                IList<string> attachParams = new List<string>();

                //检测data参数是否定义了UserId，如果参数包没有定义userid，直接构造一个UserId参数提交
                var userIdProperty = requestDataType.GetPropertyInfo("UserId");
                if (null == userIdProperty)
                {
                    attachParams.Add(string.Format("\"UserId\":{0}", this.UserId));
                }

                //检测data参数是否定义了UserName，如果未定义UserName，直接构造一个UserName参数提交
                var userNameProperty = requestDataType.GetPropertyInfo("UserName");
                if (null == userNameProperty)
                {
                    attachParams.Add(string.Format("\"UserName\":\"{0}\"", this.UserName ?? string.Empty)); //默认设置为空
                }

                //构造参数
                attachParams.Add(requestDataJsonString);

                //注入一个属性
                return "{" + string.Join(",", attachParams.ToArray());

            }
            catch
            {
                //未找到自定义的Data属性，系统自动进行转换成"{}"，
                //因为有些业务情况下，无需传入任何data参数，比如：获取全部的分类信息，Data就不会定义
                //或者直接在请求实现类里重写此方法，直接返回{}，这样效率比较高一些
                //return null;
                return "{}";
            }
        }
    }
}
