/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models.Mapping
{
    public class WProductsBuyMap : EntityTypeConfigurationMapBase<WProductsBuy>
    {
        public WProductsBuyMap()
        {
            // Primary Key
            this.HasKey(t => t.WProductID);

            // Properties
            this.Property(t => t.WProductID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.BigUnit)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WProductsBuy");
            this.Property(t => t.WProductID).HasColumnName("WProductID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.BuyPrice).HasColumnName("BuyPrice");
            this.Property(t => t.BigProductsUnitID).HasColumnName("BigProductsUnitID");
            this.Property(t => t.BigPackingQty).HasColumnName("BigPackingQty");
            this.Property(t => t.BigUnit).HasColumnName("BigUnit");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
