using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class WarehouseMap : EntityTypeConfiguration<Warehouse>
    {
        public WarehouseMap()
        {
            // Primary Key
            this.HasKey(t => t.WID);

            // Properties
            this.Property(t => t.WID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Properties
            this.Property(t => t.WCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.WName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.WTel)
                .HasMaxLength(16);

            this.Property(t => t.WContact)
                .HasMaxLength(32);

            this.Property(t => t.WAddress)
                .HasMaxLength(100);

            this.Property(t => t.WFullAddress)
                .HasMaxLength(200);

            this.Property(t => t.WCustomerServiceTel)
                .HasMaxLength(16);

            this.Property(t => t.THBTel)
                .HasMaxLength(16);

            this.Property(t => t.CWTel)
                .HasMaxLength(16);

            this.Property(t => t.YW1Tel)
                .HasMaxLength(16);

            this.Property(t => t.YW2Tel)
                .HasMaxLength(16);

            this.Property(t => t.Remark)
                .HasMaxLength(400);

            this.Property(t => t.CreateUserName)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ModityUserName)
                .IsRequired()
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("Warehouse");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.WCode).HasColumnName("WCode");
            this.Property(t => t.WName).HasColumnName("WName");
            this.Property(t => t.WLevel).HasColumnName("WLevel");
            this.Property(t => t.WSubType).HasColumnName("WSubType");
            this.Property(t => t.ParentWID).HasColumnName("ParentWID");
            this.Property(t => t.WTel).HasColumnName("WTel");
            this.Property(t => t.WContact).HasColumnName("WContact");
            this.Property(t => t.ProvinceID).HasColumnName("ProvinceID");
            this.Property(t => t.CityID).HasColumnName("CityID");
            this.Property(t => t.RegionID).HasColumnName("RegionID");
            this.Property(t => t.WAddress).HasColumnName("WAddress");
            this.Property(t => t.WFullAddress).HasColumnName("WFullAddress");
            this.Property(t => t.WCustomerServiceTel).HasColumnName("WCustomerServiceTel");
            this.Property(t => t.THBTel).HasColumnName("THBTel");
            this.Property(t => t.CWTel).HasColumnName("CWTel");
            this.Property(t => t.YW1Tel).HasColumnName("YW1Tel");
            this.Property(t => t.YW2Tel).HasColumnName("YW2Tel");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.IsFreeze).HasColumnName("IsFreeze");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModityTime).HasColumnName("ModityTime");
            this.Property(t => t.ModityUserID).HasColumnName("ModityUserID");
            this.Property(t => t.ModityUserName).HasColumnName("ModityUserName");
            this.Property(t => t.SyncFale).HasColumnName("SyncFale");
        }
    }
}
