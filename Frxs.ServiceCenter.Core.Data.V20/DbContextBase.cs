/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/24 14:47:12
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;

namespace Frxs.ServiceCenter.Data.Core
{
    /// <summary>
    /// 实体对象访问上下文基类
    /// </summary>
    public class DbContextBase : DbContext, IDbContext
    {
        /// <summary>
        /// 初始化数据库上下文
        /// </summary>
        /// <param name="nameOrConnectionString">数据库连接字符串</param>
        public DbContextBase(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        /// <summary>
        /// 映射程序集
        /// </summary>
        protected virtual Assembly EntityTypeConfigurationMapAssembly
        {
            get
            {
                return Assembly.GetExecutingAssembly();
            }
        }

        /// <summary>
        /// 自动根据实体生成对应的数据库表映射，其他继承类重写此初始化方法
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = this.EntityTypeConfigurationMapAssembly.GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null
                    && type.BaseType.IsGenericType
                    && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfigurationMapBase<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 清理被上线问管理的所有实体对象；当出现异常的时候，需要清理下，防止重试出现错误
        /// </summary>
        public void Clear()
        {
            var context = ((IObjectContextAdapter)this).ObjectContext;
            var addedObjects = context.ObjectStateManager.GetObjectStateEntries(EntityState.Added);
            foreach (var objectStateEntry in addedObjects)
            {
                context.Detach(objectStateEntry.Entity);
            }
            var modifyObjects = context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified);
            foreach (var objectStateEntry in modifyObjects)
            {
                context.Detach(objectStateEntry.Entity);
            }
        }

        /// <summary>
        /// 获取创建数据文件脚本
        /// </summary>
        /// <returns>创建数据库脚本文件</returns>
        public string CreateDatabaseScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }

        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Creates a raw SQL query that will return elements of the given generic type.  The type can be any type that has properties that match the names of the columns returned from the query, or can be a simple primitive type. The type does not have to be an entity type. The results of this query are never tracked by the context even if the type of object returned is an entity type.
        /// </summary>
        /// <typeparam name="TElement">The type of object returned by the query.</typeparam>
        /// <param name="sql">The SQL query string.</param>
        /// <param name="parameters">The parameters to apply to the SQL query string.</param>
        /// <returns>Result</returns>
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return this.Database.SqlQuery<TElement>(sql, null == parameters ? new object[] { } : parameters);
        }

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
        /// <param name="sql">The command string</param>
        /// <param name="doNotEnsureTransaction">false - the transaction creation is not ensured; true - the transaction creation is ensured.</param>
        /// <param name="timeout">Timeout value, in seconds. A null value indicates that the default value of the underlying provider will be used</param>
        /// <param name="parameters">The parameters to apply to the command string.</param>
        /// <returns>The result returned by the database after executing the command.</returns>
        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            int? previousTimeout = null;
            if (timeout.HasValue)
            {
                //store previous timeout
                previousTimeout = ((IObjectContextAdapter)this).ObjectContext.CommandTimeout;
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = timeout;
            }

            var transactionalBehavior = doNotEnsureTransaction
                ? TransactionalBehavior.DoNotEnsureTransaction
                : TransactionalBehavior.EnsureTransaction;
            var result = this.Database.ExecuteSqlCommand(transactionalBehavior, sql, parameters);

            if (timeout.HasValue)
            {
                //Set previous timeout back
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = previousTimeout;
            }

            //return result
            return result;
        }

        /// <summary>
        /// Detach an entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Detach(object entity)
        {
            if (null == entity)
            {
                throw new ArgumentNullException("entity");
            }

            ((IObjectContextAdapter)this).ObjectContext.Detach(entity);
        }

        /// <summary>
        /// Gets or sets a value indicating whether proxy creation setting is enabled (used in EF)
        /// </summary>
        public virtual bool ProxyCreationEnabled
        {
            get
            {
                return this.Configuration.ProxyCreationEnabled;
            }
            set
            {
                this.Configuration.ProxyCreationEnabled = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether auto detect changes setting is enabled (used in EF)
        /// </summary>
        public virtual bool AutoDetectChangesEnabled
        {
            get
            {
                return this.Configuration.AutoDetectChangesEnabled;
            }
            set
            {
                this.Configuration.AutoDetectChangesEnabled = value;
            }
        }
    }
}