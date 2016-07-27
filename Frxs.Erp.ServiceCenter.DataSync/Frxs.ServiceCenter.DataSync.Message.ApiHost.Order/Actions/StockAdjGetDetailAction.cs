using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 盘点调整主表(盘亏盘盈表) 同步接口
    /// </summary>
    [ActionName("StockAdj.Get.Detail")]
    public class StockAdjGetDetailAction : ActionBase<StockAdjGetDetailAction.StockAdjGetDetailActionRequestDto, StockAdjGetDetailAction.StockAdjGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockAdjGetDetailActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// SqlServer.nvarchar
            /// </summary>
            public String AdjID { get; set; }
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
        public class StockAdjGetDetailActionResponseDto
        {
            /// <summary>
            ///盘亏盘盈单 主表
            /// </summary>
            public Models.StockAdj StockAdj { get; set; }

            /// <summary>
            ///盘亏盘盈单 明细列表
            /// </summary>
            public List<Models.StockAdjDetail> StockAdjDetails { get; set; }

            /// <summary>
            ///盘亏盘盈单 明细列表
            /// </summary>
            public List<Models.StockAdjDetailsExt> StockAdjDetailsExts { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.StockAdj> _stockAdjRepository;
        private readonly IRepository<Models.StockAdjDetail> _stockAdjDetailRepository;
        private readonly IRepository<Models.StockAdjDetailsExt> _stockAdjDetailsExtRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="stockAdjRepository">数据访问仓储</param>
        /// <param name="stockAdjDetailRepository"> </param>
        /// <param name="stockAdjDetailsExtRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        public StockAdjGetDetailAction(
            IRepository<Models.StockAdj> stockAdjRepository,
            IRepository<Models.StockAdjDetail> stockAdjDetailRepository,
            IRepository<Models.StockAdjDetailsExt> stockAdjDetailsExtRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._stockAdjRepository = stockAdjRepository;
            this._stockAdjDetailRepository = stockAdjDetailRepository;
            this._stockAdjDetailsExtRepository = stockAdjDetailsExtRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<StockAdjGetDetailActionResponseDto> Execute()
        {
            var stockAdj = this._stockAdjRepository.TableNoTracking.FirstOrDefault(o => o.AdjID == this.RequestDto.AdjID);
            var stockAdjDetails = this._stockAdjDetailRepository.TableNoTracking.Where(o => o.AdjID == this.RequestDto.AdjID).ToList();
            var stockAdjDetailsExts = this._stockAdjDetailsExtRepository.TableNoTracking.Where(o => o.AdjID == this.RequestDto.AdjID).ToList();

            //输出对象
            var responseDto = new StockAdjGetDetailActionResponseDto()
            {
                StockAdj = stockAdj,
                StockAdjDetails = stockAdjDetails,
                StockAdjDetailsExts = stockAdjDetailsExts
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}