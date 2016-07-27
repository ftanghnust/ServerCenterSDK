using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class ProductsBarCodeMap : EntityTypeConfiguration<ProductsBarCode>
    {
        public ProductsBarCodeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            this.Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Properties
            this.Property(t => t.BarCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("ProductsBarCodes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.BarCode).HasColumnName("BarCode");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
