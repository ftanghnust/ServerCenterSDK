/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models.Mapping
{
    public class VendorMap : EntityTypeConfigurationMapBase<Vendor>
    {
        public VendorMap()
        {
            // Primary Key
            this.HasKey(t => t.VendorID);

            // Properties
            this.Property(t => t.VendorCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.VendorName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.VendorShortName)
                .HasMaxLength(20);

            this.Property(t => t.LinkMan)
                .HasMaxLength(20);

            this.Property(t => t.Telephone)
                .HasMaxLength(20);

            this.Property(t => t.Fax)
                .HasMaxLength(20);

            this.Property(t => t.LegalPerson)
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .HasMaxLength(200);

            this.Property(t => t.WebUrl)
                .HasMaxLength(200);

            this.Property(t => t.Region)
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

            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(32);

            this.Property(t => t.PaymentDateType)
                .HasMaxLength(32);

            this.Property(t => t.SyncSM)
                .HasMaxLength(20);

            this.Property(t => t.VExt1)
                .HasMaxLength(50);

            this.Property(t => t.VExt2)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Vendor");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.VendorCode).HasColumnName("VendorCode");
            this.Property(t => t.VendorName).HasColumnName("VendorName");
            this.Property(t => t.VendorShortName).HasColumnName("VendorShortName");
            this.Property(t => t.VendorTypeID).HasColumnName("VendorTypeID");
            this.Property(t => t.LinkMan).HasColumnName("LinkMan");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.LegalPerson).HasColumnName("LegalPerson");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.WebUrl).HasColumnName("WebUrl");
            this.Property(t => t.Region).HasColumnName("Region");
            this.Property(t => t.SettleTimeType).HasColumnName("SettleTimeType");
            this.Property(t => t.CreditLevel).HasColumnName("CreditLevel");
            this.Property(t => t.AreaPrincipal).HasColumnName("AreaPrincipal");
            this.Property(t => t.ProvinceID).HasColumnName("ProvinceID");
            this.Property(t => t.CityID).HasColumnName("CityID");
            this.Property(t => t.RegionID).HasColumnName("RegionID");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.FullAddress).HasColumnName("FullAddress");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
            this.Property(t => t.PaymentDateType).HasColumnName("PaymentDateType");
            this.Property(t => t.SyncFale).HasColumnName("SyncFale");
            this.Property(t => t.SyncSM).HasColumnName("SyncSM");
            this.Property(t => t.VExt1).HasColumnName("VExt1");
            this.Property(t => t.VExt2).HasColumnName("VExt2");
        }
    }
}
