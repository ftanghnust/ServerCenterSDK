using Frxs.ServiceCenter.DataSync.Message.ApiHost.SDK.Request;
using Frxs.ServiceCenter.DataSync.Message.ApiHost.SDK.Resp;
using Frxs.ServiceCenter.DataSync.Message.ConsumerClient;
using Frxs.ServiceCenter.DataSync.Message.ConsumerClient.EventArgs;
using System.Linq;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 消息处理类(需要重写所有的事件处理)
    /// </summary>
    public partial class DefaultMessageHandler : MessageHandler
    {
        /// <summary>
        /// 门店 创建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnShopCreated(object sender, ShopCreatedEventAgrs e)
        {
            var resp = this.ApiClient.Execute(new DataSyncBaseShopGetRequest { ShopID = e.ShopID });
            var dataContext = this.CreateBaseDataContext();
            if (dataContext.Shops.FirstOrDefault(o => o.ShopID == e.ShopID).IsNull())
            {
                dataContext.Shops.Add(resp.Data.MapTo<Models.Shop>());
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 门店 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnShopChanged(object sender, ShopChangedEventAgrs e)
        {
            var resp = this.ApiClient.Execute(new DataSyncBaseShopGetRequest { ShopID = e.ShopID });
            var dataContext = this.CreateBaseDataContext();
            var entity = dataContext.Shops.Find(e.ShopID);
            if (!entity.IsNull())
            {
                resp.Data.MapTo(entity);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 门店 移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnShopRemoved(object sender, ShopRemovedEventAgrs e)
        {
            this.OnShopChanged(sender, new ShopChangedEventAgrs() { ShopID = e.ShopID, Message = e.Message });
        }
    }
}
