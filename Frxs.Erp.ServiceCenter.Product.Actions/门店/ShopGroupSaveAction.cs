/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/25 9:57:09
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
    /// 保存 门店群组表 (新增/编辑)
    /// </summary>
    [ActionName("ShopGroup.Save")]
    public class ShopGroupSaveAction : ActionBase<ShopGroupSaveAction.ShopGroupSaveActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ShopGroupSaveActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            #region 模型

            /// <summary>
            /// Add表示新增 Edit表示编辑
            /// </summary>
            public string Flag { get; set; }

            /// <summary>
            /// 分组ID
            /// </summary>
            public int GroupID { get; set; }

            /// <summary>
            /// 群组编号
            /// </summary>           
            [Required(ErrorMessage = "{0}不能为空")]
            public string GroupCode { get; set; }

            /// <summary>
            /// 仓库ID(Warehouse.WID)
            /// </summary>          
            [Required(ErrorMessage = "{0}不能为空")]
            public int WID { get; set; }

            /// <summary>
            /// 群组名称
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string GroupName { get; set; }

            /// <summary>
            /// 备注
            /// </summary>

            public string Remark { get; set; }

            /// <summary>
            /// 门店集合
            /// </summary>         
            public IList<ShopGroupDetails> List { get; set; }

            #endregion
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
        public class ShopGroupSaveActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            //throw new NotImplementedException();

            ShopGroup shopGroup = new ShopGroup();
            shopGroup.GroupID = this.RequestDto.GroupID;
            shopGroup.GroupCode = this.RequestDto.GroupCode;
            shopGroup.GroupName = this.RequestDto.GroupName;
            shopGroup.Remark = this.RequestDto.Remark;
            shopGroup.WID = this.RequestDto.WID;

            var shopGroupDetailsList = new List<ShopGroupDetails>();
            if (this.RequestDto.List != null && this.RequestDto.List.Count > 0)
            {
                int i = 0;
                foreach (var details in RequestDto.List)
                {
                    i = i + 1;
                    ShopGroupDetails shopGroupDetails = details.MapTo<ShopGroupDetails>();
                    shopGroupDetails.GroupID = RequestDto.GroupID;
                    shopGroupDetails.WID = RequestDto.WID;
                    shopGroupDetails.ShopID = details.ShopID;

                    shopGroupDetails.CreateTime = DateTime.Now;
                    shopGroupDetails.CreateUserID = this.RequestDto.UserId;
                    shopGroupDetails.CreateUserName = this.RequestDto.UserName;

                    shopGroupDetailsList.Add(shopGroupDetails);
                }

            }
            else
            {
                return this.ErrorActionResult("明细不能为空！");
            }
            shopGroup.List = shopGroupDetailsList;//相关联的详情信息             

            if (this.RequestDto.Flag == "Add")
            {
                if (ShopGroupBLO.Exists(shopGroup))
                {
                    return this.ErrorActionResult("分组ID已经存在!");
                }
                if (ShopGroupBLO.ExistsGroupCode(shopGroup))
                {
                    return this.ErrorActionResult("分组编号已经存在!");
                }
                if (ShopGroupBLO.ExistsGroupName(shopGroup))
                {
                    return this.ErrorActionResult("分组名称已经存在!");
                }
                shopGroup.CreateTime = DateTime.Now;
                shopGroup.CreateUserID = RequestDto.UserId;
                shopGroup.CreateUserName = RequestDto.UserName;
                shopGroup.IsDeleted = 0;

                ShopGroupBLO.SaveInfo(shopGroup);

                return this.SuccessActionResult();


            }
            else
            {
                if (ShopGroupBLO.ExistsGroupCode(shopGroup))
                {
                    return this.ErrorActionResult("分组编号已经存在!");
                }
                if (ShopGroupBLO.ExistsGroupName(shopGroup))
                {
                    return this.ErrorActionResult("分组名称已经存在!");
                }
                ShopGroupBLO.EditInfo(shopGroup);

                return this.SuccessActionResult();

            }
        }

        /// <summary>
        /// 删除匹配到的缓存键
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            this.CacheManager.RemoveByPattern(ShopCacheKey.FRXS_SHOP_GROUP_PATTERN_KEY);
        }
    }
}
