/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models.Mapping
{
    public class SaleSettleDetailMap : EntityTypeConfigurationMapBase<SaleSettleDetail>
    {
        public SaleSettleDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SettleID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.BillID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.BillDetailsID)
                .HasMaxLength(50);

            this.Property(t => t.FeeCode)
                .HasMaxLength(32);

            this.Property(t => t.FeeName)
                .HasMaxLength(100);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SaleSettleDetail");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SettleID).HasColumnName("SettleID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.BillType).HasColumnName("BillType");
            this.Property(t => t.BillID).HasColumnName("BillID");
            this.Property(t => t.BillDetailsID).HasColumnName("BillDetailsID");
            this.Property(t => t.BillDate).HasColumnName("BillDate");
            this.Property(t => t.BillAmt).HasColumnName("BillAmt");
            this.Property(t => t.BillAddAmt).HasColumnName("BillAddAmt");
            this.Property(t => t.BillPayAmt).HasColumnName("BillPayAmt");
            this.Property(t => t.FeeCode).HasColumnName("FeeCode");
            this.Property(t => t.FeeName).HasColumnName("FeeName");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
