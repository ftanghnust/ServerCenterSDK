/*********************************************************
 * FRXS(ISC) ftanghnust@gmail.com 2016/4/28 9:44:40
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.ID.Model;
using Frxs.Erp.ServiceCenter.ID.BLL;

namespace Frxs.Erp.ServiceCenter.ID.Actions
{
    /// <summary>
    /// 操作日志写方法
    /// </summary>
    [ActionName("XSOperatorLog.Write")]
    public class XSOperatorLogWrite : ActionBase<XSOperatorLogWrite.XSOperatorLogWriteRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class XSOperatorLogWriteRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
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
            [Required]
            public XSOperatorLog.MenuIDEnum MenuID { get; set; }

            /// <summary>
            /// 动作值
            /// </summary>
            [Required]
            public string Action { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            [Required]
            public string Remark { get; set; }

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

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            XSOperatorLog log = requestDto.MapTo<XSOperatorLog>();
            log.CreateTime = DateTime.Now;
            log.OperatorID = requestDto.UserId;
            log.OperatorName = requestDto.UserName;

            var result = XSOperatorLogBLO.Save(log);
            if (result.IsSuccess)
            {
                return this.SuccessActionResult();
            }
            else
            {
                return this.ErrorActionResult(result.Message);
            }
        }
    }
}
