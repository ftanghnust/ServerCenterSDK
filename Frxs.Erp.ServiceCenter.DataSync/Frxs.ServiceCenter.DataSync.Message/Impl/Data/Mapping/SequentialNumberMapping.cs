/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 6:22:37 PM
 * *******************************************************/
using Frxs.ServiceCenter.Data.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl.Data.Mapping
{
    /// <summary>
    /// 数据实体与数据库映射
    /// </summary>
    public class SequentialNumberMapping : EntityTypeConfigurationMapBase<Entitys.SequentialNumber>
    {
        /// <summary>
        /// 
        /// </summary>
        public SequentialNumberMapping()
        {
            this.ToTable("SequentialNumber");
            this.HasKey(o => new { o.Year, o.Month, o.Day });
            this.Property(o => o.MaxIdentity);
        }
    }
}