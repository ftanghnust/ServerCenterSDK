using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class WAdvertisementMap : EntityTypeConfiguration<WAdvertisement>
    {
        public WAdvertisementMap()
        {
            // Primary Key
            this.HasKey(t => t.AdvertisementID);

            // Properties
            this.Property(t => t.AdvertisementName)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ImagesSrc)
                .HasMaxLength(128);

            this.Property(t => t.SelectImagesSrc)
                .HasMaxLength(128);

            this.Property(t => t.CreateUserName)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ModityUserName)
                .IsRequired()
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WAdvertisement");
            this.Property(t => t.AdvertisementID).HasColumnName("AdvertisementID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.AdvertisementPosition).HasColumnName("AdvertisementPosition");
            this.Property(t => t.AdvertisementName).HasColumnName("AdvertisementName");
            this.Property(t => t.Sort).HasColumnName("Sort");
            this.Property(t => t.ImagesSrc).HasColumnName("ImagesSrc");
            this.Property(t => t.SelectImagesSrc).HasColumnName("SelectImagesSrc");
            this.Property(t => t.AdvertisementType).HasColumnName("AdvertisementType");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
            this.Property(t => t.IsLocked).HasColumnName("IsLocked");
            this.Property(t => t.StartTime).HasColumnName("StartTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModityTime).HasColumnName("ModityTime");
            this.Property(t => t.ModityUserID).HasColumnName("ModityUserID");
            this.Property(t => t.ModityUserName).HasColumnName("ModityUserName");
        }
    }
}
