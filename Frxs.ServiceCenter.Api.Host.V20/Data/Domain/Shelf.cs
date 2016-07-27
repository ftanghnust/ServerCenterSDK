/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/9 13:54:58
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.Api.Host.Data.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class Shelf : BaseEntity
    {
        /// <summary>
        /// ID(主键)
        /// </summary>
        public int ShelfID { get; set; }

        /// <summary>
        /// 货位编号(同一个仓库不能重复)
        /// </summary>
        public string ShelfCode { get; set; }

        /// <summary>
        /// 所属货区ID(ShelfArea.ShelfAreaID)
        /// </summary>
        public int ShelfAreaID { get; set; }

        /// <summary>
        /// 货位类型(0:存储;1:)
        /// </summary>
        public string ShelfType { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 状态(0:正常;1:冻结)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 最新修改删除时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改删除用户ID
        /// </summary>
        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改删除用户名称
        /// </summary>
        public string ModifyUserName { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WName { get; set; }

        /// <summary>
        /// 货区
        /// </summary>
        public string ShelfAreaName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string StatusStr { get; set; }
    }
}