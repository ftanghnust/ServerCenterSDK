using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 采购收货单 同步接口
    /// </summary>
    [ActionName("BuyOrder.Get.Detail")]
    public class BuyOrderGetDetailAction : ActionBase<BuyOrderGetDetailAction.BuyOrderGetDetailActionRequestDto, BuyOrderGetDetailAction.BuyOrderGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class BuyOrderGetDetailActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// SqlServer.nvarchar
            /// </summary>
            public String BuyID { get; set; }

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
        public class BuyOrderGetDetailActionResponseDto
        {
            /// <summary>
            ///采购收货单 主表
            /// </summary>
            public Models.BuyOrder BuyOrder { get; set; }

            /// <summary>
            ///采购收货单 明细列表
            /// </summary>
            public List<Models.BuyOrderDetail> BuyOrderDetails { get; set; }

            /// <summary>
            /// 采购收货单 扩展列表
            /// </summary>
            public List<Models.BuyOrderDetailsExt> BuyOrderDetailsExts { get; set; }

        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.BuyOrder> _buyOrderRepository;
        private readonly IRepository<Models.BuyOrderDetail> _buyOrderDetailRepository;
        private readonly IRepository<Models.BuyOrderDetailsExt> _buyOrderDetailsExtRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="buyOrderRepository">数据访问仓储</param>
        /// <param name="buyOrderDetailsExtRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="buyOrderDetailRepository"> </param>
        public BuyOrderGetDetailAction(
            IRepository<Models.BuyOrder> buyOrderRepository,
            IRepository<Models.BuyOrderDetail> buyOrderDetailRepository,
            IRepository<Models.BuyOrderDetailsExt> buyOrderDetailsExtRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._buyOrderRepository = buyOrderRepository;
            this._buyOrderDetailRepository = buyOrderDetailRepository;
            this._buyOrderDetailsExtRepository = buyOrderDetailsExtRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<BuyOrderGetDetailActionResponseDto> Execute()
        {
            var buyOrder = this._buyOrderRepository.TableNoTracking.FirstOrDefault(o => o.BuyID == this.RequestDto.BuyID);
            var buyOrderDetails = this._buyOrderDetailRepository.TableNoTracking.Where(o => o.BuyID == this.RequestDto.BuyID).ToList();
            var buyOrderDetailsExts = this._buyOrderDetailsExtRepository.TableNoTracking.Where(o => o.BuyID == this.RequestDto.BuyID).ToList();
            
            //输出对象
            var responseDto = new BuyOrderGetDetailActionResponseDto()
            {
                BuyOrder = buyOrder,
                BuyOrderDetails = buyOrderDetails,
                BuyOrderDetailsExts = buyOrderDetailsExts
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}