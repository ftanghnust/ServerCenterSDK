/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models.Mapping
{
    public class StockFIFOOutMap : EntityTypeConfigurationMapBase<StockFIFOOut>
    {
        public StockFIFOOutMap()
        {
            // Primary Key
            this.HasKey(t => t.OutID);

            // Properties
            this.Property(t => t.BillID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.BillDetailID)
                .IsRequired()
                .HasMaxLength(39);

            // Table & Column Mappings
            this.ToTable("StockFIFOOut");
            this.Property(t => t.OutID).HasColumnName("OutID");
            this.Property(t => t.InID).HasColumnName("InID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.SubWID).HasColumnName("SubWID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.StockQty).HasColumnName("StockQty");
            this.Property(t => t.BillType).HasColumnName("BillType");
            this.Property(t => t.BillID).HasColumnName("BillID");
            this.Property(t => t.BillDetailID).HasColumnName("BillDetailID");
            this.Property(t => t.OutQty).HasColumnName("OutQty");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.StockTime).HasColumnName("StockTime");
        }
    }
}
