using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class XSUserShopMap : EntityTypeConfiguration<XSUserShop>
    {
        public XSUserShopMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CreateUserName)
                .HasMaxLength(64);

            // Table & Column Mappings
            this.ToTable("XSUserShop");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.XSUserID).HasColumnName("XSUserID");
            this.Property(t => t.ShopID).HasColumnName("ShopID");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
