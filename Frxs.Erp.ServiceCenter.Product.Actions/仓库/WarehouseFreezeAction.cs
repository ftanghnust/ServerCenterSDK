/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/15 18:24:53
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Warehouse
{
    /// <summary>
    /// 冻结或解冻仓库
    /// </summary>
    [ActionName("Warehouse.Freeze")]
    public class WarehouseFreezeAction : ActionBase<RequestDto.WarehouseFreezeRequestDto, int>
    {
        
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns>处理结果</returns>
        public override ActionResult<int> Execute()
        {
            //throw new NotImplementedException();            
            int row = 0;
            if (this.RequestDto!=null)
            {
                List<int> ids = this.RequestDto.WID;
                int isFreeze = this.RequestDto.IsFreeze;
                
                foreach (var id in ids)
                {
                    Model.Warehouse model = WarehouseBLO.GetModel(id);

                    //TODO: 可能需要先做业务逻辑判断，是否允许该操作 

                    model.IsFreeze = isFreeze;//设定IsFreeze属性的值
                    model.ModityTime = DateTime.Now;
                    model.ModityUserID = RequestDto.ModityUserID;
                    model.ModityUserName = RequestDto.ModityUserName;
                    row += WarehouseBLO.WarehouseFreeze(model);
                }
                
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.SUCCESS,
                    Info = "OK",
                    Data = row
                };
            }           
            else
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = "FAIL,上送参数的Json数据可能格式不对",
                    Data = row
                };
            }
            
        }

    }
}
