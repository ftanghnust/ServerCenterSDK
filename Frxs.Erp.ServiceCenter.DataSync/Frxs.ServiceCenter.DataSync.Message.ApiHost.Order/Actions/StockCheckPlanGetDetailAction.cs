using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("StockCheckPlan.Get.Detail")]
    public class StockCheckPlanGetDetailAction : ActionBase<StockCheckPlanGetDetailAction.StockCheckPlanGetDetailActionRequestDto, StockCheckPlanGetDetailAction.StockCheckPlanGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockCheckPlanGetDetailActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// SqlServer.nvarchar
            /// </summary>
            public String PlanID { get; set; }

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
        public class StockCheckPlanGetDetailActionResponseDto
        {
            /// <summary>
            ///盘点 主表
            /// </summary>
            public Models.StockCheckPlan StockCheckPlan { get; set; }

            /// <summary>
            ///盘点 明细列表
            /// </summary>
            public List<Models.StockCheckPlanDetail> StockCheckPlanDetails { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.StockCheckPlan> _stockCheckPlanRepository;
        private readonly IRepository<Models.StockCheckPlanDetail> _stockCheckPlanDetailRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="stockCheckPlanRepository">数据访问仓储</param>
        /// <param name="stockCheckPlanDetailRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        public StockCheckPlanGetDetailAction(
            IRepository<Models.StockCheckPlan> stockCheckPlanRepository,
            IRepository<Models.StockCheckPlanDetail> stockCheckPlanDetailRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._stockCheckPlanRepository = stockCheckPlanRepository;
            this._stockCheckPlanDetailRepository = stockCheckPlanDetailRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<StockCheckPlanGetDetailActionResponseDto> Execute()
        {
            var stockCheckPlan = this._stockCheckPlanRepository.TableNoTracking.FirstOrDefault(o => o.PlanID == this.RequestDto.PlanID);
            var stockCheckPlanDetails = this._stockCheckPlanDetailRepository.TableNoTracking.Where(o => o.PlanID == this.RequestDto.PlanID).ToList();

            //输出对象
            var responseDto = new StockCheckPlanGetDetailActionResponseDto()
            {
                StockCheckPlan = stockCheckPlan,
                StockCheckPlanDetails = stockCheckPlanDetails,
            };
            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}