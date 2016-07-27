using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    ///销售改单 同步接口
    /// </summary>
    [ActionName("SaleEdit.Get.Detail")]
    public class SaleEditGetDetailAction : ActionBase<SaleEditGetDetailAction.SaleEditGetDetailActionRequestDto, SaleEditGetDetailAction.SaleEditGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SaleEditGetDetailActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// SqlServer.nvarchar
            /// </summary>
            public String EditID { get; set; }

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
        public class SaleEditGetDetailActionResponseDto
        {
            /// <summary>
            ///销售改单 主表
            /// </summary>
            public Models.SaleEdit SaleEdit { get; set; }

            /// <summary>
            ///销售改单 订单明细 列表 
            /// </summary>
            public List<Models.SaleEditOrder> SaleEditOrders { get; set; }


            /// <summary>
            ///销售改单  商品明细表
            /// </summary>
            public List<Models.SaleEditDetail> SaleEditDetails { get; set; }

            /// <summary>
            /// 销售改单 商品明细扩展列表
            /// </summary>
            public List<Models.SaleEditDetailsExt> SaleEditDetailsExts { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.SaleEdit> _saleEditRepository;
        private readonly IRepository<Models.SaleEditOrder> _saleEditOrderRepository;
        private readonly IRepository<Models.SaleEditDetail> _saleEditDetailRepository;
        private readonly IRepository<Models.SaleEditDetailsExt> _saleEditDetailsExtRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="saleEditRepository">数据访问仓储</param>
        /// <param name="saleEditDetailsExtRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="saleEditOrderRepository"> </param>
        /// <param name="saleEditDetailRepository"> </param>
        public SaleEditGetDetailAction(
            IRepository<Models.SaleEdit> saleEditRepository,
            IRepository<Models.SaleEditOrder> saleEditOrderRepository,
            IRepository<Models.SaleEditDetail> saleEditDetailRepository,
            IRepository<Models.SaleEditDetailsExt> saleEditDetailsExtRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._saleEditRepository = saleEditRepository;
            this._saleEditOrderRepository = saleEditOrderRepository;
            this._saleEditDetailRepository = saleEditDetailRepository;
            this._saleEditDetailsExtRepository = saleEditDetailsExtRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<SaleEditGetDetailActionResponseDto> Execute()
        {
            var saleEdit = this._saleEditRepository.TableNoTracking.FirstOrDefault(o => o.EditID == this.RequestDto.EditID);
            var saleEditOrders = this._saleEditOrderRepository.TableNoTracking.Where(o => o.EditID == this.RequestDto.EditID).ToList();
            var saleEditDetails = this._saleEditDetailRepository.TableNoTracking.Where(o => o.EditID == this.RequestDto.EditID).ToList();
            var saleEditDetailsExts = this._saleEditDetailsExtRepository.TableNoTracking.Where(o => o.EditID == this.RequestDto.EditID).ToList();

            //输出对象
            var responseDto = new SaleEditGetDetailActionResponseDto()
            {
                SaleEdit = saleEdit,
                SaleEditOrders = saleEditOrders,
                SaleEditDetails = saleEditDetails,
                SaleEditDetailsExts = saleEditDetailsExts
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}