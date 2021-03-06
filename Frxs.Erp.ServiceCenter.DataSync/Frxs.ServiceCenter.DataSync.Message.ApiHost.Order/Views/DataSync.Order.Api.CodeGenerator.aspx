﻿<%@ Page Language="C#" %>
<%@ Assembly Name="Frxs.ServiceCenter.Api.Core" %>
<%@ Assembly Name="Frxs.ServiceCenter.Data.Core" %>
<%@ Assembly Name="Frxs.ServiceCenter.DataSync.Message.ApiHost.Order" %>
<%@ Assembly Name="EntityFramework" %>
<%@ Import Namespace="Frxs.ServiceCenter.Api.Core" %>
<%@ Import Namespace="System.Collections.Specialized" %>
<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="Frxs.ServiceCenter.DataSync.Message.ApiHost.Order" %>
<%@ Import Namespace="Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions" %>
<%@ Import Namespace="Frxs.ServiceCenter.Data.Core" %>
<%@ Import Namespace="System.Data.Entity" %>
<%@ Import Namespace="System.Data.Entity.Core.Metadata.Edm" %>
<%@ Import Namespace="System.Data.Entity.Infrastructure" %>

<script runat="server">
    public RequestContext RequestContext;
    public ActionResult ActionResult;
</script>

<%
    //上送对象
    var requestDto = RequestContext.RequestDto as ApiCodeGeneratorAction.ActionApiCodeGeneratorActionRequestDto;

    //下送数据
    var objectContext = ((IObjectContextAdapter)this.ActionResult.Data).ObjectContext;
    var storageModel = (StoreItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.SSpace);
    var containers = storageModel.GetItems<EntityContainer>();
%>

<%foreach (var item in containers.SelectMany(c=>c.BaseEntitySets).Where(o=>o.Name==requestDto.ModelName)){

        //获取所有主键
        var keyMembers = item.ElementType.KeyMembers;

        //模型名称
        var lowerModelName = item.Name[0].ToString().ToLower() + item.Name.Substring(1, item.Name.Length - 1);

        string orderBy = keyMembers.First().Name;

        //仓储查询条件
        List<string> search = new List<string>();
        foreach (var p in keyMembers)
        {
            search.Add("o.{0} == this.RequestDto.{0}".With(p.Name));
        }

        //映射的表
        var tableName = item.Table;

        //是否含有最后修改时间
        var modifyTime = item.ElementType.Members.FirstOrDefault(p => p.Name.Equals("ModifyTime", StringComparison.OrdinalIgnoreCase));
        //是否含有创建时间字段
        var createTime = item.ElementType.Members.FirstOrDefault(p => p.Name.Equals("CreateTime", StringComparison.OrdinalIgnoreCase));
        //是否含有仓库字段
        var wid = item.ElementType.Members.FirstOrDefault(p => p.Name.Equals("WID", StringComparison.OrdinalIgnoreCase));
 %>

/* ***************************************************************************
 * <auto-generated>
 *     This code was generated by a tool.
 *     Runtime Version:4.0.30319.42000
 *     Changes to this file may cause incorrect behavior and will be lost if
 *     the code is regenerated.
 * </auto-generated>
 * ***************************************************************************
 * FRXS(ISC) zhangliang4629@163.com <%:DateTime.Now.ToString("yyyy\\/MM\\/dd HH:mm:ss.fff") %>
 * **************************************************************************/
using System;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using System.Collections.Generic;
using System.Linq;

<!--NewLine-->

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Actions
{
    /// <summary>
    /// 同步接口 - 数据表：<%:tableName %>
    /// </summary>
    [ActionName("<%:item.Name %>.Get")]
    public class <%:item.Name %>GetAction :
        ActionBase<<%:item.Name %>GetAction.<%:item.Name %>GetActionRequestDto, Models.<%:item.Name %>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class <%:item.Name %>GetActionRequestDto : SystemRequestDtoBase
        {
            <%
                foreach (var p in keyMembers) {

                    //只能使用反射方式来获取值了，因为所有的属性都是非公开的
                    var primitiveType = p.GetType().GetProperty("PrimitiveType").GetValue(p);
                    var clrEquivalentType = primitiveType.GetType().GetProperty("ClrEquivalentType").GetValue(primitiveType);
                    var clrTypeName = clrEquivalentType.GetType().GetProperty("Name").GetValue(clrEquivalentType);
            %>
            /// <summary>
            /// <%:p.TypeUsage %>
            /// </summary>
            public <%: clrTypeName %> <%:p.Name %> { get; set; }
            <!--NewLine-->
            <%} %>

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }
        }

        <!--NewLine-->
        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.<%:item.Name %>> _<%:lowerModelName %>Repository;
        private readonly IDbContext _dbContext;

        <!--NewLine-->
        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="<%:lowerModelName %>Repository">数据访问仓储</param>
        /// <param name="dbContext">数据操作上下文</param>
        public <%:item.Name %>GetAction(
            IRepository<Models.<%:item.Name %>> <%:lowerModelName %>Repository, 
            IDbContext dbContext)
        {
            this._<%:lowerModelName %>Repository = <%:lowerModelName %>Repository;
            this._dbContext = dbContext;
        }

<!--NewLine-->

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Models.<%:item.Name %>> Execute()
        {
            return this.SuccessActionResult(this._<%:lowerModelName %>Repository.TableNoTracking
                            .FirstOrDefault(o => <%:string.Join(" && ",search.ToArray()) %>));
        }
    }

<!--NewLine-->

    /// <summary>
    /// 同步接口 - 数据表：<%:tableName %>
    /// </summary>
    [ActionName("<%:item.Name %>.Get.List")]
    public class <%:item.Name %>GetListAction :
        ActionBase<<%:item.Name %>GetListAction.<%:item.Name %>GetActionRequestDto, PagedList<Models.<%:item.Name %>>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class <%:item.Name %>GetActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// 页码大小，默认100
            /// </summary>
            public int PageSize { get; set; }

<!--NewLine-->

            /// <summary>
            /// 当前页，注意：从0开始
            /// </summary>
            public int PageIndex { get; set; }

<!--NewLine-->

            /// <summary>
            /// 总记录数，第一次访问不需要传，第二次回送，提高检索速度
            /// </summary>
            public int TotalCount { get; set; }

           <%if (modifyTime != null){ %>
<!--NewLine-->
            /// <summary>
            /// 最后修改时间
            /// </summary>
            public DateTime? ModifyTime { get; set; }

           <%} %>

<!--NewLine-->

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

<!--NewLine-->

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }
        }

<!--NewLine-->

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.<%:item.Name %>> _<%:lowerModelName %>Repository;
        private readonly IDbContext _dbContext;

<!--NewLine-->

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="<%:lowerModelName %>Repository">数据访问仓储</param>
        /// <param name="dbContext">数据操作上下文</param>
        public <%:item.Name %>GetListAction(
            IRepository<Models.<%:item.Name %>> <%:lowerModelName %>Repository,
            IDbContext dbContext)
        {
            this._<%:lowerModelName %>Repository = <%:lowerModelName %>Repository;
            this._dbContext = dbContext;
        }

<!--NewLine-->

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<PagedList<Models.<%:item.Name %>>> Execute()
        {
            //查询 <%:tableName %> 表数据
            var query = this._<%:lowerModelName %>Repository.TableNoTracking;



            <%if (wid != null) { %>
<!--NewLine-->
            //仓库编号
            if (this.RequestDto.WID > 0)
            {
                query = query.Where(o => o.WID == this.RequestDto.WID);
            }
            <%} %>


            <%if (modifyTime != null) { %>
<!--NewLine-->
            //当前修改时间是否存在
            if (this.RequestDto.ModifyTime.HasValue)
            {
                query = query.Where(o => o.<%:modifyTime.Name %> >= this.RequestDto.ModifyTime.Value); 
            }

            <%} %>

<!--NewLine-->

            //根据主键排序
            query = query.OrderBy(o => o.<%:orderBy %>);

<!--NewLine-->

            //获取分页对象
            var pagedList = new ServiceCenter.Data.Core.PagedList<Models.<%:item.Name %>>(query,
                this.RequestDto.PageIndex,
                this.RequestDto.PageSize,
                this.RequestDto.TotalCount);

<!--NewLine-->

            //返回列表数据
            return this.SuccessActionResult(new PagedList<Models.<%:item.Name %>>()
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

<%} %>


