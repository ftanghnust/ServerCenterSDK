/*********************************************************
 * FRXS(ISC) chujl 2016/3/23  
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 补货，返配申请单 录入或编辑
    /// </summary>
    [ActionName("BuyPreApp.AddOrEdit")]
    public class BuyPreAppAddOrEditAction : ActionBase<BuyPreAppAddOrEditAction.BuyPreAppAddOrEditActionRequestDto, int>
    {
        /// <summary>
        /// BuyPreApp.AddOrEditAction
        /// </summary>
        public class BuyPreAppAddOrEditActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {

            /// <summary>
            /// 添加或者编辑
            /// </summary>
            public string Flag { get; set; }

            /// <summary>
            /// 仓库ID
            /// </summary>
            [Required]
            public int WID { get; set; }

            /// <summary>
            /// 申请表
            /// </summary>
            [Required]
            public BuyPreAppRequest BuyPreAppModel { get; set; }

            /// <summary>
            ///  明细表
            /// </summary>
            public IList<BuyPreAppDetailsRequest> BuyPreAppDetailsList { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public class BuyPreAppDetailsRequest
            {

                #region 模型
                /// <summary>
                /// 编号(仓库ID+GUID)
                /// </summary>
                public string ID { get; set; }

                /// <summary>
                /// 商品编号(Prouct.ProductID)
                /// </summary>
                public int ProductId { get; set; }

                /// <summary>
                /// 申请单位数量(采购单位数量)
                /// </summary>
                public decimal AppQty { get; set; }


                /// <summary>
                /// 采购的总金额(=UnitQty*UnitPrice)
                /// </summary>
                public decimal SubAmt { get; set; }

                /// <summary>
                /// 备注
                /// </summary>
                public string Remark { get; set; }

                /// <summary>
                /// 序号(输入的序号,每一个单据从1开始)
                /// </summary>
                public int SerialNumber { get; set; }

                /// <summary>
                /// 申请单位(即采购单位)
                /// </summary>
                public string AppUnit { get; set; }

                /// <summary>
                /// 申请单位包装数(即采购单位包装数)
                /// </summary>
                public decimal AppPackingQty { get; set; }


                #endregion
            }

            /// <summary>
            /// 
            /// </summary>
            public class BuyPreAppRequest
            {

                #region 模型

                /// <summary>
                /// 申请ID
                /// </summary>
                public string AppID { get; set; }

                /// <summary>
                /// 申请类型(0:返配;1:补货)
                /// </summary>
                public int AppType { get; set; }

                /// <summary>
                /// 仓库ID(Warehouse.WID)
                /// </summary>
                public int WID { get; set; }

                /// <summary>
                /// 仓库编号(Warehouse.WCode)
                /// </summary>
                public string WCode { get; set; }

                /// <summary>
                /// 仓库名称(Warehouse.WName)
                /// </summary>
                public string WName { get; set; }

                /// <summary>
                /// 仓库柜台
                /// </summary>
                public int SubWID { get; set; }

                /// <summary>
                /// 仓库柜台编号(Warehouse.WCode)
                /// </summary>
                public string SubWCode { get; set; }

                /// <summary>
                /// 仓库柜台名称(Warehouse.WName)
                /// </summary>
                public string SubWName { get; set; }

                /// <summary>
                /// 申请时间
                /// </summary>
                public DateTime AppDate { get; set; }

                /// <summary>
                /// 备注
                /// </summary>
                public string Remark { get; set; }


                #endregion
            }


            /// <summary>
            /// 校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            string result = "0";

            BuyPreApp order = requestDto.BuyPreAppModel.MapTo<BuyPreApp>();
            order.ModifyTime = DateTime.Now;
            order.ModifyUserID = requestDto.UserId;
            order.ModifyUserName = requestDto.UserName;
            //order.BuyEmpID = requestDto.UserId;  主表采购员没有起作用
            //order.BuyEmpName = requestDto.UserName;

            var orderdetails = new List<BuyPreAppDetails>();
            if (requestDto.BuyPreAppDetailsList != null && requestDto.BuyPreAppDetailsList.Count > 0)
            {
                int i = 0;
                foreach (var model in requestDto.BuyPreAppDetailsList)
                {
                    i = i + 1;
                    BuyPreAppDetails detailsObj = model.MapTo<BuyPreAppDetails>();
                    detailsObj.ModifyTime = DateTime.Now;
                    detailsObj.ModifyUserID = requestDto.UserId;
                    detailsObj.ModifyUserName = requestDto.UserName;
                    detailsObj.AppID = order.AppID;
                    detailsObj.WID = order.WID;
                    orderdetails.Add(detailsObj);
                }
            }
            else
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = "申请单详情数据不能为空！"
                };
            }
            try
            {
                if (requestDto.Flag == "Add")
                {

                    order.CreateTime = DateTime.Now;
                    order.CreateUserID = requestDto.UserId;
                    order.CreateUserName = requestDto.UserName;
                    //order.BuyEmpID = requestDto.UserId; 主表采购员没有起作用
                    //order.BuyEmpName = requestDto.UserName;
                    order.Status = 0;  //未发布 
                    result = BuyPreAppBLO.Save(requestDto.WID, order, orderdetails);

                    if (result == "0")
                    {
                        return new ActionResult<int>()
                        {
                            Flag = ActionResultFlag.SUCCESS,
                            Info = "OK",
                            Data = int.Parse(result)
                        };
                    }
                    else
                    {
                        return new ActionResult<int>()
                        {
                            Flag = ActionResultFlag.FAIL,
                            Info = result
                        };
                    }
                }
                else
                {
                    result = BuyPreAppBLO.Edit(requestDto.WID, order, orderdetails);
                    if (result == "0")
                    {
                        return new ActionResult<int>()
                        {
                            Flag = ActionResultFlag.SUCCESS,
                            Info = "OK",
                            Data = int.Parse(result)
                        };
                    }
                    else
                    {
                        return new ActionResult<int>()
                        {
                            Flag = ActionResultFlag.FAIL,
                            Info = result
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = ex.Message
                };
            }

        }
    }
}
