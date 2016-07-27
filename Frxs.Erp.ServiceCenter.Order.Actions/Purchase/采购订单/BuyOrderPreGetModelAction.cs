/*********************************************************
 * FRXS(ISC) ftanghnust@gmail.com 2016/3/8 17:19:57
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
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Order.IDAL;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 采购收货单(待处理)获取
    /// </summary>
    [ActionName("BuyOrderPre.GetModel")]
    public class BuyOrderPreGetModelAction : ActionBase<RequestDto.BuyOrderPreGetModelActionRequestDto, ResponseDto.BuyOrderPreGetModelActionResponseDto>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ResponseDto.BuyOrderPreGetModelActionResponseDto> Execute()
        {
            var requestDto = this.RequestDto;
            if (string.IsNullOrEmpty(requestDto.BuyID))
            {
                return this.ErrorActionResult("采购单编号不能为空");
            }
            if (requestDto.WarehouseId <= 0)
            {
                return this.ErrorActionResult("错误的仓库编号");
            }
            BuyOrderPre orderTemp = BuyOrderPreBLO.GetModel(requestDto.BuyID, requestDto.WarehouseId.ToString());

            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            conditionDict.Add("BuyID", requestDto.BuyID);
            IList<BuyOrderPreDetails> orderdetailsTemp = BuyOrderPreDetailsBLO.GetList(conditionDict, requestDto.WarehouseId.ToString());
            IList<BuyOrderPreDetailsExt> orderdetailsextTemp = DALFactory.GetLazyInstance<IBuyOrderPreDetailsExtDAO>(requestDto.WarehouseId.ToString()).GetList(conditionDict);
            return this.SuccessActionResult(new ResponseDto.BuyOrderPreGetModelActionResponseDto() { order = orderTemp, orderdetails = orderdetailsTemp, orderdetailsext = orderdetailsextTemp });
        }
    }
}
