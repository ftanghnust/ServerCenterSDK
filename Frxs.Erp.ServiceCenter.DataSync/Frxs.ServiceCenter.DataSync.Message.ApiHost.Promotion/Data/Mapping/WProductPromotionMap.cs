/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Promotion.Models.Mapping
{
    public class WProductPromotionMap : EntityTypeConfigurationMapBase<WProductPromotion>
    {
        public WProductPromotionMap()
        {
            // Primary Key
            this.HasKey(t => t.PromotionID);

            // Properties
            this.Property(t => t.PromotionID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.WCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.WName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PromotionName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ConfUserName)
                .HasMaxLength(64);

            this.Property(t => t.PostingUserName)
                .HasMaxLength(64);

            this.Property(t => t.Remark)
                .HasMaxLength(200);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WProductPromotion");
            this.Property(t => t.PromotionID).HasColumnName("PromotionID");
            this.Property(t => t.PromotionType).HasColumnName("PromotionType");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.WCode).HasColumnName("WCode");
            this.Property(t => t.WName).HasColumnName("WName");
            this.Property(t => t.PromotionName).HasColumnName("PromotionName");
            this.Property(t => t.BeginTime).HasColumnName("BeginTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.Status).HasColumnName("Status");
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
