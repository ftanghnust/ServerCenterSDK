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
    public class StorageRelationshipMapping : EntityTypeConfigurationMapBase<Entitys.StorageRelationship>
    {
        /// <summary>
        /// 
        /// </summary>
        public StorageRelationshipMapping()
        {
            this.ToTable("StorageRelationship");
            this.HasKey(t => t.WID);
            this.Property(o => o.WID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(t => t.StorageName).HasMaxLength(50);
            this.Property(o => o.LastConsumeMessageId).HasMaxLength(32);
        }
    }
}