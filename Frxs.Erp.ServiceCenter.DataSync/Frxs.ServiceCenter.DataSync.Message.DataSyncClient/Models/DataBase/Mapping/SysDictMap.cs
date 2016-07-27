using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class SysDictMap : EntityTypeConfiguration<SysDict>
    {
        public SysDictMap()
        {
            // Primary Key
            this.HasKey(t => t.DictCode);

            // Properties
            this.Property(t => t.DictCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.DictName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SysDict");
            this.Property(t => t.DictCode).HasColumnName("DictCode");
            this.Property(t => t.DictName).HasColumnName("DictName");
            this.Property(t => t.DictType).HasColumnName("DictType");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
