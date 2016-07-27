/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/24 16:02:03
 * *******************************************************/
using Frxs.ServiceCenter.Data.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frxs.ServiceCenter.Api.Core.AccessRecorder.Mapping
{
    /// <summary>
    /// 访问日志映射
    /// </summary>
    public class ResponseMap : EntityTypeConfigurationMapBase<Domain.Response>
    {
        /// <summary>
        /// 
        /// </summary>
        public ResponseMap()
        {
            this.ToTable("ResponseDatas");
            this.HasKey(p => p.Id);
            this.Property(p => p.RequestData);
            this.Property(p => p.Id).HasDatabaseGeneratedOption(databaseGeneratedOption: DatabaseGeneratedOption.None);
        }
    }
}
