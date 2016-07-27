/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class AttributesValueMap : EntityTypeConfigurationMapBase<AttributesValue>
    {
        /// <summary>
        /// 
        /// </summary>
        public AttributesValueMap()
        {
            // Primary Key
            this.HasKey(t => t.ValuesId);

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
