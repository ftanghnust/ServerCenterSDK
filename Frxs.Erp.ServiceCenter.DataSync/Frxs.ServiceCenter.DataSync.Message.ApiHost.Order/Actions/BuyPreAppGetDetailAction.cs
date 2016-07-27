using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    ///采购补货返配申请单  同步接口
    /// </summary>
    [ActionName("BuyPreApp.Get.Detail")]
    public class BuyPreAppGetDetailAction : ActionBase<BuyPreAppGetDetailAction.BuyPreAppGetDetailActionRequestDto, BuyPreAppGetDetailAction.BuyPreAppGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class BuyPreAppGetDetailActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// SqlServer.nvarchar
            /// </summary>
            public String AppID { get; set; }

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
        public class BuyPreAppGetDetailActionResponseDto
        {
            /// <summary>
            ///采购补货返配申请单 主表
            /// </summary>
            public Models.BuyPreApp BuyPreApp { get; set; }

            /// <summary>
            ///采购补货返配申请生成单据表 
            /// </summary>
            public List<Models.BuyPreAppBill> BuyPreAppBills { get; set; }


            /// <summary>
            ///采购补货返配申请明细 列表
            /// </summary>
            public List<Models.BuyPreAppDetail> BuyPreAppDetails { get; set; }

            /// <summary>
            /// 采购补货返配申请明细 扩展列表
            /// </summary>
            public List<Models.BuyPreAppDetailsExt> BuyPreAppDetailsExts { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.BuyPreApp> _buyPreAppRepository;
        private readonly IRepository<Models.BuyPreAppBill> _buyPreAppBillRepository;
        private readonly IRepository<Models.BuyPreAppDetail> _buyPreAppDetailRepository;
        private readonly IRepository<Models.BuyPreAppDetailsExt> _buyPreAppDetailsExtRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="buyPreAppRepository">数据访问仓储</param>
        /// <param name="buyPreAppDetailsExtRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="buyPreAppBillRepository"> </param>
        /// <param name="buyPreAppDetailRepository"> </param>
        public BuyPreAppGetDetailAction(
            IRepository<Models.BuyPreApp> buyPreAppRepository,
            IRepository<Models.BuyPreAppBill> buyPreAppBillRepository,
            IRepository<Models.BuyPreAppDetail> buyPreAppDetailRepository,
            IRepository<Models.BuyPreAppDetailsExt> buyPreAppDetailsExtRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._buyPreAppRepository = buyPreAppRepository;
            this._buyPreAppBillRepository = buyPreAppBillRepository;
            this._buyPreAppDetailRepository = buyPreAppDetailRepository;
            this._buyPreAppDetailsExtRepository = buyPreAppDetailsExtRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<BuyPreAppGetDetailActionResponseDto> Execute()
        {
            var buyOrderPre = this._buyPreAppRepository.TableNoTracking.FirstOrDefault(o => o.AppID == this.RequestDto.AppID);
            var buyPreAppBills = this._buyPreAppBillRepository.TableNoTracking.Where(o => o.AppID == this.RequestDto.AppID).ToList();
            var buyPreAppDetails = this._buyPreAppDetailRepository.TableNoTracking.Where(o => o.AppID == this.RequestDto.AppID).ToList();
            var buyPreAppDetailsExts = this._buyPreAppDetailsExtRepository.TableNoTracking.Where(o => o.AppID == this.RequestDto.AppID).ToList();

            //输出对象
            var responseDto = new BuyPreAppGetDetailActionResponseDto()
            {
                BuyPreApp = buyOrderPre,
                BuyPreAppBills = buyPreAppBills,
                BuyPreAppDetails = buyPreAppDetails,
                BuyPreAppDetailsExts = buyPreAppDetailsExts
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}