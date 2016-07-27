using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/18 19:52:33
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Frxs.Erp.ServiceCenter.Product.Model;
using System.Threading.Tasks;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 根据网仓WCode获取到仓库ID信息，供单点登录转化使用
    /// </summary>
    [ActionName("Warehouse.Get.ForSSO")]
    public class WarehouseGetForSSOAction : ActionBase<WarehouseGetForSSOAction.WarehouseGetActionRequestDto, WarehouseGetForSSOAction.WarehouseGetActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WarehouseGetActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号，如果上送的子机构，那么返回父机构和本身；如果上送的是父机构，返回的父机构和子机构都是本身
            /// </summary>
            [Required, StringLength(50)]
            public string WCode { get; set; }

            /// <summary>
            /// 自定义校验上送参数是否正确
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
        public class WarehouseGetActionResponseDto
        {
            /// <summary>
            /// 父机构，注意：如果上送的WCode对应的仓库是根节点，那么父机构就是自己本身
            /// </summary>
            public Model.Warehouse Parent { get; set; }

            /// <summary>
            /// 当前仓库信息
            /// </summary>
            public Model.Warehouse Current { get; set; }

            /// <summary>
            /// 对应父机构下属的子机构集合
            /// </summary>
            public List<Model.Warehouse> ParentSubWarehouses { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<WarehouseGetActionResponseDto> Execute()
        {
            //当前仓库信息
            IWarehouseDAO iWarehouse = DALFactory.GetLazyInstance<IWarehouseDAO>();
            var warehouse = iWarehouse.GetModel(new Dictionary<string, object>().Append("WCode", this.RequestDto.WCode));
            if (warehouse.IsNull())
            {
                return this.ErrorActionResult("仓库编号 {0} 不存在".With(this.RequestDto.WCode));
            }

            //直接是父节点的直接返回
            if (warehouse.ParentWID == 0)
            {
                return this.SuccessActionResult(new WarehouseGetActionResponseDto()
                {
                    Current = warehouse,
                    Parent = warehouse,
                    ParentSubWarehouses =
                        iWarehouse.GetList(new Dictionary<string, object>().Append("ParentWID", warehouse.WID))
                            .Where(o => o.IsDeleted == 0)
                            .ToList()
                });
            }

            //是仓库机构
            var parent = iWarehouse.GetModel(warehouse.ParentWID.Value);
            if (parent.IsNull())
            {
                this.ErrorActionResult("仓库{0}对应的父仓库不存在".With(this.RequestDto.WCode));
            }

            //返回
            return this.SuccessActionResult(new WarehouseGetActionResponseDto()
            {
                Current = warehouse,
                Parent = parent,
                ParentSubWarehouses =
                    iWarehouse.GetList(new Dictionary<string, object>().Append("ParentWID", parent.WID))
                        .Where(o => o.IsDeleted == 0)
                        .ToList()
            });
        }
    }
}
