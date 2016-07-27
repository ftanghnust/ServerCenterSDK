using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class SaleOrderPreMap : EntityTypeConfiguration<SaleOrderPre>
    {
        public SaleOrderPreMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderId);

            // Properties
            this.Property(t => t.OrderId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SettleID)
                .HasMaxLength(36);

            this.Property(t => t.WCode)
                .HasMaxLength(32);

            this.Property(t => t.WName)
                .HasMaxLength(50);

            this.Property(t => t.SubWCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.SubWName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShopCode)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ShopName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ProvinceName)
                .HasMaxLength(100);

            this.Property(t => t.CityName)
                .HasMaxLength(100);

            this.Property(t => t.RegionName)
                .HasMaxLength(100);

            this.Property(t => t.Address)
                .HasMaxLength(100);

            this.Property(t => t.FullAddress)
                .HasMaxLength(200);

            this.Property(t => t.RevLinkMan)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.RevTelephone)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.LineName)
                .HasMaxLength(50);

            this.Property(t => t.PackingEmpName)
                .HasMaxLength(32);

            this.Property(t => t.PrintUserName)
                .HasMaxLength(32);

            this.Property(t => t.ShippingUserName)
                .HasMaxLength(32);

            this.Property(t => t.CloseReason)
                .HasMaxLength(200);

            this.Property(t => t.Remark)
                .HasMaxLength(400);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SaleOrderPre");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.SettleID).HasColumnName("SettleID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.SubWID).HasColumnName("SubWID");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            this.Property(t => t.OrderType).HasColumnName("OrderType");
            this.Property(t => t.WCode).HasColumnName("WCode");
            this.Property(t => t.WName).HasColumnName("WName");
            this.Property(t => t.SubWCode).HasColumnName("SubWCode");
            this.Property(t => t.SubWName).HasColumnName("SubWName");
            this.Property(t => t.ShopID).HasColumnName("ShopID");
            this.Property(t => t.XSUserID).HasColumnName("XSUserID");
            this.Property(t => t.ShopType).HasColumnName("ShopType");
            this.Property(t => t.ShopCode).HasColumnName("ShopCode");
            this.Property(t => t.ShopName).HasColumnName("ShopName");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.ProvinceID).HasColumnName("ProvinceID");
            this.Property(t => t.CityID).HasColumnName("CityID");
            this.Property(t => t.RegionID).HasColumnName("RegionID");
            this.Property(t => t.ProvinceName).HasColumnName("ProvinceName");
            this.Property(t => t.CityName).HasColumnName("CityName");
            this.Property(t => t.RegionName).HasColumnName("RegionName");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.FullAddress).HasColumnName("FullAddress");
            this.Property(t => t.RevLinkMan).HasColumnName("RevLinkMan");
            this.Property(t => t.RevTelephone).HasColumnName("RevTelephone");
            this.Property(t => t.ConfDate).HasColumnName("ConfDate");
            this.Property(t => t.SendDate).HasColumnName("SendDate");
            this.Property(t => t.LineID).HasColumnName("LineID");
            this.Property(t => t.LineName).HasColumnName("LineName");
            this.Property(t => t.StationNumber).HasColumnName("StationNumber");
            this.Property(t => t.PickingBeginDate).HasColumnName("PickingBeginDate");
            this.Property(t => t.PickingEndDate).HasColumnName("PickingEndDate");
            this.Property(t => t.StockOutRate).HasColumnName("StockOutRate");
            this.Property(t => t.PackingEmpID).HasColumnName("PackingEmpID");
            this.Property(t => t.PackingEmpName).HasColumnName("PackingEmpName");
            this.Property(t => t.PackingTime).HasColumnName("PackingTime");
            this.Property(t => t.IsPrinted).HasColumnName("IsPrinted");
            this.Property(t => t.PrintDate).HasColumnName("PrintDate");
            this.Property(t => t.PrintUserID).HasColumnName("PrintUserID");
            this.Property(t => t.PrintUserName).HasColumnName("PrintUserName");
            this.Property(t => t.ShippingBeginDate).HasColumnName("ShippingBeginDate");
            this.Property(t => t.ShippingUserID).HasColumnName("ShippingUserID");
            this.Property(t => t.ShippingUserName).HasColumnName("ShippingUserName");
            this.Property(t => t.ShippingEndDate).HasColumnName("ShippingEndDate");
            this.Property(t => t.FinishDate).HasColumnName("FinishDate");
            this.Property(t => t.CancelDate).HasColumnName("CancelDate");
            this.Property(t => t.CloseDate).HasColumnName("CloseDate");
            this.Property(t => t.CloseReason).HasColumnName("CloseReason");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.TotalProductAmt).HasColumnName("TotalProductAmt");
            this.Property(t => t.CouponAmt).HasColumnName("CouponAmt");
            this.Property(t => t.TotalAddAmt).HasColumnName("TotalAddAmt");
            this.Property(t => t.PayAmount).HasColumnName("PayAmount");
            this.Property(t => t.TotalPoint).HasColumnName("TotalPoint");
            this.Property(t => t.TotalBasePoint).HasColumnName("TotalBasePoint");
            this.Property(t => t.UserShowFlag).HasColumnName("UserShowFlag");
            this.Property(t => t.ClientType).HasColumnName("ClientType");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
