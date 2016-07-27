using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class WarehouseEmpMap : EntityTypeConfiguration<WarehouseEmp>
    {
        public WarehouseEmpMap()
        {
            // Primary Key
            this.HasKey(t => t.EmpID);

            // Properties
            this.Property(t => t.EmpName)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.UserAccount)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.UserMobile)
                .HasMaxLength(20);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.PasswordSalt)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.CreateUserName)
                .HasMaxLength(64);

            this.Property(t => t.ModifyUserName)
                .HasMaxLength(64);

            // Table & Column Mappings
            this.ToTable("WarehouseEmp");
            this.Property(t => t.EmpID).HasColumnName("EmpID");
            this.Property(t => t.EmpName).HasColumnName("EmpName");
            this.Property(t => t.UserAccount).HasColumnName("UserAccount");
            this.Property(t => t.UserType).HasColumnName("UserType");
            this.Property(t => t.IsMaster).HasColumnName("IsMaster");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.UserMobile).HasColumnName("UserMobile");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.PasswordSalt).HasColumnName("PasswordSalt");
            this.Property(t => t.IsFrozen).HasColumnName("IsFrozen");
            this.Property(t => t.IsLocked).HasColumnName("IsLocked");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.LastLoginTime).HasColumnName("LastLoginTime");
            this.Property(t => t.LastPasswordChangeTime).HasColumnName("LastPasswordChangeTime");
            this.Property(t => t.FailedPasswordCount).HasColumnName("FailedPasswordCount");
            this.Property(t => t.FailedPasswordLockTime).HasColumnName("FailedPasswordLockTime");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ModifyUserID).HasColumnName("ModifyUserID");
            this.Property(t => t.ModifyUserName).HasColumnName("ModifyUserName");
        }
    }
}
