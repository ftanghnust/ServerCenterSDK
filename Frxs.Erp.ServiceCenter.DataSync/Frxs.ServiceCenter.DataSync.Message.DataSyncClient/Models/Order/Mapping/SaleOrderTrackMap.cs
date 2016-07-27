using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class SaleOrderTrackMap : EntityTypeConfiguration<SaleOrderTrack>
    {
        public SaleOrderTrackMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.OrderID)
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.OrderStatusName)
                .HasMaxLength(20);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SaleOrderTrack");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.IsDisplayUser).HasColumnName("IsDisplayUser");
            this.Property(t => t.OrderStatus).HasColumnName("OrderStatus");
            this.Property(t => t.OrderStatusName).HasColumnName("OrderStatusName");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
