/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models.Mapping
{
    public class SaleOrderDetailMap : EntityTypeConfigurationMapBase<SaleOrderDetail>
    {
        public SaleOrderDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.OrderID)
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

            this.Property(t => t.SaleUnit)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.Unit)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.EditID)
                .HasMaxLength(36);

            this.Property(t => t.PromotionID)
                .HasMaxLength(50);

            this.Property(t => t.PromotionName)
                .HasMaxLength(100);

            this.Property(t => t.Remark)
                .HasMaxLength(50);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SaleOrderDetails");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.SKU).HasColumnName("SKU");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.BarCode).HasColumnName("BarCode");
            this.Property(t => t.ProductImageUrl200).HasColumnName("ProductImageUrl200");
            this.Property(t => t.ProductImageUrl400).HasColumnName("ProductImageUrl400");
            this.Property(t => t.WCProductID).HasColumnName("WCProductID");
            this.Property(t => t.PreQty).HasColumnName("PreQty");
            this.Property(t => t.SaleUnit).HasColumnName("SaleUnit");
            this.Property(t => t.SalePackingQty).HasColumnName("SalePackingQty");
            this.Property(t => t.SalePrice).HasColumnName("SalePrice");
            this.Property(t => t.SaleQty).HasColumnName("SaleQty");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.UnitQty).HasColumnName("UnitQty");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.PromotionUnitPrice).HasColumnName("PromotionUnitPrice");
            this.Property(t => t.SubAmt).HasColumnName("SubAmt");
            this.Property(t => t.ShopAddPerc).HasColumnName("ShopAddPerc");
            this.Property(t => t.ShopPoint).HasColumnName("ShopPoint");
            this.Property(t => t.PromotionShopPoint).HasColumnName("PromotionShopPoint");
            this.Property(t => t.BasePoint).HasColumnName("BasePoint");
            this.Property(t => t.VendorPerc1).HasColumnName("VendorPerc1");
            this.Property(t => t.VendorPerc2).HasColumnName("VendorPerc2");
            this.Property(t => t.SubAddAmt).HasColumnName("SubAddAmt");
            this.Property(t => t.SubPoint).HasColumnName("SubPoint");
            this.Property(t => t.SubBasePoint).HasColumnName("SubBasePoint");
            this.Property(t => t.SubVendor1Amt).HasColumnName("SubVendor1Amt");
            this.Property(t => t.SubVendor2Amt).HasColumnName("SubVendor2Amt");
            this.Property(t => t.IsAppend).HasColumnName("IsAppend");
            this.Property(t => t.EditID).HasColumnName("EditID");
            this.Property(t => t.IsStockOut).HasColumnName("IsStockOut");
            this.Property(t => t.PromotionID).HasColumnName("PromotionID");
            this.Property(t => t.PromotionName).HasColumnName("PromotionName");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
