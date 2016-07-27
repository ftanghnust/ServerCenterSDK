/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/29 21:04:18
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions.仓库
{
    /// <summary>
    /// 根据 WID或者Wcode 判断仓库是否已经存在
    /// true表示存在 false表示不存在
    /// </summary>
    [ActionName("Warehouse.Exists")]
    public class WarehouseExistsAction : ActionBase<WarehouseExistsAction.WarehouseExistsActionRequestDto, bool>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WarehouseExistsActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            ///  仓库ID(从1000开始编号)
            /// </summary>
            public int? WID { get; set; }

            /// <summary>
            /// 仓库编号(唯一)
            /// </summary>
            public string WCode { get; set; }

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
        /// 下送的数据
        /// </summary>
        public class WarehouseExistsActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<bool> Execute()
        {
            bool ExistWid = false;
            bool ExistCode = false;
            bool Exist = false;
            var requestDto = this.RequestDto;

            Model.Warehouse model = new Model.Warehouse();

            if (!string.IsNullOrEmpty(requestDto.WCode))
            {
                model.WCode = requestDto.WCode.Trim();
                model.WID = (requestDto.WID.HasValue) ? requestDto.WID.Value : 0;
                ExistCode = WarehouseBLO.ExistsWCode(model);
            }
            else
            {
                if (requestDto.WID.HasValue)
                {
                    model.WID = requestDto.WID.Value;
                    ExistWid = WarehouseBLO.Exists(model);
                }
            }
            Exist = (ExistWid == true || ExistCode == true);
            return this.SuccessActionResult(Exist);
        }
    }
}
