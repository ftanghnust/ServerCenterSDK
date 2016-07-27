/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/27/2016 9:59:58 AM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.Data.Core
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 该值表述了当前的Unit Of Work事务是否已被提交。
        /// </summary>
        bool Committed { get; }

        /// <summary>
        /// 保存领域对象
        /// </summary>
        /// <returns></returns>
        int Commit();
    }
}
