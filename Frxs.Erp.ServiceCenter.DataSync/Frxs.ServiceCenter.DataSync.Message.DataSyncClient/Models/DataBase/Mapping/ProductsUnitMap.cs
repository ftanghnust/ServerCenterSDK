using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class ProductsUnitMap : EntityTypeConfiguration<ProductsUnit>
    {
        public ProductsUnitMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductsUnitID);

            this.Property(t => t.ProductsUnitID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Properties
            this.Property(t => t.Unit)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Spec)
                .HasMaxLength(20);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("ProductsUnit");
            this.Property(t => t.ProductsUnitID).HasColumnName("ProductsUnitID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.PackingQty).HasColumnName("PackingQty");
            this.Property(t => t.Spec).HasColumnName("Spec");
            this.Property(t => t.IsUnit).HasColumnName("IsUnit");
            this.Property(t => t.IsSaleUnit).HasColumnName("IsSaleUnit");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
