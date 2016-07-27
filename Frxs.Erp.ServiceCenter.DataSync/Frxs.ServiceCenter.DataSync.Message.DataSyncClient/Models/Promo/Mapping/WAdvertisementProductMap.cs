using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class WAdvertisementProductMap : EntityTypeConfiguration<WAdvertisementProduct>
    {
        public WAdvertisementProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CreateUserName)
                .IsRequired()
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WAdvertisementProduct");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.AdvertisementID).HasColumnName("AdvertisementID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
