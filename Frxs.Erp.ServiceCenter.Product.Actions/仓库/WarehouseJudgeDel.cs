/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/30 20:21:13
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 判断一个仓库是否可以被删除 
    /// true 表示可以删除 false 表示不可以
    /// </summary>
    [ActionName("Warehouse.JudgeDel")]
    public class WarehouseJudgeDel : ActionBase<WarehouseJudgeDel.WarehouseJudgeDelRequestDto, bool>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WarehouseJudgeDelRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            ///  仓库ID(从1000开始编号)
            /// </summary>
            public int WID { get; set; }
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
        public class WarehouseJudgeDelResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<bool> Execute()
        {
            bool can = true;

            return this.SuccessActionResult(can);
        }

    }
}
