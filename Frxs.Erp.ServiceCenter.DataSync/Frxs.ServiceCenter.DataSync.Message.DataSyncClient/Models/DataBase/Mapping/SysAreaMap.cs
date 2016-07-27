using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class SysAreaMap : EntityTypeConfiguration<SysArea>
    {
        public SysAreaMap()
        {
            // Primary Key
            this.HasKey(t => t.AreaID);

            // Properties
            this.Property(t => t.AreaID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AreaName)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SysArea");
            this.Property(t => t.AreaID).HasColumnName("AreaID");
            this.Property(t => t.AreaName).HasColumnName("AreaName");
            this.Property(t => t.Level).HasColumnName("Level");
            this.Property(t => t.ParentID).HasColumnName("ParentID");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
            this.Property(t => t.SyncFale).HasColumnName("SyncFale");
        }
    }
}
