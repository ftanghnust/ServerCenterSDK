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
        /// 商品规格属性创建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnAttributeCreated(object sender, AttributeCreatedEventAgrs e)
        {
            var resp = this.ApiClient.Execute(new DataSyncBaseAttributeGetDetailRequest
            {
                AttributeId = e.AttributeId
            });
            var dataContext = this.CreateBaseDataContext();
            if (null == dataContext.Attributes.FirstOrDefault(o => o.AttributeId == e.AttributeId))
            {
                //添加 规格属性值
                foreach (var attributesValue in resp.Data.AttributesValues)
                {
                    dataContext.AttributesValues.Add(attributesValue.MapTo<Models.AttributesValue>());
                }
                dataContext.Attributes.Add(resp.Data.Attribute.MapTo<Models.Attribute>());
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 商品规格属性更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnAttributeChanged(object sender, AttributeChangedEventAgrs e)
        {
            var resp = this.ApiClient.Execute(new DataSyncBaseAttributeGetDetailRequest
            {
                AttributeId = e.AttributeId
            });
            var dataContext = this.CreateBaseDataContext();
            var entity = dataContext.Attributes.Find(e.AttributeId);
            if (null != entity)
            {
                //删除 规格属性值
                var attributesValues = dataContext.AttributesValues.Where(o => o.AttributeId == e.AttributeId).ToList();
                foreach (var item in attributesValues)
                {
                    dataContext.AttributesValues.Remove(item);
                }
                //添加 规格属性值
                foreach (var attributesValue in resp.Data.AttributesValues)
                {
                    dataContext.AttributesValues.Add(attributesValue.MapTo<Models.AttributesValue>());
                }
                resp.Data.Attribute.MapTo(entity);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 商品规格属性删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnAttributeRemoved(object sender, AttributeRemovedEventAgrs e)
        {
            this.OnAttributeChanged(sender, new AttributeChangedEventAgrs() { AttributeId = e.AttributeId, Message = e.Message });
        }
    }
}
