using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models;
using Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BaseDataContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        static BaseDataContext()
        {
           // Database.SetInitializer<BaseDataContext>(null);
        }

        /// <summary>
        /// 
        /// </summary>
        public BaseDataContext(string nameOrConnectionString)
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
            foreach(var objectStateEntry in addedObjects)
            {
                context.Detach(objectStateEntry.Entity);
            }
            var modifyObjects = context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified);
            foreach(var objectStateEntry in modifyObjects)
            {
                context.Detach(objectStateEntry.Entity);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<AppVersion> AppVersions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Attribute> Attributes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<AttributesValue> AttributesValues { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<BaseProduct> BaseProducts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<BrandCategory> BrandCategories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<PreBuyOrder> PreBuyOrders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductsAttribute> ProductsAttributes { get; set; }
        public DbSet<ProductsAttributesPicture> ProductsAttributesPictures { get; set; }
        public DbSet<ProductsBarCode> ProductsBarCodes { get; set; }
        public DbSet<ProductsDescription> ProductsDescriptions { get; set; }
        public DbSet<ProductsDescriptionPicture> ProductsDescriptionPictures { get; set; }
        public DbSet<ProductsPictureDetail> ProductsPictureDetails { get; set; }
        public DbSet<ProductsSKUNumberService> ProductsSKUNumberServices { get; set; }
        public DbSet<ProductsUnit> ProductsUnits { get; set; }
        public DbSet<ProductsVendor> ProductsVendors { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<ShelfArea> ShelfAreas { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopCategory> ShopCategories { get; set; }
        public DbSet<ShopGroup> ShopGroups { get; set; }
        public DbSet<ShopGroupDetail> ShopGroupDetails { get; set; }
        public DbSet<SYS_DB_CONFIG> SYS_DB_CONFIG { get; set; }
        public DbSet<SysAppSetting> SysAppSettings { get; set; }
        public DbSet<SysArea> SysAreas { get; set; }
        public DbSet<SysDict> SysDicts { get; set; }
        public DbSet<SysDictDetail> SysDictDetails { get; set; }
        public DbSet<SysParam> SysParams { get; set; }
        public DbSet<SysParamsWH> SysParamsWHs { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorType> VendorTypes { get; set; }
        public DbSet<VendorWarehouse> VendorWarehouses { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseEmp> WarehouseEmps { get; set; }
        public DbSet<WarehouseEmpShelf> WarehouseEmpShelves { get; set; }
        public DbSet<WarehouseLine> WarehouseLines { get; set; }
        public DbSet<WarehouseLineShop> WarehouseLineShops { get; set; }
        public DbSet<WProductAdjPrice> WProductAdjPrices { get; set; }
        public DbSet<WProductAdjPriceDetail> WProductAdjPriceDetails { get; set; }
        public DbSet<WProductAdjShelf> WProductAdjShelves { get; set; }
        public DbSet<WProductAdjShelfDetail> WProductAdjShelfDetails { get; set; }
        public DbSet<WProductNoSale> WProductNoSales { get; set; }
        public DbSet<WProductNoSaleDetail> WProductNoSaleDetails { get; set; }
        public DbSet<WProductNoSaleShop> WProductNoSaleShops { get; set; }
        public DbSet<WProduct> WProducts { get; set; }
        public DbSet<WProductsBuy> WProductsBuys { get; set; }
        public DbSet<WProductsBuyEmp> WProductsBuyEmps { get; set; }
        public DbSet<WStationNumber> WStationNumbers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppVersionMap());
            modelBuilder.Configurations.Add(new AttributeMap());
            modelBuilder.Configurations.Add(new AttributesValueMap());
            modelBuilder.Configurations.Add(new BaseProductMap());
            modelBuilder.Configurations.Add(new BrandCategoryMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new PreBuyOrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductsAttributeMap());
            modelBuilder.Configurations.Add(new ProductsAttributesPictureMap());
            modelBuilder.Configurations.Add(new ProductsBarCodeMap());
            modelBuilder.Configurations.Add(new ProductsDescriptionMap());
            modelBuilder.Configurations.Add(new ProductsDescriptionPictureMap());
            modelBuilder.Configurations.Add(new ProductsPictureDetailMap());
            modelBuilder.Configurations.Add(new ProductsSKUNumberServiceMap());
            modelBuilder.Configurations.Add(new ProductsUnitMap());
            modelBuilder.Configurations.Add(new ProductsVendorMap());
            modelBuilder.Configurations.Add(new ShelfMap());
            modelBuilder.Configurations.Add(new ShelfAreaMap());
            modelBuilder.Configurations.Add(new ShopMap());
            modelBuilder.Configurations.Add(new ShopCategoryMap());
            modelBuilder.Configurations.Add(new ShopGroupMap());
            modelBuilder.Configurations.Add(new ShopGroupDetailMap());
            modelBuilder.Configurations.Add(new SYS_DB_CONFIGMap());
            modelBuilder.Configurations.Add(new SysAppSettingMap());
            modelBuilder.Configurations.Add(new SysAreaMap());
            modelBuilder.Configurations.Add(new SysDictMap());
            modelBuilder.Configurations.Add(new SysDictDetailMap());
            modelBuilder.Configurations.Add(new SysParamMap());
            modelBuilder.Configurations.Add(new SysParamsWHMap());
            modelBuilder.Configurations.Add(new VendorMap());
            modelBuilder.Configurations.Add(new VendorTypeMap());
            modelBuilder.Configurations.Add(new VendorWarehouseMap());
            modelBuilder.Configurations.Add(new WarehouseMap());
            modelBuilder.Configurations.Add(new WarehouseEmpMap());
            modelBuilder.Configurations.Add(new WarehouseEmpShelfMap());
            modelBuilder.Configurations.Add(new WarehouseLineMap());
            modelBuilder.Configurations.Add(new WarehouseLineShopMap());
            modelBuilder.Configurations.Add(new WProductAdjPriceMap());
            modelBuilder.Configurations.Add(new WProductAdjPriceDetailMap());
            modelBuilder.Configurations.Add(new WProductAdjShelfMap());
            modelBuilder.Configurations.Add(new WProductAdjShelfDetailMap());
            modelBuilder.Configurations.Add(new WProductNoSaleMap());
            modelBuilder.Configurations.Add(new WProductNoSaleDetailMap());
            modelBuilder.Configurations.Add(new WProductNoSaleShopMap());
            modelBuilder.Configurations.Add(new WProductMap());
            modelBuilder.Configurations.Add(new WProductsBuyMap());
            modelBuilder.Configurations.Add(new WProductsBuyEmpMap());
            modelBuilder.Configurations.Add(new WStationNumberMap());
        }
    }
}
