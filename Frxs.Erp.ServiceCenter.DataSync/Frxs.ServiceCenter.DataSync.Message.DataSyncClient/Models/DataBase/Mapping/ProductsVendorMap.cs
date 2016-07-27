using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class ProductsVendorMap : EntityTypeConfiguration<ProductsVendor>
    {
        public ProductsVendorMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            this.Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Properties
            this.Property(t => t.Unit)
                .HasMaxLength(32);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("ProductsVendor");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.BuyPrice).HasColumnName("BuyPrice");
            this.Property(t => t.IsMaster).HasColumnName("IsMaster");
            this.Property(t => t.LastBuyPrice).HasColumnName("LastBuyPrice");
            this.Property(t => t.LastBuyTime).HasColumnName("LastBuyTime");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
