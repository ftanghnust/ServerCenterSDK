/*********************************************************
 * FRXS(ISC) ftanghnust@gmail.com 2016/6/24 16:10:16
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions.SysAppSettings
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("SysAppSettings.Get")]
    public class SysAppSettingsGetAction : ActionBase<SysAppSettingsGetAction.SysAppSettingsGetRequestDto, Model.SysAppSettings>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SysAppSettingsGetRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {

            /// <summary>
            /// 仓库ID
            /// </summary>            
            public int WID { get; set; }


            /// <summary>
            /// 配置唯一标识
            /// </summary>            
            public string SKey { get; set; }


            /// <summary>
            /// 校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }

        }


        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Model.SysAppSettings> Execute()
        {
            var requestDto = this.RequestDto;

            Model.SysAppSettings mode = SysAppSettingsBLO.GetModel(requestDto.WID, requestDto.SKey);

            return new ActionResult<Model.SysAppSettings>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = mode
            };
        }

    }
}
