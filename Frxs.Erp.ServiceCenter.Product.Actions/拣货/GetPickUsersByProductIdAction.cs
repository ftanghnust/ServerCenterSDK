/*********************************************************
 * FRXS 小马哥 2016/4/12 15:53:11
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Platform.Utility;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 根据商品编号获取指定仓库中用户名和用户编号
    /// </summary>
    [ActionName("GetPickUsersByProductId")]
    public class GetPickUsersByProductIdAction : ActionBase<GetPickUsersByProductIdAction.GetPickUsersByProductIdActionRequestDto, List<GetPickUsersByProductIdAction.GetPickUsersByProductIdActionResponseDto>>
    {
        /// <summary>
        /// 传入参数
        /// </summary>
        public class GetPickUsersByProductIdActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 商品编号-多个商品编号请用,隔开(如:1,2,3,4)
            /// </summary>
            [Required]
            public string ProductIds { get; set; }

            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required]
            public string WID { get; set; }

            /// <summary>
            /// 用户编号
            /// </summary>
            [Required]
            public int EmpID { get; set; }
        }

        /// <summary>
        /// 接口返回数据
        /// </summary>
        public class GetPickUsersByProductIdActionResponseDto : ResponseDtoBase
        {
            /// <summary>
            /// 员工编号
            /// </summary>
            public int EmpID { get; set; }

            /// <summary>
            /// 员工姓名
            /// </summary>
            public string EmpName { get; set; }

            /// <summary>
            /// 商品编号
            /// </summary>
            public int ProductID { get; set; }
        }

        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>        
        public override ActionResult<List<GetPickUsersByProductIdActionResponseDto>> Execute()
        {
            List<Model.WarehouseEmp> listModel = WarehouseEmpBLO.GetPickUsersByProductId(RequestDto.ProductIds, Utils.StrToInt(RequestDto.WID, 0), RequestDto.EmpID);
            if (listModel != null)
            {
                List<GetPickUsersByProductIdActionResponseDto> list = new List<GetPickUsersByProductIdActionResponseDto>();
                listModel.ToList().ForEach(x =>
                {
                    GetPickUsersByProductIdActionResponseDto model = new GetPickUsersByProductIdActionResponseDto();
                    model.EmpID = x.EmpID;
                    model.EmpName = x.EmpName;
                    model.ProductID = x.ProductID;
                    list.Add(model);
                });
                return SuccessActionResult(list);
            }
            else
            {
                return ErrorActionResult("未查到拣货员工信息");
            }
        }
    }
}
