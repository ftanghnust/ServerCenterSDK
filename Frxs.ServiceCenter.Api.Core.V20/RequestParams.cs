/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/31/2015 11:04:21 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 接口客户端提交的核心参数包
    /// </summary>
    [Serializable]
    public class RequestParams
    {
        /// <summary>
        /// 客户端ID：比如：20009等
        /// </summary>
        public string AppKey { get; set; }

        /// <summary>
        /// 从请求的信息里获取到请求的接口名称，比如：API.Help
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 客户端指定接口服务器返回数据的格式化方式 XML/JSON/VIEW
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 上传的JSON数据；就算是不需上送参数，也需要上送"{}"字符串
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 上传时间戳（服务器与服务端到时候进行时间比对）;格式为：yyyy/MM/dd HH:mm:ss
        /// 应用场景：比如，一个接口如果不加这个时间戳的时候，只要有人截获了提交参数以及知道了URL
        /// 那么截获访问消息的人，完全可以重复提交接口数据，这尤其在针对数据操作的时候，影响比较大，
        /// 因此加上次时间戳，让调用客户端上送客户端时间，然后服务器比对时间戳与服务器时间，
        /// 如果相差时间间隔比较大（比如1分钟），那么不允许提交
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// 接口版本（在有多个接口名称一致的情况下；可以根据指定接口版本来选择特定的版本接口）
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 客户端数据签名（具体的数据签名方式需要在实际业务场景里约定）
        /// </summary>
        public string Sign { get; set; }

        ///// <summary>
        ///// 重写下2此请求参数对象是否相同
        ///// </summary>
        ///// <param name="lRequestParams"></param>
        ///// <param name="rRequestParams"></param>
        ///// <returns></returns>
        //public static bool operator ==(RequestParams lRequestParams, RequestParams rRequestParams)
        //{
        //    return lRequestParams.Equals(rRequestParams);
        //}

        ///// <summary>
        ///// 重写下2此请求参数对象是否不同
        ///// </summary>
        ///// <param name="lRequestParams"></param>
        ///// <param name="rRequestParams"></param>
        ///// <returns></returns>
        //public static bool operator !=(RequestParams lRequestParams, RequestParams rRequestParams)
        //{
        //    return !(lRequestParams == rRequestParams);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="other"></param>
        ///// <returns></returns>
        //protected bool Equals(RequestParams other)
        //{
        //    return string.Equals(AppKey, other.AppKey) && string.Equals(ActionName, other.ActionName) &&
        //           string.Equals(Format, other.Format) && string.Equals(Data, other.Data) &&
        //           string.Equals(TimeStamp, other.TimeStamp) && string.Equals(Version, other.Version) &&
        //           string.Equals(Sign, other.Sign);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //public override bool Equals(object obj)
        //{
        //    if (ReferenceEquals(null, obj)) return false;
        //    if (ReferenceEquals(this, obj)) return true;
        //    if (obj.GetType() != this.GetType()) return false;
        //    return Equals((RequestParams)obj);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public override int GetHashCode()
        //{
        //    unchecked
        //    {
        //        var hashCode = (AppKey != null ? AppKey.GetHashCode() : 0);
        //        hashCode = (hashCode * 397) ^ (ActionName != null ? ActionName.GetHashCode() : 0);
        //        hashCode = (hashCode * 397) ^ (Format != null ? Format.GetHashCode() : 0);
        //        hashCode = (hashCode * 397) ^ (Data != null ? Data.GetHashCode() : 0);
        //        hashCode = (hashCode * 397) ^ (TimeStamp != null ? TimeStamp.GetHashCode() : 0);
        //        hashCode = (hashCode * 397) ^ (Version != null ? Version.GetHashCode() : 0);
        //        hashCode = (hashCode * 397) ^ (Sign != null ? Sign.GetHashCode() : 0);
        //        return hashCode;
        //    }
        //}
    }
}
