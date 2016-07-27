/* ***************************************************************************
 * <auto-generated>
 *     This code was generated by a tool.
 *     Runtime Version:4.0.30319.42000
 *     Changes to this file may cause incorrect behavior and will be lost if
 *     the code is regenerated.
 * </auto-generated>
 * ***************************************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/07/26 17:07:14.236
 * **************************************************************************/
using System;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 同步接口 - 数据表：StockFIFOOut
    /// </summary>
    [ActionName("StockFIFOOut.Get")]
    public class StockFIFOOutGetAction :
        ActionBase<StockFIFOOutGetAction.StockFIFOOutGetActionRequestDto, Models.StockFIFOOut>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockFIFOOutGetActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// SqlServer.bigint
            /// </summary>
            public Int64 OutID { get; set; }
            
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
        private readonly IRepository<Models.StockFIFOOut> _stockFIFOOutRepository;
        private readonly IDbContext _dbContext;
        
        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="stockFIFOOutRepository">数据访问仓储</param>
        /// <param name="dbContext">数据操作上下文</param>
        public StockFIFOOutGetAction(
            IRepository<Models.StockFIFOOut> stockFIFOOutRepository, 
            IDbContext dbContext)
        {
            this._stockFIFOOutRepository = stockFIFOOutRepository;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Models.StockFIFOOut> Execute()
        {
            return this.SuccessActionResult(this._stockFIFOOutRepository.TableNoTracking
                            .FirstOrDefault(o => o.OutID == this.RequestDto.OutID));
        }
    }

    /// <summary>
    /// 同步接口 - 数据表：StockFIFOOut
    /// </summary>
    [ActionName("StockFIFOOut.Get.List")]
    public class StockFIFOOutGetListAction :
        ActionBase<StockFIFOOutGetListAction.StockFIFOOutGetActionRequestDto, PagedList<Models.StockFIFOOut>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockFIFOOutGetActionRequestDto : SystemRequestDtoBase
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
        private readonly IRepository<Models.StockFIFOOut> _stockFIFOOutRepository;
        private readonly IDbContext _dbContext;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="stockFIFOOutRepository">数据访问仓储</param>
        /// <param name="dbContext">数据操作上下文</param>
        public StockFIFOOutGetListAction(
            IRepository<Models.StockFIFOOut> stockFIFOOutRepository,
            IDbContext dbContext)
        {
            this._stockFIFOOutRepository = stockFIFOOutRepository;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<PagedList<Models.StockFIFOOut>> Execute()
        {
            //查询 StockFIFOOut 表数据
            var query = this._stockFIFOOutRepository.TableNoTracking;

            //仓库编号
            if (this.RequestDto.WID > 0)
            {
                query = query.Where(o => o.WID == this.RequestDto.WID);
            }

            //根据主键排序
            query = query.OrderBy(o => o.OutID);

            //获取分页对象
            var pagedList = new ServiceCenter.Data.Core.PagedList<Models.StockFIFOOut>(query,
                this.RequestDto.PageIndex,
                this.RequestDto.PageSize,
                this.RequestDto.TotalCount);

            //返回列表数据
            return this.SuccessActionResult(new PagedList<Models.StockFIFOOut>()
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