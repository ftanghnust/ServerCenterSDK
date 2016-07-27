/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/21 15:23:44
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Shop
{
    /// <summary>
    /// 冻结或解冻门店
    /// </summary>
    [ActionName("Shop.Freeze")]
    public class ShopFreezeAction : ActionBase<ShopFreezeRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            int row = 0;
            if (this.RequestDto != null)
            {
                //定义要批量操作的id序列
                List<int> shopIdList = new List<int>();
                //转换成string类型的List
                List<string> listStr = this.RequestDto.ShopID.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();//
                foreach (var str in listStr)
                {
                    shopIdList.Add(int.Parse(str));//转换成int类型
                }

                foreach (var id in shopIdList)
                {
                    Model.Shop model = ShopBLO.GetModel(id);

                    //TODO: 可能需要增加一些业务逻辑的判断，比如有人员和其他信息关联到该仓库的时候，不允许该操作，开发早期还没有足够的相关信息，预留在这里
                    model.Status = this.RequestDto.Status;
                    model.ModifyUserID = this.RequestDto.UserId;
                    model.ModifyUserName = this.RequestDto.UserName;
                    row += ShopBLO.ShopFreeze(model);
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
