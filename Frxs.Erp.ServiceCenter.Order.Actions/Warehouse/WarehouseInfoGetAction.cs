/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/28 14:25:12
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.BLL;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 获取仓库机构在订单项目中的信息，用于辅助总部BOSS后台判断仓库子机构是否可以被安全删除
    /// </summary>
    [ActionName("Warehouse.Info.Get")]
    public class WarehouseInfoGetAction : ActionBase<WarehouseInfoGetAction.WarehouseInfoGetActionRequestDto, WarehouseInfoGetAction.WarehouseInfoGetActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WarehouseInfoGetActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 仓库ID(父级)
            /// </summary>
            public int? WID { get; set; }

            /// <summary>
            /// 子机构ID
            /// </summary>
            public int SubWID { get; set; }
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
        public class WarehouseInfoGetActionResponseDto
        {
            /// <summary>
            /// 仓库子机构订单信息
            /// </summary>
            public List<WarehouseBillExt> subWarehouseBill { get; set; }

            /// <summary>
            /// 是否可以删除仓库子机构 true表示可以 false表示不可以
            /// </summary>
            public bool CanDel { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<WarehouseInfoGetActionResponseDto> Execute()
        {
            if (!RequestDto.WID.HasValue || RequestDto.WID.Value == 0)
            {
                return ErrorActionResult("仓库ID不正确!请检查参数!");
            }
            //获取仓库子机构在订单项目中的信息，用于辅助总部BOSS后台判断仓库子机构是否可以被安全删除
            WarehouseInfoGetActionResponseDto model = new WarehouseInfoGetActionResponseDto();
            IList<WarehouseBillExt> subWarehouseBills = new List<WarehouseBillExt>();

            try
            {
                //尝试获取订单信息
                subWarehouseBills = WarehouseBillExtBLO.GetList(RequestDto.WID.Value, RequestDto.SubWID);
                if (subWarehouseBills != null && subWarehouseBills.Count > 0)
                {
                    model.CanDel = false;
                    model.subWarehouseBill = subWarehouseBills.ToList();
                }
                else
                {
                    model.CanDel = true;
                }
            }
            catch (Exception ex)
            {
                //若没有对应的分库，
                model.CanDel = false;
                bool isSqlException = ex is System.Data.SqlClient.SqlException;
                string errMsg = isSqlException ? "打开订单数据库失败" : string.Format("查询仓库单据信息失败 {0}", ex.Message);

                if (isSqlException == true)
                {//2016-5-6 咨询胡总、叶求意见，当不存在对应的订单分库（尽管登录失败也可能是因为帐号密码错误或其他原因，斟酌后认为可以忽略该因素），允许删除子机构记录。
                    model.CanDel = true;
                    return SuccessActionResult("没有相应的订单数据库，子机构可以删除。", model);
                }
                return ErrorActionResult(errMsg, model);
                //throw;
            }
            return SuccessActionResult("查询完成", model);
        }
    }
}
