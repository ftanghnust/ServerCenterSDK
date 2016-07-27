/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models.Mapping
{
    public class ProductsDescriptionPictureMap : EntityTypeConfigurationMapBase<ProductsDescriptionPicture>
    {
        public ProductsDescriptionPictureMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ImageUrlOrg, t.ImageUrl400x400, t.ImageUrl200x200, t.ImageUrl120x120, t.ImageUrl60x60 });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

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
