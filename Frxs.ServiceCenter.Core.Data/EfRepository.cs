/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/24 14:47:30
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace Frxs.ServiceCenter.Data.Core
{
    /// <summary>
    /// 默认仓储泛型实现类
    /// 扩展库
    /// 源码：https://github.com/loresoft/EntityFramework.Extended
    /// 获取：https://www.nuget.org/packages/EntityFramework.Extended
    /// </summary>
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        private IDbSet<T> _entities;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EfRepository(IDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// 根据实体主键ID获取实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        private void ThrowException(DbEntityValidationException exception)
        {
            var msg = string.Empty;
            foreach (var validationErrors in exception.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                }
            }
            throw new Exception(msg, exception);
        }

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(T entity)
        {
            try
            {
                if (null == entity)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Add(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                this.ThrowException(dbEx);
            }
        }

        /// <summary>
        /// 批量插入实体
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (null == entities)
                {
                    throw new ArgumentNullException("entities");
                }
                foreach (var entity in entities)
                {
                    this.Entities.Add(entity);
                }
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                this.ThrowException(dbEx);
            }
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            try
            {
                if (null == entity)
                {
                    throw new ArgumentNullException("entity");
                }
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                this.ThrowException(dbEx);
            }
        }

        /// <summary>
        /// 批量更新实体
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Update(IEnumerable<T> entities)
        {
            try
            {
                if (null == entities)
                {
                    throw new ArgumentNullException("entities");
                }
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                this.ThrowException(dbEx);
            }
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Remove(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                this.ThrowException(dbEx);
            }
        }

        /// <summary>
        /// 批量删除实体对象
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (null == entities)
                {
                    throw new ArgumentNullException("entities");
                }
                foreach (var entity in entities)
                {
                    this.Entities.Remove(entity);
                }
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                this.ThrowException(dbEx);
            }
        }

        /// <summary>
        /// 获取一个映射的上下文查询对象
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        /// <summary>
        /// 如果是只读情况，请使用此属性，EF不会跟踪对象实体到本地上下文，因此能大大提高访问速度
        /// </summary>
        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (null == _entities)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }
    }
}