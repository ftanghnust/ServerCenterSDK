/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models.Mapping
{
    public class SaleOrderSendNumberMap : EntityTypeConfigurationMapBase<SaleOrderSendNumber>
    {
        public SaleOrderSendNumberMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderID);

            // Properties
            this.Property(t => t.OrderID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(100);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SaleOrderSendNumber");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.LineSerialNumber).HasColumnName("LineSerialNumber");
            this.Property(t => t.ShopSerialNumber).HasColumnName("ShopSerialNumber");
            this.Property(t => t.SendNumber).HasColumnName("SendNumber");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
