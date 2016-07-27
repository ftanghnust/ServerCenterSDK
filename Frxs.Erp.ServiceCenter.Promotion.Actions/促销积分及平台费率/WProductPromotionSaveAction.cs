/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/8 16:07:41
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 商品促销保存(新增和修改)
    /// Add表示信息 Edit表示修改
    /// </summary>
    [ActionName("WProduct.Promotion.Save")]
    public class WProductPromotionSaveAction : ActionBase<WProductPromotionSaveAction.WProductPromotionSaveActioncsRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductPromotionSaveActioncsRequestDto : RequestDtoParent //RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 促销类型(1:门店积分促销;2:平台费率促销)
            /// </summary>
            public int PromotionType { get; set; }
            /// <summary>
            /// 标志位 Add表示信息 Edit表示修改
            /// </summary>
            public string Flag { get; set; }

            #region 主表实体中需的数据
            /// <summary>
            /// 主键ID(WID+ID服务表)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string PromotionID { get; set; }

            /// <summary>
            /// 仓库ID(WarehouseID)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public int WID { get; set; }

            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string WCode { get; set; }

            /// <summary>
            /// 仓库名称
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string WName { get; set; }

            /// <summary>
            /// 活动主题
            /// </summary>
            //[Required(ErrorMessage = "{0}不能为空")]
            public string PromotionName { get; set; }

            /// <summary>
            /// 生效开始时间(yyyy-MM-dd HH:mm:ss)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public DateTime BeginTime { get; set; }

            /// <summary>
            /// 生效结束时间(yyyy-MM-dd HH:mm:ss)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public DateTime EndTime { get; set; }

            /// <summary>
            /// 状态(0:未提交;1:已提交;2:已过帐/已开始;3:已停用)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public int Status { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            public string Remark { get; set; }
            #endregion
            /// <summary>
            /// 促销商品详情列表
            /// </summary>
            public IList<WProductPromotionDetails> DetailList { get; set; }

            /// <summary>
            /// 促销门店列表
            /// </summary>
            public IList<WProductPromotionShops> ShopList { get; set; }

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
        public class WProductPromotionSaveActioncsResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            WProductPromotion modelToSave = new WProductPromotion();

            var requestDto = this.RequestDto;
            if (requestDto != null)
            {
                modelToSave = requestDto.MapTo<WProductPromotion>();
                string warehouseId = requestDto.WarehouseId.ToString();
                #region 主表 通用的属性赋值
                modelToSave.ModifyTime = DateTime.Now;
                modelToSave.ModifyUserID = requestDto.UserId;
                modelToSave.ModifyUserName = requestDto.UserName;
                #endregion

                if (requestDto.Flag.ToLower() != "edit")
                {
                    #region 主表 新增
                    modelToSave.CreateTime = DateTime.Now;
                    modelToSave.CreateUserID = requestDto.UserId;
                    modelToSave.CreateUserName = requestDto.UserName;
                    #endregion
                    try
                    {
                        WProductPromotionBLO.SaveInfo(modelToSave, requestDto.DetailList, requestDto.ShopList, warehouseId);
                    }
                    catch (Exception ex)
                    {
                        return this.ErrorActionResult("操作失败! " + ex.Message);
                    }
                    return this.SuccessActionResult("新增数据成功！", 1);
                }
                else
                {
                    //修改记录时必须先验证一下，表头是否在录单状态。
                    WProductPromotion modelNow = WProductPromotionBLO.GetModel(modelToSave.PromotionID, warehouseId);
                    if (modelNow != null)
                    {
                        if (modelNow.Status == 0)
                        {
                            WProductPromotionBLO.EditInfo(modelToSave, requestDto.DetailList, requestDto.ShopList, warehouseId);
                            return this.SuccessActionResult("修改数据成功！", 1);
                        }
                        else
                        {
                            return this.ErrorActionResult("该单据不是“录单”状态,不能修改!");
                        }
                    }
                    else
                    {
                        return this.ErrorActionResult("该单据不存在!");
                    }
                }
            }
            else
            {
                return this.ErrorActionResult("上送的参数不正确!");
            }
        }

    }
}
