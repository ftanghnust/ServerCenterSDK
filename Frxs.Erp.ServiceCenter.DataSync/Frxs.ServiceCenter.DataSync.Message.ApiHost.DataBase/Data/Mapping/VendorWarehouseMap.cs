/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models.Mapping
{
    public class VendorWarehouseMap : EntityTypeConfigurationMapBase<VendorWarehouse>
    {
        public VendorWarehouseMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.VendorID });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.VendorID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.WID)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("VendorWarehouse");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
