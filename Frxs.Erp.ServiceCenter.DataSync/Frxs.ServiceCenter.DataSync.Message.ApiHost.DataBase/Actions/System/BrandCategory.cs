/* ***************************************************************************
 * <auto-generated>
 *     This code was generated by a tool.
 *     Runtime Version:4.0.30319.42000
 *     Changes to this file may cause incorrect behavior and will be lost if
 *     the code is regenerated.
 * </auto-generated>
 * ***************************************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/07/26 16:56:25.923
 * **************************************************************************/
using System;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Actions
{
    /// <summary>
    /// 同步接口 - 数据表：BrandCategories
    /// </summary>
    [ActionName("BrandCategory.Get")]
    public class BrandCategoryGetAction : 
       ActionBase<BrandCategoryGetAction.BrandCategoryGetActionRequestDto, Models.BrandCategory>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class BrandCategoryGetActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// SqlServer.int
            /// </summary>
            public Int32 BrandId { get; set; }
            
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
        private readonly IRepository<Models.BrandCategory> _brandCategoryRepository;
        private readonly IDbContext _dbContext;
        
        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="brandCategoryRepository">数据访问仓储</param>
        /// <param name="dbContext">数据操作上下文</param>
        public BrandCategoryGetAction(
            IRepository<Models.BrandCategory> brandCategoryRepository,
            IDbContext dbContext)
        {
            this._brandCategoryRepository = brandCategoryRepository;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Models.BrandCategory> Execute()
        {
            return this.SuccessActionResult(this._brandCategoryRepository.TableNoTracking
                            .FirstOrDefault(o => o.BrandId == this.RequestDto.BrandId));
        }
    }

    /// <summary>
    /// 同步接口 - 数据表：BrandCategories
    /// </summary>
    [ActionName("BrandCategory.Get.List")]
    public class BrandCategoryGetListAction : 
       ActionBase<BrandCategoryGetListAction.BrandCategoryGetActionRequestDto, PagedList<Models.BrandCategory>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class BrandCategoryGetActionRequestDto : RequestDtoBase
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
        private readonly IRepository<Models.BrandCategory> _brandCategoryRepository;
        private readonly IDbContext _dbContext;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="brandCategoryRepository">数据访问仓储</param>
        /// <param name="dbContext">数据操作上下文</param>
        public BrandCategoryGetListAction(
            IRepository<Models.BrandCategory> brandCategoryRepository,
            IDbContext dbContext)
        {
            this._brandCategoryRepository = brandCategoryRepository;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<PagedList<Models.BrandCategory>> Execute()
        {
            //查询 BrandCategories 表数据
            var query = this._brandCategoryRepository.TableNoTracking;

            //当前修改时间是否存在
            if (this.RequestDto.ModifyTime.HasValue)
            {
                query = query.Where(o => o.ModifyTime >= this.RequestDto.ModifyTime.Value); 
            }

            //根据主键排序
            query = query.OrderBy(o => o.BrandId);

            //获取分页对象
            var pagedList = new ServiceCenter.Data.Core.PagedList<Models.BrandCategory>(query,
                this.RequestDto.PageIndex,
                this.RequestDto.PageSize,
                this.RequestDto.TotalCount);

            //返回列表数据
            return this.SuccessActionResult(new PagedList<Models.BrandCategory>()
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
