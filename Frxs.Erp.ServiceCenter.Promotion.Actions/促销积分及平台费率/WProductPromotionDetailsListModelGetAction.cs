/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/6 16:39:57
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Promotion.BLL;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 促销门店商品列表查询
    /// </summary>
    [ActionName("WProduct.PromotionDetails.ListModel.Get")]
    public class WProductPromotionDetailsListModelGetAction : ActionBase<WProductPromotionDetailsListModelGetAction.WProductPromotionDetailsListModelGetActionRequestDto, IList<WProductPromotionDetails>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductPromotionDetailsListModelGetActionRequestDto : RequestDtoBase  //(分页列表继承基类)
        {
            /// <summary>
            /// 仓库ID(WarehouseID)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public int WID { get; set; }

            /// <summary>
            /// 生效开始时间(yyyy-MM-dd HH:mm:ss)
            /// </summary>
            public DateTime? BeginTime { get; set; }

            /// <summary>
            /// 生效结束时间(yyyy-MM-dd HH:mm:ss)
            /// </summary>
            public DateTime? EndTime { get; set; }

            /// <summary>
            /// 门店ID
            /// </summary>
            public int? ShopID { get; set; }

            /// <summary>
            /// 商品ID
            /// </summary>
            public string ProductIDList { get; set; }

            /// <summary>
            /// 促销类型(1:门店积分促销;2:平台费率促销)
            /// </summary>
            public int? PromotionType { get; set; }

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
        public class WProductPromotionListGetActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<WProductPromotionDetails>> Execute()
        {
            //throw new NotImplementedException();
            var requestDto = this.RequestDto;

            if (this.RequestDto == null)
            {
                return ErrorActionResult("上传的参数不对!");
            }

            string wid = requestDto.WID.ToString();
            
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            IList<Model.WProductPromotionDetails> models = WProductPromotionDetailsBLO.GetList(requestDtoDict, wid);

            return this.SuccessActionResult(models);
        }

    }
}
