/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models.Mapping
{
    public class ProductsPictureDetailMap : EntityTypeConfigurationMapBase<ProductsPictureDetail>
    {
        public ProductsPictureDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
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
            this.ToTable("ProductsPictureDetail");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ImageProductId).HasColumnName("ImageProductId");
            this.Property(t => t.ImageUrlOrg).HasColumnName("ImageUrlOrg");
            this.Property(t => t.ImageUrl400x400).HasColumnName("ImageUrl400x400");
            this.Property(t => t.ImageUrl200x200).HasColumnName("ImageUrl200x200");
            this.Property(t => t.ImageUrl120x120).HasColumnName("ImageUrl120x120");
            this.Property(t => t.ImageUrl60x60).HasColumnName("ImageUrl60x60");
            this.Property(t => t.OrderNumber).HasColumnName("OrderNumber");
            this.Property(t => t.IsMaster).HasColumnName("IsMaster");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
