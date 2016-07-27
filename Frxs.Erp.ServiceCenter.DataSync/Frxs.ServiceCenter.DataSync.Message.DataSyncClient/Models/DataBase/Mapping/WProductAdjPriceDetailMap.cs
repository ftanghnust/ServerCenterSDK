using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class WProductAdjPriceDetailMap : EntityTypeConfiguration<WProductAdjPriceDetail>
    {
        public WProductAdjPriceDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Unit)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WProductAdjPriceDetails");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.AdjID).HasColumnName("AdjID");
            this.Property(t => t.WProductID).HasColumnName("WProductID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.OldPrice).HasColumnName("OldPrice");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.OldMarketPrice).HasColumnName("OldMarketPrice");
            this.Property(t => t.MarketPrice).HasColumnName("MarketPrice");
            this.Property(t => t.OldShopPoint).HasColumnName("OldShopPoint");
            this.Property(t => t.OldShopAddPerc).HasColumnName("OldShopAddPerc");
            this.Property(t => t.ShopPoint).HasColumnName("ShopPoint");
            this.Property(t => t.ShopPerc).HasColumnName("ShopPerc");
            this.Property(t => t.OldBasePoint).HasColumnName("OldBasePoint");
            this.Property(t => t.BasePoint).HasColumnName("BasePoint");
            this.Property(t => t.OldVendorPerc1).HasColumnName("OldVendorPerc1");
            this.Property(t => t.OldVendorPerc2).HasColumnName("OldVendorPerc2");
            this.Property(t => t.VendorPerc1).HasColumnName("VendorPerc1");
            this.Property(t => t.VendorPerc2).HasColumnName("VendorPerc2");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
