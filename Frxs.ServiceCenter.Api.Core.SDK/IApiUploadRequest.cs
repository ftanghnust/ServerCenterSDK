/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/9 10:07:39
 * *******************************************************/
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// 上传接口请求参数接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IApiUploadRequest<T> : IApiRequest<T> where T : ResponseBase
    {
        /// <summary>
        /// 获取待上传的文件列表
        /// </summary>
        /// <returns></returns>
        IDictionary<string, FileItem> GetFileParameters();
    }
}
