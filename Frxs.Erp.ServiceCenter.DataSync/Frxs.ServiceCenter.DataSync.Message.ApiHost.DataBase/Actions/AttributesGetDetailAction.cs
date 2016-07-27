using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Actions
{
    /// <summary>
    /// 同步接口
    /// </summary>
    [ActionName("Attribute.Get.Detail")]
    public class AttributesGetDetailAction : ActionBase<AttributesGetDetailAction.AttributeGetDetailActionRequestDto, AttributesGetDetailAction.AttributeGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class AttributeGetDetailActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// SqlServer.int
            /// </summary>
            public Int32 AttributeId { get; set; }
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
        public class AttributeGetDetailActionResponseDto
        {
            /// <summary>
            ///商品规格属性主表
            /// </summary>
            public Models.Attribute Attribute { get; set; }

            /// <summary>
            /// 商品规格属性值表
            /// </summary>
            public List<Models.AttributesValue> AttributesValues { get; set; }

        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.Attribute> _attributeRepository;
        private readonly IRepository<Models.AttributesValue> _attributesValueRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="attributeRepository">数据访问仓储</param>
        /// <param name="attributesValueRepository">数据访问仓储 </param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        public AttributesGetDetailAction(
            IRepository<Models.Attribute> attributeRepository,
            IRepository<Models.AttributesValue> attributesValueRepository,
            IDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this._attributeRepository = attributeRepository;
            this._attributesValueRepository = attributesValueRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<AttributeGetDetailActionResponseDto> Execute()
        {
            var attribute = this._attributeRepository.TableNoTracking.FirstOrDefault(o => o.AttributeId == this.RequestDto.AttributeId);
            var attributesValues = this._attributesValueRepository.TableNoTracking.Where(o => o.AttributeId == this.RequestDto.AttributeId).ToList();
            //输出对象
            var responseDto = new AttributeGetDetailActionResponseDto()
            {
                Attribute = attribute,
                AttributesValues = attributesValues,
            };
            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}