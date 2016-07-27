/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models.Mapping
{
    public class SaleSettleMap : EntityTypeConfigurationMapBase<SaleSettle>
    {
        public SaleSettleMap()
        {
            // Primary Key
            this.HasKey(t => t.SettleID);

            // Properties
            this.Property(t => t.SettleID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.WCode)
                .HasMaxLength(32);

            this.Property(t => t.WName)
                .HasMaxLength(50);

            this.Property(t => t.OrderID)
                .HasMaxLength(50);

            this.Property(t => t.ShopCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ShopName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.BankAccount)
                .HasMaxLength(50);

            this.Property(t => t.BankAccountName)
                .HasMaxLength(100);

            this.Property(t => t.BankType)
                .HasMaxLength(200);

            this.Property(t => t.Remark)
                .HasMaxLength(400);

            this.Property(t => t.SettleType)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.SettleName)
                .HasMaxLength(32);

            this.Property(t => t.ConfUserName)
                .HasMaxLength(64);

            this.Property(t => t.PostingUserName)
                .HasMaxLength(64);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(64);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SaleSettle");
            this.Property(t => t.SettleID).HasColumnName("SettleID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.WCode).HasColumnName("WCode");
            this.Property(t => t.WName).HasColumnName("WName");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.SaleAmt).HasColumnName("SaleAmt");
            this.Property(t => t.BackAmt).HasColumnName("BackAmt");
            this.Property(t => t.FeeAmt).HasColumnName("FeeAmt");
            this.Property(t => t.SettleAmt).HasColumnName("SettleAmt");
            this.Property(t => t.SettleTime).HasColumnName("SettleTime");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.ShopID).HasColumnName("ShopID");
            this.Property(t => t.ShopCode).HasColumnName("ShopCode");
            this.Property(t => t.ShopType).HasColumnName("ShopType");
            this.Property(t => t.ShopName).HasColumnName("ShopName");
            this.Property(t => t.CreditAmt).HasColumnName("CreditAmt");
            this.Property(t => t.BankAccount).HasColumnName("BankAccount");
            this.Property(t => t.BankAccountName).HasColumnName("BankAccountName");
            this.Property(t => t.BankType).HasColumnName("BankType");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.SettleType).HasColumnName("SettleType");
            this.Property(t => t.SettleName).HasColumnName("SettleName");
            this.Property(t => t.ConfTime).HasColumnName("ConfTime");
            this.Property(t => t.ConfUserID).HasColumnName("ConfUserID");
            this.Property(t => t.ConfUserName).HasColumnName("ConfUserName");
            this.Property(t => t.PostingTime).HasColumnName("PostingTime");
            this.Property(t => t.PostingUserID).HasColumnName("PostingUserID");
            this.Property(t => t.PostingUserName).HasColumnName("PostingUserName");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
