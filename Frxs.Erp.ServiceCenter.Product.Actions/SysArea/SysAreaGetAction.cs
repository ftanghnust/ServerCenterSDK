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
    /// 获取系统地区表信息
    /// </summary>
    [ActionName("SysArea.Get")]
    class SysAreaGetAction : ActionBase<SysAreaGetAction.SysAreaGetActionRequestDto, IList<SysArea>>
    {

        /// <summary>
        /// 上送的参数对象
        /// 可按照 地区ID、父级ID、区域级别 查询
        /// 不传参数则获取所有地区信息
        /// </summary>
        public class SysAreaGetActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {

            /// <summary>
            /// 地区ID
            /// </summary>
            public int? AreaID { get; set; }

            /// <summary>
            /// 父级ID
            /// </summary>
            public int? ParentID { get; set; }

            /// <summary>
            /// 区域级别(0:全国;1:省;2:市;3:区)
            /// </summary>
            public int? Level { get; set; }

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
        public class SysAreaGetActionResponseDto
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
            if (RequestDto.AreaID.HasValue)
            {
                query.AreaID = RequestDto.AreaID;
            }
            else if (RequestDto.ParentID.HasValue)
            {
                query.ParentID = RequestDto.ParentID;
            }
            else if(RequestDto.Level.HasValue)
            {
                query.Level = RequestDto.Level;
            }
            list = SysAreaBLO.GetList(query);
            return SuccessActionResult(list);
        }
    }
}
