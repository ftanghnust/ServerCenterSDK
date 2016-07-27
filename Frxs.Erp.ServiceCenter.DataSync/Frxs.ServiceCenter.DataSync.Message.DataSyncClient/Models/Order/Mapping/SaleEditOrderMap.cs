using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class SaleEditOrderMap : EntityTypeConfiguration<SaleEditOrder>
    {
        public SaleEditOrderMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.EditID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.OrderID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShopCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ShopName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ProcRemark)
                .HasMaxLength(100);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SaleEditOrders");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.EditID).HasColumnName("EditID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            this.Property(t => t.SendDate).HasColumnName("SendDate");
            this.Property(t => t.ShopID).HasColumnName("ShopID");
            this.Property(t => t.ShopCode).HasColumnName("ShopCode");
            this.Property(t => t.ShopName).HasColumnName("ShopName");
            this.Property(t => t.ProcFlag).HasColumnName("ProcFlag");
            this.Property(t => t.ProcRemark).HasColumnName("ProcRemark");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
