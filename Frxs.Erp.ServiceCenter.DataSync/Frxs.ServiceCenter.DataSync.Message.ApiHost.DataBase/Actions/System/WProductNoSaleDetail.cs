/* ***************************************************************************
 * <auto-generated>
 *     This code was generated by a tool.
 *     Runtime Version:4.0.30319.42000
 *     Changes to this file may cause incorrect behavior and will be lost if
 *     the code is regenerated.
 * </auto-generated>
 * ***************************************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/07/26 16:56:25.947
 * **************************************************************************/
using System;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Actions
{
    /// <summary>
    /// 同步接口 - 数据表：WProductNoSaleDetails
    /// </summary>
    [ActionName("WProductNoSaleDetail.Get")]
    public class WProductNoSaleDetailGetAction : 
       ActionBase<WProductNoSaleDetailGetAction.WProductNoSaleDetailGetActionRequestDto, Models.WProductNoSaleDetail>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductNoSaleDetailGetActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// SqlServer.int
            /// </summary>
            public Int32 ID { get; set; }
            
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
        private readonly IRepository<Models.WProductNoSaleDetail> _wProductNoSaleDetailRepository;
        private readonly IDbContext _dbContext;
        
        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="wProductNoSaleDetailRepository">数据访问仓储</param>
        /// <param name="dbContext">数据操作上下文</param>
        public WProductNoSaleDetailGetAction(
            IRepository<Models.WProductNoSaleDetail> wProductNoSaleDetailRepository,
            IDbContext dbContext)
        {
            this._wProductNoSaleDetailRepository = wProductNoSaleDetailRepository;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Models.WProductNoSaleDetail> Execute()
        {
            return this.SuccessActionResult(this._wProductNoSaleDetailRepository.TableNoTracking
                            .FirstOrDefault(o => o.ID == this.RequestDto.ID));
        }
    }

    /// <summary>
    /// 同步接口 - 数据表：WProductNoSaleDetails
    /// </summary>
    [ActionName("WProductNoSaleDetail.Get.List")]
    public class WProductNoSaleDetailGetListAction : 
       ActionBase<WProductNoSaleDetailGetListAction.WProductNoSaleDetailGetActionRequestDto, PagedList<Models.WProductNoSaleDetail>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductNoSaleDetailGetActionRequestDto : RequestDtoBase
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
            /// 仓库编号
            /// </summary>
            public int? WID { get; set; }

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
        private readonly IRepository<Models.WProductNoSaleDetail> _wProductNoSaleDetailRepository;
        private readonly IDbContext _dbContext;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="wProductNoSaleDetailRepository">数据访问仓储</param>
        /// <param name="dbContext">数据操作上下文</param>
        public WProductNoSaleDetailGetListAction(
            IRepository<Models.WProductNoSaleDetail> wProductNoSaleDetailRepository,
            IDbContext dbContext)
        {
            this._wProductNoSaleDetailRepository = wProductNoSaleDetailRepository;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<PagedList<Models.WProductNoSaleDetail>> Execute()
        {
            //查询 WProductNoSaleDetails 表数据
            var query = this._wProductNoSaleDetailRepository.TableNoTracking;

            //仓库编号
            if (this.RequestDto.WID.HasValue)
            {
                query = query.Where(o => o.WID == this.RequestDto.WID.Value); 
            }

            //根据主键排序
            query = query.OrderBy(o => o.ID);

            //获取分页对象
            var pagedList = new ServiceCenter.Data.Core.PagedList<Models.WProductNoSaleDetail>(query,
                this.RequestDto.PageIndex,
                this.RequestDto.PageSize,
                this.RequestDto.TotalCount);

            //返回列表数据
            return this.SuccessActionResult(new PagedList<Models.WProductNoSaleDetail>()
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