/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/21/2016 1:42:08 PM
 * *******************************************************/
using Frxs.ServiceCenter.DataSync.Message.ApiHost.SDK.Request;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Handler.Sync
{
    /// <summary>
    /// 数据库同步处理
    /// </summary>
    public class ProductsBarCodeDataSyncHandler : DataSyncHandler
    {
        /// <summary>
        /// 每页获取多一点，业务数据表不是很宽，总的数据量不是很大
        /// </summary>
        public override int PageSize
        {
            get
            {
                return 1000;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Execute()
        {
            //获取到同步接口调用客户端
            var apiClient = ApiClientRoute.CreateApiClient();

            //请求参数
            var request = new DataSyncBaseProductsBarCodeGetListRequest()
            {
                PageIndex = 0,
                PageSize = this.PageSize
            };

            //获取同步数据
            var resp = apiClient.Execute(request);

            //开始执行同步
            if (null != this.OnExecuted)
            {
                this.OnExecuting(new ExecutingEventArgs()
                {
                    TotalCount = resp.Data.TotalCount,
                    PageSize = resp.Data.PageSize,
                    TotalPages = resp.Data.TotalPages
                });
            }

            //删除所有数据
            DbContextFactory.CreateBaseDataContext().Delete<Models.ProductsBarCode>();

            //当前索引号
            int index = 0;

            //分批次请求同步数据
            for (int page = 0; page < resp.Data.TotalPages; page++)
            {
                //构造请求
                request.PageIndex = page;
                request.PageSize = resp.Data.PageSize;
                request.TotalCount = resp.Data.TotalCount;

                //第一页不再请求
                if (page > 0)
                {
                    resp = apiClient.Execute(request);
                }

                //创建数据映射上下文
                var dbContext = DbContextFactory.CreateBaseDataContext();
                dbContext.Configuration.AutoDetectChangesEnabled = false;

                //添加实体到上下文
                foreach (var item in resp.Data.Items)
                {
                    index++;

                    dbContext.ProductsBarCodes.Add(item.MapTo<Models.ProductsBarCode>());

                    //触发添加成功事件
                    if (null != this.OnItemSyncComplete)
                    {
                        this.OnItemSyncComplete(new ItemSyncCompleteEventArgs()
                        {
                            Index = index,
                            Message = item.BarCode,
                            Status = SyncStatus.OK
                        });
                    }
                }

                dbContext.SaveChanges();
            }

            //执行同步完成
            if (null != this.OnExecuted)
            {
                this.OnExecuted(new ExecutedEventArgs());
            }
        }
    }
}
