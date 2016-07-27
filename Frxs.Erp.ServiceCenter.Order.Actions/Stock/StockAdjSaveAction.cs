/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/15 13:41:51
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.BLL;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Stock
{
    /// <summary>
    /// 盘点调整主表(盘亏盘盈表) 保存接口
    /// </summary>
    [ActionName("StockAdj.Save")]
    public class StockAdjSaveAction : ActionBase<StockAdjSaveAction.StockAdjSaveActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockAdjSaveActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 标志位 0表示新增，1表示修改
            /// </summary>
            public int Flag { get; set; }
            /// <summary>
            /// 调整ID(WID+ ID服务)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string AdjID { get; set; }

            /// <summary>
            /// 开单日期
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public DateTime AdjDate { get; set; }

            /// <summary>
            /// 盘点计划ID
            /// </summary>
            public string PlanID { get; set; }

            /// <summary>
            /// 仓库ID(WarehouseID) 该数据决定了访问哪个数据库
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public int WID { get; set; }

            /// <summary>
            /// 仓库编号(Warehouse.WCode)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string WCode { get; set; }

            /// <summary>
            /// 仓库名称(Warehouse.WarehouseName)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string WName { get; set; }

            /// <summary>
            /// 仓库子机构ID(WarehouseID)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public int SubWID { get; set; }

            /// <summary>
            /// 仓库子机构编号(Warehouse.WCode)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string SubWCode { get; set; }

            /// <summary>
            /// 仓库柜台名称(Warehouse.WarehouseName)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string SubWName { get; set; }

            /// <summary>
            /// 状态(0:未提交;1:已提交;2:已过帐;3:作废) 0>1 1->2 1>0; 1>3; 0 删除时物理删除;
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public int Status { get; set; }

            /// <summary>
            /// 调整类型(0:调增库存;1:调减库存)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public int AdjType { get; set; }

            /// <summary>
            /// 备注
            /// </summary>

            public string Remark { get; set; }


            /// <summary>
            /// 校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (this.WID <= 0) yield return new RequestDtoValidatorResultError("WID");
            }

        }

        /// <summary>
        /// 下送的数据
        /// </summary>
        public class StockAdjListSaveActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            string warehouseId = RequestDto.WID.ToString();
            int result = 0;
            StockAdj model = new StockAdj();

            model.AdjID = RequestDto.AdjID;
            model.AdjDate = RequestDto.AdjDate;
            model.AdjType = RequestDto.AdjType;

            model.WID = RequestDto.WID;
            model.WCode = RequestDto.WCode;
            model.WName = RequestDto.WName;

            model.SubWID = RequestDto.SubWID;
            model.SubWCode = RequestDto.SubWCode;
            model.SubWName = RequestDto.SubWName;

            model.PlanID = RequestDto.PlanID;
            model.Remark = RequestDto.Remark;
            model.ModifyTime = DateTime.Now;
            model.ModifyUserID = RequestDto.UserId;
            model.ModifyUserName = RequestDto.UserName;

            if (RequestDto.Flag == 0)
            {
                model.Status = 0;
                model.CreateTime = DateTime.Now;
                model.CreateUserID = RequestDto.UserId;
                model.CreateUserName = RequestDto.UserName;

                if (StockAdjBLO.Exists(model, warehouseId))
                {
                    return this.ErrorActionResult("有重复的记录!");
                }
                result = StockAdjBLO.Save(model, warehouseId);
            }
            else
            {
                var existModel = StockAdjBLO.GetModel(model.AdjID, warehouseId);
                if (existModel == null)
                {
                    return ErrorActionResult("该记录不存在!");
                }
                else
                {
                    if (existModel.Status != 0)
                    {
                        return ErrorActionResult("当前记录不是录单状态,不能修改!");
                    }
                    else
                    {
                        result = StockAdjBLO.Edit(model, warehouseId);
                    }
                }
            }
            return SuccessActionResult("保存成功", 1);
        }
    }
}
