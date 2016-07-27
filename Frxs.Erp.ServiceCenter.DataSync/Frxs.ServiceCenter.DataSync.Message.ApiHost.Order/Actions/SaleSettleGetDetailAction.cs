using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 门店结算单 同步接口
    /// </summary>
    [ActionName("SaleSettle.Get.Detail")]
    public class SaleSettleGetDetailAction : ActionBase<SaleSettleGetDetailAction.SaleSettleGetDetailActionRequestDto, SaleSettleGetDetailAction.SaleSettleGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SaleSettleGetDetailActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// SqlServer.nvarchar
            /// </summary>
            public String SettleID { get; set; }
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
        public class SaleSettleGetDetailActionResponseDto
        {
            /// <summary>
            ///门店结算单 主表
            /// </summary>
            public Models.SaleSettle SaleSettle { get; set; }

            /// <summary>
            ///门店结算单 明细列表
            /// </summary>
            public List<Models.SaleSettleDetail> SaleSettleDetails { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.SaleSettle> _saleSettleRepository;
        private readonly IRepository<Models.SaleSettleDetail> _saleSettleDetailRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="saleSettleRepository">数据访问仓储</param>
        /// <param name="saleSettleDetailRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        public SaleSettleGetDetailAction(
            IRepository<Models.SaleSettle> saleSettleRepository,
            IRepository<Models.SaleSettleDetail> saleSettleDetailRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._saleSettleRepository = saleSettleRepository;
            this._saleSettleDetailRepository = saleSettleDetailRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<SaleSettleGetDetailActionResponseDto> Execute()
        {
            var saleSettle = this._saleSettleRepository.TableNoTracking.FirstOrDefault(o => o.SettleID == this.RequestDto.SettleID);
            var saleSettleDetails = this._saleSettleDetailRepository.TableNoTracking.Where(o => o.SettleID == this.RequestDto.SettleID).ToList();

            //输出对象
            var responseDto = new SaleSettleGetDetailActionResponseDto()
            {
                SaleSettle = saleSettle,
                SaleSettleDetails = saleSettleDetails
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}