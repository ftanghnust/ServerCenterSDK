using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models;
using Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PromoContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        static PromoContext()
        {
            //Database.SetInitializer<PromoContext>(null);
        }

        /// <summary>
        /// 
        /// </summary>
        public PromoContext(string nameOrConnectionString)
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

        public DbSet<SaleCart> SaleCarts { get; set; }
        public DbSet<SaleOrderShop> SaleOrderShops { get; set; }
        public DbSet<SaleOrderShopDetail> SaleOrderShopDetails { get; set; }
        public DbSet<SaleOrderShopDetailsExt> SaleOrderShopDetailsExts { get; set; }
        public DbSet<WAdvertisement> WAdvertisements { get; set; }
        public DbSet<WAdvertisementProduct> WAdvertisementProducts { get; set; }
        public DbSet<WarehouseMessage> WarehouseMessages { get; set; }
        public DbSet<WarehouseMessageShop> WarehouseMessageShops { get; set; }
        public DbSet<WProductAddPerc> WProductAddPercs { get; set; }
        public DbSet<WProductAddPercDetail> WProductAddPercDetails { get; set; }
        public DbSet<WProductAddPercShop> WProductAddPercShops { get; set; }
        public DbSet<WProductPromotion> WProductPromotions { get; set; }
        public DbSet<WProductPromotionDetail> WProductPromotionDetails { get; set; }
        public DbSet<WProductPromotionShop> WProductPromotionShops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SaleCartMap());
            modelBuilder.Configurations.Add(new SaleOrderShopMap());
            modelBuilder.Configurations.Add(new SaleOrderShopDetailMap());
            modelBuilder.Configurations.Add(new SaleOrderShopDetailsExtMap());
            modelBuilder.Configurations.Add(new WAdvertisementMap());
            modelBuilder.Configurations.Add(new WAdvertisementProductMap());
            modelBuilder.Configurations.Add(new WarehouseMessageMap());
            modelBuilder.Configurations.Add(new WarehouseMessageShopMap());
            modelBuilder.Configurations.Add(new WProductAddPercMap());
            modelBuilder.Configurations.Add(new WProductAddPercDetailMap());
            modelBuilder.Configurations.Add(new WProductAddPercShopMap());
            modelBuilder.Configurations.Add(new WProductPromotionMap());
            modelBuilder.Configurations.Add(new WProductPromotionDetailMap());
            modelBuilder.Configurations.Add(new WProductPromotionShopMap());
        }
    }
}
