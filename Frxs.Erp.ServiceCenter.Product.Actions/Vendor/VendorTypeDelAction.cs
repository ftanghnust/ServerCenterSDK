/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/14 9:31:38
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto.Vendor
{
    /// <summary>
    /// 供应商分类删除接口
    /// </summary>
    [ActionName("VendorType.Del")]
    public class VendorTypeDelAction : ActionBase<VendorTypeDelAction.VendorTypeDelActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class VendorTypeDelActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 待删除的供应商分类ID序列
            /// Web UI端可以调用 StringExtension类的 ToIntArray方法方便的转换string成int数组
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public IList<int> VendorTypeIDList { get; set; }
            /// <summary>
            /// 校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }

        }

        /// <summary>
        /// 下送的数据
        /// </summary>
        public class VendorTypeDelActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            if (this.RequestDto != null && this.RequestDto.VendorTypeIDList != null && this.RequestDto.VendorTypeIDList.Count > 0)
            {
                int rows = 0;
                string msg = string.Empty;
                List<int> idList = RequestDto.VendorTypeIDList.ToList();

                int existVendor = 0;

                VendorType model = new VendorType();
                foreach (var typeID in idList)
                {
                    bool existsVendor = false;//是否被引用
                    model = VendorTypeBLO.GetModel(typeID);
                    string vendorTypeName = (model != null && !string.IsNullOrEmpty(model.VendorTypeName)) ? model.VendorTypeName : "未知分类";
                    //TODO 需要逻辑判断供应商分类是否被引用
                    //1.有主供应商相关联 不能删除  SELECT * FROM WProductsBuy WHERE VendorID={id} 
                    if (VendorTypeBLO.ExistsVendor(model))
                    {
                        existVendor += 1;
                        existsVendor = true;
                        msg += string.Format(" 分类[{0}]有关联的供应商,不能删除 <br />", vendorTypeName);
                    }
                    //叶求建议先做好基础功能 第2、3条后续再完善。
                    //2. SELECT COUNT(*) FROM vBuyOrder WHERE VendorID IN (SELECT VendorID FROM Vendor WHERE VendorTypeID =@VendorTypeID) 需读取跨库视图 

                    //3. SELECT COUNT(*) FROM vBuyBack WHERE VendorID IN (SELECT VendorID FROM Vendor WHERE VendorTypeID =@VendorTypeID) 需读取跨库视图

                    if (model != null && existsVendor == false)
                    {
                        rows += VendorTypeBLO.LogicDelete(typeID);
                    }
                }
                if (rows < idList.Count)
                {
                    return ErrorActionResult(string.Format("操作完成。<br />成功删除{0}个分类，{1}个分类删除失败! <br />原因：<br />{2}", rows, idList.Count - rows, msg), rows);
                }
                return this.SuccessActionResult(string.Format("操作完成，删除了{0}个分类!{1}", rows, msg), rows);
            }
            else
            {
                return this.ErrorActionResult("上送的参数不对！");
            }
        }
    }
}
