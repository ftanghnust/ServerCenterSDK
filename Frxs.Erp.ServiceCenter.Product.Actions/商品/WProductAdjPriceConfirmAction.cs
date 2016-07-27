/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/29 14:40:47
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Platform.IOCFactory;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 仓库商品价格调整表 确认/反确认 操作；返回操作条数
    /// </summary>
    [ActionName("WProduct.AdjustPrice.Confirm")]
    public class WProductAdjPriceConfirmAction : ActionBase<WProductAdjPriceConfirmAction.WProductAdjPriceConfirmActionRequestDto, int?>
    {
        /// <summary>
        /// 
        /// </summary>
        private IActionSelector _actionSelector;

        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductAdjPriceConfirmActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 调整单集合
            /// </summary>
            [Required]
            public List<int> AdjIds { get; set; }

            /// <summary>
            /// 确认与反确认操作，确认操作（将未提交的调整单状态改变为已确认状态），反确认（即已经确认的调整单，反确认到未确认状态）
            /// </summary>
            public OperatorType Type { get; set; }

            /// <summary>
            /// 操作类型
            /// </summary>
            public enum OperatorType
            {
                /// <summary>
                /// 确认
                /// </summary>
                Confirm,
                /// <summary>
                /// 反确认
                /// </summary>
                UndoConfirm
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionSelector"></param>
        public WProductAdjPriceConfirmAction(IActionSelector actionSelector)
        {
            this._actionSelector = actionSelector;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public string GetStatusDescription(int status)
        {
            switch (status)
            {
                case 0:
                    return "未提交";
                case 1:
                    return "已确认";
                case 2:
                    return "已过账";
                default:
                    return "未知状态";
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int?> Execute()
        {
            //成功数
            int success = 0;

            //消息详细
            List<string> errmessage = new List<string>();

            //获取调价单详情
            var adjDal = DALFactory.GetLazyInstance<IWProductAdjPriceDAO>();

            //确认或者反确认
            switch (this.RequestDto.Type)
            {
                //确认
                case WProductAdjPriceConfirmActionRequestDto.OperatorType.Confirm:

                    foreach (var item in this.RequestDto.AdjIds)
                    {
                        //详情
                        var adj = adjDal.GetModel(item);

                        //调价单不存在
                        if (adj.IsNull())
                        {
                            continue;
                        }

                        //未处于待确认的调价单不允许修改
                        if (adj.Status == 0)
                        {
                            adj.Status = 1; // 状态(0:未提交;1:已确认;2:已过帐;)
                            adj.ConfTime = DateTime.Now;
                            adj.ConfUserID = this.RequestDto.UserId;
                            adj.ConfUserName = this.RequestDto.UserName;
                            adj.ModifyTime = DateTime.Now;
                            adj.ModifyUserID = this.RequestDto.UserId;
                            adj.ModifyUserName = this.RequestDto.UserName;
                            adjDal.Edit(adj);

                            //成功数+1
                            success++;

                            //如果生效时间小于当前时间就自动生效(接口访问接口)
                            //if (adj.BeginTime <= DateTime.Now)
                            //{
                            //    //接口名称
                            //    string actionName = "WProduct.AdjustPrice.Posting";

                            //    //直接构造上送业务参数对象
                            //    var requestDto = new WProductAdjPricePostingAction.WProductAdjPricePostingActionRequestDto()
                            //    {
                            //        WID = adj.WID,
                            //        AdjIds = new List<int> { adj.AdjID },
                            //        UserId = this.RequestDto.UserId,
                            //        UserName = this.RequestDto.UserName
                            //    };

                            //    //直接构造原始请求参数
                            //    var requestParams = new RequestParams()
                            //    {
                            //        ActionName = actionName,
                            //        Data = requestDto.SerializeObjectToJosn(),
                            //        Format = this.RequestContext.RawRequestParams.Format,
                            //        AppKey = "",
                            //        Sign = "",
                            //        TimeStamp = DateTime.Now.ToString(CultureInfo.CurrentCulture),
                            //        Version = ""
                            //    };

                            //    //构造请求上下文
                            //    var requestContext = new RequestContext(
                            //                httpContext: this.RequestContext.HttpContext,
                            //                systemOptions: SystemOptionsManager.Current,
                            //                requestDto: requestDto,
                            //                actionDescriptor: this._actionSelector.GetActionDescriptor(actionName, ""),
                            //                rawRequestParams: requestParams,
                            //                decryptedRequestParams: requestParams.MapTo<RequestParams>());

                            //    //直接接口方法
                            //    IAction apiDocAction = new WProductAdjPricePostingAction();
                            //    apiDocAction.RequestDto = requestDto;
                            //    apiDocAction.RequestContext = requestContext;
                            //    apiDocAction.ActionDescriptor = (ActionDescriptor)requestContext.ActionDescriptor;
                            //    var actionResult = apiDocAction.Execute();
                            //}
                        }
                        else
                        {
                            errmessage.Add("调价单:{0}状态已改变，当前状态为：{1}， 请在列表页面刷新查看".With(item, GetStatusDescription(adj.Status)));
                        }
                    }

                    break;

                //取消确认
                case WProductAdjPriceConfirmActionRequestDto.OperatorType.UndoConfirm:

                    foreach (var item in this.RequestDto.AdjIds)
                    {
                        //详情
                        var adj = adjDal.GetModel(item);

                        //调价单不存在
                        if (adj.IsNull())
                        {
                            continue;
                        }

                        //未处于待确认的调价单不允许修改
                        if (adj.Status == 1)
                        {
                            adj.Status = 0; // 状态(0:未提交;1:已确认;2:已过帐;)
                            adj.ModifyTime = DateTime.Now;
                            adj.ModifyUserID = this.RequestDto.UserId;
                            adj.ModifyUserName = this.RequestDto.UserName;
                            adj.ConfTime = null;
                            adj.ConfUserID = null;
                            adj.ConfUserName = null;
                            adjDal.Edit(adj);

                            //成功数+1
                            success++;
                        }
                        else
                        {
                            errmessage.Add("调价单:{0}状态已改变，当前状态为：{1}， 请在列表页面刷新查看".With(item, GetStatusDescription(adj.Status)));
                        }
                    }

                    break;
            }

            //返回成功
            return this.RequestDto.AdjIds.Count == success ? this.SuccessActionResult(success) : this.ErrorActionResult(string.Join("|", errmessage.ToArray()), success);
        }

        /// <summary>
        /// 删除匹配到的缓存键
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            this.CacheManager.RemoveByPattern(WProductAdjPriceCacheKey.FRXS_WPRODUCT_ADJPRICE_PATTERN_KEY);
            this.CacheManager.RemoveByPattern(WProductsCacheKey.FRXS_WPRODUCTS_PATTERN_KEY);
        }
    }
}
