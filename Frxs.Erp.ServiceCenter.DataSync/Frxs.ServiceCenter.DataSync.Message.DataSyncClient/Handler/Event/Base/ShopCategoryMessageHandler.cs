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
        /// 运营分类创建(Created)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnShopCategoryCreated(object sender, ShopCategoryCreatedEventAgrs e)
        {
            var resp = this.ApiClient.Execute(new DataSyncBaseShopCategoryGetRequest { CategoryId = e.CategoryId });
            var dataContext = this.CreateBaseDataContext();
            if (dataContext.ShopCategories.FirstOrDefault(o => o.CategoryId == e.CategoryId).IsNull())
            {
                dataContext.ShopCategories.Add(resp.Data.MapTo<Models.ShopCategory>());
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 运营分类变更(Changed)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnShopCategoryChanged(object sender, ShopCategoryChangedEventAgrs e)
        {
            var resp = this.ApiClient.Execute(new DataSyncBaseShopCategoryGetRequest { CategoryId = e.CategoryId });
            var dataContext = this.CreateBaseDataContext();
            var entity = dataContext.ShopCategories.FirstOrDefault(o => o.CategoryId == e.CategoryId);
            if (!entity.IsNull())
            {
                resp.Data.MapTo(entity);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 运营分类移除(Remove)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnShopCategoryRemoved(object sender, ShopCategoryRemovedEventAgrs e)
        {
            this.OnShopCategoryChanged(sender, new ShopCategoryChangedEventAgrs() { CategoryId = e.CategoryId, Message = e.Message });
        }
    }
}
