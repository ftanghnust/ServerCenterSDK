using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    ///  预销售订单 同步接口
    /// </summary>
    [ActionName("SaleOrderPre.Get.Detail")]
    public class SaleOrderPreGetDetailAction : ActionBase<SaleOrderPreGetDetailAction.SaleOrderPreGetDetailActionRequestDto, SaleOrderPreGetDetailAction.SaleOrderPreGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SaleOrderPreGetDetailActionRequestDto : SystemRequestDtoBase
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
        public class SaleOrderPreGetDetailActionResponseDto
        {
            /// <summary>
            ///预销售订单 主表
            /// </summary>
            public Models.SaleOrderPre SaleOrderPre { get; set; }

            /// <summary>
            ///预销售订单 商品明细列表
            /// </summary>
            public List<Models.SaleOrderPreDetail> SaleOrderPreDetails { get; set; }

            /// <summary>
            ///预销售订单 商品明细扩展列表
            /// </summary>
            public List<Models.SaleOrderPreDetailsExt> SaleOrderPreDetailsExts { get; set; }

            /// <summary>
            ///预销售订单 商品拣货明细列表
            /// </summary>
            public List<Models.SaleOrderPreDetailsPick> SaleOrderPreDetailsPicks { get; set; }

            /// <summary>
            ///预销售订单 装箱数表
            /// </summary>
            public Models.SaleOrderPrePacking SaleOrderPrePacking { get; set; }

            /// <summary>
            ///预销售订单 待拣货区列表 
            /// </summary>
            public List<Models.SaleOrderPreShelfArea> SaleOrderPreShelfAreas { get; set; }

        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.SaleOrderPre> _saleOrderPreRepository;
        private readonly IRepository<Models.SaleOrderPreDetail> _saleOrderPreDetailRepository;
        private readonly IRepository<Models.SaleOrderPreDetailsExt> _saleOrderPreDetailsExtRepository;
        private readonly IRepository<Models.SaleOrderPreDetailsPick> _saleOrderPreDetailsPickRepository;
        private readonly IRepository<Models.SaleOrderPrePacking> _saleOrderPrePackingRepository;
        private readonly IRepository<Models.SaleOrderPreShelfArea> _saleOrderPreShelfAreaRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="saleOrderPreRepository">数据访问仓储</param>
        /// <param name="saleOrderPreShelfAreaRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="saleOrderPreDetailRepository"> </param>
        /// <param name="saleOrderPreDetailsExtRepository"> </param>
        /// <param name="saleOrderPreDetailsPickRepository"> </param>
        /// <param name="saleOrderPrePackingRepository"> </param>
        public SaleOrderPreGetDetailAction(
            IRepository<Models.SaleOrderPre> saleOrderPreRepository,
            IRepository<Models.SaleOrderPreDetail> saleOrderPreDetailRepository,
            IRepository<Models.SaleOrderPreDetailsExt> saleOrderPreDetailsExtRepository,
            IRepository<Models.SaleOrderPreDetailsPick> saleOrderPreDetailsPickRepository,
            IRepository<Models.SaleOrderPrePacking> saleOrderPrePackingRepository,
            IRepository<Models.SaleOrderPreShelfArea> saleOrderPreShelfAreaRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._saleOrderPreRepository = saleOrderPreRepository;
            this._saleOrderPreDetailRepository = saleOrderPreDetailRepository;
            this._saleOrderPreDetailsExtRepository = saleOrderPreDetailsExtRepository;
            this._saleOrderPreDetailsPickRepository = saleOrderPreDetailsPickRepository;
            this._saleOrderPrePackingRepository = saleOrderPrePackingRepository;
            this._saleOrderPreShelfAreaRepository = saleOrderPreShelfAreaRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<SaleOrderPreGetDetailActionResponseDto> Execute()
        {
            var saleOrderPre = this._saleOrderPreRepository.TableNoTracking.FirstOrDefault(o => o.OrderId == this.RequestDto.OrderId);
            var saleOrderPreDetails = this._saleOrderPreDetailRepository.TableNoTracking.Where(o => o.OrderID == this.RequestDto.OrderId).ToList();
            var saleOrderPreDetailsExts = this._saleOrderPreDetailsExtRepository.TableNoTracking.Where(o => o.OrderID == this.RequestDto.OrderId).ToList();
            var saleOrderPreDetailsPicks = this._saleOrderPreDetailsPickRepository.TableNoTracking.Where(o => o.OrderID == this.RequestDto.OrderId).ToList();
            var saleOrderPrePacking = this._saleOrderPrePackingRepository.TableNoTracking.FirstOrDefault(o => o.OrderID == this.RequestDto.OrderId);
            var saleOrderPreShelfAreas = this._saleOrderPreShelfAreaRepository.TableNoTracking.Where(o => o.OrderID == this.RequestDto.OrderId).ToList();

            //输出对象
            var responseDto = new SaleOrderPreGetDetailActionResponseDto()
            {
                SaleOrderPre = saleOrderPre,
                SaleOrderPreDetails = saleOrderPreDetails,
                SaleOrderPreDetailsExts = saleOrderPreDetailsExts,
                SaleOrderPreDetailsPicks = saleOrderPreDetailsPicks,
                SaleOrderPrePacking = saleOrderPrePacking,
                SaleOrderPreShelfAreas = saleOrderPreShelfAreas,
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}