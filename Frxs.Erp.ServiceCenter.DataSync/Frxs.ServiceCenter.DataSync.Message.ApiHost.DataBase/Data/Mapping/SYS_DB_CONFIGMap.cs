/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models.Mapping
{
    public class SYS_DB_CONFIGMap : EntityTypeConfigurationMapBase<SYS_DB_CONFIG>
    {
        public SYS_DB_CONFIGMap()
        {
            // Primary Key
            this.HasKey(t => t.CON_KEY);

            // Properties
            this.Property(t => t.CON_KEY)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.DB_NAME)
                .HasMaxLength(50);

            this.Property(t => t.DB_USER)
                .HasMaxLength(20);

            this.Property(t => t.DB_PWD)
                .HasMaxLength(20);

            this.Property(t => t.DB_SERVER)
                .HasMaxLength(20);

            this.Property(t => t.REMARK)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SYS_DB_CONFIG");
            this.Property(t => t.CON_KEY).HasColumnName("CON_KEY");
            this.Property(t => t.DB_NAME).HasColumnName("DB_NAME");
            this.Property(t => t.DB_USER).HasColumnName("DB_USER");
            this.Property(t => t.DB_PWD).HasColumnName("DB_PWD");
            this.Property(t => t.DB_SERVER).HasColumnName("DB_SERVER");
            this.Property(t => t.REMARK).HasColumnName("REMARK");
        }
    }
}
