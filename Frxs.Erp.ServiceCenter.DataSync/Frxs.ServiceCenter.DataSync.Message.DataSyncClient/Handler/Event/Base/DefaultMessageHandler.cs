/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/12 9:43:51
 * *******************************************************/
using Frxs.ServiceCenter.DataSync.Message.ApiHost.SDK;
using Frxs.ServiceCenter.DataSync.Message.ConsumerClient;
using System;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 消息处理类(需要重写所有的事件处理)
    /// </summary>
    public partial class DefaultMessageHandler : MessageHandler
    {
        /// <summary>
        /// 数据同步接口
        /// </summary>
        public IApiClient ApiClient { get; private set; }

        /// <summary>
        /// 创建基础库数据访问上下文
        /// </summary>
        public BaseDataContext CreateBaseDataContext()
        {
            return DbContextFactory.CreateBaseDataContext();
        }

        /// <summary>
        /// 创建用户库数据访问上下文
        /// </summary>
        public UserContext CreateUserContext()
        {
            return DbContextFactory.CreateUserContext();
        }

        /// <summary>
        /// 创建订单库数据访问上下文
        /// </summary>
        /// <param name="wid">仓库编号</param>
        /// <returns></returns>
        public OrderContext CreateOrderContext(int wid)
        {
            return DbContextFactory.CreateOrderContext(wid);
        }

        /// <summary>
        /// 促销库数据访问上下文
        /// </summary>
        /// <param name="wid">仓库编号</param>
        public PromoContext CreatePromoContext(int wid)
        {
            return DbContextFactory.CreatePromoContext(wid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageServerUrl">消息中间件服务器地址</param>
        /// <param name="josnSerializer">JSON序列化接口</param>
        /// <param name="wid">当前仓库编号（如果不指定，请返回0，相当于消费全部消息）</param>
        /// <param name="apiClient">同步中心数据访问接口</param>
        public DefaultMessageHandler(string messageServerUrl, IJosnSerializer josnSerializer, Func<int> wid, IApiClient apiClient)
            : base(messageServerUrl, josnSerializer, wid)
        {
            this.ApiClient = apiClient;
        }
    }
}
