using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class WProductAdjShelfMap : EntityTypeConfiguration<WProductAdjShelf>
    {
        public WProductAdjShelfMap()
        {
            // Primary Key
            this.HasKey(t => t.AdjID);

            // Properties
            this.Property(t => t.AdjID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ConfUserName)
                .HasMaxLength(32);

            this.Property(t => t.PostingUserName)
                .HasMaxLength(32);

            this.Property(t => t.Remark)
                .HasMaxLength(200);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WProductAdjShelf");
            this.Property(t => t.AdjID).HasColumnName("AdjID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.AdjType).HasColumnName("AdjType");
            this.Property(t => t.ConfTime).HasColumnName("ConfTime");
            this.Property(t => t.ConfUserID).HasColumnName("ConfUserID");
            this.Property(t => t.ConfUserName).HasColumnName("ConfUserName");
            this.Property(t => t.PostingTime).HasColumnName("PostingTime");
            this.Property(t => t.PostingUserID).HasColumnName("PostingUserID");
            this.Property(t => t.PostingUserName).HasColumnName("PostingUserName");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
