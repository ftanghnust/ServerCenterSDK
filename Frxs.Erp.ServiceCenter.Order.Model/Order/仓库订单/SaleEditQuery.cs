using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model
{
    public class SaleEditQuery
    {
        #region 模型
        /// <summary>
        /// 改单ID
        /// </summary>
        public string EditID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        public int? WID { get; set; }

        /// <summary>
        /// 仓库编号(Warehouse.WCode)
        /// </summary>
        public string WCode { get; set; }

        /// <summary>
        /// 子机构ID
        /// </summary>
        public int? SubWID { get; set; }

        /// <summary>
        /// 子机构name
        /// </summary>
        public string SubWName { get; set; }
        
        /// <summary>
        /// 改单日期(格式:yyyy-MM-dd)
        /// </summary>
        public DateTime? CreateTimeBegin { get; set; }


        /// <summary>
        /// 改单日期(格式:yyyy-MM-dd)
        /// </summary>
        public DateTime? CreateTimeEnd { get; set; }


        /// <summary>
        /// 状态(0:未提交;1:已确认;2:已过帐;)
        /// </summary>
        public int? Status { get; set; }
        
        /// <summary>
        /// 提交用户ID
        /// </summary>
        public int? CreateUserId { get; set; }

        /// <summary>
        /// 提交用户名称
        /// </summary>
        public string CreateUserName { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }


        #endregion

        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public string SortBy { get; set; }

    }
}
