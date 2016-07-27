using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class SaleOrderShelfAreaMap : EntityTypeConfiguration<SaleOrderShelfArea>
    {
        public SaleOrderShelfAreaMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.OrderID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShelfAreaCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ShelfAreaName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PickUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            this.Property(t => t.CheckUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SaleOrderShelfArea");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.Package1Qty).HasColumnName("Package1Qty");
            this.Property(t => t.Package2Qty).HasColumnName("Package2Qty");
            this.Property(t => t.Package3Qty).HasColumnName("Package3Qty");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.ShelfAreaID).HasColumnName("ShelfAreaID");
            this.Property(t => t.ShelfAreaCode).HasColumnName("ShelfAreaCode");
            this.Property(t => t.ShelfAreaName).HasColumnName("ShelfAreaName");
            this.Property(t => t.PickUserID).HasColumnName("PickUserID");
            this.Property(t => t.PickUserName).HasColumnName("PickUserName");
            this.Property(t => t.BeginTime).HasColumnName("BeginTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
            this.Property(t => t.CheckTime).HasColumnName("CheckTime");
            this.Property(t => t.CheckUserID).HasColumnName("CheckUserID");
            this.Property(t => t.CheckUserName).HasColumnName("CheckUserName");
        }
    }
}
