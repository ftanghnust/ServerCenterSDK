/*********************************************************
 * FRXS(ISC) ftanghnust@gmail.com 2016/3/11 9:28:42
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.ID.Model;

namespace Frxs.Erp.ServiceCenter.ID.Actions.RequestDto
{
    public class XSOperatorLogGetListRequestDto : RequestDtoBase
    {
        [Required]
        public int PageIndex { get; set; }

        [Required]
        public int PageSize { get; set; }

        public string SortBy { get; set; }

        /// <summary>
        /// 系统ID
        /// </summary>
        [Required]
        public int WID { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public int? MenuID { get; set; }

        /// <summary>
        /// 动作值
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 搜索开始时间
        /// </summary>
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 搜索结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            if (WID < 0)//经会议讨论，总部BOSS后台的WID约定为0，故允许WID=0
            {
                yield return new RequestDtoValidatorResultError("WID");
            }
        }
    }
}
