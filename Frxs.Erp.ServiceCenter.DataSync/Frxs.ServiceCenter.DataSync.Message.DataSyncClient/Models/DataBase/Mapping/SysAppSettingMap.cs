using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class SysAppSettingMap : EntityTypeConfiguration<SysAppSetting>
    {
        public SysAppSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.SKey)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SVal1)
                .HasMaxLength(500);

            this.Property(t => t.SVal2)
                .HasMaxLength(500);

            this.Property(t => t.SVal3)
                .HasMaxLength(500);

            this.Property(t => t.SVal4)
                .HasMaxLength(500);

            this.Property(t => t.SVal5)
                .HasMaxLength(500);

            this.Property(t => t.SVal6)
                .HasMaxLength(500);

            this.Property(t => t.SVal7)
                .HasMaxLength(500);

            this.Property(t => t.SVal8)
                .HasMaxLength(500);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SysAppSettings");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.SKey).HasColumnName("SKey");
            this.Property(t => t.SVal1).HasColumnName("SVal1");
            this.Property(t => t.SVal2).HasColumnName("SVal2");
            this.Property(t => t.SVal3).HasColumnName("SVal3");
            this.Property(t => t.SVal4).HasColumnName("SVal4");
            this.Property(t => t.SVal5).HasColumnName("SVal5");
            this.Property(t => t.SVal6).HasColumnName("SVal6");
            this.Property(t => t.SVal7).HasColumnName("SVal7");
            this.Property(t => t.SVal8).HasColumnName("SVal8");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
