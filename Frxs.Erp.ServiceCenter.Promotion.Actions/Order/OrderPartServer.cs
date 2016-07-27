using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.SDK.Request;
using Frxs.Erp.ServiceCenter.Product.SDK.Resp;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    public class OrderPartsServer
    {
        
        /// <summary>
        /// 获取仓库商品列表
        /// </summary>
        /// <param name="Wid">仓库ID</param>
        /// <param name="productIds">商品List</param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public FrxsErpProductWProductsGetToB2BResp.FrxsErpProductWProductsGetToB2BRespData GetWProductsInfo(int Wid, IList<int> productIds, int shopId, int userId, string userName)
        {
            var client = WorkContext.GetErpProductSDKClient();
            var req = new FrxsErpProductWProductsGetToB2BRequest()
            {
                ProductIds = productIds,
                UserId = userId,
                UserName = userName,
                WID = Wid,
                ShopID = shopId
            };
            var resp = client.Execute(req);
            if (resp == null)
            {
                throw new Exception("查询仓库商品信息失败");
            }
            if (resp.Flag != 0)
            {
                throw new Exception(resp.Info);
            }
            else
            {
                return resp.Data;
            }
        }
    }

}
