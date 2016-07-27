using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using Frxs.ServiceCenter.DataSync.Message.ApiHost.Promotion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Promotion.Actions
{
    /// <summary>
    /// 门店销售订单促销信息 同步接口
    /// </summary>
    [ActionName("SaleOrderShop.Get.Detail")]
    public class SaleOrderShopGetDetailAction : ActionBase<SaleOrderShopGetDetailAction.SaleOrderShopGetDetailActionRequestDto, SaleOrderShopGetDetailAction.SaleOrderShopGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SaleOrderShopGetDetailActionRequestDto : SystemRequestDtoBase
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
        public class SaleOrderShopGetDetailActionResponseDto
        {
            /// <summary>
            ///门店销售订单促销信息 主表
            /// </summary>
            public SaleOrderShop SaleOrderShop { get; set; }

            /// <summary>
            ///门店销售订单促销信息 明细列表
            /// </summary>
            public List<SaleOrderShopDetail> SaleOrderShopDetails { get; set; }

            /// <summary>
            ///门店销售订单促销信息 明细扩展列表
            /// </summary>
            public List<SaleOrderShopDetailsExt> SaleOrderShopDetailsExts { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<SaleOrderShop> _saleOrderShopRepository;
        private readonly IRepository<SaleOrderShopDetail> _saleOrderShopDetailRepository;
        private readonly IRepository<SaleOrderShopDetailsExt> _saleOrderShopDetailsExtRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="saleOrderShopRepository">数据访问仓储</param>
        /// <param name="saleOrderShopDetailsExtRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="saleOrderShopDetailRepository"> </param>
        public SaleOrderShopGetDetailAction(
            IRepository<SaleOrderShop> saleOrderShopRepository,
            IRepository<SaleOrderShopDetail> saleOrderShopDetailRepository,
            IRepository<SaleOrderShopDetailsExt> saleOrderShopDetailsExtRepository,
            IDbContext dbContext, IUnitOfWork unitOfWork)
        {
            this._saleOrderShopRepository = saleOrderShopRepository;
            this._saleOrderShopDetailRepository = saleOrderShopDetailRepository;
            this._saleOrderShopDetailsExtRepository = saleOrderShopDetailsExtRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<SaleOrderShopGetDetailActionResponseDto> Execute()
        {
            var saleOrderShop = this._saleOrderShopRepository.TableNoTracking.FirstOrDefault(o => o.OrderId == this.RequestDto.OrderId);
            var saleOrderShopDetails = this._saleOrderShopDetailRepository.TableNoTracking.Where(o => o.OrderID == this.RequestDto.OrderId).ToList();
            var saleOrderShopDetailsExts = this._saleOrderShopDetailsExtRepository.TableNoTracking.Where(o => o.OrderID == this.RequestDto.OrderId).ToList();

            //输出对象
            var responseDto = new SaleOrderShopGetDetailActionResponseDto()
            {
                SaleOrderShop = saleOrderShop,
                SaleOrderShopDetails = saleOrderShopDetails,
                SaleOrderShopDetailsExts = saleOrderShopDetailsExts
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}