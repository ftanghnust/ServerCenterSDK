/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models.Mapping
{
    public class WProductsBuyEmpMap : EntityTypeConfigurationMapBase<WProductsBuyEmp>
    {
        public WProductsBuyEmpMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CreateUserName)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WProductsBuyEmp");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.WProductID).HasColumnName("WProductID");
            this.Property(t => t.WID).HasColumnName("WID");
            this.Property(t => t.EmpID).HasColumnName("EmpID");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateUserID).HasColumnName("CreateUserID");
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName");
        }
    }
}
