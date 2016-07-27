using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class SaleOrderDetailsExtMap : EntityTypeConfiguration<SaleOrderDetailsExt>
    {
        public SaleOrderDetailsExtMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.OrderID)
                .HasMaxLength(50);

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
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SaleOrderDetailsExt");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
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
