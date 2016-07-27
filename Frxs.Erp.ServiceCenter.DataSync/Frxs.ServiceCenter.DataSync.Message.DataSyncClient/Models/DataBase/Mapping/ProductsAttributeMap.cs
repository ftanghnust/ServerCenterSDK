using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class ProductsAttributeMap : EntityTypeConfiguration<ProductsAttribute>
    {
        public ProductsAttributeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            this.Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Properties
            this.Property(t => t.AttributeName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ValueStr)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("ProductsAttributes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.AttributeId).HasColumnName("AttributeId");
            this.Property(t => t.AttributeName).HasColumnName("AttributeName");
            this.Property(t => t.ValuesId).HasColumnName("ValuesId");
            this.Property(t => t.ValueStr).HasColumnName("ValueStr");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
