using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class BrandCategoryMap : EntityTypeConfiguration<BrandCategory>
    {
        public BrandCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.BrandId);


            // Properties
            this.Property(t => t.BrandId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


            // Properties
            this.Property(t => t.BrandName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.BrandEnName)
                .HasMaxLength(50);

            this.Property(t => t.Logo)
                .HasMaxLength(255);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("BrandCategories");
            this.Property(t => t.BrandId).HasColumnName("BrandId");
            this.Property(t => t.BrandName).HasColumnName("BrandName");
            this.Property(t => t.BrandEnName).HasColumnName("BrandEnName");
            this.Property(t => t.Logo).HasColumnName("Logo");
            this.Property(t => t.DisplaySequence).HasColumnName("DisplaySequence");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
