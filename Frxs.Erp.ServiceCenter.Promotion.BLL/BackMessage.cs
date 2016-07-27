using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Promotion.BLL
{
    /// <summary>
    /// 业务处理类返回的消息结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BackMessage<T>
    {
        /// <summary>
        /// 是否操作成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 成功/错误消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回的实体类型
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 返回一个成功的消息
        /// </summary>
        /// <param name="t">T</param>
        /// <param name="msg">message</param>
        /// <returns></returns>
        public static BackMessage<T> SuccessBack(T t, string msg = "")
        {
            return new BackMessage<T>()
            {
                IsSuccess = true,
                Message = msg,
                Data = t
            };
        }

        /// <summary>
        /// 返回一个失败的消息
        /// </summary>
        /// <param name="t">T</param>
        /// <param name="msg">message</param>
        /// <returns></returns>
        public static BackMessage<T> FailBack(T t, string msg = "")
        {
            return new BackMessage<T>()
            {
                IsSuccess = false,
                Message = msg,
                Data = t
            };
        }


    }
}
