using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class ProductsDescriptionPictureMap : EntityTypeConfiguration<ProductsDescriptionPicture>
    {
        public ProductsDescriptionPictureMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ImageUrlOrg)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.ImageUrl400x400)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.ImageUrl200x200)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.ImageUrl120x120)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.ImageUrl60x60)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("ProductsDescriptionPicture");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.BaseProductId).HasColumnName("BaseProductId");
            this.Property(t => t.ImageUrlOrg).HasColumnName("ImageUrlOrg");
            this.Property(t => t.ImageUrl400x400).HasColumnName("ImageUrl400x400");
            this.Property(t => t.ImageUrl200x200).HasColumnName("ImageUrl200x200");
            this.Property(t => t.ImageUrl120x120).HasColumnName("ImageUrl120x120");
            this.Property(t => t.ImageUrl60x60).HasColumnName("ImageUrl60x60");
            this.Property(t => t.OrderNumber).HasColumnName("OrderNumber");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
