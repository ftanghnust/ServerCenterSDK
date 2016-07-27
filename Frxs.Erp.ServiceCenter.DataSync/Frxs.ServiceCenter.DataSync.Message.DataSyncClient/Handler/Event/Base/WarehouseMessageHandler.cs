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
        protected override void OnWarehouseCreated(object sender, WarehouseCreatedEventAgrs e)
        {
            var resp = this.ApiClient.Execute(new DataSyncBaseWarehouseGetRequest { WID = e.WID });
            var dataContext = this.CreateBaseDataContext();
            if (dataContext.Warehouses.FirstOrDefault(o => o.WID == e.WID).IsNull())
            {
                dataContext.Warehouses.Add(resp.Data.MapTo<Models.Warehouse>());
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnWarehouseChanged(object sender, WarehouseChangedEventAgrs e)
        {
            var resp = this.ApiClient.Execute(new DataSyncBaseWarehouseGetRequest { WID = e.WID });
            var dataContext = this.CreateBaseDataContext();
            var entity = dataContext.Warehouses.Find(e.WID);
            if (!entity.IsNull())
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
        protected override void OnWarehouseRemoved(object sender, WarehouseRemovedEventAgrs e)
        {
            this.OnWarehouseChanged(sender, new WarehouseChangedEventAgrs() { WID = e.WID, Message = e.Message });
        }
    }
}
