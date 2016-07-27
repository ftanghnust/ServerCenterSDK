using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/19 9:24:15
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 根据货位信息获取到当前货位有那些仓库商品
    /// </summary>
    [ActionName("WProducts.Get.ByShelfID"), Author("NIck")]
    public class WProductsGetByShelfIDAction : ActionBase<WProductsGetByShelfIDAction.WProductsGetV20ActionRequestDto, List<Model.WProducts>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsGetV20ActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库ID
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 货位ID(如果ShelfID和ShelfCode同时传值了,ShelfID优先)
            /// </summary>
            public int? ShelfID { get; set; }

            /// <summary>
            /// 货位编号
            /// </summary>
            public string ShelfCode { get; set; }

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (!this.ShelfID.HasValue && this.ShelfCode.IsNullOrEmpty())
                {
                    yield return new RequestDtoValidatorResultError("WID和ShelfCode不能同时为空");
                }
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<Model.WProducts>> Execute()
        {

            Model.Shelf shelf = null;

            //获取
            if (this.RequestDto.ShelfID.HasValue)
            {
                shelf = DALFactory.GetLazyInstance<IShelfDAO>().GetModel(this.RequestDto.ShelfID.Value);
            }
            else
            {
                shelf = DALFactory.GetLazyInstance<IShelfDAO>().GetModel(new Dictionary<string, object>().Append("WID", this.RequestDto.WID).Append("ShelfCode", this.RequestDto.ShelfCode));
            }

            if (shelf.IsNull())
            {
                return this.ErrorActionResult("货位不存在");
            }

            //获取仓库商品集合
            var products = DALFactory.GetLazyInstance<IWProductsDAO>().GetList(new Dictionary<string, object>().Append("WID", this.RequestDto.WID).Append("ShelfID", shelf.ShelfID));

            //返回
            return this.SuccessActionResult(products.ToList());
        }
    }
}
