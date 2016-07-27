using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class StockCheckPlanDetailMap : EntityTypeConfiguration<StockCheckPlanDetail>
    {
        public StockCheckPlanDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PlanID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.BaseInfoCode)
                .HasMaxLength(32);

            this.Property(t => t.BaseInfoName)
                .HasMaxLength(50);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(64);

            // Table & Column Mappings
            this.ToTable("StockCheckPlanDetail");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PlanID).HasColumnName("PlanID");
            this.Property(t => t.BaseInfoID).HasColumnName("BaseInfoID");
            this.Property(t => t.BaseInfoCode).HasColumnName("BaseInfoCode");
            this.Property(t => t.BaseInfoName).HasColumnName("BaseInfoName");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
