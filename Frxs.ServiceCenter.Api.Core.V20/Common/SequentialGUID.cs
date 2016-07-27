/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/12/22 13:04:45
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 有序GUID生成器；用于有可能需要排序保存的场景下使用
    /// </summary>
    public class SequentialGUID
    {
        /// <summary>
        /// 导入系统提供输出有序GUID方法
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [DllImport("rpcrt4.dll", SetLastError = true)]
        private static extern int UuidCreateSequential(out Guid guid);

        /// <summary>
        /// 创建一个有序的GUID
        /// </summary>
        /// <returns>返回一个有序的GUID</returns>
        public static Guid GenerateSequentialGuid()
        {
            Guid result;
            UuidCreateSequential(out result);
            return result;
        }

        /// <summary>
        /// 获取一批有序GUID
        /// </summary>
        /// <param name="n">返回多少条有序GUID值</param>
        /// <returns></returns>
        public static IEnumerable<Guid> GenerateSequentialGuids(int n)
        {
            if (0 >= n)
            {
                throw new ArgumentException("参数n必须大于0");
            }
            for (int i = 0; i < n; i++)
            {
                yield return GenerateSequentialGuid();
            }
        }
    }
}
