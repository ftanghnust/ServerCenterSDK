using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class ShelfMap : EntityTypeConfiguration<Shelf>
    {
        public ShelfMap()
        {
            // Primary Key
            this.HasKey(t => t.ShelfID);

            // Properties
            this.Property(t => t.ShelfCode)
                .HasMaxLength(50);

            this.Property(t => t.ShelfType)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.Remark)
                .HasMaxLength(400);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("Shelf");
            this.Property(t => t.ShelfID).HasColumnName("ShelfID");
            this.Property(t => t.ShelfCode).HasColumnName("ShelfCode");
            this.Property(t => t.ShelfAreaID).HasColumnName("ShelfAreaID");
            this.Property(t => t.ShelfType).HasColumnName("ShelfType");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
