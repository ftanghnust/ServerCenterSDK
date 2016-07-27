using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class SettlementDetailMap : EntityTypeConfiguration<SettlementDetail>
    {
        public SettlementDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.RefSet_ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SKU)
                .HasMaxLength(50);

            this.Property(t => t.ProductName)
                .HasMaxLength(200);

            this.Property(t => t.BarCode)
                .HasMaxLength(20);

            this.Property(t => t.Unit)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.CategoryId1Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CategoryId2Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CategoryId3Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ShopCategoryId1Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ShopCategoryId2Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ShopCategoryId3Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.BrandId1Name)
                .HasMaxLength(100);

            this.Property(t => t.BrandId2Name)
                .HasMaxLength(100);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(64);

            // Table & Column Mappings
            this.ToTable("SettlementDetail");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RefSet_ID).HasColumnName("RefSet_ID");
            this.Property(t => t.SKU).HasColumnName("SKU");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.BarCode).HasColumnName("BarCode");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.BuyPrice).HasColumnName("BuyPrice");
            this.Property(t => t.SalePrice).HasColumnName("SalePrice");
            this.Property(t => t.BeginQty).HasColumnName("BeginQty");
            this.Property(t => t.BeginAmt).HasColumnName("BeginAmt");
            this.Property(t => t.BuyQty).HasColumnName("BuyQty");
            this.Property(t => t.BuyAmt).HasColumnName("BuyAmt");
            this.Property(t => t.BuyBackQty).HasColumnName("BuyBackQty");
            this.Property(t => t.BuyBackAmt).HasColumnName("BuyBackAmt");
            this.Property(t => t.SaleQty).HasColumnName("SaleQty");
            this.Property(t => t.SaleAmt).HasColumnName("SaleAmt");
            this.Property(t => t.SaleBackQty).HasColumnName("SaleBackQty");
            this.Property(t => t.SaleBackAmt).HasColumnName("SaleBackAmt");
            this.Property(t => t.AdjGainQty).HasColumnName("AdjGainQty");
            this.Property(t => t.AjgGginAmt).HasColumnName("AjgGginAmt");
            this.Property(t => t.AdjLossQty).HasColumnName("AdjLossQty");
            this.Property(t => t.AjgLosssAmt).HasColumnName("AjgLosssAmt");
            this.Property(t => t.StockQty).HasColumnName("StockQty");
            this.Property(t => t.StockAmt).HasColumnName("StockAmt");
            this.Property(t => t.EndQty).HasColumnName("EndQty");
            this.Property(t => t.EndStockAmt).HasColumnName("EndStockAmt");
            this.Property(t => t.EndDiffQty).HasColumnName("EndDiffQty");
            this.Property(t => t.EndDiffStockAmt).HasColumnName("EndDiffStockAmt");
            this.Property(t => t.SubBasePoint).HasColumnName("SubBasePoint");
            this.Property(t => t.SubPoint).HasColumnName("SubPoint");
            this.Property(t => t.SaleSubAddAmt).HasColumnName("SaleSubAddAmt");
            this.Property(t => t.SaleSubVendor1Amt).HasColumnName("SaleSubVendor1Amt");
            this.Property(t => t.SaleSubVendor2Amt).HasColumnName("SaleSubVendor2Amt");
            this.Property(t => t.BackSubAddAmt).HasColumnName("BackSubAddAmt");
            this.Property(t => t.BackSubVendor1Amt).HasColumnName("BackSubVendor1Amt");
            this.Property(t => t.BackSubVendor2Amt).HasColumnName("BackSubVendor2Amt");
            this.Property(t => t.CategoryId1).HasColumnName("CategoryId1");
            this.Property(t => t.CategoryId1Name).HasColumnName("CategoryId1Name");
            this.Property(t => t.CategoryId2).HasColumnName("CategoryId2");
            this.Property(t => t.CategoryId2Name).HasColumnName("CategoryId2Name");
            this.Property(t => t.CategoryId3).HasColumnName("CategoryId3");
            this.Property(t => t.CategoryId3Name).HasColumnName("CategoryId3Name");
            this.Property(t => t.ShopCategoryId1).HasColumnName("ShopCategoryId1");
            this.Property(t => t.ShopCategoryId1Name).HasColumnName("ShopCategoryId1Name");
            this.Property(t => t.ShopCategoryId2).HasColumnName("ShopCategoryId2");
            this.Property(t => t.ShopCategoryId2Name).HasColumnName("ShopCategoryId2Name");
            this.Property(t => t.ShopCategoryId3).HasColumnName("ShopCategoryId3");
            this.Property(t => t.ShopCategoryId3Name).HasColumnName("ShopCategoryId3Name");
            this.Property(t => t.BrandId1).HasColumnName("BrandId1");
            this.Property(t => t.BrandId1Name).HasColumnName("BrandId1Name");
            this.Property(t => t.BrandId2).HasColumnName("BrandId2");
            this.Property(t => t.BrandId2Name).HasColumnName("BrandId2Name");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
