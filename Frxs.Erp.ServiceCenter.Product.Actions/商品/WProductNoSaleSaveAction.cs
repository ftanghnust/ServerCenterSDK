/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/31 15:38:18
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 商品限购信息 保存
    /// </summary>
    [ActionName("WProduct.NoSale.Save")]
    public class WProductNoSaleSaveAction : ActionBase<WProductNoSaleSaveAction.WProductNoSaleSaveRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductNoSaleSaveRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 标志位 Add 表示新增 Edit 表示
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string Flag { get; set; }

            #region 主表相关模型

            /// <summary>
            /// 主键ID(WID + GUID)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string NoSaleID { get; set; }

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
            /// 提交时间
            /// </summary>            
            public DateTime? ConfTime { get; set; }

            /// <summary>
            /// 提交用户ID
            /// </summary>

            public int? ConfUserID { get; set; }

            /// <summary>
            /// 提交用户名称
            /// </summary>

            public string ConfUserName { get; set; }

            /// <summary>
            /// 过帐时间
            /// </summary>            
            public DateTime? PostingTime { get; set; }

            /// <summary>
            /// 过帐用户ID
            /// </summary>
            public int? PostingUserID { get; set; }

            /// <summary>
            /// 过帐用户名称
            /// </summary>
            public string PostingUserName { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            public string Remark { get; set; }

            #endregion


            /// <summary>
            /// 详情表集合
            /// </summary>
            public List<Model.WProductNoSaleDetails> DetailsList { get; set; }

            /// <summary>
            /// 门店关联表集合
            /// </summary>
            public List<Model.WProductNoSaleShops> ShopList { get; set; }

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
        public class WProductNoSaleSaveResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            WProductNoSale noSaleToSave = new WProductNoSale();



            var requestDto = this.RequestDto;
            if (requestDto != null)
            {
                noSaleToSave = requestDto.MapTo<WProductNoSale>();

                #region 主表 通用的属性赋值
                noSaleToSave.ModifyTime = DateTime.Now;
                noSaleToSave.ModifyUserID = requestDto.UserId;
                noSaleToSave.ModifyUserName = requestDto.UserName;
                #endregion

                if (requestDto.Flag.ToLower() != "edit")
                {
                    #region 主表 新增
                    noSaleToSave.CreateTime = DateTime.Now;
                    noSaleToSave.CreateUserID = requestDto.UserId;
                    noSaleToSave.CreateUserName = requestDto.UserName;
                    #endregion

                    WProductNoSaleBLO.SaveInfo(noSaleToSave, requestDto.DetailsList, requestDto.ShopList);   //Nosale是主键，不需要验证Exists                 
                    return this.SuccessActionResult();
                }
                else
                {
                    var model = WProductNoSaleBLO.GetModel(RequestDto.NoSaleID);
                    if (model == null || model.Status != 0)
                    {
                        return ErrorActionResult("当前记录不处于“录单”状态，不能编辑!");
                    }
                    WProductNoSaleBLO.EditInfo(noSaleToSave, requestDto.DetailsList, requestDto.ShopList);
                    return this.SuccessActionResult();
                }
            }
            else
            {
                return this.ErrorActionResult("上送的参数不正确!");
            }
        }
    }
}
