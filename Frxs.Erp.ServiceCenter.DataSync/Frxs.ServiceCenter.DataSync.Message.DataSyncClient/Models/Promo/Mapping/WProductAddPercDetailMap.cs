using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class WProductAddPercDetailMap : EntityTypeConfiguration<WProductAddPercDetail>
    {
        public WProductAddPercDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.PercID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WProductAddPercDetails");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PercID).HasColumnName("PercID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.WProductID).HasColumnName("WProductID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.ShopAddPerc).HasColumnName("ShopAddPerc");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
