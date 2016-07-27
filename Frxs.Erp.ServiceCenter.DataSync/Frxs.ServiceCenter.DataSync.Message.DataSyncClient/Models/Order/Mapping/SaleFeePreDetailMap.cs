using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class SaleFeePreDetailMap : EntityTypeConfiguration<SaleFeePreDetail>
    {
        public SaleFeePreDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.FeeID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.ShopCode)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ShopName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.FeeName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Reason)
                .HasMaxLength(500);

            this.Property(t => t.OrderId)
                .HasMaxLength(50);

            this.Property(t => t.SettleID)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(64);

            // Table & Column Mappings
            this.ToTable("SaleFeePreDetails");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.FeeID).HasColumnName("FeeID");
            this.Property(t => t.ShopID).HasColumnName("ShopID");
            this.Property(t => t.ShopCode).HasColumnName("ShopCode");
            this.Property(t => t.ShopName).HasColumnName("ShopName");
            this.Property(t => t.FeeCode).HasColumnName("FeeCode");
            this.Property(t => t.FeeName).HasColumnName("FeeName");
            this.Property(t => t.Reason).HasColumnName("Reason");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.FeeAmt).HasColumnName("FeeAmt");
            this.Property(t => t.SettleID).HasColumnName("SettleID");
            this.Property(t => t.SettleTime).HasColumnName("SettleTime");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
