using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class StockQtyMap : EntityTypeConfiguration<StockQty>
    {
        public StockQtyMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.SKU)
                .HasMaxLength(32);

            this.Property(t => t.ProductName)
                .HasMaxLength(50);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("StockQty");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.SKU).HasColumnName("SKU");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.WProductID).HasColumnName("WProductID");
            this.Property(t => t.SubWID).HasColumnName("SubWID");
            this.Property(t => t.StockQty1).HasColumnName("StockQty");
            this.Property(t => t.SaleTranQty).HasColumnName("SaleTranQty");
            this.Property(t => t.BuyTranQty).HasColumnName("BuyTranQty");
            this.Property(t => t.UpdateStockTime).HasColumnName("UpdateStockTime");
            this.Property(t => t.LastCheckQty).HasColumnName("LastCheckQty");
            this.Property(t => t.LastCheckTime).HasColumnName("LastCheckTime");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
