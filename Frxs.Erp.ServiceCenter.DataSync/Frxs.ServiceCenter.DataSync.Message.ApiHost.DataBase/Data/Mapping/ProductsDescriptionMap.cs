/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models.Mapping
{
    public class ProductsDescriptionMap : EntityTypeConfigurationMapBase<ProductsDescription>
    {
        public ProductsDescriptionMap()
        {
            // Primary Key
            this.HasKey(t => t.BaseProductId);

            // Properties
            this.Property(t => t.BaseProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("ProductsDescription");
            this.Property(t => t.BaseProductId).HasColumnName("BaseProductId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
