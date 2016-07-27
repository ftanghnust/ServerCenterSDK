using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto.Vendor;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions.Vendor
{
    /// <summary>
    /// 获取供应商列表
    /// </summary>
    [ActionName("Vendor.Del")]
    public class VendorDelAction : ActionBase<VendorDelRequest, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            int row = 0;

            if (!string.IsNullOrEmpty(requestDto.VendorIDs))
            {
                string sids = requestDto.VendorIDs.Replace("'", "").Trim();
                if (sids.EndsWith(","))
                {
                    sids = sids.Substring(0, sids.Length - 1);
                }
                var vendorIDs = sids.Split(',');

                foreach (string id in vendorIDs)
                {
                    if (ProductsVendorBLO.GetVendProductsCount(int.Parse(id)) == 0)
                    {
                        //判断是否存在供货关系
                        row += VendorBLO.LogicDelete(int.Parse(id));
                    }
                }
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.SUCCESS,
                    Info = (row == vendorIDs.Length) ? "成功删除" : row == 0 ? string.Format("{0}个供应商存在供货关系、不能删除！", vendorIDs.Length) : string.Format("{0}个供应商删除成功，{1}个供应商存在供货关系、不能删除！",row,vendorIDs.Length-row),
                    Data = row
                };
            }
            else
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.SUCCESS,
                    Info = "没有选择删除的供应商",
                    Data = 0
                };
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [ActionName("Vendor.IsFrozen")]
    public class VendorIsFrozenAction : ActionBase<VendorIsFrozenRequest, int>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            int row = 0;
            if (!string.IsNullOrEmpty(requestDto.VendorIDs))
            {
                string sids = requestDto.VendorIDs.Replace("'", "").Trim();
                if (sids.EndsWith(","))
                {
                    sids = sids.Substring(0, sids.Length - 1);
                }
                var shelfIds = sids.Split(',');

                row = VendorBLO.UpdateStatus(shelfIds, requestDto.Status, DateTime.Now, requestDto.UserId, requestDto.UserName);
            }
            return new ActionResult<int>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = row
            };
        }
    }
}
