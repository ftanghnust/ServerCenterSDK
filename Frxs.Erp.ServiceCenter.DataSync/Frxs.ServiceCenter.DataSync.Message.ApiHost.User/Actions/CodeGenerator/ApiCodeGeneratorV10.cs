/***************************************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 1:14:35 PM (4.0.30319.42000)
 * *************************************************************************/
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using System.IO;
using System.Linq;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.User.Actions
{
    /// <summary>
    /// 接口层代码生成器(此接口为当前项目接口层代码生成器)
    /// </summary>
    [ActionName("Api.CodeGenerator")]
    public class ApiCodeGeneratorV10 : ActionBase<NullRequestDto, object>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IDbContext _dbContext;
        private readonly IActionSelector _actionSelector;
        private readonly IMediaTypeFormatterFactory _mediaTypeFormatterFactory;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="actionSelector">接口搜索器</param>
        /// <param name="mediaTypeFormatterFactory">格式化器创建器</param>
        public ApiCodeGeneratorV10(
            IDbContext dbContext,
            IActionSelector actionSelector,
            IMediaTypeFormatterFactory mediaTypeFormatterFactory)
        {
            this._dbContext = dbContext;
            this._actionSelector = actionSelector;
            this._mediaTypeFormatterFactory = mediaTypeFormatterFactory;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<object> Execute()
        {
            var objectContext = ((IObjectContextAdapter)this._dbContext).ObjectContext;
            var storageModel = (StoreItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.SSpace);
            var containers = storageModel.GetItems<EntityContainer>();

            //请求的内部接口
            string actionName = "DataSync.User.Api.CodeGenerator";

            //循环当前注册的所有模型
            foreach (var item in containers.SelectMany(c => c.BaseEntitySets))
            {
                //上送参数
                var requestDto = new ApiCodeGeneratorAction.ActionApiCodeGeneratorActionRequestDto()
                {
                    ModelName = item.Name,
                    UserId = 0,
                    UserName = "system"
                };

                //原始请求参数
                var requestParams = new RequestParams()
                {
                    ActionName = actionName,
                    Data = requestDto.SerializeObjectToJosn(),
                    Format = "View",
                    AppKey = "",
                    Sign = "",
                    TimeStamp = DateTime.Now.ToString(),
                    Version = ""
                };

                //构造请求上下文
                var requestContext = new RequestContext(
                            httpContext: this.RequestContext.HttpContext,
                            systemOptions: SystemOptionsManager.Current,
                            requestDto: requestDto,
                            actionDescriptor: this._actionSelector.GetActionDescriptor(actionName, ""),
                            rawRequestParams: requestParams,
                            decryptedRequestParams: requestParams.MapTo<RequestParams>());

                //构造接口对象
                IAction action = new ApiCodeGeneratorAction(this._dbContext);
                action.RequestContext = requestContext;
                action.RequestDto = requestDto;
                action.ActionDescriptor = (ActionDescriptor)requestContext.ActionDescriptor;

                //执行文档生成器接口（当成服务使用）
                var actionResult = action.Execute();

                //格式化器，默认使用view
                var mediaTypeFormatter = this._mediaTypeFormatterFactory.Create(ResponseFormat.VIEW);

                //格式化后的数据
                var serializedActionResultToString = mediaTypeFormatter.SerializedActionResultToString(requestContext,
                    new ActionResult()
                    {
                        Data = actionResult.Data,
                        Flag = ActionResultFlag.SUCCESS,
                        Info = "OK"
                    });

                //输出到文件
                const string saveDirectory = "~/Actions/System";
                using (var streamWriter = new StreamWriter(this.RequestContext.HttpContext.Server
                    .MapPath("{0}/{1}.cs".With(saveDirectory, item.Name))))
                {
                    streamWriter.WriteLine(serializedActionResultToString);
                }
            }

            //生成接口成功
            return this.SuccessActionResult("OK");
        }
    }
}