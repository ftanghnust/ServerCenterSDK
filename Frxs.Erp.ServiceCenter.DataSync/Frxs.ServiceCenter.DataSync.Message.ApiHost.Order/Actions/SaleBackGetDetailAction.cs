using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 销售退货单 同步接口
    /// </summary>
    [ActionName("SaleBack.Get.Detail")]
    public class SaleBackGetDetailAction : ActionBase<SaleBackGetDetailAction.SaleBackGetDetailActionRequestDto, SaleBackGetDetailAction.SaleBackGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SaleBackGetDetailActionRequestDto : SystemRequestDtoBase
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
        public class SaleBackGetDetailActionResponseDto
        {
            /// <summary>
            ///销售退货单 主表
            /// </summary>
            public Models.SaleBack SaleBack { get; set; }

            /// <summary>
            ///销售退货单明细 列表
            /// </summary>
            public List<Models.SaleBackDetail> SaleBackDetails { get; set; }

            /// <summary>
            /// 销售退货单明细 扩展列表
            /// </summary>
            public List<Models.SaleBackDetailsExt> SaleBackDetailsExts { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.SaleBack> _saleBackRepository;
        private readonly IRepository<Models.SaleBackDetail> _saleBackDetailRepository;
        private readonly IRepository<Models.SaleBackDetailsExt> _saleBackDetailsExtRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="saleBackRepository">数据访问仓储</param>
        /// <param name="saleBackDetailsExtRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="saleBackDetailRepository"> </param>
        public SaleBackGetDetailAction(
            IRepository<Models.SaleBack> saleBackRepository,
            IRepository<Models.SaleBackDetail> saleBackDetailRepository,
            IRepository<Models.SaleBackDetailsExt> saleBackDetailsExtRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._saleBackRepository = saleBackRepository;
            this._saleBackDetailRepository = saleBackDetailRepository;
            this._saleBackDetailsExtRepository = saleBackDetailsExtRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<SaleBackGetDetailActionResponseDto> Execute()
        {
            var saleBack = this._saleBackRepository.TableNoTracking.FirstOrDefault(o => o.BackID == this.RequestDto.BackID);
            var saleBackDetails = this._saleBackDetailRepository.TableNoTracking.Where(o => o.BackID == this.RequestDto.BackID).ToList();
            var saleBackDetailsExts = this._saleBackDetailsExtRepository.TableNoTracking.Where(o => o.BackID == this.RequestDto.BackID).ToList();

            //输出对象
            var responseDto = new SaleBackGetDetailActionResponseDto()
            {
                SaleBack = saleBack,
                SaleBackDetails = saleBackDetails,
                SaleBackDetailsExts = saleBackDetailsExts
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}