using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 门店费用临时表 同步接口
    /// </summary>
    [ActionName("SaleFeePre.Get.Detail")]
    public class SaleFeePreGetDetailAction : ActionBase<SaleFeePreGetDetailAction.SaleFeePreGetDetailActionRequestDto, SaleFeePreGetDetailAction.SaleFeePreGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SaleFeePreGetDetailActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// SqlServer.nvarchar
            /// </summary>
            public String FeeID { get; set; }

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
        public class SaleFeePreGetDetailActionResponseDto
        {
            /// <summary>
            ///门店费用临时表 主表
            /// </summary>
            public Models.SaleFeePre SaleFeePre { get; set; }

            /// <summary>
            ///门店费用临时表  单据明细列表
            /// </summary>
            public List<Models.SaleFeePreDetail> SaleFeePreDetails { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.SaleFeePre> _saleFeePreRepository;
        private readonly IRepository<Models.SaleFeePreDetail> _saleFeePreDetailRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="saleFeePreRepository">数据访问仓储</param>
        /// <param name="saleFeePreDetailRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        public SaleFeePreGetDetailAction(
            IRepository<Models.SaleFeePre> saleFeePreRepository,
            IRepository<Models.SaleFeePreDetail> saleFeePreDetailRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._saleFeePreRepository = saleFeePreRepository;
            this._saleFeePreDetailRepository = saleFeePreDetailRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<SaleFeePreGetDetailActionResponseDto> Execute()
        {
            var saleFeePre = this._saleFeePreRepository.TableNoTracking.FirstOrDefault(o => o.FeeID == this.RequestDto.FeeID);
            var saleFeePreDetails = this._saleFeePreDetailRepository.TableNoTracking.Where(o => o.FeeID == this.RequestDto.FeeID).ToList();

            //输出对象
            var responseDto = new SaleFeePreGetDetailActionResponseDto()
            {
                SaleFeePre = saleFeePre,
                SaleFeePreDetails = saleFeePreDetails,
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}