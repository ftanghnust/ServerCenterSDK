using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    ///盘点  同步接口
    /// </summary>
    [ActionName("StockCheck.Get.Detail")]
    public class StockCheckGetDetailAction : ActionBase<StockCheckGetDetailAction.StockCheckGetDetailActionRequestDto, StockCheckGetDetailAction.StockCheckGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockCheckGetDetailActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// SqlServer.nvarchar
            /// </summary>
            public String StockCheckID { get; set; }
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
        public class StockCheckGetDetailActionResponseDto
        {
            /// <summary>
            ///盘点 主表
            /// </summary>
            public Models.StockCheck StockCheck { get; set; }

            /// <summary>
            ///盘点 明细列表
            /// </summary>
            public List<Models.StockCheckDetail> StockCheckDetails { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.StockCheck> _stockCheckRepository;
        private readonly IRepository<Models.StockCheckDetail> _stockCheckDetailRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="stockCheckRepository">数据访问仓储</param>
        /// <param name="stockCheckDetailRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        public StockCheckGetDetailAction(
            IRepository<Models.StockCheck> stockCheckRepository,
            IRepository<Models.StockCheckDetail> stockCheckDetailRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._stockCheckRepository = stockCheckRepository;
            this._stockCheckDetailRepository = stockCheckDetailRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<StockCheckGetDetailActionResponseDto> Execute()
        {
            var stockCheck = this._stockCheckRepository.TableNoTracking.FirstOrDefault(o => o.StockCheckID == this.RequestDto.StockCheckID);
            var stockCheckDetails = this._stockCheckDetailRepository.TableNoTracking.Where(o => o.CheckStockID == this.RequestDto.StockCheckID).ToList();

            //输出对象
            var responseDto = new StockCheckGetDetailActionResponseDto()
            {
                StockCheck = stockCheck,
                StockCheckDetails = stockCheckDetails,

            };
            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}