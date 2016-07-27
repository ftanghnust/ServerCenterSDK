using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    public class SaleEditModelRequestDto : RequestDtoParent
    {
        #region 模型
        /// <summary>
        /// 改单ID
        /// </summary>
        public string EditID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [Required]
        public int WID { get; set; }

        /// <summary>
        /// 仓库编号(Warehouse.WCode)
        /// </summary>
       [Required]
        public string WCode { get; set; }

        /// <summary>
        /// 仓库名称(Warehouse.WName)
        /// </summary>
        public string WName { get; set; }

        /// <summary>
        /// 改单日期(格式:yyyy-MM-dd)
        /// </summary>
        public DateTime EditDate { get; set; }

        /// <summary>
        /// 状态(0:未提交;1:已确认;2:已过帐;)
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime? ConfTime { get; set; }

        /// <summary>
        /// 提交用户ID
        /// </summary>
        public int? ConfUserID { get; set; }

        /// <summary>
        /// 提交用户名称
        /// </summary>
        public string ConfUserName { get; set; }

        /// <summary>
        /// 过帐时间
        /// </summary>
        public DateTime? PostingTime { get; set; }

        /// <summary>
        /// 过帐用户ID
        /// </summary>
        public int? PostingUserID { get; set; }

        /// <summary>
        /// 过帐用户名称
        /// </summary>
        public string PostingUserName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        public int? CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        public int? ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        public string ModifyUserName { get; set; }

        /// <summary>
        /// 子机构ID
        /// </summary>
        public int SubWID { get; set; }

        /// <summary>
        /// 子机构code
        /// </summary>
        public string SubWCode { get; set; }

        /// <summary>
        /// 子机构名
        /// </summary>
        public string SubWName { get; set; }

        #endregion
    }
}
