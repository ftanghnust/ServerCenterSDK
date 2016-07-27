using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class BuyPreAppBillMap : EntityTypeConfiguration<BuyPreAppBill>
    {
        public BuyPreAppBillMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.AppID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.BillID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("BuyPreAppBills");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.AppID).HasColumnName("AppID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.BillID).HasColumnName("BillID");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
