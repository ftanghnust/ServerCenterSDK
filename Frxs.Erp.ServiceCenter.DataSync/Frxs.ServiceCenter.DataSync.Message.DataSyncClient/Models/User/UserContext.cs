using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models;
using Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UserContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        static UserContext()
        {
            //Database.SetInitializer<UserContext>(null);
        }

        /// <summary>
        /// 
        /// </summary>
        public UserContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        /// <summary>
        /// 清理被上线问管理的所有实体对象
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
        /// 
        /// </summary>
        public DbSet<XSUser> XSUsers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<XSUserShop> XSUserShops { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new XSUserMap());
            modelBuilder.Configurations.Add(new XSUserShopMap());
        }
    }
}
