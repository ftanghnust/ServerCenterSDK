/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/28 10:50:55
 * *******************************************************/
using System;
using System.Threading;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 实现写锁
    /// </summary>
    public class WriteLockDisposable : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ReaderWriterLockSlim _readerWriterLocker;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rwLock"></param>
        public WriteLockDisposable(ReaderWriterLockSlim rwLock)
        {
            _readerWriterLocker = rwLock;
            _readerWriterLocker.EnterWriteLock();
        }

        /// <summary>
        /// 释放写锁
        /// </summary>
        void IDisposable.Dispose()
        {
            _readerWriterLocker.ExitWriteLock();
        }
    }
}
