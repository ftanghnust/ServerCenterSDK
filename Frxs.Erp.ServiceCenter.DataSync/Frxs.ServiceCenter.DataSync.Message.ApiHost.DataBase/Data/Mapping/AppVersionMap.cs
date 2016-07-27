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
    public class AppVersionMap : EntityTypeConfigurationMapBase<AppVersion>
    {
        /// <summary>
        /// 
        /// </summary>
        public AppVersionMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CurVersion)
                .IsRequired()
                .HasMaxLength(7);

            this.Property(t => t.DownUrl)
                .HasMaxLength(100);

            this.Property(t => t.UpdateRemark)
                .HasMaxLength(400);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("AppVersion");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SysType).HasColumnName("SysType");
            this.Property(t => t.AppType).HasColumnName("AppType");
            this.Property(t => t.CurVersion).HasColumnName("CurVersion");
            this.Property(t => t.DownUrl).HasColumnName("DownUrl");
            this.Property(t => t.UpdateFlag).HasColumnName("UpdateFlag");
            this.Property(t => t.UpdateRemark).HasColumnName("UpdateRemark");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
