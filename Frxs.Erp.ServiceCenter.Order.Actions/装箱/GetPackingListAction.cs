/*********************************************************
 * FRXS 小马哥 2016/4/16 15:39:03
 * *******************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 等待装箱订单列表
    /// </summary>
    public class GetPackingListAction : ActionBase<Frxs.Erp.ServiceCenter.Order.Actions.GetPackingListAction.GetPackingListActionRequestDto, Frxs.Erp.ServiceCenter.Order.Actions.GetPackingListAction.GetPackingListActionResponseDto>
    {
        /// <summary>
        /// 调用接口传入参数
        /// </summary>
        public class GetPackingListActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required]
            public string WID { get; set; }
        }

        /// <summary>
        /// 输出参数
        /// </summary>
        public class GetPackingListActionResponseDto : ResponseDtoBase
        {
            public List<SaleOrderPre> OrderData { get; set; }
        }

        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<GetPackingListActionResponseDto> Execute()
        {
            IList<SaleOrderPre> list = SaleOrderPreBLO.GetPackingList(RequestDto.WID);
            if (list.Count > 0)
            {
                GetPackingListActionResponseDto resp = new GetPackingListActionResponseDto();

                resp.OrderData = new List<SaleOrderPre>();
                list.ToList().ForEach(x =>
                {
                    #region 赋值
                    SaleOrderPre model = new SaleOrderPre();
                    model.OrderId = x.OrderId;
                    model.SettleID = x.SettleID;
                    model.WID = x.WID;
                    model.SubWID = x.SubWID;
                    model.OrderDate = x.OrderDate;
                    model.OrderType = x.OrderType;
                    model.WCode = x.WCode;
                    model.WName = x.WName;
                    model.SubWCode = x.SubWCode;
                    model.SubWName = x.SubWName;
                    model.ShopID = x.ShopID;
                    model.XSUserID = x.XSUserID;
                    model.ShopType = x.ShopType;
                    model.ShopCode = x.ShopCode;
                    model.ShopName = x.ShopName;
                    model.Status = x.Status;
                    model.ProvinceID = x.ProvinceID;
                    model.CityID = x.CityID;
                    model.RegionID = x.RegionID;
                    model.ProvinceName = x.ProvinceName;
                    model.CityName = x.CityName;
                    model.RegionName = x.RegionName;
                    model.Address = x.Address;
                    model.FullAddress = x.FullAddress;
                    model.RevLinkMan = x.RevLinkMan;
                    model.RevTelephone = x.RevTelephone;
                    model.ConfDate = x.ConfDate;
                    model.SendDate = x.SendDate;
                    model.LineID = x.LineID;
                    model.LineName = x.LineName;
                    model.StationNumber = x.StationNumber;
                    model.PickingBeginDate = x.PickingBeginDate;
                    model.PickingEndDate = x.PickingEndDate;
                    model.StockOutRate = x.StockOutRate;
                    model.PackingEmpID = x.PackingEmpID;
                    model.PackingEmpName = x.PackingEmpName;
                    model.PackingTime = x.PackingTime;
                    model.IsPrinted = x.IsPrinted;
                    model.PrintDate = x.PrintDate;
                    model.PrintUserID = x.PrintUserID;
                    model.PrintUserName = x.PrintUserName;
                    model.ShippingBeginDate = x.ShippingBeginDate;
                    model.ShippingUserID = x.ShippingUserID;
                    model.ShippingUserName = x.ShippingUserName;
                    model.ShippingEndDate = x.ShippingEndDate;
                    model.FinishDate = x.FinishDate;
                    model.CancelDate = x.CancelDate;
                    model.CloseDate = x.CloseDate;
                    model.CloseReason = x.CloseReason;
                    model.Remark = x.Remark;
                    model.TotalProductAmt = x.TotalProductAmt;
                    model.CouponAmt = x.CouponAmt;
                    model.TotalAddAmt = x.TotalAddAmt;
                    model.PayAmount = x.PayAmount;
                    model.TotalPoint = x.TotalPoint;
                    model.TotalBasePoint = x.TotalBasePoint;
                    model.UserShowFlag = x.UserShowFlag;
                    model.ClientType = x.ClientType;
                    model.CreateTime = x.CreateTime;
                    model.CreateUserID = x.CreateUserID;
                    model.CreateUserName = x.CreateUserName;
                    model.ModifyTime = x.ModifyTime;
                    model.ModifyUserID = x.ModifyUserID;
                    model.ModifyUserName = x.ModifyUserName;
                    resp.OrderData.Add(model);
                    #endregion
                });
                return SuccessActionResult(resp);
            }
            else
            {
                return ErrorActionResult("未查询到信息");
            }
        }
    }
}
