/* ***************************************************************************
 * <auto-generated>
 *     This code was generated by a tool.
 *     Runtime Version:4.0.30319.42000
 *     Changes to this file may cause incorrect behavior and will be lost if
 *     the code is regenerated.
 * </auto-generated>
 * ***************************************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/07/26 17:07:14.206
 * **************************************************************************/
using System;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 同步接口 - 数据表：SaleEditDetailsExt
    /// </summary>
    [ActionName("SaleEditDetailsExt.Get")]
    public class SaleEditDetailsExtGetAction :
        ActionBase<SaleEditDetailsExtGetAction.SaleEditDetailsExtGetActionRequestDto, Models.SaleEditDetailsExt>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SaleEditDetailsExtGetActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// SqlServer.nvarchar
            /// </summary>
            public String ID { get; set; }
            
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
        /// 
        /// </summary>
        private readonly IRepository<Models.SaleEditDetailsExt> _saleEditDetailsExtRepository;
        private readonly IDbContext _dbContext;
        
        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="saleEditDetailsExtRepository">数据访问仓储</param>
        /// <param name="dbContext">数据操作上下文</param>
        public SaleEditDetailsExtGetAction(
            IRepository<Models.SaleEditDetailsExt> saleEditDetailsExtRepository, 
            IDbContext dbContext)
        {
            this._saleEditDetailsExtRepository = saleEditDetailsExtRepository;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Models.SaleEditDetailsExt> Execute()
        {
            return this.SuccessActionResult(this._saleEditDetailsExtRepository.TableNoTracking
                            .FirstOrDefault(o => o.ID == this.RequestDto.ID));
        }
    }

    /// <summary>
    /// 同步接口 - 数据表：SaleEditDetailsExt
    /// </summary>
    [ActionName("SaleEditDetailsExt.Get.List")]
    public class SaleEditDetailsExtGetListAction :
        ActionBase<SaleEditDetailsExtGetListAction.SaleEditDetailsExtGetActionRequestDto, PagedList<Models.SaleEditDetailsExt>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SaleEditDetailsExtGetActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// 页码大小，默认100
            /// </summary>
            public int PageSize { get; set; }

            /// <summary>
            /// 当前页，注意：从0开始
            /// </summary>
            public int PageIndex { get; set; }

            /// <summary>
            /// 总记录数，第一次访问不需要传，第二次回送，提高检索速度
            /// </summary>
            public int TotalCount { get; set; }

            /// <summary>
            /// 最后修改时间
            /// </summary>
            public DateTime? ModifyTime { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public override void BeforeValid()
            {
                if (this.PageSize <= 0)
                {
                    this.PageSize = 100;
                }
                if (this.PageIndex < 0)
                {
                    this.PageIndex = 0;
                }
                base.BeforeValid();
            }

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
        /// 
        /// </summary>
        private readonly IRepository<Models.SaleEditDetailsExt> _saleEditDetailsExtRepository;
        private readonly IDbContext _dbContext;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="saleEditDetailsExtRepository">数据访问仓储</param>
        /// <param name="dbContext">数据操作上下文</param>
        public SaleEditDetailsExtGetListAction(
            IRepository<Models.SaleEditDetailsExt> saleEditDetailsExtRepository,
            IDbContext dbContext)
        {
            this._saleEditDetailsExtRepository = saleEditDetailsExtRepository;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<PagedList<Models.SaleEditDetailsExt>> Execute()
        {
            //查询 SaleEditDetailsExt 表数据
            var query = this._saleEditDetailsExtRepository.TableNoTracking;

            //当前修改时间是否存在
            if (this.RequestDto.ModifyTime.HasValue)
            {
                query = query.Where(o => o.ModifyTime >= this.RequestDto.ModifyTime.Value); 
            }

            //根据主键排序
            query = query.OrderBy(o => o.ID);

            //获取分页对象
            var pagedList = new ServiceCenter.Data.Core.PagedList<Models.SaleEditDetailsExt>(query,
                this.RequestDto.PageIndex,
                this.RequestDto.PageSize,
                this.RequestDto.TotalCount);

            //返回列表数据
            return this.SuccessActionResult(new PagedList<Models.SaleEditDetailsExt>()
            {
                PageIndex = pagedList.PageIndex,
                PageSize = pagedList.PageSize,
                TotalCount = pagedList.TotalCount,
                TotalPages = pagedList.TotalPages,
                Items = pagedList.ToList()
            });
        }
    }
}
