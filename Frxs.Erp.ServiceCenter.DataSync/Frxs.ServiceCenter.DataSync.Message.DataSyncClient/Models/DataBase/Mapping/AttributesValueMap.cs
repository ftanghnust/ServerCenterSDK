using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class AttributesValueMap : EntityTypeConfiguration<AttributesValue>
    {
        public AttributesValueMap()
        {
            // Primary Key
            this.HasKey(t => t.ValuesId);

            this.Property(t => t.AttributeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


            // Properties
            this.Property(t => t.ValueStr)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("AttributesValues");
            this.Property(t => t.ValuesId).HasColumnName("ValuesId");
            this.Property(t => t.AttributeId).HasColumnName("AttributeId");
            this.Property(t => t.ValueStr).HasColumnName("ValueStr");
            this.Property(t => t.DisplaySequence).HasColumnName("DisplaySequence");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}