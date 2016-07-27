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
        /// 基本分类创建(Created)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnCategoryCreated(object sender, CategoryCreatedEventAgrs e)
        {
            var resp = this.ApiClient.Execute(new DataSyncBaseCategoryGetRequest { CategoryId = e.CategoryId });
            var dataContext = this.CreateBaseDataContext();
            if (dataContext.Categories.FirstOrDefault(o => o.CategoryId == e.CategoryId).IsNull())
            {
                var entity = resp.Data.MapTo<Models.Category>();
                dataContext.Categories.Add(entity);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 基本分类变更(Changed)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnCategoryChanged(object sender, CategoryChangedEventAgrs e)
        {
            var resp = this.ApiClient.Execute(new DataSyncBaseCategoryGetRequest { CategoryId = e.CategoryId });
            var dataContext = this.CreateBaseDataContext();
            var entity = dataContext.Categories.Find(e.CategoryId);
            if (entity.IsNull())
            {
                resp.Data.MapTo(entity);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 基本分类移除(Remove)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnCategoryRemoved(object sender, CategoryRemovedEventAgrs e)
        {
            this.OnCategoryChanged(sender, new CategoryChangedEventAgrs() { CategoryId = e.CategoryId, Message = e.Message });
        }
    }
}
