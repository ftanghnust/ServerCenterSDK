/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/9 14:30:46
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
    public class WarehouseMap : EntityTypeConfigurationMapBase<Domain.Warehouse>
    {
        /// <summary>
        /// 
        /// </summary>
        public WarehouseMap()
        {
            this.ToTable("Warehouses");
            this.HasKey(t => t.WHID);
            this.Property(t => t.WHID).HasMaxLength(50);
            this.Property(t => t.WHName).HasMaxLength(100);
        }
    }
}