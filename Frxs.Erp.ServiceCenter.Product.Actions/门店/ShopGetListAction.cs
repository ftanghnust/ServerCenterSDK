/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/21 15:20:02
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Platform.Utility.Pager;
using System.Collections;

namespace Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Shop
{
    /// <summary>
    /// 获取总部后台门店信息详情
    /// </summary>
    [ActionName("Shop.GetList")]
    public class ShopGetListAction : ActionBase<ShopGetShopListRequestDto, IList<Model.Shop>>
    {
        
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<Model.Shop>> Execute()
        {
            //System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //sw.Start();
            //Frxs.Platform.Utility.Log.Logger.GetInstance().DebugLog
            //    (
            //        new Platform.Utility.Log.NormalLog
            //        {
            //            LogTime = DateTime.Now,
            //            LogContent = "计时开始",
            //            LogSource = "Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Shop.ShopGetListAction.Execute",
            //            LogOperation = "获取总部后台门店信息详情开始",
            //            LogIp = this.RequestContext.HttpContext.Request.GetClientIp()
            //        }
            //    );
            var requestDto = this.RequestDto;

            PageListBySql<Model.Shop> page = new PageListBySql<Model.Shop>(
                       1,
                       100000);
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();

            ArrayList arr = new ArrayList();

            foreach (ShopIDLsitRequestDto item in requestDto.ShopList)
            {
                arr.Add(item.ShopID);
            }

            conditionDict.Add("ShopIDList", arr);

            PageListBySql<Model.Shop> models = ShopBLO.GetPageList(page, conditionDict);

            //sw.Stop();
            //Frxs.Platform.Utility.Log.Logger.GetInstance().DebugLog
            //    (
            //        new Platform.Utility.Log.NormalLog
            //        {
            //            LogTime = DateTime.Now,
            //            LogContent = string.Format("计时结束，耗时{0}毫秒", sw.ElapsedMilliseconds),
            //            LogSource = "Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Shop.ShopGetListAction.Execute",
            //            LogOperation = "获取总部后台门店信息详情结束",
            //            LogIp = this.RequestContext.HttpContext.Request.GetClientIp()
            //        }
            //    );

            return this.SuccessActionResult(models.ItemList); 
        }

    }
}
