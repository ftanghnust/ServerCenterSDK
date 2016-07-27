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
        /// 供应商创建(Created)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnVendorCreated(object sender, VendorCreatedEventAgrs e)
        {
            var resp = this.ApiClient.Execute(new DataSyncBaseVendorGetDetailRequest { VendorID = e.VendorID });
            var dataContext = this.CreateBaseDataContext();
            if (dataContext.Vendors.FirstOrDefault(o => o.VendorID == e.VendorID).IsNull())
            {

                //添加 供应商仓库关系
                foreach (var vendorWarehouse in resp.Data.VendorWarehouses)
                {
                    dataContext.VendorWarehouses.Add(vendorWarehouse.MapTo<Models.VendorWarehouse>());
                }

                dataContext.Vendors.Add(resp.Data.Vendor.MapTo<Models.Vendor>());

                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 供应商变更(Changed)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnVendorChanged(object sender, VendorChangedEventAgrs e)
        {
            var resp = this.ApiClient.Execute(new DataSyncBaseVendorGetDetailRequest { VendorID = e.VendorID });
            var dataContext = this.CreateBaseDataContext();
            var entity = dataContext.Vendors.Find(e.VendorID);
            if (!entity.IsNull())
            {
                //删除 供应商仓库关系
                var vendorWarehouses = dataContext.VendorWarehouses.Where(o => o.VendorID == e.VendorID).ToList();
                foreach (var item in vendorWarehouses)
                {
                    dataContext.VendorWarehouses.Remove(item);
                }

                //添加 供应商仓库关系
                foreach (var vendorWarehouse in resp.Data.VendorWarehouses)
                {
                    dataContext.VendorWarehouses.Add(vendorWarehouse.MapTo<Models.VendorWarehouse>());
                }

                resp.Data.Vendor.MapTo(entity);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 供应商移除(Remove)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnVendorRemoved(object sender, VendorRemovedEventAgrs e)
        {
            this.OnVendorChanged(sender, new VendorChangedEventAgrs() { VendorID = e.VendorID, Message = e.Message });
        }
    }
}
