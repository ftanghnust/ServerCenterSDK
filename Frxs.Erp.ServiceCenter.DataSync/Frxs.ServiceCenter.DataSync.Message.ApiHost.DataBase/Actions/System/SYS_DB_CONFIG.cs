/* ***************************************************************************
 * <auto-generated>
 *     This code was generated by a tool.
 *     Runtime Version:4.0.30319.42000
 *     Changes to this file may cause incorrect behavior and will be lost if
 *     the code is regenerated.
 * </auto-generated>
 * ***************************************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/07/26 16:56:25.938
 * **************************************************************************/
using System;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Actions
{
    /// <summary>
    /// 同步接口 - 数据表：SYS_DB_CONFIG
    /// </summary>
    [ActionName("SYS_DB_CONFIG.Get")]
    public class SYS_DB_CONFIGGetAction : 
       ActionBase<SYS_DB_CONFIGGetAction.SYS_DB_CONFIGGetActionRequestDto, Models.SYS_DB_CONFIG>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SYS_DB_CONFIGGetActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// SqlServer.nvarchar
            /// </summary>
            public String CON_KEY { get; set; }
            
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
        private readonly IRepository<Models.SYS_DB_CONFIG> _sYS_DB_CONFIGRepository;
        private readonly IDbContext _dbContext;
        
        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="sYS_DB_CONFIGRepository">数据访问仓储</param>
        /// <param name="dbContext">数据操作上下文</param>
        public SYS_DB_CONFIGGetAction(
            IRepository<Models.SYS_DB_CONFIG> sYS_DB_CONFIGRepository,
            IDbContext dbContext)
        {
            this._sYS_DB_CONFIGRepository = sYS_DB_CONFIGRepository;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Models.SYS_DB_CONFIG> Execute()
        {
            return this.SuccessActionResult(this._sYS_DB_CONFIGRepository.TableNoTracking
                            .FirstOrDefault(o => o.CON_KEY == this.RequestDto.CON_KEY));
        }
    }

    /// <summary>
    /// 同步接口 - 数据表：SYS_DB_CONFIG
    /// </summary>
    [ActionName("SYS_DB_CONFIG.Get.List")]
    public class SYS_DB_CONFIGGetListAction : 
       ActionBase<SYS_DB_CONFIGGetListAction.SYS_DB_CONFIGGetActionRequestDto, PagedList<Models.SYS_DB_CONFIG>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class SYS_DB_CONFIGGetActionRequestDto : RequestDtoBase
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
        private readonly IRepository<Models.SYS_DB_CONFIG> _sYS_DB_CONFIGRepository;
        private readonly IDbContext _dbContext;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="sYS_DB_CONFIGRepository">数据访问仓储</param>
        /// <param name="dbContext">数据操作上下文</param>
        public SYS_DB_CONFIGGetListAction(
            IRepository<Models.SYS_DB_CONFIG> sYS_DB_CONFIGRepository,
            IDbContext dbContext)
        {
            this._sYS_DB_CONFIGRepository = sYS_DB_CONFIGRepository;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<PagedList<Models.SYS_DB_CONFIG>> Execute()
        {
            //查询 SYS_DB_CONFIG 表数据
            var query = this._sYS_DB_CONFIGRepository.TableNoTracking;

            //根据主键排序
            query = query.OrderBy(o => o.CON_KEY);

            //获取分页对象
            var pagedList = new ServiceCenter.Data.Core.PagedList<Models.SYS_DB_CONFIG>(query,
                this.RequestDto.PageIndex,
                this.RequestDto.PageSize,
                this.RequestDto.TotalCount);

            //返回列表数据
            return this.SuccessActionResult(new PagedList<Models.SYS_DB_CONFIG>()
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
