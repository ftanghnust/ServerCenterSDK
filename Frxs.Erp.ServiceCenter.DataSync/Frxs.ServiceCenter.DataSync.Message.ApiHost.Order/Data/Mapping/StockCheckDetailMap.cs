/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;
namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models.Mapping
{
    public class StockCheckDetailMap : EntityTypeConfigurationMapBase<StockCheckDetail>
    {
        public StockCheckDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(50);

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

            this.Property(t => t.Unit)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ShleftCode)
                .HasMaxLength(32);

            this.Property(t => t.SaleUnit)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.CheckUserName)
                .HasMaxLength(32);

            this.Property(t => t.Remark)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("StockCheckDetails");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.CheckStockID).HasColumnName("CheckStockID");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.SKU).HasColumnName("SKU");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.BarCode).HasColumnName("BarCode");
            this.Property(t => t.ProductImageUrl200).HasColumnName("ProductImageUrl200");
            this.Property(t => t.ProductImageUrl400).HasColumnName("ProductImageUrl400");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.ShelfID).HasColumnName("ShelfID");
            this.Property(t => t.ShleftCode).HasColumnName("ShleftCode");
            this.Property(t => t.SaleUnit).HasColumnName("SaleUnit");
            this.Property(t => t.SalePackingQty).HasColumnName("SalePackingQty");
            this.Property(t => t.CheckUnitQty).HasColumnName("CheckUnitQty");
            this.Property(t => t.StockUnitQty).HasColumnName("StockUnitQty");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.SubAmt).HasColumnName("SubAmt");
            this.Property(t => t.CheckUserID).HasColumnName("CheckUserID");
            this.Property(t => t.CheckUserName).HasColumnName("CheckUserName");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
