using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class SysParamMap : EntityTypeConfiguration<SysParam>
    {
        public SysParamMap()
        {
            // Primary Key
            this.HasKey(t => t.ParamCode);

            // Properties
            this.Property(t => t.ParamCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ParamName)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ParamValue)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.Remark)
                .HasMaxLength(200);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SysParams");
            this.Property(t => t.ParamCode).HasColumnName("ParamCode");
            this.Property(t => t.ParamName).HasColumnName("ParamName");
            this.Property(t => t.ParamValue).HasColumnName("ParamValue");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.IsDisEdit).HasColumnName("IsDisEdit");
        }
    }
}
