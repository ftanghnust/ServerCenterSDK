using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.BLL
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
    }
}
