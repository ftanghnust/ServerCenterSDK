using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class ShelfAreaMap : EntityTypeConfiguration<ShelfArea>
    {
        public ShelfAreaMap()
        {
            // Primary Key
            this.HasKey(t => t.ShelfAreaID);

            // Properties
            this.Property(t => t.ShelfAreaCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ShelfAreaName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(200);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("ShelfArea");
            this.Property(t => t.ShelfAreaID).HasColumnName("ShelfAreaID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.ShelfAreaCode).HasColumnName("ShelfAreaCode");
            this.Property(t => t.ShelfAreaName).HasColumnName("ShelfAreaName");
            this.Property(t => t.PickingMaxRecord).HasColumnName("PickingMaxRecord");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
