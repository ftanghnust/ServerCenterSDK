using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class WProductNoSaleShopMap : EntityTypeConfiguration<WProductNoSaleShop>
    {
        public WProductNoSaleShopMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.NoSaleID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WProductNoSaleShops");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.NoSaleID).HasColumnName("NoSaleID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.GroupID).HasColumnName("GroupID");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
