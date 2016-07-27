/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseProductMap : EntityTypeConfigurationMapBase<BaseProduct>
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseProductMap()
        {
            // Primary Key
            this.HasKey(t => t.BaseProductId);

            // Properties
            this.Property(t => t.BaseProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ProductBaseName)
                .HasMaxLength(100);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("BaseProducts");
            this.Property(t => t.BaseProductId).HasColumnName("BaseProductId");
            this.Property(t => t.CategoryId1).HasColumnName("CategoryId1");
            this.Property(t => t.CategoryId2).HasColumnName("CategoryId2");
            this.Property(t => t.CategoryId3).HasColumnName("CategoryId3");
            this.Property(t => t.ShopCategoryId1).HasColumnName("ShopCategoryId1");
            this.Property(t => t.ShopCategoryId2).HasColumnName("ShopCategoryId2");
            this.Property(t => t.ShopCategoryId3).HasColumnName("ShopCategoryId3");
            this.Property(t => t.BrandId1).HasColumnName("BrandId1");
            this.Property(t => t.BrandId2).HasColumnName("BrandId2");
            this.Property(t => t.IsMutiAttribute).HasColumnName("IsMutiAttribute");
            this.Property(t => t.IsBaseProductId).HasColumnName("IsBaseProductId");
            this.Property(t => t.ProductBaseName).HasColumnName("ProductBaseName");
            this.Property(t => t.IsVendor).HasColumnName("IsVendor");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
