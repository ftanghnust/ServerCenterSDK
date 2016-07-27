/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/12/3 19:09:05
 * *******************************************************/
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.Api.Core.AccessRecorder.Mapping
{
    /// <summary>
    /// 接口信息映射
    /// </summary>
    public class ActionDescriptorMap : EntityTypeConfigurationMapBase<Domain.ActionDescriptor>
    {
        /// <summary>
        /// 
        /// </summary>
        public ActionDescriptorMap()
        {
            this.ToTable("ActionDescriptors");
            this.HasKey(p => p.Id);
            this.Property(p => p.ActionName).IsRequired().HasMaxLength(200);
            this.Property(p => p.HttpMethod).HasMaxLength(20);
            this.Property(p => p.Version).HasMaxLength(20);
            this.Property(p => p.Description).HasMaxLength(500);
            this.Property(p => p.AuthorName).HasMaxLength(50);
        }
    }
}
