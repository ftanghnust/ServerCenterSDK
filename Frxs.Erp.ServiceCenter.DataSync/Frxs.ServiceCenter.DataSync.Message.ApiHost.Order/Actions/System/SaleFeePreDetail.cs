/* ***************************************************************************
 * <auto-generated>
 *     This code was generated by a tool.
 *     Runtime Version:4.0.30319.42000
 *     Changes to this file may cause incorrect behavior and will be lost if
 *     the code is regenerated.
 * </auto-generated>
 * ***************************************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/07/26 17:07:14.209
 * **************************************************************************/
using System;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 同步接口 - 数据表：SaleFeePreDetails
    /// </summary>
    [ActionName("SaleFeePreDetail.Get")]
    public class SaleFeePreDetailGetAction :
        ActionBase<SaleFeePreDetailGetAction.SaleFeePreDetailGetActionRequestDto, Models.SaleFeePreDetail>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SaleFeePreDetailGetActionRequestDto : SystemRequestDtoBase
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
        private readonly IRepository<Models.SaleFeePreDetail> _saleFeePreDetailRepository;
        private readonly IDbContext _dbContext;
        
        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="saleFeePreDetailRepository">数据访问仓储</param>
        /// <param name="dbContext">数据操作上下文</param>
        public SaleFeePreDetailGetAction(
            IRepository<Models.SaleFeePreDetail> saleFeePreDetailRepository, 
            IDbContext dbContext)
        {
            this._saleFeePreDetailRepository = saleFeePreDetailRepository;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Models.SaleFeePreDetail> Execute()
        {
            return this.SuccessActionResult(this._saleFeePreDetailRepository.TableNoTracking
                            .FirstOrDefault(o => o.ID == this.RequestDto.ID));
        }
    }

    /// <summary>
    /// 同步接口 - 数据表：SaleFeePreDetails
    /// </summary>
    [ActionName("SaleFeePreDetail.Get.List")]
    public class SaleFeePreDetailGetListAction :
        ActionBase<SaleFeePreDetailGetListAction.SaleFeePreDetailGetActionRequestDto, PagedList<Models.SaleFeePreDetail>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SaleFeePreDetailGetActionRequestDto : SystemRequestDtoBase
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
        private readonly IRepository<Models.SaleFeePreDetail> _saleFeePreDetailRepository;
        private readonly IDbContext _dbContext;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="saleFeePreDetailRepository">数据访问仓储</param>
        /// <param name="dbContext">数据操作上下文</param>
        public SaleFeePreDetailGetListAction(
            IRepository<Models.SaleFeePreDetail> saleFeePreDetailRepository,
            IDbContext dbContext)
        {
            this._saleFeePreDetailRepository = saleFeePreDetailRepository;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<PagedList<Models.SaleFeePreDetail>> Execute()
        {
            //查询 SaleFeePreDetails 表数据
            var query = this._saleFeePreDetailRepository.TableNoTracking;

            //仓库编号
            if (this.RequestDto.WID > 0)
            {
                query = query.Where(o => o.WID == this.RequestDto.WID);
            }

            //当前修改时间是否存在
            if (this.RequestDto.ModifyTime.HasValue)
            {
                query = query.Where(o => o.ModifyTime >= this.RequestDto.ModifyTime.Value); 
            }

            //根据主键排序
            query = query.OrderBy(o => o.ID);

            //获取分页对象
            var pagedList = new ServiceCenter.Data.Core.PagedList<Models.SaleFeePreDetail>(query,
                this.RequestDto.PageIndex,
                this.RequestDto.PageSize,
                this.RequestDto.TotalCount);

            //返回列表数据
            return this.SuccessActionResult(new PagedList<Models.SaleFeePreDetail>()
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
