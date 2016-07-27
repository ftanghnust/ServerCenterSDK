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
        /// 数据字典 创建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnSysDictCreated(object sender, SysDictCreatedEventAgrs e)
        {
            var request = new DataSyncBaseSysDictGetDetailRequest { DictCode = e.DictCode };
            var resp = this.ApiClient.Execute(request);
            var dataContext = this.CreateBaseDataContext();
            if (dataContext.SysDicts.FirstOrDefault(o => o.DictCode == e.DictCode).IsNull())
            {
                dataContext.SysDicts.Add(resp.Data.SysDict.MapTo<Models.SysDict>());
                foreach (var item in resp.Data.SysDictDetails)
                {
                    dataContext.SysDictDetails.Add(item.MapTo<Models.SysDictDetail>());
                }
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 数据字典 更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnSysDictChanged(object sender, SysDictChangedEventAgrs e)
        {
            var request = new DataSyncBaseSysDictGetDetailRequest { DictCode = e.DictCode };
            var resp = this.ApiClient.Execute(request);
            var dataContext = this.CreateBaseDataContext();
            var entity = dataContext.SysDicts.Find(e.DictCode);
            if (null != entity)
            {
                //先删除
                var sysDictDetails = dataContext.SysDictDetails.Where(o => o.DictCode == e.DictCode).ToList();
                foreach (var item in sysDictDetails)
                {
                    dataContext.SysDictDetails.Remove(item);
                }

                //后添加数据字典明细数据
                foreach (var sysDictDetail in resp.Data.SysDictDetails)
                {
                    dataContext.SysDictDetails.Add(sysDictDetail.MapTo<Models.SysDictDetail>());
                }
                //添加数据字典主表数据
                resp.Data.SysDict.MapTo(entity);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 数据字典 移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnSysDictRemoved(object sender, SysDictRemovedEventAgrs e)
        {
            var dataContext = this.CreateBaseDataContext();
            var entity = dataContext.SysDicts.Find(e.DictCode);
            if (null != entity)
            {
                var sysDictDetails = dataContext.SysDictDetails.Where(o => o.DictCode == e.DictCode).ToList();
                foreach (var sysDictDetail in sysDictDetails)
                {
                    dataContext.SysDictDetails.Remove(sysDictDetail);
                }
                dataContext.SysDicts.Remove(entity);
                dataContext.SaveChanges();
            }
        }
    }
}
