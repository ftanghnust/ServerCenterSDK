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
    /// 销售退货单(待处理)获取
    /// </summary>
    [ActionName("SaleBackPre.GetModel")]
    public class SaleBackPreGetModelAction : ActionBase<RequestDto.SaleBackPreGetModelActionRequestDto, ResponseDto.SaleBackPreGetModelActionResponseDto>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ResponseDto.SaleBackPreGetModelActionResponseDto> Execute()
        {
            var requestDto = this.RequestDto;
            if (string.IsNullOrEmpty(requestDto.BackID))
            {
                return this.ErrorActionResult("销售退货单编号不能为空");
            }
            if (requestDto.WarehouseId <= 0)
            {
                return this.ErrorActionResult("错误的仓库编号");
            }

            SaleBackPre orderTemp = SaleBackPreBLO.GetModel(requestDto.BackID, requestDto.WarehouseId.ToString());

            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            conditionDict.Add("BackID", requestDto.BackID);
            IList<SaleBackPreDetails> orderdetailsTemp = SaleBackPreDetailsBLO.GetList(conditionDict, requestDto.WarehouseId.ToString());
            IList<SaleBackPreDetailsExt> orderdetailsextTemp = DALFactory.GetLazyInstance<ISaleBackPreDetailsExtDAO>(requestDto.WarehouseId.ToString()).GetList(conditionDict);
            return this.SuccessActionResult(new ResponseDto.SaleBackPreGetModelActionResponseDto() { order = orderTemp, orderdetails = orderdetailsTemp, orderdetailsext = orderdetailsextTemp });
        }
    }
}
