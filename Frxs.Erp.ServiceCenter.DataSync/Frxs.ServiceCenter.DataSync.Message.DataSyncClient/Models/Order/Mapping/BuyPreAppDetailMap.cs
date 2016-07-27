using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class BuyPreAppDetailMap : EntityTypeConfiguration<BuyPreAppDetail>
    {
        public BuyPreAppDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.AppID)
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

            this.Property(t => t.AppUnit)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.Unit)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.Remark)
                .HasMaxLength(200);

            this.Property(t => t.VendorCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.VendorName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            this.Property(t => t.BuyEmpName)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("BuyPreAppDetails");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.AppID).HasColumnName("AppID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.SKU).HasColumnName("SKU");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.BarCode).HasColumnName("BarCode");
            this.Property(t => t.ProductImageUrl200).HasColumnName("ProductImageUrl200");
            this.Property(t => t.ProductImageUrl400).HasColumnName("ProductImageUrl400");
            this.Property(t => t.AppUnit).HasColumnName("AppUnit");
            this.Property(t => t.AppPackingQty).HasColumnName("AppPackingQty");
            this.Property(t => t.AppQty).HasColumnName("AppQty");
            this.Property(t => t.AppPrice).HasColumnName("AppPrice");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.UnitQty).HasColumnName("UnitQty");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.SubAmt).HasColumnName("SubAmt");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.VendorCode).HasColumnName("VendorCode");
            this.Property(t => t.VendorName).HasColumnName("VendorName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
            this.Property(t => t.BuyEmpID).HasColumnName("BuyEmpID");
            this.Property(t => t.BuyEmpName).HasColumnName("BuyEmpName");
        }
    }
}
