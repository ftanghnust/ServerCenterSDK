/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/4 10:10:53
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.BLL.Shop;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Shop
{
    /// <summary>
    /// 获取门店在订单项目中的订单信息，用于辅助总部BOSS后台判断门店是否可以被安全删除
    /// </summary>
    [ActionName("Shop.Info.Get")]
    public class ShopInfoGetAction : ActionBase<ShopInfoGetAction.ShopInfoGetActionRequestDto, ShopInfoGetAction.ShopInfoGetActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ShopInfoGetActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 仓库ID
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 门店ID
            /// </summary>
            public int ShopID { get; set; }

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
        /// 下送的数据
        /// </summary>
        public class ShopInfoGetActionResponseDto
        {
            /// <summary>
            /// 门店订单信息
            /// </summary>
            public List<ShopBillExt> shopBill { get; set; }

            /// <summary>
            /// 是否可以删除门店 true表示可以 false表示不可以
            /// </summary>
            public bool CanDel { get; set; }

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ShopInfoGetActionResponseDto> Execute()
        {
            if (RequestDto.WID <= 0)
            {
                return ErrorActionResult("仓库ID不正确!请检查参数!");
            }
            //获取门店在订单项目中的信息，用于辅助总部BOSS后台判断门店是否可以被安全删除
            ShopInfoGetActionResponseDto model = new ShopInfoGetActionResponseDto();
            IList<ShopBillExt> shopBills = new List<ShopBillExt>();

            try
            {
                shopBills = ShopBillExtBLO.GetList(RequestDto.WID, RequestDto.ShopID);
                if (shopBills != null && shopBills.Count > 0)
                {
                    model.CanDel = false;
                    model.shopBill = shopBills.ToList();
                }
                else
                {
                    model.CanDel = true;
                }
            }
            catch (Exception ex)
            {
                model.CanDel = false;
                bool isSqlException = ex is System.Data.SqlClient.SqlException;
                string errMsg = isSqlException ? "打开订单数据库失败" : string.Format("查询门店单据信息失败 {0}", ex.Message);

                if (isSqlException == true)
                {//2016-5-6 咨询胡总、叶求意见，当不存在对应的订单分库（尽管登录失败也可能是因为帐号密码错误或其他原因，斟酌后认为可以忽略该因素），允许删除门店记录。
                    model.CanDel = true;
                    return SuccessActionResult("没有相应的订单数据库，门店可以删除。", model);
                }
                return ErrorActionResult(errMsg, model);
                //throw;
            }
            return SuccessActionResult("查询完成", model);
        }
    }
}
