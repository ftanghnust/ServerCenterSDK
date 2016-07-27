using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto
{
    public class SaleEditResponseDto : ResponseDtoBase
    {
        #region 模型
        /// <summary>
        /// 改单ID
        /// </summary>
        public string EditID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 仓库编号(Warehouse.WCode)
        /// </summary>
        public string WCode { get; set; }

        /// <summary>
        /// 仓库名称(Warehouse.WName)
        /// </summary>
        public string WName { get; set; }

        /// <summary>
        /// 仓库子机构ID
        /// </summary>
        public int? SubWID { get; set; }

        /// <summary>
        /// 仓库子机构编号(Warehouse.WCode)
        /// </summary>
        public string SubWCode { get; set; }

        /// <summary>
        /// 仓库子机构名称(Warehouse.WName)
        /// </summary>
        public string SubWName { get; set; }

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
        /// 处理标识(0:未处理;1:已处理;3:中断处理)
        /// </summary>
        public int ProcFlag { get; set; }

        /// <summary>
        /// 处理备注
        /// </summary>
        public string ProcRemark { get; set; }

        /// <summary>
        /// 配送时间
        /// </summary>
        public DateTime SendDate { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        public int OrderCount { get; set; }
        #endregion

    }
}
