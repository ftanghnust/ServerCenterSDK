using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class SaleOrderPreDetailsPickMap : EntityTypeConfiguration<SaleOrderPreDetailsPick>
    {
        public SaleOrderPreDetailsPickMap()
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

            this.Property(t => t.ShelfCode)
                .HasMaxLength(10);

            this.Property(t => t.SaleUnit)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.PickUserName)
                .HasMaxLength(32);

            this.Property(t => t.CheckUserName)
                .HasMaxLength(32);

            this.Property(t => t.Remark)
                .HasMaxLength(200);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SaleOrderPreDetailsPick");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.WCProductID).HasColumnName("WCProductID");
            this.Property(t => t.SKU).HasColumnName("SKU");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.BarCode).HasColumnName("BarCode");
            this.Property(t => t.ProductImageUrl200).HasColumnName("ProductImageUrl200");
            this.Property(t => t.ProductImageUrl400).HasColumnName("ProductImageUrl400");
            this.Property(t => t.ShelfAreaID).HasColumnName("ShelfAreaID");
            this.Property(t => t.ShelfID).HasColumnName("ShelfID");
            this.Property(t => t.ShelfCode).HasColumnName("ShelfCode");
            this.Property(t => t.SaleQty).HasColumnName("SaleQty");
            this.Property(t => t.SaleUnit).HasColumnName("SaleUnit");
            this.Property(t => t.SalePackingQty).HasColumnName("SalePackingQty");
            this.Property(t => t.PickQty).HasColumnName("PickQty");
            this.Property(t => t.PickUserID).HasColumnName("PickUserID");
            this.Property(t => t.PickUserName).HasColumnName("PickUserName");
            this.Property(t => t.PickTime).HasColumnName("PickTime");
            this.Property(t => t.CheckTime).HasColumnName("CheckTime");
            this.Property(t => t.CheckUserID).HasColumnName("CheckUserID");
            this.Property(t => t.CheckUserName).HasColumnName("CheckUserName");
            this.Property(t => t.IsCheckRight).HasColumnName("IsCheckRight");
            this.Property(t => t.IsAppend).HasColumnName("IsAppend");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
            this.Property(t => t.CheckQty).HasColumnName("CheckQty");
        }
    }
}
