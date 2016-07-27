/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Promotion.Models.Mapping
{
    public class WProductAddPercShopMap : EntityTypeConfigurationMapBase<WProductAddPercShop>
    {
        public WProductAddPercShopMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.PercID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShopCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ShopName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WProductAddPercShops");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PercID).HasColumnName("PercID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.ShopID).HasColumnName("ShopID");
            this.Property(t => t.ShopCode).HasColumnName("ShopCode");
            this.Property(t => t.ShopName).HasColumnName("ShopName");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
