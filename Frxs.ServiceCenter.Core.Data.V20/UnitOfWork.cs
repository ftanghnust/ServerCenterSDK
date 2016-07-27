/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/27/2016 10:02:58 AM
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
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        private IDbContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public UnitOfWork(IDbContext dbContext)
        {
            this.Committed = false;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Committed { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            try
            {
                var result = this._dbContext.SaveChanges();
                this.Committed = true;
                return result;
            }
            catch (Exception ex)
            {
                this.Committed = false;
                throw new Exception(ex.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            // throw new NotImplementedException();
        }
    }
}
