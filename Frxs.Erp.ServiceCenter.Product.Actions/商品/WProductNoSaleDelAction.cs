/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/31 15:39:07
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 商品限购 删除
    /// 返回删除的行数
    /// </summary>
    [ActionName("WProduct.NoSale.Del")]
    public class WProductNoSaleDelAction : ActionBase<WProductNoSaleDelAction.WProductNoSaleDelRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductNoSaleDelRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 要删除的ID序列
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public List<string> IdList { get; set; }

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
        public class WProductNoSaleDelResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            int result = 0;
            string msg = string.Empty;
            if (this.RequestDto != null && this.RequestDto.IdList.Count > 0)
            {
                foreach (var noSaleID in this.RequestDto.IdList)
                {
                    var model = WProductNoSaleBLO.GetModel(noSaleID);
                    if (model.Status == 0)
                    {
                        result += WProductNoSaleBLO.DeleteInfo(noSaleID);
                    }
                    else
                    {
                        msg += string.Format(" 单号[{0}]的记录不是“录单”状态,不能删除！ <br />", noSaleID);
                    }
                }
                if (result < RequestDto.IdList.Count)
                {
                    return ErrorActionResult(string.Format("操作完成！{0}条记录操作成功,{1}条记录操作失败! <br />原因：<br />{2}", result, RequestDto.IdList.Count - result, msg), result);
                }
                return this.SuccessActionResult(string.Format("操作完成! 删除了{0}条数据。", result) + msg, result);
            }
            else
            {
                return this.ErrorActionResult("上送的参数不正确！", result);
            }
        }
    }
}
