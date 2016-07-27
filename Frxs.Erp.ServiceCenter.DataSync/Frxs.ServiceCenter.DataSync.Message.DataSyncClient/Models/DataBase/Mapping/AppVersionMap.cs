using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class AppVersionMap : EntityTypeConfiguration<AppVersion>
    {
        public AppVersionMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CurVersion)
                .IsRequired()
                .HasMaxLength(7);

            this.Property(t => t.DownUrl)
                .HasMaxLength(100);

            this.Property(t => t.UpdateRemark)
                .HasMaxLength(400);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("AppVersion");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SysType).HasColumnName("SysType");
            this.Property(t => t.AppType).HasColumnName("AppType");
            this.Property(t => t.CurVersion).HasColumnName("CurVersion");
            this.Property(t => t.DownUrl).HasColumnName("DownUrl");
            this.Property(t => t.UpdateFlag).HasColumnName("UpdateFlag");
            this.Property(t => t.UpdateRemark).HasColumnName("UpdateRemark");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
