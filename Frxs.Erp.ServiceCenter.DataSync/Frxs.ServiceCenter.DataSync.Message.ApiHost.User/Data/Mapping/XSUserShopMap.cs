/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.User.Models.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class XSUserShopMap : EntityTypeConfigurationMapBase<XSUserShop>
    {
        public XSUserShopMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CreateUserName)
                .HasMaxLength(64);

            // Table & Column Mappings
            this.ToTable("XSUserShop");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.XSUserID).HasColumnName("XSUserID");
            this.Property(t => t.ShopID).HasColumnName("ShopID");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
