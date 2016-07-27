/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/24 14:47:16
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Frxs.ServiceCenter.Data.Core
{
    /// <summary>
    /// 方便直接使用SQL语句
    /// </summary>
    public interface IDbContext : IDisposable
    {
        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Executes the given DDL/DML command against the database. As with any API that
        /// accepts SQL it is important to parameterize any user input to protect against
        /// a SQL injection attack. You can include parameter place holders in the SQL query
        /// string and then supply parameter values as additional arguments. Any parameter
        /// values you supply will automatically be converted to a DbParameter. context.Database.ExecuteSqlCommand("UPDATE
        /// dbo.Posts SET Rating = 5 WHERE Author = @p0", userSuppliedAuthor); Alternatively,
        /// you can also construct a DbParameter and supply it to SqlQuery. This allows you
        /// to use named parameters in the SQL query string. context.Database.ExecuteSqlCommand("UPDATE
        /// dbo.Posts SET Rating = 5 WHERE Author = @author", new SqlParameter("@author",
        /// userSuppliedAuthor));
        /// </summary>
        /// <typeparam name="TElement">The type of object returned by the query.</typeparam>
        /// <param name="sql">The SQL query string.</param>
        /// <param name="parameters">The parameters to apply to the SQL query string.</param>
        /// <returns>Result</returns>
        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

        /// <summary>
        /// Executes the given DDL/DML command against the database.
        /// </summary>
        /// <param name="sql">The command string</param>
        /// <param name="doNotEnsureTransaction">false - the transaction creation is not ensured; true - the transaction creation is ensured.</param>
        /// <param name="timeout">Timeout value, in seconds. A null value indicates that the default value of the underlying provider will be used</param>
        /// <param name="parameters">The parameters to apply to the command string.</param>
        /// <returns>The result returned by the database after executing the command.</returns>
        int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);

        /// <summary>
        /// Detach an entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Detach(object entity);

        /// <summary>
        /// Gets or sets a value indicating whether proxy creation setting is enabled (used in EF)
        /// </summary>
        bool ProxyCreationEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether auto detect changes setting is enabled (used in EF)
        /// </summary>
        bool AutoDetectChangesEnabled { get; set; }
    }
}
