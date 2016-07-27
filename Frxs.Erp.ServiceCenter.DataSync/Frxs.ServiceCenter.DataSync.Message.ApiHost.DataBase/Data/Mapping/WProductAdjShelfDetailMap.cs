/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models.Mapping
{
    public class WProductAdjShelfDetailMap : EntityTypeConfigurationMapBase<WProductAdjShelfDetail>
    {
        public WProductAdjShelfDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.AdjID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Unit)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.OldShelfCode)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ShelfCode)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Remark)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WProductAdjShelfDetails");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.AdjID).HasColumnName("AdjID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.WProductID).HasColumnName("WProductID");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.OldShelfID).HasColumnName("OldShelfID");
            this.Property(t => t.OldShelfCode).HasColumnName("OldShelfCode");
            this.Property(t => t.ShelfID).HasColumnName("ShelfID");
            this.Property(t => t.ShelfCode).HasColumnName("ShelfCode");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
