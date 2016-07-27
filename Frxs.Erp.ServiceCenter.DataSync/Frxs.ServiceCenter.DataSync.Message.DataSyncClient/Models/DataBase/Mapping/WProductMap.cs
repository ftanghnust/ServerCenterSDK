using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class WProductMap : EntityTypeConfiguration<WProduct>
    {
        public WProductMap()
        {
            // Primary Key
            this.HasKey(t => t.WProductID);

    

            // Properties
            this.Property(t => t.ProductName2)
                .HasMaxLength(400);

            this.Property(t => t.Unit)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.MarketUnit)
                .HasMaxLength(32);

            this.Property(t => t.BigUnit)
                .HasMaxLength(32);

            this.Property(t => t.SaleBackFlag)
                .HasMaxLength(20);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WProducts");
            this.Property(t => t.WProductID).HasColumnName("WProductID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.ProductName2).HasColumnName("ProductName2");
            this.Property(t => t.WStatus).HasColumnName("WStatus");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.SalePrice).HasColumnName("SalePrice");
            this.Property(t => t.MarketPrice).HasColumnName("MarketPrice");
            this.Property(t => t.MarketUnit).HasColumnName("MarketUnit");
            this.Property(t => t.BigProductsUnitID).HasColumnName("BigProductsUnitID");
            this.Property(t => t.BigPackingQty).HasColumnName("BigPackingQty");
            this.Property(t => t.BigUnit).HasColumnName("BigUnit");
            this.Property(t => t.ShelfID).HasColumnName("ShelfID");
            this.Property(t => t.ShopAddPerc).HasColumnName("ShopAddPerc");
            this.Property(t => t.ShopPoint).HasColumnName("ShopPoint");
            this.Property(t => t.BasePoint).HasColumnName("BasePoint");
            this.Property(t => t.VendorPerc1).HasColumnName("VendorPerc1");
            this.Property(t => t.VendorPerc2).HasColumnName("VendorPerc2");
            this.Property(t => t.SaleBackFlag).HasColumnName("SaleBackFlag");
            this.Property(t => t.BackDays).HasColumnName("BackDays");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
