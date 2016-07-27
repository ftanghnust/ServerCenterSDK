using System;
using System.Collections.Generic;
using System.Linq;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Actions
{
    /// <summary>
    /// 仓库商品 领域
    /// </summary>
    [ActionName("WProduct.Get.Detail")]
    public class WProductGetDetailAction : ActionBase<WProductGetDetailAction.WProductGetDetailActionRequestDto, WProductGetDetailAction.WProductGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductGetDetailActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// SqlServer.bigint
            /// </summary>
            public Int64 WProductID { get; set; }
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
        /// 下送的数据
        /// </summary>
        public class WProductGetDetailActionResponseDto
        {
            /// <summary>
            /// 仓库商品信息
            /// </summary>
            public Models.WProduct WProduct { get; set; }

            /// <summary>
            /// 仓库商品采购信息
            /// </summary>
            public Models.WProductsBuy WProductsBuy { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.WProduct> _wProductRepository;
        private readonly IRepository<Models.WProductsBuy> _wProductsBuyRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="wProductRepository">数据访问仓储</param>
        /// <param name="wProductsBuyRepository">数据访问仓储 </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        public WProductGetDetailAction(
            IRepository<Models.WProduct> wProductRepository,
            IRepository<Models.WProductsBuy> wProductsBuyRepository,
            IDbContext dbContext, IUnitOfWork unitOfWork)
        {
            this._wProductRepository = wProductRepository;
            this._wProductsBuyRepository = wProductsBuyRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<WProductGetDetailActionResponseDto> Execute()
        {
            var wProduct = this._wProductRepository.TableNoTracking.FirstOrDefault(o => o.WProductID == this.RequestDto.WProductID);
            var wProductsBuy =
                this._wProductsBuyRepository.TableNoTracking.FirstOrDefault(
                    o => o.WProductID == this.RequestDto.WProductID);
            //输出对象
            var responseDto = new WProductGetDetailActionResponseDto()
            {
                WProduct = wProduct,
                WProductsBuy = wProductsBuy,

            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}