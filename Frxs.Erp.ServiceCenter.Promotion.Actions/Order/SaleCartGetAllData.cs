using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Promotion.Actions.ResponseDto;
using Frxs.Erp.ServiceCenter.Promotion.Actions.ResponseDto.Order;
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 由门店ID取购物车及详情
    /// </summary>
    [ActionName("SaleCart.GetAllData")]
    public class SaleCartGetAllData : ActionBase<RequestDto.SaleCartQueryRequestDto, SaleCartGetAllDataResponseDto>
    {
        public override ActionResult<SaleCartGetAllDataResponseDto> Execute()
        {
            var dto = this.RequestDto;

            if (dto.ShopID <= 0)
            {
                return this.ErrorActionResult("错误的门店ID");
            }

            IAction cartAction=new SaleCartGetByShopIdAction();
            cartAction.RequestDto = dto;
            var cartData = cartAction.Execute();
            if(cartData==null)
            {
                return this.ErrorActionResult("获取购物车信息失败");
            }
            if(cartData.Flag!=ActionResultFlag.SUCCESS)
            {
                return this.ErrorActionResult(cartData.Info);
            }

            if(cartData.Data==null)
            {
                return this.ErrorActionResult("购物车中没有商品");
            }


            //获取productList
            SaleCartGetByShopIdResponseDto cart = (SaleCartGetByShopIdResponseDto)cartData.Data;
            var productList = new List<int>();
            foreach (var item in cart.Carts)
            {
                productList.Add(item.ProductID);
            }

            var productStr = "";
            foreach (var productId in productList)
            {
                productStr += productId + ",";
            }
            productStr = productStr.Substring(0, productStr.Length - 1);

            //获取门店返点信息
            IAction promotinRebate = new WProductPromotionDetailsListModelGetAction();
            promotinRebate.RequestDto = new WProductPromotionDetailsListModelGetAction.WProductPromotionDetailsListModelGetActionRequestDto()
                                            {
                                                WID = dto.WarehouseId,
                                                ShopID = dto.ShopID,
                                                ProductIDList = productStr,
                                                BeginTime = DateTime.Now,
                                                EndTime = DateTime.Now,
                                                PromotionType = 1,
                                                UserId = dto.UserId,
                                                UserName = dto.UserName
                                            };

            var rebateData = promotinRebate.Execute();
            if(rebateData==null)
            {
                return this.ErrorActionResult("获取门店返点列表信息失败");
            }

            IAction promotionRate = new WProductPromotionDetailsListModelGetAction();
            promotionRate.RequestDto = new WProductPromotionDetailsListModelGetAction.WProductPromotionDetailsListModelGetActionRequestDto()
            {
                WID = dto.WarehouseId,
                ShopID = dto.ShopID,
                ProductIDList = productStr,
                PromotionType = 2,
                UserId = dto.UserId,
                UserName = dto.UserName
            };
            var rateData = promotionRate.Execute();
            if (rateData == null)
            {
                return this.ErrorActionResult("获取门店促销费率信息失败");
            }
            return this.SuccessActionResult(new SaleCartGetAllDataResponseDto()
                                                {
                                                    Carts = cart.Carts,
                                                    RebateData = (IList<WProductPromotionDetails>)rebateData.Data,
                                                    ReteData = (IList<WProductPromotionDetails>)rateData.Data
                                                });
        }
    }
}
