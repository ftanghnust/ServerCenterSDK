using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class StockAdjDetailMap : EntityTypeConfiguration<StockAdjDetail>
    {
        public StockAdjDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.AdjID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.SKU)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.BarCode)
                .HasMaxLength(20);

            this.Property(t => t.ProductImageUrl200)
                .HasMaxLength(200);

            this.Property(t => t.ProductImageUrl400)
                .HasMaxLength(200);

            this.Property(t => t.AdjUnit)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.Unit)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.VendorCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.VendorName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(200);

            this.Property(t => t.StockCheckID)
                .HasMaxLength(50);

            this.Property(t => t.StockCheckDetailsID)
                .HasMaxLength(50);

            this.Property(t => t.CheckUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("StockAdjDetail");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.AdjID).HasColumnName("AdjID");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.SKU).HasColumnName("SKU");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.BarCode).HasColumnName("BarCode");
            this.Property(t => t.ProductImageUrl200).HasColumnName("ProductImageUrl200");
            this.Property(t => t.ProductImageUrl400).HasColumnName("ProductImageUrl400");
            this.Property(t => t.AdjUnit).HasColumnName("AdjUnit");
            this.Property(t => t.AdjPackingQty).HasColumnName("AdjPackingQty");
            this.Property(t => t.AdjQty).HasColumnName("AdjQty");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.UnitQty).HasColumnName("UnitQty");
            this.Property(t => t.BuyPrice).HasColumnName("BuyPrice");
            this.Property(t => t.SalePrice).HasColumnName("SalePrice");
            this.Property(t => t.AdjAmt).HasColumnName("AdjAmt");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.VendorCode).HasColumnName("VendorCode");
            this.Property(t => t.VendorName).HasColumnName("VendorName");
            this.Property(t => t.StockQty).HasColumnName("StockQty");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.StockCheckID).HasColumnName("StockCheckID");
            this.Property(t => t.StockCheckDetailsID).HasColumnName("StockCheckDetailsID");
            this.Property(t => t.CheckUserID).HasColumnName("CheckUserID");
            this.Property(t => t.CheckUserName).HasColumnName("CheckUserName");
            this.Property(t => t.CheckUnitQty).HasColumnName("CheckUnitQty");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
