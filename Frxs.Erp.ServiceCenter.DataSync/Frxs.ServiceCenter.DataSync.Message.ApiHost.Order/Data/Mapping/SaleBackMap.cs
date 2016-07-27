/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models.Mapping
{
    public class SaleBackMap : EntityTypeConfigurationMapBase<SaleBack>
    {
        public SaleBackMap()
        {
            // Primary Key
            this.HasKey(t => t.BackID);

            // Properties
            this.Property(t => t.BackID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.SettleID)
                .HasMaxLength(36);

            this.Property(t => t.WCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.WName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SubWCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.SubWName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShopCode)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ShopName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ConfUserName)
                .HasMaxLength(64);

            this.Property(t => t.PostingUserName)
                .HasMaxLength(64);

            this.Property(t => t.SettleUserName)
                .HasMaxLength(64);

            this.Property(t => t.Remark)
                .HasMaxLength(400);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SaleBack");
            this.Property(t => t.BackID).HasColumnName("BackID");
            this.Property(t => t.SettleID).HasColumnName("SettleID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.WCode).HasColumnName("WCode");
            this.Property(t => t.WName).HasColumnName("WName");
            this.Property(t => t.SubWID).HasColumnName("SubWID");
            this.Property(t => t.SubWCode).HasColumnName("SubWCode");
            this.Property(t => t.SubWName).HasColumnName("SubWName");
            this.Property(t => t.BackDate).HasColumnName("BackDate");
            this.Property(t => t.XSUserID).HasColumnName("XSUserID");
            this.Property(t => t.ShopID).HasColumnName("ShopID");
            this.Property(t => t.ShopCode).HasColumnName("ShopCode");
            this.Property(t => t.ShopName).HasColumnName("ShopName");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.TotalBackQty).HasColumnName("TotalBackQty");
            this.Property(t => t.TotalBackAmt).HasColumnName("TotalBackAmt");
            this.Property(t => t.TotalBasePoint).HasColumnName("TotalBasePoint");
            this.Property(t => t.TotalAddAmt).HasColumnName("TotalAddAmt");
            this.Property(t => t.PayAmount).HasColumnName("PayAmount");
            this.Property(t => t.ConfTime).HasColumnName("ConfTime");
            this.Property(t => t.ConfUserID).HasColumnName("ConfUserID");
            this.Property(t => t.ConfUserName).HasColumnName("ConfUserName");
            this.Property(t => t.PostingTime).HasColumnName("PostingTime");
            this.Property(t => t.PostingUserID).HasColumnName("PostingUserID");
            this.Property(t => t.PostingUserName).HasColumnName("PostingUserName");
            this.Property(t => t.SettleTime).HasColumnName("SettleTime");
            this.Property(t => t.SettleUserID).HasColumnName("SettleUserID");
            this.Property(t => t.SettleUserName).HasColumnName("SettleUserName");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
