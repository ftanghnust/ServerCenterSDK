/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/29 14:43:06
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Frxs.Platform.IOCFactory;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 仓库商品价格调整表【过账】操作；操作成功后返回成功的过账条数
    /// </summary>
    [ActionName("WProduct.AdjustPrice.Posting")]
    public class WProductAdjPricePostingAction : ActionBase<WProductAdjPricePostingAction.WProductAdjPricePostingActionRequestDto, int?>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductAdjPricePostingActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 调整单单据编号集合
            /// </summary>
            [Required]
            public List<int> AdjIds { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public string GetStatusDescription(int status)
        {
            switch (status)
            {
                case 0:
                    return "未提交";
                case 1:
                    return "已确认";
                case 2:
                    return "已过账";
                default:
                    return "未知状态";
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int?> Execute()
        {
            //过账成功数
            int success = 0;

            //消息详细
            List<string> errmessage = new List<string>();

            //调价单
            var wproductAdjPriceDao = DALFactory.GetLazyInstance<IWProductAdjPriceDAO>();
            var wproductAdjPriceDetailsDao = DALFactory.GetLazyInstance<IWProductAdjPriceDetailsDAO>();
            var wproductsDao = DALFactory.GetLazyInstance<IWProductsDAO>();
            var wproductsBuyDao = DALFactory.GetLazyInstance<IWProductsBuyDAO>();

            //循环过账
            foreach (var item in this.RequestDto.AdjIds.OrderBy(id => id))
            {
                //调价单详情
                var wproductAdjPrice = wproductAdjPriceDao.GetModel(item);

                //调价单不存在
                if (wproductAdjPrice.IsNull())
                {
                    continue;
                }

                //调价单明细
                var wproductAdjPriceDetails = wproductAdjPriceDetailsDao.GetList(new Dictionary<string, object>().Append("AdjID", item));
                if (wproductAdjPriceDetails.IsNull() || wproductAdjPriceDetails.IsEmpty())
                {
                    continue;
                }

                //未处于已确认状态
                if (wproductAdjPrice.Status != 1)
                {
                    errmessage.Add("调价单:{0}状态已修改，当前状态为：{1}，请在单据列表中刷新查看新的单据状态".With(item, GetStatusDescription(wproductAdjPrice.Status)));
                    continue;
                }

                //已过账
                wproductAdjPrice.PostingTime = DateTime.Now;
                wproductAdjPrice.PostingUserID = this.RequestDto.UserId;
                wproductAdjPrice.PostingUserName = this.RequestDto.UserName;
                wproductAdjPrice.Status = 2;
                wproductAdjPriceDao.Edit(wproductAdjPrice);

                //成功数+1；
                success++;

                //调价单类型
                switch (wproductAdjPrice.AdjType)
                {
                    case 0://采购进货价

                        foreach (var x in wproductAdjPriceDetails)
                        {
                            var buy = wproductsBuyDao.GetModel(x.WProductID);
                            buy.BuyPrice = x.Price.Value;
                            wproductsBuyDao.Edit(buy);
                        }
                        break;

                    case 1: //配送价

                        foreach (var x in wproductAdjPriceDetails)
                        {
                            var wp = wproductsDao.GetModel(x.WProductID);
                            wp.SalePrice = x.Price;
                            wproductsDao.Edit(wp);
                        }

                        break;

                    case 2: // 平台费率

                        foreach (var x in wproductAdjPriceDetails)
                        {
                            var wp = wproductsDao.GetModel(x.WProductID);
                            wp.ShopPoint = (decimal)x.ShopPoint;
                            wp.ShopAddPerc = (decimal)x.ShopPerc;
                            wp.BasePoint = (decimal)x.BasePoint;
                            wp.VendorPerc1 = (decimal)x.VendorPerc1;
                            wp.VendorPerc2 = (decimal)x.VendorPerc2;
                            wproductsDao.Edit(wp);
                        }

                        break;
                }
            }

            if (this.RequestDto.AdjIds.Count == success)
            {
                return this.SuccessActionResult(success);
            }
            else
            {
                return this.ErrorActionResult(string.Join("|", errmessage.ToArray()), success);
            }
        }

        /// <summary>
        /// 删除匹配到的缓存键
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            this.CacheManager.RemoveByPattern(WProductAdjPriceCacheKey.FRXS_WPRODUCT_ADJPRICE_PATTERN_KEY);
            this.CacheManager.RemoveByPattern(WProductsCacheKey.FRXS_WPRODUCTS_PATTERN_KEY);
        }
    }
}
