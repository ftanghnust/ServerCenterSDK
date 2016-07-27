using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Actions
{
    /// <summary>
    /// 数据字典领域
    /// </summary>
    [ActionName("SysDict.Get.Detail")]
    public class SysDictGetDetailAction : ActionBase<SysDictGetDetailAction.SysDictGetDetailActionRequestDto, SysDictGetDetailAction.SysDictGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SysDictGetDetailActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// SqlServer.nvarchar
            /// </summary>
            public String DictCode { get; set; }
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
        public class SysDictGetDetailActionResponseDto
        {
            /// <summary>
            ///数据字典主表
            /// </summary>
            public Models.SysDict SysDict { get; set; }

            /// <summary>
            /// 数据字典数据列表（从表）
            /// </summary>
            public List<Models.SysDictDetail> SysDictDetails { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.SysDict> _sysDictRepository;
        private readonly IRepository<Models.SysDictDetail> _sysDictDetailRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="sysDictRepository">数据访问仓储</param>
        /// <param name="sysDictDetailRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        public SysDictGetDetailAction(
            IRepository<Models.SysDict> sysDictRepository,
            IRepository<Models.SysDictDetail> sysDictDetailRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._sysDictRepository = sysDictRepository;
            this._sysDictDetailRepository = sysDictDetailRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<SysDictGetDetailActionResponseDto> Execute()
        {
            var sysDict = this._sysDictRepository.TableNoTracking.FirstOrDefault(o => o.DictCode == this.RequestDto.DictCode);
            var sysDictDetails = this._sysDictDetailRepository.TableNoTracking.Where(o => o.DictCode == this.RequestDto.DictCode).ToList();
            //输出对象
            var responseDto = new SysDictGetDetailActionResponseDto()
            {
                SysDict = sysDict,
                SysDictDetails = sysDictDetails,
            };
            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}