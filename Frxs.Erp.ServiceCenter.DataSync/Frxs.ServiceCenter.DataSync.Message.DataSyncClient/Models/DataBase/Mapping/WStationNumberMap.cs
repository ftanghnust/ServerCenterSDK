using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class WStationNumberMap : EntityTypeConfiguration<WStationNumber>
    {
        public WStationNumberMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.OrderID)
                .HasMaxLength(50);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WStationNumber");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.StationNumber).HasColumnName("StationNumber");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.ShopID).HasColumnName("ShopID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.OrderConfDate).HasColumnName("OrderConfDate");
            this.Property(t => t.LineID).HasColumnName("LineID");
            this.Property(t => t.OrderStatus).HasColumnName("OrderStatus");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
