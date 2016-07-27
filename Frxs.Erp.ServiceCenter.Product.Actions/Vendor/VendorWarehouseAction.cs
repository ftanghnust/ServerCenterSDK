using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto.Vendor;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions.Vendor
{
    
    [Serializable]
    public class VendorGetVendorWarehouseRequest:RequestDtoBase
    {
        /// <summary>
        /// 供应商ID
        /// </summary>
        public int VendorID { get; set; }
    }

    [Serializable]
    public class VendorAddVendorWarehouseRequest : RequestDtoBase
    {
        /// <summary>
        /// 供应商ID
        /// </summary>
        public int VendorID { get; set; }

        private IList<WarehouseSelectModel> modelList = null;

        /// <summary>
        /// 关系表
        /// </summary>
        public IList<WarehouseSelectModel> ModelList
        {
            get { return modelList; }
            set { modelList = value; }
        }
    }

    /// <summary>
    /// 获取供应商列表
    /// </summary>
    [ActionName("Vendor.GetVendorWarehouse")]
    public class VendorGetVendorWarehouseAction : ActionBase<VendorGetVendorWarehouseRequest, IList<WarehouseSelectModel>>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<WarehouseSelectModel>> Execute()
        {
            var requestDto = this.RequestDto;
            IList<WarehouseSelectModel> items = VendorBLO.GetVendorWarehouse(requestDto.VendorID);
            return new ActionResult<IList<WarehouseSelectModel>>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = items
            };
        }
    }

    /// <summary>
    /// 获取供应商列表
    /// </summary>
    [ActionName("Vendor.GetNoneVendorWarehouse")]
    public class VendorGetNoneVendorWarehouseAction : ActionBase<VendorGetVendorWarehouseRequest, IList<WarehouseSelectModel>>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<WarehouseSelectModel>> Execute()
        {
            var requestDto = this.RequestDto;
            IList<WarehouseSelectModel> items = VendorBLO.GetNoneVendorWarehouse(requestDto.VendorID);
            return new ActionResult<IList<WarehouseSelectModel>>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = items
            };
        }
    }

    /// <summary>
    /// 获取供应商列表
    /// </summary>
    [ActionName("Vendor.AddVendorWarehouse")]
    public class VendorAddVendorWarehouseAction : ActionBase<VendorAddVendorWarehouseRequest, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            int rowcnt = VendorBLO.AddVendorWarehouse(requestDto.VendorID, requestDto.ModelList);
            return new ActionResult<int>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = rowcnt
            };
        }
    }
}
