using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 门店费用表 同步接口
    /// </summary>
    [ActionName("SaleFee.Get.Detail")]
    public class SaleFeeGetDetailAction : ActionBase<SaleFeeGetDetailAction.SaleFeeGetDetailActionRequestDto, SaleFeeGetDetailAction.SaleFeeGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SaleFeeGetDetailActionRequestDto : SystemRequestDtoBase
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
        public class SaleFeeGetDetailActionResponseDto
        {
            /// <summary>
            ///门店费用单 主表
            /// </summary>
            public Models.SaleFee SaleFee { get; set; }

            /// <summary>
            ///门店费用单  单据明细表
            /// </summary>
            public List<Models.SaleFeeDetail> SaleFeeDetails { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.SaleFee> _saleFeeRepository;
        private readonly IRepository<Models.SaleFeeDetail> _saleFeeDetailRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="saleFeeRepository">数据访问仓储</param>
        /// <param name="saleFeeDetailRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        public SaleFeeGetDetailAction(
            IRepository<Models.SaleFee> saleFeeRepository,
            IRepository<Models.SaleFeeDetail> saleFeeDetailRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._saleFeeRepository = saleFeeRepository;
            this._saleFeeDetailRepository = saleFeeDetailRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<SaleFeeGetDetailActionResponseDto> Execute()
        {
            var saleFee = this._saleFeeRepository.TableNoTracking.FirstOrDefault(o => o.FeeID == this.RequestDto.FeeID);
            var saleFeeDetails = this._saleFeeDetailRepository.TableNoTracking.Where(o => o.FeeID == this.RequestDto.FeeID).ToList();

            //输出对象
            var responseDto = new SaleFeeGetDetailActionResponseDto()
            {
                SaleFee = saleFee,
                SaleFeeDetails = saleFeeDetails,
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}