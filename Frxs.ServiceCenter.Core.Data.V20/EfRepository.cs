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
    /// Ĭ�ϲִ�����ʵ����
    /// ��չ��
    /// Դ�룺https://github.com/loresoft/EntityFramework.Extended
    /// ��ȡ��https://www.nuget.org/packages/EntityFramework.Extended
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
        /// ����ʵ������ID��ȡʵ�����
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
        /// ����ʵ��
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
                //this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                this.ThrowException(dbEx);
            }
        }

        /// <summary>
        /// ��������ʵ��
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
                //this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                this.ThrowException(dbEx);
            }
        }

        /// <summary>
        /// ����ʵ��
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
                //this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                this.ThrowException(dbEx);
            }
        }

        /// <summary>
        /// ��������ʵ��
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
                //this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                this.ThrowException(dbEx);
            }
        }

        /// <summary>
        /// ɾ��ʵ��
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
                //this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                this.ThrowException(dbEx);
            }
        }

        /// <summary>
        /// ����ɾ��ʵ�����
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
                //this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                this.ThrowException(dbEx);
            }
        }

        /// <summary>
        /// ��ȡһ��ӳ��������Ĳ�ѯ����
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        /// <summary>
        /// �����ֻ���������ʹ�ô����ԣ�EF������ٶ���ʵ�嵽���������ģ�����ܴ����߷����ٶ�
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