using System;
using System.Collections.Generic;
using System.Linq;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 预采购退货单 同步接口
    /// </summary>
    [ActionName("BuyBackPre.Get.Detail")]
    public class BuyBackPreGetDetailAction : ActionBase<BuyBackPreGetDetailAction.BuyBackPreGetDetailActionRequestDto, BuyBackPreGetDetailAction.BuyBackPreGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class BuyBackPreGetDetailActionRequestDto : SystemRequestDtoBase
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
        public class BuyBackPreGetDetailActionResponseDto
        {
            /// <summary>
            ///预采购退货单 主表
            /// </summary>
            public Models.BuyBackPre BuyBackPre { get; set; }

            /// <summary>
            ///预采购退货单 明细列表
            /// </summary>
            public List<Models.BuyBackPreDetail> BuyBackPreDetails { get; set; }

            /// <summary>
            /// 预采购退货单 扩展列表
            /// </summary>
            public List<Models.BuyBackPreDetailsExt> BuyBackPreDetailsExts { get; set; }

        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.BuyBackPre> _buyBackPreRepository;
        private readonly IRepository<Models.BuyBackPreDetail> _buyBackPreDetailRepository;
        private readonly IRepository<Models.BuyBackPreDetailsExt> _buyBackPreDetailsExtRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="buyBackPreRepository">数据访问仓储</param>
        /// <param name="buyBackPreDetailsExtRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="buyBackPreDetailRepository"> </param>
        public BuyBackPreGetDetailAction(
            IRepository<Models.BuyBackPre> buyBackPreRepository,
            IRepository<Models.BuyBackPreDetail> buyBackPreDetailRepository,
            IRepository<Models.BuyBackPreDetailsExt> buyBackPreDetailsExtRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._buyBackPreRepository = buyBackPreRepository;
            this._buyBackPreDetailRepository = buyBackPreDetailRepository;
            this._buyBackPreDetailsExtRepository = buyBackPreDetailsExtRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<BuyBackPreGetDetailActionResponseDto> Execute()
        {
            var buyBackPre = this._buyBackPreRepository.TableNoTracking.FirstOrDefault(o => o.BackID == this.RequestDto.BackID);
            var buyBackPreDetails = this._buyBackPreDetailRepository.TableNoTracking.Where(o => o.BackID == this.RequestDto.BackID).ToList();
            var buyBackPreDetailsExts = this._buyBackPreDetailsExtRepository.TableNoTracking.Where(o => o.BackID == this.RequestDto.BackID).ToList();
            
            //输出对象
            var responseDto = new BuyBackPreGetDetailActionResponseDto()
            {
                BuyBackPre = buyBackPre,
                BuyBackPreDetails = buyBackPreDetails,
                BuyBackPreDetailsExts = buyBackPreDetailsExts
            };

            //返回消息
            return this.SuccessActionResult(responseDto);

        }
    }
}