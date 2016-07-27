using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class SaleOrderPackingMap : EntityTypeConfiguration<SaleOrderPacking>
    {
        public SaleOrderPackingMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderID);

            // Properties
            this.Property(t => t.OrderID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(200);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SaleOrderPacking");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.Package1Qty).HasColumnName("Package1Qty");
            this.Property(t => t.Package2Qty).HasColumnName("Package2Qty");
            this.Property(t => t.Package3Qty).HasColumnName("Package3Qty");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
