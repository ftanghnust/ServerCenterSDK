/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Promotion.Models.Mapping
{
    public class WarehouseMessageMap : EntityTypeConfigurationMapBase<WarehouseMessage>
    {
        public WarehouseMessageMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Message)
                .IsRequired();

            this.Property(t => t.ConfUserName)
                .HasMaxLength(32);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModityUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WarehouseMessage");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.MessageType).HasColumnName("MessageType");
            this.Property(t => t.RangType).HasColumnName("RangType");
            this.Property(t => t.BeginTime).HasColumnName("BeginTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.ConfTime).HasColumnName("ConfTime");
            this.Property(t => t.ConfUserID).HasColumnName("ConfUserID");
            this.Property(t => t.ConfUserName).HasColumnName("ConfUserName");
            this.Property(t => t.IsFirst).HasColumnName("IsFirst");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModityTime).HasColumnName("ModityTime");
            this.Property(t => t.ModityUserID).HasColumnName("ModityUserID");
            this.Property(t => t.ModityUserName).HasColumnName("ModityUserName");
        }
    }
}
