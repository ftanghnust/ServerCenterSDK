/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/25 9:57:36
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 删除门店群组 支持批量操作 采用事务操作 
    /// Web UI端可以调用 StringExtension类的 ToIntArray方法方便的转换string成int数组
    /// </summary>
    [ActionName("ShopGroup.Del")]
    public class ShopGroupDelAction : ActionBase<ShopGroupDelAction.ShopGroupDelActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ShopGroupDelActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 群组ID 支持批量操作 js端使用 , 分隔
            /// Web UI端可以调用Infrastructure文件夹中的StringExtension类的 ToIntArray方法方便的转换string成int数组，再用ToList()即可转换成List
            /// </summary>
            public List<int> GroupID { get; set; }

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
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            //throw new NotImplementedException();

            //TODO: 删除关联的详情表 再删除主表
            List<int> groupIDs = this.RequestDto.GroupID;
            int row = 0;
            if (this.RequestDto != null && this.RequestDto.GroupID.Count > 0)
            {
                #region 采用事物处理，到业务逻辑层处理
                try
                {
                    row = ShopGroupBLO.LogicDelete(RequestDto.GroupID);
                }
                catch (Exception ex)
                {
                    return this.ErrorActionResult("错误:" + ex.Message, row);
                }

                #endregion

                #region 批量逻辑删除 旧方法，未采用事务
                //foreach (var id in groupIDs)
                //{
                //    //TODO: 是否应该增加一些业务逻辑的判断，比如有人员和其他信息关联到的时候，不允许删除，开发早期还没有足够的相关信息，预留在这里

                //    ShopGroupDetailsBLO.DeleteByGroupID(id);//先删除关联的详情表
                //    row += ShopGroupBLO.LogicDelete(id);//再逻辑删除主表信息
                //}
                //return new ActionResult<int>()
                //{
                //    Flag = ActionResultFlag.SUCCESS,
                //    Info = "OK",
                //    Data = row
                //};
                #endregion

                return this.SuccessActionResult(row);
            }
            else
            {
                return this.ErrorActionResult("FAIL,上送参数的Json数据可能格式不对", row);
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
