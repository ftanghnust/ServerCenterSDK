/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/9 13:56:58
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.Api.Host.Data.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class ShelfMap : EntityTypeConfigurationMapBase<Domain.Shelf>
    {
        /// <summary>
        /// 
        /// </summary>
        public ShelfMap()
        {
            this.ToTable("Shelf");
            this.HasKey(t => t.ShelfID);
            this.Property(t => t.ShelfCode).HasMaxLength(50);
            this.Property(t => t.ShelfType).HasMaxLength(50);
            this.Property(t => t.WName).HasMaxLength(200);
        }
    }
}