using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/8 17:31:38
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.ID.Actions
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("Class1")]
    public class Class1 : ActionBase<Class1.Class1RequestDto, Class1.Class1ResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class Class1RequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {

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
        public class Class1ResponseDto
        {

        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ValidRequestDto()
        {
            base.ValidRequestDto();
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Class1ResponseDto> Execute()
        {
            throw new NotImplementedException();
        }

    }
}
