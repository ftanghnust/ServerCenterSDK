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
        /// 供应商类型 更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnVendorTypeChanged(object sender, VendorTypeChangedEventAgrs e)
        {
            var request = new DataSyncBaseVendorTypeGetRequest { VendorTypeID = e.VendorTypeID };
            var resp = this.ApiClient.Execute(request);
            var dataContext = this.CreateBaseDataContext();
            var entity = dataContext.VendorTypes.Find(e.VendorTypeID);
            if (null != entity)
            {
                resp.Data.MapTo(entity);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 供应商类型 创建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnVendorTypeCreated(object sender, VendorTypeCreatedEventAgrs e)
        {
            var request = new DataSyncBaseVendorTypeGetRequest { VendorTypeID = e.VendorTypeID };
            var resp = this.ApiClient.Execute(request);
            var dataContext = this.CreateBaseDataContext();
            if (dataContext.VendorTypes.FirstOrDefault(o => o.VendorTypeID == e.VendorTypeID).IsNull())
            {
                dataContext.VendorTypes.Add(resp.Data.MapTo<Models.VendorType>());
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 供应商类型 移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnVendorTypeRemoved(object sender, VendorTypeRemovedEventAgrs e)
        {
            this.OnVendorTypeChanged(sender, new VendorTypeChangedEventAgrs() { VendorTypeID = e.VendorTypeID, Message = e.Message });
        }


    }
}
