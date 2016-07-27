/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/24 14:47:30
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core.AccessRecorder
{
    /// <summary>
    /// 所有记录模型基类
    /// </summary>
    public class BaseEntity : Frxs.ServiceCenter.Data.Core.BaseEntity
    {
        /// <summary>
        /// 主键ID;每个实体对象默认设置一个ID属性
        /// </summary>
        public long Id { get; set; }
    }
}
