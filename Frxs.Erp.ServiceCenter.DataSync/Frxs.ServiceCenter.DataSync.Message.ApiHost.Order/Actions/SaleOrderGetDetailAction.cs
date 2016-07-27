using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 销售订单 同步接口
    /// </summary>
    [ActionName("SaleOrder.Get.Detail")]
    public class SaleOrderGetDetailAction : ActionBase<SaleOrderGetDetailAction.SaleOrderGetDetailActionRequestDto, SaleOrderGetDetailAction.SaleOrderGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SaleOrderGetDetailActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// SqlServer.nvarchar
            /// </summary>
            public String OrderId { get; set; }

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }
        }

        /// <summary>
        ///下送的数据
        /// </summary>
        public class SaleOrderGetDetailActionResponseDto
        {
            /// <summary>
            ///销售订单 主表
            /// </summary>
            public Models.SaleOrder SaleOrder { get; set; }

            /// <summary>
            ///销售订单 商品明细列表
            /// </summary>
            public List<Models.SaleOrderDetail> SaleOrderDetails { get; set; }

            /// <summary>
            ///销售订单 商品明细扩展列表
            /// </summary>
            public List<Models.SaleOrderDetailsExt> SaleOrderDetailsExts { get; set; }

            /// <summary>
            ///销售订单 商品拣货明细列表
            /// </summary>
            public List<Models.SaleOrderDetailsPick> SaleOrderDetailsPicks { get; set; }

            /// <summary>
            ///销售订单 装箱数表
            /// </summary>
            public Models.SaleOrderPacking SaleOrderPacking { get; set; }

            /// <summary>
            ///销售订单 待拣货区列表 
            /// </summary>
            public List<Models.SaleOrderShelfArea> SaleOrderShelfAreas { get; set; }

            /// <summary>
            ///销售订单 跟踪 列表表
            /// </summary>
            public List<Models.SaleOrderTrack> SaleOrderTracks { get; set; }

            /// <summary>
            ///销售订单 发货顺序表
            /// </summary>
            public Models.SaleOrdeSendNumber SaleOrdeSendNumber { get; set; }

        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.SaleOrder> _saleOrderRepository;
        private readonly IRepository<Models.SaleOrderDetail> _saleOrderDetailRepository;
        private readonly IRepository<Models.SaleOrderDetailsExt> _saleOrderDetailsExtRepository;
        private readonly IRepository<Models.SaleOrderDetailsPick> _saleOrderDetailsPickRepository;
        private readonly IRepository<Models.SaleOrderPacking> _saleOrderPackingRepository;
        private readonly IRepository<Models.SaleOrderShelfArea> _saleOrderShelfAreaRepository;
        private readonly IRepository<Models.SaleOrderTrack> _saleOrderTrackRepository;
        private readonly IRepository<Models.SaleOrdeSendNumber> _saleOrdeSendNumberRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="saleOrderRepository">数据访问仓储</param>
        /// <param name="saleOrderDetailRepository"> </param>
        /// <param name="saleOrderDetailsExtRepository"> </param>
        /// <param name="saleOrderDetailsPickRepository"> </param>
        /// <param name="saleOrderPackingRepository"> </param>
        /// <param name="saleOrderShelfAreaRepository"> </param>
        /// <param name="saleOrderTrackRepository"> </param>
        /// <param name="saleOrdeSendNumberRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        public SaleOrderGetDetailAction(
            IRepository<Models.SaleOrder> saleOrderRepository,
            IRepository<Models.SaleOrderDetail> saleOrderDetailRepository,
            IRepository<Models.SaleOrderDetailsExt> saleOrderDetailsExtRepository,
            IRepository<Models.SaleOrderDetailsPick> saleOrderDetailsPickRepository,
            IRepository<Models.SaleOrderPacking> saleOrderPackingRepository,
            IRepository<Models.SaleOrderShelfArea> saleOrderShelfAreaRepository,
            IRepository<Models.SaleOrderTrack> saleOrderTrackRepository,
            IRepository<Models.SaleOrdeSendNumber> saleOrdeSendNumberRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._saleOrderRepository = saleOrderRepository;
            this._saleOrderDetailRepository = saleOrderDetailRepository;
            this._saleOrderDetailsExtRepository = saleOrderDetailsExtRepository;
            this._saleOrderDetailsPickRepository = saleOrderDetailsPickRepository;
            this._saleOrderPackingRepository = saleOrderPackingRepository;
            this._saleOrderShelfAreaRepository = saleOrderShelfAreaRepository;
            this._saleOrderTrackRepository = saleOrderTrackRepository;
            this._saleOrdeSendNumberRepository = saleOrdeSendNumberRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<SaleOrderGetDetailActionResponseDto> Execute()
        {
            var saleOrder = this._saleOrderRepository.TableNoTracking.FirstOrDefault(o => o.OrderId == this.RequestDto.OrderId);
            var saleOrderDetails = this._saleOrderDetailRepository.TableNoTracking.Where(o => o.OrderID == this.RequestDto.OrderId).ToList();
            var saleOrderDetailsExts = this._saleOrderDetailsExtRepository.TableNoTracking.Where(o => o.OrderID == this.RequestDto.OrderId).ToList();
            var saleOrderDetailsPicks = this._saleOrderDetailsPickRepository.TableNoTracking.Where(o => o.OrderID == this.RequestDto.OrderId).ToList();
            var saleOrderPacking = this._saleOrderPackingRepository.TableNoTracking.FirstOrDefault(o => o.OrderID == this.RequestDto.OrderId);
            var saleOrderShelfAreas = this._saleOrderShelfAreaRepository.TableNoTracking.Where(o => o.OrderID == this.RequestDto.OrderId).ToList();
            var saleOrderTracks = this._saleOrderTrackRepository.TableNoTracking.Where(o => o.OrderID == this.RequestDto.OrderId).ToList();
            var saleOrdeSendNumber = this._saleOrdeSendNumberRepository.TableNoTracking.FirstOrDefault(o => o.OrderID == this.RequestDto.OrderId);

            //输出对象
            var responseDto = new SaleOrderGetDetailActionResponseDto()
            {
                SaleOrder = saleOrder,
                SaleOrderDetails = saleOrderDetails,
                SaleOrderDetailsExts = saleOrderDetailsExts,
                SaleOrderDetailsPicks = saleOrderDetailsPicks,
                SaleOrderPacking = saleOrderPacking,
                SaleOrderShelfAreas = saleOrderShelfAreas,
                SaleOrderTracks = saleOrderTracks,
                SaleOrdeSendNumber = saleOrdeSendNumber
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}