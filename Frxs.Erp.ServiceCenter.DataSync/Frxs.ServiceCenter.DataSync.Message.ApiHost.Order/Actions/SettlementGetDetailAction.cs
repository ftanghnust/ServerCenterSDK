using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 日结算单 同步接口
    /// </summary>
    [ActionName("Settlement.Get.Detail")]
    public class SettlementGetDetailAction : ActionBase<SettlementGetDetailAction.SettlementGetDetailActionRequestDto, SettlementGetDetailAction.SettlementGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SettlementGetDetailActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// SqlServer.nvarchar
            /// </summary>
            public String ID { get; set; }

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
        public class SettlementGetDetailActionResponseDto
        {
            /// <summary>
            ///日结算单 主表
            /// </summary>
            public Models.Settlement Settlement { get; set; }

            /// <summary>
            ///日结算单 明细列表
            /// </summary>
            public List<Models.SettlementDetail> SettlementDetails { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.Settlement> _settlementRepository;
        private readonly IRepository<Models.SettlementDetail> _settlementDetailRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="settlementRepository">数据访问仓储</param>
        /// <param name="settlementDetailRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        public SettlementGetDetailAction(
            IRepository<Models.Settlement> settlementRepository,
            IRepository<Models.SettlementDetail> settlementDetailRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._settlementRepository = settlementRepository;
            this._settlementDetailRepository = settlementDetailRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 业务执行逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<SettlementGetDetailActionResponseDto> Execute()
        {
            var settlement = this._settlementRepository.TableNoTracking.FirstOrDefault(o => o.ID == this.RequestDto.ID);
            var settlementDetails = this._settlementDetailRepository.TableNoTracking.Where(o => o.RefSet_ID == this.RequestDto.ID).ToList();

            //输出对象
            var responseDto = new SettlementGetDetailActionResponseDto()
            {
                Settlement = settlement,
                SettlementDetails = settlementDetails
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}