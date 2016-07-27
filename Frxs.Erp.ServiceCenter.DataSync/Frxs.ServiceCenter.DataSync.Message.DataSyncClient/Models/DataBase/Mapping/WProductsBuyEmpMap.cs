using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class WProductsBuyEmpMap : EntityTypeConfiguration<WProductsBuyEmp>
    {
        public WProductsBuyEmpMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WProductsBuyEmp");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.WProductID).HasColumnName("WProductID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.EmpID).HasColumnName("EmpID");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
