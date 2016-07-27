/*********************************************************
 * FRXS(ISC) chujl 2016/3/23  
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.Erp.ServiceCenter.Promotion.Model;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 仓库消息录入或编辑
    /// </summary>
    [ActionName("WAdvertisement.AddOrEdit")]
    public class WAdvertisementAddOrEditAction : ActionBase<RequestDto.WAdvertisementAddOrEditActionRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            WAdvertisement order = requestDto.order.MapTo<WAdvertisement>();

            //var advertisementProducts = new List<WAdvertisementProduct>();
            //if (requestDto.advertisementProduct != null && requestDto.advertisementProduct.Count > 0)
            //{
            //    foreach (var advertisementProduct in requestDto.advertisementProduct)
            //    {
            //        WAdvertisementProduct product = advertisementProduct.MapTo<WAdvertisementProduct>();
            //        advertisementProducts.Add(product);
            //    }
            //}
            //if (requestDto.Flag == "Add")
            //{
            //    int result = WAdvertisementBLO.SaveWAdvertisementAndProducts(order, advertisementProducts);
            //    if (result <= 0)
            //    {
            //        return new ActionResult<int>()
            //        {
            //            Flag = ActionResultFlag.FAIL,
            //            Info = "新增广告橱窗信息失败！"
            //        };
            //    }
            //    else
            //    {
            //        return new ActionResult<int>()
            //        {
            //            Flag = ActionResultFlag.SUCCESS,
            //            Info = "OK",
            //            Data = result
            //        };
            //    }
            //}
            //else
            //{
            //    int result = WAdvertisementBLO.EditWAdvertisementAndProducts(order, advertisementProducts);
            //    if (result > 0)
            //    {
            //        return new ActionResult<int>()
            //        {
            //            Flag = ActionResultFlag.SUCCESS,
            //            Info = "OK",
            //            Data = result
            //        };
            //    }
            //    else
            //    {
            //        return new ActionResult<int>()
            //        {
            //            Flag = ActionResultFlag.FAIL,
            //            Info = "编辑广告橱窗失败"
            //        };
            //    }
            //}

            //注释原未加事务代码
            if (requestDto.Flag == "Add")
            {
                int result = WAdvertisementBLO.Save(order);
                if (result == 0)
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = "新增广告橱窗信息失败！"
                    };
                }
                else
                {
                    order.AdvertisementID = result;//新增项主键
                    SaveAdvertisementProducts(order, requestDto.advertisementProduct);
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.SUCCESS,
                        Info = "OK",
                        Data = result
                    };
                }
            }
            else
            {
                int result = WAdvertisementBLO.Edit(order);
                if (result == 1)
                {
                    SaveAdvertisementProducts(order, requestDto.advertisementProduct);
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.SUCCESS,
                        Info = "OK",
                        Data = result
                    };
                }
                else
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = "编辑广告橱窗失败"
                    };
                }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="wAdvertisement"></param>
        /// <param name="advertisementProducts"></param>
        public void SaveAdvertisementProducts(WAdvertisement wAdvertisement, List<Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto.WAdvertisementProductRequestDto> advertisementProducts)
        {
            WAdvertisementProductBLO.DeleteByWAdvertisement(wAdvertisement.WID, wAdvertisement.AdvertisementID);
            foreach (var advertisementProduct in advertisementProducts)
            {
                advertisementProduct.WID = wAdvertisement.WID;
                advertisementProduct.AdvertisementID = wAdvertisement.AdvertisementID;
                WAdvertisementProduct product = advertisementProduct.MapTo<WAdvertisementProduct>();
                int result = WAdvertisementProductBLO.Save(product);
            }
        }
    }
}
