using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class ProductsDescriptionMap : EntityTypeConfiguration<ProductsDescription>
    {
        public ProductsDescriptionMap()
        {
            // Primary Key
            this.HasKey(t => t.BaseProductId);

            // Properties
            this.Property(t => t.BaseProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("ProductsDescription");
            this.Property(t => t.BaseProductId).HasColumnName("BaseProductId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
