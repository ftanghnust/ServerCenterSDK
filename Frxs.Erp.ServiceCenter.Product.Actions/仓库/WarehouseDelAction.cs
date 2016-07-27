using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions.Warehouse
{
    /// <summary>
    /// 删除仓库，支持批量删除 仓库id是int类型的集合
    /// 仓库有子机构，则不能删除
    /// 仓库商品表中有产品关联，不能删除
    /// </summary>
    [ActionName("Warehouse.Del")]
    public class WarehouseDelAction : ActionBase<RequestDto.WarehouseDelRequestDto, int>
    {

        /// <summary>
        /// 删除仓库
        /// 仓库有子机构，则不能删除
        /// 仓库商品表中有产品关联，不能删除
        /// </summary>
        /// <returns>影响记录的数量</returns>
        public override ActionResult<int> Execute()
        {
            int row = 0;
            string errInfo = string.Empty;//返回的附加说明信息
            if (this.RequestDto != null)
            {
                List<int> ids = this.RequestDto.WID;
                foreach (var id in ids)
                {
                    //每个仓库的具体信息
                    string msgForOne = string.Empty;
                    Model.Warehouse model = WarehouseBLO.GetModel(id);
                    string wcode = model.WCode;
                    int subNum = WarehouseBLO.GetSubNum(id);
                    //1.仓库有子机构，则不能删除
                    if (subNum > 0)
                    {
                        msgForOne += string.Format(" 有{0}个关联的子机构;", subNum);
                    }
                    //门店数量
                    int shopNum = 0;
                    shopNum = WarehouseBLO.GetShopNum(id);
                    if (shopNum > 0)
                    {
                        msgForOne += string.Format(" 有{0}个关联的门店;", shopNum);
                    }
                    //商品数量
                    int prodNum = 0;
                    prodNum = WarehouseBLO.GetWProductsNum(id);
                    //2.仓库商品表中有产品关联，不能删除
                    if (prodNum > 0)
                    {
                        msgForOne += string.Format(" 有{0}个关联的产品; ", prodNum);
                    }

                    if (subNum == 0 && prodNum == 0 && shopNum == 0)
                    {
                        model.ModityTime = DateTime.Now;
                        model.ModityUserID = this.RequestDto.ModityUserID;
                        model.ModityUserName = this.RequestDto.ModityUserName;
                        row += WarehouseBLO.LogicDelete(model);
                    }
                    else
                    {
                        errInfo += string.Format(" 仓库[{0}]不能删除:{1}<br />", wcode, msgForOne);
                    }
                }
                if (row < ids.Count)
                {
                    string errMsg = (row > 0) ? string.Format(" {0}个仓库删除成功，{1}个仓库删除失败! <br />原因：<br />{2}", row, ids.Count - row, errInfo) : string.Format("仓库删除失败！ <br />原因：<br />{0}", errInfo);
                    //删除失败了
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = errMsg,// row > 0 ? string.Format(" {0}个仓库删除成功，{1}个仓库删除失败! <br />", row, ids.Count - row) : "仓库删除失败！ <br />" + errInfo,
                        Data = row
                    };
                }
                else
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.SUCCESS,
                        Info = string.Format(" 成功删除{0}个仓库!<br />", row),
                        Data = row
                    };
                }
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
