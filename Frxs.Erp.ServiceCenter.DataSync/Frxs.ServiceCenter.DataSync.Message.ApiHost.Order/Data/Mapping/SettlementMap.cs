/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models.Mapping
{
    public class SettlementMap : EntityTypeConfigurationMapBase<Settlement>
    {
        public SettlementMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SettleNo)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.WCode)
                .HasMaxLength(32);

            this.Property(t => t.WName)
                .HasMaxLength(50);

            this.Property(t => t.SubWCode)
                .HasMaxLength(32);

            this.Property(t => t.SubWName)
                .HasMaxLength(50);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(64);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(64);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Settlement");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SettleNo).HasColumnName("SettleNo");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.WCode).HasColumnName("WCode");
            this.Property(t => t.WName).HasColumnName("WName");
            this.Property(t => t.SubWID).HasColumnName("SubWID");
            this.Property(t => t.SubWCode).HasColumnName("SubWCode");
            this.Property(t => t.SubWName).HasColumnName("SubWName");
            this.Property(t => t.SettleDate).HasColumnName("SettleDate");
            this.Property(t => t.SettleStartTime).HasColumnName("SettleStartTime");
            this.Property(t => t.SettleEndTime).HasColumnName("SettleEndTime");
            this.Property(t => t.BeginQty).HasColumnName("BeginQty");
            this.Property(t => t.BeginAmt).HasColumnName("BeginAmt");
            this.Property(t => t.BuyQty).HasColumnName("BuyQty");
            this.Property(t => t.BuyAmt).HasColumnName("BuyAmt");
            this.Property(t => t.BuyBackQty).HasColumnName("BuyBackQty");
            this.Property(t => t.BuyBackAmt).HasColumnName("BuyBackAmt");
            this.Property(t => t.SaleQty).HasColumnName("SaleQty");
            this.Property(t => t.SaleAmt).HasColumnName("SaleAmt");
            this.Property(t => t.SaleBackQty).HasColumnName("SaleBackQty");
            this.Property(t => t.SaleBackAmt).HasColumnName("SaleBackAmt");
            this.Property(t => t.AdjGainQty).HasColumnName("AdjGainQty");
            this.Property(t => t.AjgGginAmt).HasColumnName("AjgGginAmt");
            this.Property(t => t.AdjLossQty).HasColumnName("AdjLossQty");
            this.Property(t => t.AjgLosssAmt).HasColumnName("AjgLosssAmt");
            this.Property(t => t.StockQty).HasColumnName("StockQty");
            this.Property(t => t.StockAmt).HasColumnName("StockAmt");
            this.Property(t => t.EndQty).HasColumnName("EndQty");
            this.Property(t => t.EndStockAmt).HasColumnName("EndStockAmt");
            this.Property(t => t.EndDiffQty).HasColumnName("EndDiffQty");
            this.Property(t => t.EndDiffStockAmt).HasColumnName("EndDiffStockAmt");
            this.Property(t => t.SaleSubBasePoint).HasColumnName("SaleSubBasePoint");
            this.Property(t => t.SaleSubPoint).HasColumnName("SaleSubPoint");
            this.Property(t => t.SaleSubAddAmt).HasColumnName("SaleSubAddAmt");
            this.Property(t => t.SaleSubVendor1Amt).HasColumnName("SaleSubVendor1Amt");
            this.Property(t => t.SaleSubVendor2Amt).HasColumnName("SaleSubVendor2Amt");
            this.Property(t => t.BackSubAddAmt).HasColumnName("BackSubAddAmt");
            this.Property(t => t.BackSubVendor1Amt).HasColumnName("BackSubVendor1Amt");
            this.Property(t => t.BackSubVendor2Amt).HasColumnName("BackSubVendor2Amt");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
            this.Property(t => t.Remark).HasColumnName("Remark");
        }
    }
}
