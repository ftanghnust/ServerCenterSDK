using System;
using System.Collections.Generic;
using System.Linq;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 采购退货单 同步接口
    /// </summary>
    [ActionName("BuyBack.Get.Detail")]
    public class BuyBackGetDetailAction : ActionBase<BuyBackGetDetailAction.BuyBackGetDetailActionRequestDto, BuyBackGetDetailAction.BuyBackGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class BuyBackGetDetailActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// SqlServer.nvarchar
            /// </summary>
            public String BackID { get; set; }

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
        public class BuyBackGetDetailActionResponseDto
        {
            /// <summary>
            ///采购退货单 主表
            /// </summary>
            public Models.BuyBack BuyBack { get; set; }

            /// <summary>
            ///采购退货单 明细列表
            /// </summary>
            public List<Models.BuyBackDetail> BuyBackDetails { get; set; }

            /// <summary>
            /// 采购退货单 扩展列表
            /// </summary>
            public List<Models.BuyBackDetailsExt> BuyBackDetailsExts { get; set; }

        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.BuyBack> _buyBackRepository;
        private readonly IRepository<Models.BuyBackDetail> _buyBackDetailRepository;
        private readonly IRepository<Models.BuyBackDetailsExt> _buyBackDetailsExtRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="buyBackRepository">数据访问仓储</param>
        /// <param name="buyBackDetailRepository">数据访问仓储 </param>
        /// <param name="buyBackDetailsExtRepository"> 数据访问仓储</param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        public BuyBackGetDetailAction(
            IRepository<Models.BuyBack> buyBackRepository,
            IRepository<Models.BuyBackDetail> buyBackDetailRepository,
            IRepository<Models.BuyBackDetailsExt> buyBackDetailsExtRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._buyBackRepository = buyBackRepository;
            this._buyBackDetailRepository = buyBackDetailRepository;
            this._buyBackDetailsExtRepository = buyBackDetailsExtRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<BuyBackGetDetailActionResponseDto> Execute()
        {
            var buyBack = this._buyBackRepository.TableNoTracking.FirstOrDefault(o => o.BackID == this.RequestDto.BackID);
            var buyBackDetails = this._buyBackDetailRepository.TableNoTracking.Where(o => o.BackID == this.RequestDto.BackID).ToList();
            var buyBackDetailsExts = this._buyBackDetailsExtRepository.TableNoTracking.Where(o => o.BackID == this.RequestDto.BackID).ToList();

            //输出对象
            var responseDto = new BuyBackGetDetailActionResponseDto()
            {
                BuyBack = buyBack,
                BuyBackDetails = buyBackDetails,
                BuyBackDetailsExts = buyBackDetailsExts
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}