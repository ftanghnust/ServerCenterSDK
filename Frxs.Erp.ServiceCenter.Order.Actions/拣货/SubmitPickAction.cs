/*********************************************************
 * FRXS 小马哥 2016/4/15 19:12:05
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.Model.Order;
using Frxs.Platform.Utility;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 提交拣货
    /// </summary>
    [ActionName("SubmitPick")]
    public class SubmitPickAction : ActionBase<Frxs.Erp.ServiceCenter.Order.Actions.SubmitPickAction.SubmitPickActionRequest, Frxs.Erp.ServiceCenter.Order.Actions.SubmitPickAction.SubmitPickActionResponse>
    {
        /// <summary>
        /// 接口上传参数
        /// </summary>
        public class SubmitPickActionRequest : RequestDtoBase
        {
            /// <summary>
            /// 需提交拣货的订单和商品详细(序列化)
            /// </summary>
            [Required]
            public SubmitPickOrder ProductData { get; set; }

            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required]
            public string WID { get; set; }
        }

        /// <summary>
        /// 接口返回参数
        /// </summary>
        public class SubmitPickActionResponse : ResponseDtoBase
        {
            /// <summary>
            /// 提交拣货结果
            /// </summary>
            public bool IsResult { get; set; }

            /// <summary>
            /// 返回标识
            /// 0:提交成功
            /// 1:找不到订单编号对应的数据
            /// 2:订单已完成拣货
            /// 3:订单的当前货区已完成拣货(针对APP使用)
            /// 4:提交的商品数据为空
            /// </summary>
            public int Flag { get; set; }

            /// <summary>
            /// 返回消息
            /// </summary>
            public string Info { get; set; }
        }

        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<SubmitPickActionResponse> Execute()
        {
            SubmitPickOrder model = RequestDto.ProductData;
            model.PickUserID = RequestDto.UserId;
            model.PickUserName = RequestDto.UserName;
            var productList = model.ProductsData.ToList().Select(x => { return x.ProductID; });
            //获取拣货人信息
            var getUserInfo = WorkContext.CreateProductSdkClient().Execute(new Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductGetPickUsersByProductIdRequest()
            {
                ProductIds = string.Join(",", productList),
                WID = RequestDto.WID,
                EmpID = RequestDto.UserId
            });
            if (getUserInfo != null && getUserInfo.Data != null && getUserInfo.Flag == (int)ActionResultFlag.SUCCESS)
            {
                List<PickUserIdAndUserName> list = new List<PickUserIdAndUserName>();
                getUserInfo.Data.ToList().ForEach(y =>
                {
                    PickUserIdAndUserName pickModel = new PickUserIdAndUserName();
                    pickModel.EmpID = y.EmpID;
                    pickModel.EmpName = y.EmpName;
                    pickModel.ProductID = y.ProductID;
                    list.Add(pickModel);
                });

                ReturnSubmitInfo isResult = SaleOrderPreBLO.SubmitPick(model, RequestDto.WID, list);
                if (isResult.IsResult)
                {
                    return SuccessActionResult(new SubmitPickActionResponse()
                    {
                        Flag = isResult.Flag,
                        Info = isResult.Info,
                        IsResult = isResult.IsResult
                    });
                }
                else
                {
                    return ErrorActionResult(isResult.Info, new SubmitPickActionResponse()
                    {
                        Flag = isResult.Flag,
                        Info = isResult.Info,
                        IsResult = isResult.IsResult
                    });
                }
            }
            else
            {
                ReturnSubmitInfo isResult = SaleOrderPreBLO.SubmitPick(model, RequestDto.WID, null);
                if (isResult.IsResult)
                {
                    return SuccessActionResult(new SubmitPickActionResponse()
                    {
                        Flag = isResult.Flag,
                        Info = isResult.Info,
                        IsResult = isResult.IsResult
                    });
                }
                else
                {
                    return ErrorActionResult(isResult.Info, new SubmitPickActionResponse()
                    {
                        Flag = isResult.Flag,
                        Info = isResult.Info,
                        IsResult = isResult.IsResult
                    });
                }
            }
        }
    }
}
