using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class SysDictDetailMap : EntityTypeConfiguration<SysDictDetail>
    {
        public SysDictDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            this.Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Properties
            this.Property(t => t.DictCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.DictValue)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.DictLabel)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(100);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SysDictDetail");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.DictCode).HasColumnName("DictCode");
            this.Property(t => t.DictValue).HasColumnName("DictValue");
            this.Property(t => t.DictLabel).HasColumnName("DictLabel");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
