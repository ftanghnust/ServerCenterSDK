using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 根据ID集合获取系统地区表信息
    /// </summary>
    [ActionName("SysArea.GetByIDs")]
    class SysAreaGetByIDsAction : ActionBase<SysAreaGetByIDsAction.SysAreaGetByIDsActionRequestDto, IList<SysArea>>
    {

        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SysAreaGetByIDsActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 区域ID集合
            /// </summary>
            public List<int> Ids { get; set; }

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
        public class SysAreaGetByIDsActionResponseDto
        {

        }


        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<SysArea>> Execute()
        {
            IList<SysArea> list = new List<SysArea>();
            SysAreaQuery query = new SysAreaQuery();
            if (RequestDto.Ids.Count>0)
            {
                list = SysAreaBLO.GetListByIDs(RequestDto.Ids);
            }
            return SuccessActionResult(list);
        }
    }
}
