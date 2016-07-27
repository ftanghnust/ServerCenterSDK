using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 同步接口
    /// </summary>
    [ActionName("SaleBackPre.Get.Detail")]
    public class SaleBackPreGetDetailAction : ActionBase<SaleBackPreGetDetailAction.SaleBackPreGetDetailActionRequestDto, SaleBackPreGetDetailAction.SaleBackPreGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SaleBackPreGetDetailActionRequestDto : SystemRequestDtoBase
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
        public class SaleBackPreGetDetailActionResponseDto
        {
            /// <summary>
            ///预销售退货单 主表
            /// </summary>
            public Models.SaleBackPre SaleBackPre { get; set; }

            /// <summary>
            ///预销售退货单明细 列表
            /// </summary>
            public List<Models.SaleBackPreDetail> SaleBackPreDetails { get; set; }

            /// <summary>
            /// 预销售退货单明细 扩展列表
            /// </summary>
            public List<Models.SaleBackPreDetailsExt> SaleBackPreDetailsExts { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.SaleBackPre> _saleBackPreRepository;
        private readonly IRepository<Models.SaleBackPreDetail> _saleBackPreDetailRepository;
        private readonly IRepository<Models.SaleBackPreDetailsExt> _saleBackPreDetailsExtRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="saleBackPreRepository">数据访问仓储</param>
        /// <param name="saleBackPreDetailsExtRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="saleBackPreDetailRepository"> </param>
        public SaleBackPreGetDetailAction(
            IRepository<Models.SaleBackPre> saleBackPreRepository,
            IRepository<Models.SaleBackPreDetail> saleBackPreDetailRepository,
            IRepository<Models.SaleBackPreDetailsExt> saleBackPreDetailsExtRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._saleBackPreRepository = saleBackPreRepository;
            this._saleBackPreDetailRepository = saleBackPreDetailRepository;
            this._saleBackPreDetailsExtRepository = saleBackPreDetailsExtRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<SaleBackPreGetDetailActionResponseDto> Execute()
        {
            var saleBackPre = this._saleBackPreRepository.TableNoTracking.FirstOrDefault(o => o.BackID == this.RequestDto.BackID);
            var saleBackPreDetails = this._saleBackPreDetailRepository.TableNoTracking.Where(o => o.BackID == this.RequestDto.BackID).ToList();
            var saleBackPreDetailsExts = this._saleBackPreDetailsExtRepository.TableNoTracking.Where(o => o.BackID == this.RequestDto.BackID).ToList();

            //输出对象
            var responseDto = new SaleBackPreGetDetailActionResponseDto()
            {
                SaleBackPre = saleBackPre,
                SaleBackPreDetails = saleBackPreDetails,
                SaleBackPreDetailsExts = saleBackPreDetailsExts
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}