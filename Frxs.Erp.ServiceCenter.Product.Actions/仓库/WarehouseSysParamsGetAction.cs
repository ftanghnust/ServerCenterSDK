using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/23 14:50:31
 * *******************************************************/
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// (复合接口)获取对应仓库系统设置列表信息；注意此接口有个业务逻辑；即：如果仓库未设置对应的参数获取到的将会是系统全局设置的
    /// </summary>
    [ActionName("Warehouse.SysParams.Get"), ActionResultCache("Frxs.SysParams")]
    public class WarehouseSysParamsGetAction : ActionBase<WarehouseSysParamsGetAction.WarehouseSysParamsGetActionRequestDto, List<SysParams>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WarehouseSysParamsGetActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号，必须传入
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 可以为空，业务设置参数编码；如果此参数编码未指定值，系统将查询出仓库所有的业务配置，如果指定了将返回单个参数配置
            /// </summary>
            [StringLength(32)]
            public string ParamCode { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<SysParams>> Execute()
        {
            var model = DALFactory.GetLazyInstance<ISysParamsWHDAO>()
                .GetWHSysParams(this.RequestDto.WID, this.RequestDto.ParamCode)
                .ToList();
            return this.SuccessActionResult(model);
        }
    }
}
