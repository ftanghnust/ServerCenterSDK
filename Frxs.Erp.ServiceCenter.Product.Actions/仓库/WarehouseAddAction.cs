using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions.Warehouse
{
    /// <summary>
    /// 新增仓库信息
    /// </summary>
    [ActionName("Warehouse.Save")]
    public class WarehouseSaveAction : ActionBase<RequestDto.WarehouseSaveRequestDto, int>
    {

        /// <summary>
        /// 新增仓库
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;

            requestDto.MapTo<RequestDto.WarehouseSaveRequestDto>();

            Model.Warehouse mode = requestDto.MapTo<Model.Warehouse>();


            if (WarehouseBLO.Exists(mode))
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = "仓库已经存在！"
                };
                //WarehouseBLO.Edit(mode);
            }
            else
            {
                if (WarehouseBLO.ExistsWCode(mode))
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = "仓库编号已经存在！"
                    };
                }
                else if (WarehouseBLO.ExistsWName(mode) && mode.WLevel.HasValue && mode.WLevel.Value == 1)
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = "仓库名称已经存在！"
                    };
                }
                else
                {
                    WarehouseBLO.Save(mode);
                }
            }
            return new ActionResult<int>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK"
            };
        }
    }
}
