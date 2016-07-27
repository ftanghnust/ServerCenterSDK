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
    /// 采购退货单(待处理)获取
    /// </summary>
    [ActionName("BuyBackPre.GetModel")]
    public class BuyBackPreGetModelAction : ActionBase<RequestDto.BuyBackPreGetModelActionRequestDto, ResponseDto.BuyBackPreGetModelActionResponseDto>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ResponseDto.BuyBackPreGetModelActionResponseDto> Execute()
        {
            var requestDto = this.RequestDto;
            if (string.IsNullOrEmpty(requestDto.BackID))
            {
                return this.ErrorActionResult("采购退货单编号不能为空");
            }
            if (requestDto.WarehouseId <= 0)
            {
                return this.ErrorActionResult("错误的仓库编号");
            }

            BuyBackPre orderTemp = BuyBackPreBLO.GetModel(requestDto.BackID, requestDto.WarehouseId.ToString());

            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            conditionDict.Add("BackID", requestDto.BackID);
            IList<BuyBackPreDetails> orderdetailsTemp = BuyBackPreDetailsBLO.GetList(conditionDict, requestDto.WarehouseId.ToString());
            IList<BuyBackPreDetailsExt> orderdetailsextTemp = DALFactory.GetLazyInstance<IBuyBackPreDetailsExtDAO>(requestDto.WarehouseId.ToString()).GetList(conditionDict);

            return this.SuccessActionResult(new ResponseDto.BuyBackPreGetModelActionResponseDto() { order = orderTemp, orderdetails = orderdetailsTemp, orderdetailsext = orderdetailsextTemp });
        }
    }
}
