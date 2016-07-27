using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/2 9:25:13
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 仓库商品状态修改；成功后返回的data数据值为商品仓库ID编号WProductID
    /// 此接口集合了：0:已移除1:正常;2:淘汰;3:冻结;功能
    /// 成功后，返回操作成功的商品数量，客户端可以根据提交的商品ID数和返回的成功数比较来确定弹出消息框
    /// </summary>
    [ActionName("WProducts.Status.Update")]
    public class WProductsStatusUpdateAction : ActionBase<WProductsStatusUpdateAction.WProductsStatusUpdateActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsStatusUpdateActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 仓库ID
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 商品ID集合
            /// </summary>
            [Required]
            public List<int> ProductIds { get; set; }

            /// <summary>
            /// 需要改变的仓库商品状态：仓库商品状态(0:已移除1:正常;2:淘汰;3:冻结;) ;淘汰商品和冻结商品不能销售;加入或重新加入时为正常；移除后再加入时为正常
            /// </summary>
            [In(0, 1, 2, 3)]
            public int Status { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            //采购记录数
            int successed = 0;

            IWProductsDAO iWProducts = DALFactory.GetLazyInstance<IWProductsDAO>();

            //循环操作
            foreach (var item in this.RequestDto.ProductIds)
            {
                try
                {
                    //仓库商品信息
                    var wproduct = iWProducts.GetModel(new Dictionary<string, object>()
                        .Append("WID", this.RequestDto.WID)
                        .Append("ProductId", item));

                    //商品不存在
                    if (wproduct.IsNull())
                    {
                        continue;
                    }

                    //修改状态
                    wproduct.WStatus = this.RequestDto.Status;
                    iWProducts.Edit(wproduct);

                    //成功数+1
                    successed++;
                }
                catch
                {
                    // ignored
                }
            }

            //成功
            return this.SuccessActionResult(successed);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            //删除匹配到的缓存键
            this.CacheManager.RemoveByPattern(WProductsCacheKey.FRXS_WPRODUCTS_PATTERN_KEY);
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
