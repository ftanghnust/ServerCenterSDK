using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto
{
    /// <summary>
    /// 请求对象基类，继承自RequestDtoBase。 针对多数据库访问时需要指定仓库ID的需求 增加WarehouseId属性，继承它以后无需反复定义仓库ID属性
    /// </summary>
    public class RequestDtoParent : RequestDtoBase
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 验证仓库编号是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            if (this.WarehouseId <= 0)
            {
                yield return new RequestDtoValidatorResultError("WarehouseId", "仓库编号不正确。");
            }
            base.Valid();
        }
    }
}
