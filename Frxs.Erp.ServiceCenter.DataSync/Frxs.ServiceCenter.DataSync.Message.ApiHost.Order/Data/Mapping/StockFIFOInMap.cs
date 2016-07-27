/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models.Mapping
{
    public class StockFIFOInMap : EntityTypeConfigurationMapBase<StockFIFOIn>
    {
        public StockFIFOInMap()
        {
            // Primary Key
            this.HasKey(t => t.InID);

            // Properties
            this.Property(t => t.BatchNO)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.WCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.WName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SubWName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SKU)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.BillID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.BillDetailID)
                .IsRequired()
                .HasMaxLength(39);

            this.Property(t => t.Unit)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.VendorCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.VendorName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("StockFIFOIn");
            this.Property(t => t.InID).HasColumnName("InID");
            this.Property(t => t.BatchNO).HasColumnName("BatchNO");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.WCode).HasColumnName("WCode");
            this.Property(t => t.WName).HasColumnName("WName");
            this.Property(t => t.SubWID).HasColumnName("SubWID");
            this.Property(t => t.SubWName).HasColumnName("SubWName");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.SKU).HasColumnName("SKU");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.StockQty).HasColumnName("StockQty");
            this.Property(t => t.BillType).HasColumnName("BillType");
            this.Property(t => t.BillID).HasColumnName("BillID");
            this.Property(t => t.BillDetailID).HasColumnName("BillDetailID");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.Qty).HasColumnName("Qty");
            this.Property(t => t.TotalOutQty).HasColumnName("TotalOutQty");
            this.Property(t => t.Flag).HasColumnName("Flag");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.VendorCode).HasColumnName("VendorCode");
            this.Property(t => t.VendorName).HasColumnName("VendorName");
            this.Property(t => t.InPrice).HasColumnName("InPrice");
            this.Property(t => t.StockTime).HasColumnName("StockTime");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
        }
    }
}
