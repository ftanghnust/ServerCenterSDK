using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 同步接口
    /// </summary>
    [ActionName("BuyOrderPre.Get.Detail")]
    public class BuyOrderPreGetDetailAction : ActionBase<BuyOrderPreGetDetailAction.BuyOrderPreGetDetailActionRequestDto, BuyOrderPreGetDetailAction.BuyOrderPreGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class BuyOrderPreGetDetailActionRequestDto : SystemRequestDtoBase
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
        public class BuyOrderPreGetDetailActionResponseDto
        {
            /// <summary>
            ///采购收货单 主表
            /// </summary>
            public Models.BuyOrderPre BuyOrderPre { get; set; }

            /// <summary>
            ///采购收货单 明细列表
            /// </summary>
            public List<Models.BuyOrderPreDetail> BuyOrderPreDetails { get; set; }

            /// <summary>
            /// 采购收货单 扩展列表
            /// </summary>
            public List<Models.BuyOrderPreDetailsExt> BuyOrderPreDetailsExts { get; set; }

        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.BuyOrderPre> _buyOrderPreRepository;
        private readonly IRepository<Models.BuyOrderPreDetail> _buyOrderPreDetailRepository;
        private readonly IRepository<Models.BuyOrderPreDetailsExt> _buyOrderPreDetailsExtRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;


        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="buyOrderPreRepository">数据访问仓储</param>
        /// <param name="buyOrderPreDetailRepository"> </param>
        /// <param name="buyOrderPreDetailsExtRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        public BuyOrderPreGetDetailAction(
            IRepository<Models.BuyOrderPre> buyOrderPreRepository,
            IRepository<Models.BuyOrderPreDetail> buyOrderPreDetailRepository,
            IRepository<Models.BuyOrderPreDetailsExt> buyOrderPreDetailsExtRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._buyOrderPreRepository = buyOrderPreRepository;
            this._buyOrderPreDetailRepository = buyOrderPreDetailRepository;
            this._buyOrderPreDetailsExtRepository = buyOrderPreDetailsExtRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<BuyOrderPreGetDetailActionResponseDto> Execute()
        {
            var buyOrderPre = this._buyOrderPreRepository.TableNoTracking.FirstOrDefault(o => o.BuyID == this.RequestDto.BuyID);
            var buyOrderPreDetails = this._buyOrderPreDetailRepository.TableNoTracking.Where(o => o.BuyID == this.RequestDto.BuyID).ToList();
            var buyOrderPreDetailsExts = this._buyOrderPreDetailsExtRepository.TableNoTracking.Where(o => o.BuyID == this.RequestDto.BuyID).ToList();

            //输出对象
            var responseDto = new BuyOrderPreGetDetailActionResponseDto()
            {
                BuyOrderPre = buyOrderPre,
                BuyOrderPreDetails = buyOrderPreDetails,
                BuyOrderPreDetailsExts = buyOrderPreDetailsExts
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}