/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models.Mapping
{
    public class ProductsSKUNumberServiceMap : EntityTypeConfigurationMapBase<ProductsSKUNumberService>
    {
        public ProductsSKUNumberServiceMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProductsSKUNumberService");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.States).HasColumnName("States");
        }
    }
}
