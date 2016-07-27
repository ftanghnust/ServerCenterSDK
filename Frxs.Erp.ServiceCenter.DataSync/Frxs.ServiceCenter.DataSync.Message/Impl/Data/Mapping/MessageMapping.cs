/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 6:22:37 PM
 * *******************************************************/
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl.Data.Mapping
{
    /// <summary>
    /// 数据实体与数据库映射
    /// </summary>
    public class MessageMapping : EntityTypeConfigurationMapBase<Entitys.Message>
    {
        /// <summary>
        /// 
        /// </summary>
        public MessageMapping()
        {
            this.ToTable("Message");
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasMaxLength(50);
            this.Property(t => t.Topic).HasMaxLength(50).IsRequired();
            this.Property(t => t.Body).HasMaxLength(500);
        }
    }
}