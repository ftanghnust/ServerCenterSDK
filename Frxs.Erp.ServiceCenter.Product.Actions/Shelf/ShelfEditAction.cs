using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions.Shelf
{
    public class ShelfEditAction : ActionBase<ShelfEditAction.ShelfEditRequest, int>
    {
        /// <summary>
        /// 
        /// </summary>
        public class ShelfEditRequest : RequestDtoBase
        {
            /// <summary>
            /// ID(主键)
            /// </summary>            
            public int? ShelfID { get; set; }

            /// <summary>
            /// 货位编号(同一个仓库不能重复)
            /// </summary>
            public string ShelfCode { get; set; }

            /// <summary>
            /// 所属货区ID(ShelfArea.ShelfAreaID)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public int ShelfAreaID { get; set; }

            /// <summary>
            /// 货位类型(0:存储;1:)
            /// </summary>
            public string ShelfType { get; set; }

            /// <summary>
            /// 仓库ID(Warehouse.WID)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public int WID { get; set; }

            /// <summary>
            /// 状态(0:正常;1:冻结)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string Status { get; set; }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {

            var requestDto = this.RequestDto;
            
            ShelfBLO.Edit(requestDto.MapTo<Frxs.Erp.ServiceCenter.Product.Model.Shelf>());


            return new ActionResult<int>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK"
            };
        }
    }
}
