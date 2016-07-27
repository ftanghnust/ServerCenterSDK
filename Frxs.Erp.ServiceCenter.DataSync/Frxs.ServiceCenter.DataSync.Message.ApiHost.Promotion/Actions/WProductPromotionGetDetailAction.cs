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
    /// 同步接口
    /// </summary>
    [ActionName("WProductPromotion.Get.Detail")]
    public class WProductPromotionGetDetailAction : ActionBase<WProductPromotionGetDetailAction.WProductPromotionGetDetailActionRequestDto, WProductPromotionGetDetailAction.WProductPromotionGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductPromotionGetDetailActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// SqlServer.nvarchar
            /// </summary>
            public String PromotionID { get; set; }

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
        public class WProductPromotionGetDetailActionResponseDto
        {
            /// <summary>
            ///商品促销信息 主表
            /// </summary>
            public WProductPromotion WProductPromotion { get; set; }

            /// <summary>
            ///商品促销仓库商品 明细列表
            /// </summary>
            public List<WProductPromotionDetail> WProductPromotionDetails { get; set; }

            /// <summary>
            ///商品促销门店 列表
            /// </summary>
            public List<WProductPromotionShop> WProductPromotionShops { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<WProductPromotion> _wProductPromotionRepository;
        private readonly IRepository<WProductPromotionDetail> _wProductPromotionDetailRepository;
        private readonly IRepository<WProductPromotionShop> _wProductPromotionShopRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="wProductPromotionRepository">数据访问仓储</param>
        /// <param name="wProductPromotionShopRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="wProductPromotionDetailRepository"> </param>
        public WProductPromotionGetDetailAction(
            IRepository<WProductPromotion> wProductPromotionRepository,
            IRepository<WProductPromotionDetail> wProductPromotionDetailRepository,
            IRepository<WProductPromotionShop> wProductPromotionShopRepository,
            IDbContext dbContext, IUnitOfWork unitOfWork)
        {
            this._wProductPromotionRepository = wProductPromotionRepository;
            this._wProductPromotionDetailRepository = wProductPromotionDetailRepository;
            this._wProductPromotionShopRepository = wProductPromotionShopRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行以为逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<WProductPromotionGetDetailActionResponseDto> Execute()
        {
            var wProductPromotion = this._wProductPromotionRepository.TableNoTracking.FirstOrDefault(o => o.PromotionID == this.RequestDto.PromotionID);
            var wProductPromotionDetails = this._wProductPromotionDetailRepository.TableNoTracking.Where(o => o.PromotionID == this.RequestDto.PromotionID).ToList();
            var wProductPromotionShops = this._wProductPromotionShopRepository.TableNoTracking.Where(o => o.PromotionID == this.RequestDto.PromotionID).ToList();

            //输出对象
            var responseDto = new WProductPromotionGetDetailActionResponseDto()
            {
                WProductPromotion = wProductPromotion,
                WProductPromotionDetails = wProductPromotionDetails,
                WProductPromotionShops = wProductPromotionShops
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}