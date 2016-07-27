/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models.Mapping
{
    public class XSOperatorLogMap : EntityTypeConfigurationMapBase<XSOperatorLog>
    {
        public XSOperatorLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MenuName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Action)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(t => t.OperatorName)
                .IsRequired()
                .HasMaxLength(64);

            // Table & Column Mappings
            this.ToTable("XSOperatorLog");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.MenuID).HasColumnName("MenuID");
            this.Property(t => t.MenuName).HasColumnName("MenuName");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.OperatorID).HasColumnName("OperatorID");
            this.Property(t => t.OperatorName).HasColumnName("OperatorName");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
        }
    }
}
