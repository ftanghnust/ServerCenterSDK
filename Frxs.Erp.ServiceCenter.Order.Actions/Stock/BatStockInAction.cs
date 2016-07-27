using Frxs.Erp.ServiceCenter.Order.BLL.Stock;
using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Stock
{
    /// <summary>
    /// 批次入库请求参数
    /// </summary>
    [Serializable]
    public class BatStockInDTO : RequestDtoBase
    {
        public BatStockInModel Data { get; set; }
    }

    /// <summary>
    /// 根据条件获取库存信息
    /// </summary>
    [ActionName("StockQty.BatStockIn")]
    public class BatStockInAction : ActionBase<BatStockInDTO, bool>
    {
        /// <summary>
        /// 执行业务逻辑（批次入库参数全部参数不能为空）
        /// </summary>
        /// <returns></returns>
        public override ActionResult<bool> Execute()
        {
            BatStockInDTO reqDTO = this.RequestDto;
            if (reqDTO.Data == null)
            {
                return ErrorActionResult("Data:参数不能为空");               
            }
            if (reqDTO.Data.InPList == null || reqDTO.Data.InPList.Count == 0)
            {
                return ErrorActionResult("Data.InPList:批次入库商品列表为空");
            }
            if (reqDTO.Data.WID <= 0)
            {
                return ErrorActionResult("WID:参数不能为空");
            }
            if (reqDTO.Data.SubWID <= 0)
            {
                return ErrorActionResult("SubWID:参数不能为空");
            }
            if (reqDTO.Data.CreateUserID == null || (int)reqDTO.Data.CreateUserID <= 0)
            {
                return ErrorActionResult("CreateUserID:参数不能为空");
            }
            bool result = StockMangerBLO.BatStockIn(reqDTO.Data);
            return SuccessActionResult(result);
        }

        
    }
}
