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
    public class ProductMap : EntityTypeConfigurationMapBase<Product>
    {
        /// <summary>
        /// 
        /// </summary>
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductId);

            // Properties
            this.Property(t => t.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SKU)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ProductName2)
                .HasMaxLength(400);

            this.Property(t => t.Mnemonic)
                .HasMaxLength(10);

            this.Property(t => t.Keywords)
                .HasMaxLength(200);

            this.Property(t => t.TXTKID)
                .IsFixedLength()
                .HasMaxLength(36);

            this.Property(t => t.MutAttributes)
                .HasMaxLength(200);

            this.Property(t => t.MutValues)
                .HasMaxLength(200);

            this.Property(t => t.SaleBackFlag)
                .HasMaxLength(20);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            this.Property(t => t.SyncSM)
                .HasMaxLength(20);

            this.Property(t => t.VExt1)
                .HasMaxLength(50);

            this.Property(t => t.VExt2)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Products");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.SKU).HasColumnName("SKU");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.ProductName2).HasColumnName("ProductName2");
            this.Property(t => t.BaseProductId).HasColumnName("BaseProductId");
            this.Property(t => t.ImageProductId).HasColumnName("ImageProductId");
            this.Property(t => t.Mnemonic).HasColumnName("Mnemonic");
            this.Property(t => t.Keywords).HasColumnName("Keywords");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.TXTKID).HasColumnName("TXTKID");
            this.Property(t => t.MutAttributes).HasColumnName("MutAttributes");
            this.Property(t => t.MutValues).HasColumnName("MutValues");
            this.Property(t => t.SaleBackFlag).HasColumnName("SaleBackFlag");
            this.Property(t => t.BackDays).HasColumnName("BackDays");
            this.Property(t => t.Volume).HasColumnName("Volume");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
            this.Property(t => t.SyncFale).HasColumnName("SyncFale");
            this.Property(t => t.SyncSM).HasColumnName("SyncSM");
            this.Property(t => t.VExt1).HasColumnName("VExt1");
            this.Property(t => t.VExt2).HasColumnName("VExt2");
        }
    }
}
