/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models.Mapping
{
    public class ShopMap : EntityTypeConfigurationMapBase<Shop>
    {
        public ShopMap()
        {
            // Primary Key
            this.HasKey(t => t.ShopID);

            // Properties
            this.Property(t => t.ShopCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ShopName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShopAccount)
                .HasMaxLength(32);

            this.Property(t => t.SettleType)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.LinkMan)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Telephone)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.LegalPerson)
                .HasMaxLength(20);

            this.Property(t => t.SettleTimeType)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.CreditLevel)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.AreaPrincipal)
                .HasMaxLength(20);

            this.Property(t => t.Address)
                .HasMaxLength(100);

            this.Property(t => t.FullAddress)
                .HasMaxLength(200);

            this.Property(t => t.Latitude)
                .HasMaxLength(20);

            this.Property(t => t.Longitude)
                .HasMaxLength(20);

            this.Property(t => t.BankAccount)
                .HasMaxLength(50);

            this.Property(t => t.BankAccountName)
                .HasMaxLength(100);

            this.Property(t => t.BankType)
                .HasMaxLength(200);

            this.Property(t => t.CardID)
                .HasMaxLength(32);

            this.Property(t => t.RegionMaster)
                .HasMaxLength(50);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(64);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(64);

            // Table & Column Mappings
            this.ToTable("Shop");
            this.Property(t => t.ShopID).HasColumnName("ShopID");
            this.Property(t => t.ShopCode).HasColumnName("ShopCode");
            this.Property(t => t.ShopType).HasColumnName("ShopType");
            this.Property(t => t.ShopName).HasColumnName("ShopName");
            this.Property(t => t.ShopAccount).HasColumnName("ShopAccount");
            this.Property(t => t.SettleType).HasColumnName("SettleType");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.LinkMan).HasColumnName("LinkMan");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.LegalPerson).HasColumnName("LegalPerson");
            this.Property(t => t.SettleTimeType).HasColumnName("SettleTimeType");
            this.Property(t => t.CreditLevel).HasColumnName("CreditLevel");
            this.Property(t => t.CreditAmt).HasColumnName("CreditAmt");
            this.Property(t => t.AreaPrincipal).HasColumnName("AreaPrincipal");
            this.Property(t => t.ProvinceID).HasColumnName("ProvinceID");
            this.Property(t => t.CityID).HasColumnName("CityID");
            this.Property(t => t.RegionID).HasColumnName("RegionID");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.FullAddress).HasColumnName("FullAddress");
            this.Property(t => t.ShopArea).HasColumnName("ShopArea");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.Latitude).HasColumnName("Latitude");
            this.Property(t => t.Longitude).HasColumnName("Longitude");
            this.Property(t => t.TotalPoint).HasColumnName("TotalPoint");
            this.Property(t => t.BankAccount).HasColumnName("BankAccount");
            this.Property(t => t.BankAccountName).HasColumnName("BankAccountName");
            this.Property(t => t.BankType).HasColumnName("BankType");
            this.Property(t => t.CardID).HasColumnName("CardID");
            this.Property(t => t.RegionMaster).HasColumnName("RegionMaster");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
            this.Property(t => t.SyncFale).HasColumnName("SyncFale");
        }
    }
}
