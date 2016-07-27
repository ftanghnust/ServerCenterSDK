using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class WarehouseLineMap : EntityTypeConfiguration<WarehouseLine>
    {
        public WarehouseLineMap()
        {
            // Primary Key
            this.HasKey(t => t.LineID);

            // Properties
            this.Property(t => t.LineCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.LineName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(400);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(64);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(64);

            // Table & Column Mappings
            this.ToTable("WarehouseLine");
            this.Property(t => t.LineID).HasColumnName("LineID");
            this.Property(t => t.LineCode).HasColumnName("LineCode");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.LineName).HasColumnName("LineName");
            this.Property(t => t.EmpID).HasColumnName("EmpID");
            this.Property(t => t.SendW1).HasColumnName("SendW1");
            this.Property(t => t.SendW2).HasColumnName("SendW2");
            this.Property(t => t.SendW6).HasColumnName("SendW6");
            this.Property(t => t.SendW5).HasColumnName("SendW5");
            this.Property(t => t.SendW4).HasColumnName("SendW4");
            this.Property(t => t.SendW3).HasColumnName("SendW3");
            this.Property(t => t.SendW7).HasColumnName("SendW7");
            this.Property(t => t.OrderEndTime).HasColumnName("OrderEndTime");
            this.Property(t => t.Distance).HasColumnName("Distance");
            this.Property(t => t.SendNeedTime).HasColumnName("SendNeedTime");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.IsLocked).HasColumnName("IsLocked");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
