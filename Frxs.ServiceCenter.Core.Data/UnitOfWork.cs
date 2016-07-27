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
    /// 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
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
            catch (Exception exc)
            {
                this.Committed = false;
            }

            return 0;
        }
    }
}
