/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models.Mapping
{
    public class StockCheckMap : EntityTypeConfigurationMapBase<StockCheck>
    {
        public StockCheckMap()
        {
            // Primary Key
            this.HasKey(t => t.StockCheckID);

            // Properties
            this.Property(t => t.StockCheckID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.WCode)
                .HasMaxLength(32);

            this.Property(t => t.WName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SubWName)
                .HasMaxLength(50);

            this.Property(t => t.ConfUserName)
                .HasMaxLength(64);

            this.Property(t => t.PostingUserName)
                .HasMaxLength(64);

            this.Property(t => t.SettleUserName)
                .HasMaxLength(64);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(64);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(64);

            // Table & Column Mappings
            this.ToTable("StockCheck");
            this.Property(t => t.StockCheckID).HasColumnName("StockCheckID");
            this.Property(t => t.StockCheckDate).HasColumnName("StockCheckDate");
            this.Property(t => t.PlanID).HasColumnName("PlanID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.SubWID).HasColumnName("SubWID");
            this.Property(t => t.WCode).HasColumnName("WCode");
            this.Property(t => t.WName).HasColumnName("WName");
            this.Property(t => t.SubWName).HasColumnName("SubWName");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CheckNumber).HasColumnName("CheckNumber");
            this.Property(t => t.ConfTime).HasColumnName("ConfTime");
            this.Property(t => t.ConfUserID).HasColumnName("ConfUserID");
            this.Property(t => t.ConfUserName).HasColumnName("ConfUserName");
            this.Property(t => t.PostingTime).HasColumnName("PostingTime");
            this.Property(t => t.PostingUserID).HasColumnName("PostingUserID");
            this.Property(t => t.PostingUserName).HasColumnName("PostingUserName");
            this.Property(t => t.SettleTime).HasColumnName("SettleTime");
            this.Property(t => t.SettleUserID).HasColumnName("SettleUserID");
            this.Property(t => t.SettleUserName).HasColumnName("SettleUserName");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
