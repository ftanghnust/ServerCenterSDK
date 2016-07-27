using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models;
using Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 
    /// </summary>
    public partial class OrderContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        static OrderContext()
        {
            //Database.SetInitializer<OrderContext>(null);
        }

        /// <summary>
        /// 
        /// </summary>
        public OrderContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        /// <summary>
        /// 清理被上线问管理的所有实体对象
        /// </summary>
        public void Clear()
        {
            var context = ((IObjectContextAdapter)this).ObjectContext;
            var addedObjects = context.ObjectStateManager.GetObjectStateEntries(EntityState.Added);
            foreach (var objectStateEntry in addedObjects)
            {
                context.Detach(objectStateEntry.Entity);
            }
            var modifyObjects = context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified);
            foreach (var objectStateEntry in modifyObjects)
            {
                context.Detach(objectStateEntry.Entity);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<BuyBack> BuyBacks { get; set; }
        public DbSet<BuyBackDetail> BuyBackDetails { get; set; }
        public DbSet<BuyBackDetailsExt> BuyBackDetailsExts { get; set; }
        public DbSet<BuyBackPre> BuyBackPres { get; set; }
        public DbSet<BuyBackPreDetail> BuyBackPreDetails { get; set; }
        public DbSet<BuyBackPreDetailsExt> BuyBackPreDetailsExts { get; set; }
        public DbSet<BuyOrder> BuyOrders { get; set; }
        public DbSet<BuyOrderDetail> BuyOrderDetails { get; set; }
        public DbSet<BuyOrderDetailsExt> BuyOrderDetailsExts { get; set; }
        public DbSet<BuyOrderPre> BuyOrderPres { get; set; }
        public DbSet<BuyOrderPreDetail> BuyOrderPreDetails { get; set; }
        public DbSet<BuyOrderPreDetailsExt> BuyOrderPreDetailsExts { get; set; }
        public DbSet<BuyPreApp> BuyPreApps { get; set; }
        public DbSet<BuyPreAppBill> BuyPreAppBills { get; set; }
        public DbSet<BuyPreAppDetail> BuyPreAppDetails { get; set; }
        public DbSet<BuyPreAppDetailsExt> BuyPreAppDetailsExts { get; set; }
        public DbSet<PreBuyOrder> PreBuyOrders { get; set; }
        public DbSet<SaleBack> SaleBacks { get; set; }
        public DbSet<SaleBackDetail> SaleBackDetails { get; set; }
        public DbSet<SaleBackDetailsExt> SaleBackDetailsExts { get; set; }
        public DbSet<SaleBackPre> SaleBackPres { get; set; }
        public DbSet<SaleBackPreDetail> SaleBackPreDetails { get; set; }
        public DbSet<SaleBackPreDetailsExt> SaleBackPreDetailsExts { get; set; }
        public DbSet<SaleEdit> SaleEdits { get; set; }
        public DbSet<SaleEditDetail> SaleEditDetails { get; set; }
        public DbSet<SaleEditDetailsExt> SaleEditDetailsExts { get; set; }
        public DbSet<SaleEditOrder> SaleEditOrders { get; set; }
        public DbSet<SaleFee> SaleFees { get; set; }
        public DbSet<SaleFeeDetail> SaleFeeDetails { get; set; }
        public DbSet<SaleFeePre> SaleFeePres { get; set; }
        public DbSet<SaleFeePreDetail> SaleFeePreDetails { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<SaleOrderDetail> SaleOrderDetails { get; set; }
        public DbSet<SaleOrderDetailsExt> SaleOrderDetailsExts { get; set; }
        public DbSet<SaleOrderDetailsPick> SaleOrderDetailsPicks { get; set; }
        public DbSet<SaleOrderPacking> SaleOrderPackings { get; set; }
        public DbSet<SaleOrderPre> SaleOrderPres { get; set; }
        public DbSet<SaleOrderPreDetail> SaleOrderPreDetails { get; set; }
        public DbSet<SaleOrderPreDetailsExt> SaleOrderPreDetailsExts { get; set; }
        public DbSet<SaleOrderPreDetailsPick> SaleOrderPreDetailsPicks { get; set; }
        public DbSet<SaleOrderPrePacking> SaleOrderPrePackings { get; set; }
        public DbSet<SaleOrderPreShelfArea> SaleOrderPreShelfAreas { get; set; }
        public DbSet<SaleOrderSendNumber> SaleOrderSendNumbers { get; set; }
        public DbSet<SaleOrderShelfArea> SaleOrderShelfAreas { get; set; }
        public DbSet<SaleOrderTrack> SaleOrderTracks { get; set; }
        public DbSet<SaleOrdeSendNumber> SaleOrdeSendNumbers { get; set; }
        public DbSet<SaleSettle> SaleSettles { get; set; }
        public DbSet<SaleSettleDetail> SaleSettleDetails { get; set; }
        public DbSet<Settlement> Settlements { get; set; }
        public DbSet<SettlementDetail> SettlementDetails { get; set; }
        public DbSet<StockAdj> StockAdjs { get; set; }
        public DbSet<StockAdjDetail> StockAdjDetails { get; set; }
        public DbSet<StockAdjDetailsExt> StockAdjDetailsExts { get; set; }
        public DbSet<StockCheck> StockChecks { get; set; }
        public DbSet<StockCheckDetail> StockCheckDetails { get; set; }
        public DbSet<StockCheckPlan> StockCheckPlans { get; set; }
        public DbSet<StockCheckPlanDetail> StockCheckPlanDetails { get; set; }
        public DbSet<StockFIFOIn> StockFIFOIns { get; set; }
        public DbSet<StockFIFOOut> StockFIFOOuts { get; set; }
        public DbSet<StockQty> StockQties { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BuyBackMap());
            modelBuilder.Configurations.Add(new BuyBackDetailMap());
            modelBuilder.Configurations.Add(new BuyBackDetailsExtMap());
            modelBuilder.Configurations.Add(new BuyBackPreMap());
            modelBuilder.Configurations.Add(new BuyBackPreDetailMap());
            modelBuilder.Configurations.Add(new BuyBackPreDetailsExtMap());
            modelBuilder.Configurations.Add(new BuyOrderMap());
            modelBuilder.Configurations.Add(new BuyOrderDetailMap());
            modelBuilder.Configurations.Add(new BuyOrderDetailsExtMap());
            modelBuilder.Configurations.Add(new BuyOrderPreMap());
            modelBuilder.Configurations.Add(new BuyOrderPreDetailMap());
            modelBuilder.Configurations.Add(new BuyOrderPreDetailsExtMap());
            modelBuilder.Configurations.Add(new BuyPreAppMap());
            modelBuilder.Configurations.Add(new BuyPreAppBillMap());
            modelBuilder.Configurations.Add(new BuyPreAppDetailMap());
            modelBuilder.Configurations.Add(new BuyPreAppDetailsExtMap());
            modelBuilder.Configurations.Add(new PreBuyOrderMap());
            modelBuilder.Configurations.Add(new SaleBackMap());
            modelBuilder.Configurations.Add(new SaleBackDetailMap());
            modelBuilder.Configurations.Add(new SaleBackDetailsExtMap());
            modelBuilder.Configurations.Add(new SaleBackPreMap());
            modelBuilder.Configurations.Add(new SaleBackPreDetailMap());
            modelBuilder.Configurations.Add(new SaleBackPreDetailsExtMap());
            modelBuilder.Configurations.Add(new SaleEditMap());
            modelBuilder.Configurations.Add(new SaleEditDetailMap());
            modelBuilder.Configurations.Add(new SaleEditDetailsExtMap());
            modelBuilder.Configurations.Add(new SaleEditOrderMap());
            modelBuilder.Configurations.Add(new SaleFeeMap());
            modelBuilder.Configurations.Add(new SaleFeeDetailMap());
            modelBuilder.Configurations.Add(new SaleFeePreMap());
            modelBuilder.Configurations.Add(new SaleFeePreDetailMap());
            modelBuilder.Configurations.Add(new SaleOrderMap());
            modelBuilder.Configurations.Add(new SaleOrderDetailMap());
            modelBuilder.Configurations.Add(new SaleOrderDetailsExtMap());
            modelBuilder.Configurations.Add(new SaleOrderDetailsPickMap());
            modelBuilder.Configurations.Add(new SaleOrderPackingMap());
            modelBuilder.Configurations.Add(new SaleOrderPreMap());
            modelBuilder.Configurations.Add(new SaleOrderPreDetailMap());
            modelBuilder.Configurations.Add(new SaleOrderPreDetailsExtMap());
            modelBuilder.Configurations.Add(new SaleOrderPreDetailsPickMap());
            modelBuilder.Configurations.Add(new SaleOrderPrePackingMap());
            modelBuilder.Configurations.Add(new SaleOrderPreShelfAreaMap());
            modelBuilder.Configurations.Add(new SaleOrderSendNumberMap());
            modelBuilder.Configurations.Add(new SaleOrderShelfAreaMap());
            modelBuilder.Configurations.Add(new SaleOrderTrackMap());
            modelBuilder.Configurations.Add(new SaleOrdeSendNumberMap());
            modelBuilder.Configurations.Add(new SaleSettleMap());
            modelBuilder.Configurations.Add(new SaleSettleDetailMap());
            modelBuilder.Configurations.Add(new SettlementMap());
            modelBuilder.Configurations.Add(new SettlementDetailMap());
            modelBuilder.Configurations.Add(new StockAdjMap());
            modelBuilder.Configurations.Add(new StockAdjDetailMap());
            modelBuilder.Configurations.Add(new StockAdjDetailsExtMap());
            modelBuilder.Configurations.Add(new StockCheckMap());
            modelBuilder.Configurations.Add(new StockCheckDetailMap());
            modelBuilder.Configurations.Add(new StockCheckPlanMap());
            modelBuilder.Configurations.Add(new StockCheckPlanDetailMap());
            modelBuilder.Configurations.Add(new StockFIFOInMap());
            modelBuilder.Configurations.Add(new StockFIFOOutMap());
            modelBuilder.Configurations.Add(new StockQtyMap());
        }
    }
}
