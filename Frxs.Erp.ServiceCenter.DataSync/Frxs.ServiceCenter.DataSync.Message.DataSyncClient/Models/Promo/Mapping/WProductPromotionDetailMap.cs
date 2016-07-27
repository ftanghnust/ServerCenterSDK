using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class WProductPromotionDetailMap : EntityTypeConfiguration<WProductPromotionDetail>
    {
        public WProductPromotionDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.PromotionID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SKU)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Unit)
                .HasMaxLength(32);

            this.Property(t => t.SaleUnit)
                .HasMaxLength(32);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WProductPromotionDetails");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PromotionID).HasColumnName("PromotionID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.WProductID).HasColumnName("WProductID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.SKU).HasColumnName("SKU");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.PackingQty).HasColumnName("PackingQty");
            this.Property(t => t.SaleUnit).HasColumnName("SaleUnit");
            this.Property(t => t.SalePrice).HasColumnName("SalePrice");
            this.Property(t => t.OldPoint).HasColumnName("OldPoint");
            this.Property(t => t.Point).HasColumnName("Point");
            this.Property(t => t.MaxOrderQty).HasColumnName("MaxOrderQty");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
