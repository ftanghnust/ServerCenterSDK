/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/12 9:43:51
 * *******************************************************/
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnBrandCategoryCreated(object sender, BrandCategoryCreatedEventAgrs e)
        {
            var resp = this.ApiClient.Execute(new DataSyncBaseBrandCategoryGetRequest { BrandId = e.BrandId });
            var dataContext = this.CreateBaseDataContext();
            if (null == dataContext.BrandCategories.FirstOrDefault(o => o.BrandId == e.BrandId))
            {
                dataContext.BrandCategories.Add(resp.Data.MapTo<Models.BrandCategory>());
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnBrandCategoryChanged(object sender, BrandCategoryChangedEventAgrs e)
        {
            var resp = this.ApiClient.Execute(new DataSyncBaseBrandCategoryGetRequest { BrandId = e.BrandId });
            var dataContext = this.CreateBaseDataContext();
            var entity = dataContext.BrandCategories.Find(e.BrandId);
            if (null != entity)
            {
                resp.Data.MapTo(entity);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnBrandCategoryRemoved(object sender, BrandCategoryRemovedEventAgrs e)
        {
            this.OnBrandCategoryChanged(sender, new BrandCategoryChangedEventAgrs() { BrandId = e.BrandId, Message = e.Message });
        }
    }
}
