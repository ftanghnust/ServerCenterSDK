using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;

namespace Frxs.Erp.ServiceCenter.Product.Actions.Warehouse
{
    /// <summary>
    /// 获取仓库信息详情
    /// </summary>
    [ActionName("Warehouse.Get")]
    public class WarehouseGetAction : ActionBase<RequestDto.WarehouseGetRequestDto, Model.Warehouse>
    {
        
        /// <summary>
        /// 获取仓库信息详情
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Model.Warehouse> Execute()
        {
            var requestDto = this.RequestDto;
            Model.Warehouse mode = WarehouseBLO.GetModel(requestDto.WID);
            return this.SuccessActionResult(mode);
        }
    }

    public class ValidateWSubWRes
    {

    }

    /// <summary>
    /// 增加验证仓库子机构是否合法接口WarehouseSubWarehouse.Validate
    /// </summary>
    [ActionName("WarehouseSubWarehouse.Validate")]
    public class WarehouseSubWarehouseValidateAction : ActionBase<RequestDto.WarehouseSubWarehouseValidateRequestDto, bool>
    {

        /// <summary>
        /// 获取仓库信息详情
        /// </summary>
        /// <returns></returns>
        public override ActionResult<bool> Execute()
        {
            var requestDto = this.RequestDto;
            if (requestDto == null)
            {
                return ErrorActionResult("WarehouseSubWarehouse.Validate方法，传入参数不能为空");          
            }
            if (requestDto.WID <= 0)
            {
                return ErrorActionResult("WarehouseSubWarehouse.Validate方法，WID参数不能为空");          
            }
            if (requestDto.SubWID <= 0)
            {
                return ErrorActionResult("WarehouseSubWarehouse.Validate方法，SubWID参数不能为空");
            }
            IList<Frxs.Erp.ServiceCenter.Product.Model.Warehouse> lissubws = WarehouseBLO.GetWarehouseSubWarehouse(requestDto.WID,requestDto.SubWID);
            if (lissubws == null || lissubws.Count == 0)
            {
                return ErrorActionResult(string.Format("仓库[{0}]下子机构[{1}]不存在",requestDto.WID,requestDto.SubWID));
            }
            if (lissubws.Count>1)
            {
                return ErrorActionResult(string.Format("仓库[{0}]中存在多个相同子机构[{1}]", requestDto.WID, requestDto.SubWID));
            }
            if (lissubws[0].IsDeleted == 1)
            {
                return ErrorActionResult(string.Format("仓库[{0}]中子机构[{1}]已被删除", requestDto.WID, requestDto.SubWID));
            }
            if (lissubws[0].IsFreeze == 1)
            {
                return ErrorActionResult(string.Format("仓库[{0}]中子机构[{1}]已被冻结", requestDto.WID, requestDto.SubWID));
            }
            lissubws = null;
            return this.SuccessActionResult(true);
        }
    }

}
