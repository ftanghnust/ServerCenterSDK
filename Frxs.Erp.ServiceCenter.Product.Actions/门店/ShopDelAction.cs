/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/21 15:11:39
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
    /// 逻辑删除门店 支持批量删除(,作为分隔符)
    /// </summary>
    [ActionName("Shop.Del")]
    public class ShopDelAction : ActionBase<ShopDelRequestDto, int>
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

                    //应该增加一些业务逻辑的判断，比如该门店有相关单据的时候，不允许删除，
                    //经过需求确认，需要查询订单项目中该门店的相关信息，不能在基础资料的SDK中反向引用订单项目的SDK，
                    //所以能否删除的逻辑只能放到应用程序层调用订单中心的SDK来预先处理 因此本接口只接受筛选之后能够删除的门店列表

                    model.ModifyUserID = this.RequestDto.UserId;
                    model.ModifyUserName = this.RequestDto.UserName;
                    row += ShopBLO.LogicDelete(model);
                    //删除门店时 删除仓库配送线路门店关系表 相应记录
                    WarehouseLineShopBLO.DeleteByShopID(model.ShopID);
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
