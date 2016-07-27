using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/24 16:51:17
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取网仓商品信息(包括限购)，包括分页和不分页
    /// </summary>
    [ActionName("WProducts.Get.ToB2BExt")]
    public class WProductsGetToB2BExtAction : ActionBase<WProductsGetToB2BExtAction.WProductsGetToB2BExtActionRequestDto, WProductsGetToB2BExtAction.WProductsGetToB2BExtActionResponsetDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsGetToB2BExtActionRequestDto : RequestDtoBase
        {

            /// <summary>
            /// 是否分页(0表示不分，1表示分页)
            /// </summary>
            public int? IsPage { get; set; }

            /// <summary>
            ///PageIndex
            /// </summary>
            public int PageIndex { get; set; }

            /// <summary>
            /// PageSize
            /// </summary>
            public int PageSize { get; set; }

            /// <summary>
            ///  排序字段
            /// </summary>
            public string SortBy { get; set; }

            /// <summary>
            /// 仓库编号，必须填写
            /// </summary>
            [Required]
            public int? WID { get; set; }

            /// <summary>
            /// 商品ID  
            /// </summary>
            public IList<int> ProductIds { get; set; }

            /// <summary>
            /// 商品SKU
            /// </summary>
            public string SKU { get; set; }

            /// <summary>
            /// 商品名称
            /// </summary>
            public string ProductName { get; set; }

            /// <summary>
            /// 基础分类1
            /// </summary>
            public string CategoryId1 { get; set; }

            /// <summary>
            /// 基础分类2
            /// </summary>
            public string CategoryId2 { get; set; }

            /// <summary>
            /// 基础分类3
            /// </summary>
            public string CategoryId3 { get; set; }

            /// <summary>
            /// 关键字
            /// </summary>
            public string KeyWord { get; set; }  

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }

        }

        /// <summary>
        /// 输出对象信息
        /// </summary>
        public class WProductsGetToB2BExtActionResponsetDto
        {
            /// <summary>
            /// 仓库商品集合
            /// </summary>
            public IList<WProductExt> ItemList { get; set; }

            /// <summary>
            /// 总数
            /// </summary>
            public int TotalRecords { get; set; }
        }


        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<WProductsGetToB2BExtActionResponsetDto> Execute()
        {
            var productIds = "";

            //查询条件
            var searchCondition = new Dictionary<string, object>()
                .Append("WID", this.RequestDto.WID);

            #region 参数
            if (this.RequestDto.ProductIds != null && this.RequestDto.ProductIds.Count > 0)
            {
                productIds = string.Join(",", this.RequestDto.ProductIds);
            }
            if (!string.IsNullOrEmpty(this.RequestDto.SKU))
            {
                searchCondition.Add("SKU", this.RequestDto.SKU);
            }
            if (!string.IsNullOrEmpty(this.RequestDto.ProductName))
            {
                searchCondition.Add("ProductName", this.RequestDto.ProductName);
            }
            if (!string.IsNullOrEmpty(productIds)) //商品ID集合
            {
                searchCondition.Add("ProductIDs", productIds);
            }

            if (!string.IsNullOrEmpty(this.RequestDto.CategoryId1))
            {
                searchCondition.Add("CategoryId1", this.RequestDto.CategoryId1);
            }

            if (!string.IsNullOrEmpty(this.RequestDto.CategoryId2))
            {
                searchCondition.Add("CategoryId2", this.RequestDto.CategoryId2);
            }

            if (!string.IsNullOrEmpty(this.RequestDto.CategoryId3))
            {
                searchCondition.Add("CategoryId3", this.RequestDto.CategoryId3);
            }

            if (!string.IsNullOrEmpty(this.RequestDto.KeyWord))
            {
                searchCondition.Add("KeyWord", this.RequestDto.KeyWord);
            }
            
            searchCondition.Add("PageIndex", this.RequestDto.PageIndex);
            searchCondition.Add("PageSize", this.RequestDto.PageSize);
            if (!string.IsNullOrEmpty(this.RequestDto.SortBy))
            {
                searchCondition.Add("SortBy", this.RequestDto.SortBy);
            }
            #endregion 
            var responseDto = new WProductsGetToB2BExtActionResponsetDto();

            if (this.RequestDto.IsPage == 1)
            {

                var wProductObj = DALFactory.GetLazyInstance<IWProductsDAO>().GetListToB2BExtByPage(searchCondition);
                //返回仓库商品信息
                responseDto.TotalRecords = int.Parse( wProductObj["totalCount"].ToString());
                responseDto.ItemList = (List<WProductExt>)wProductObj["itemList"];
            }
            else
            {
                var wProductList = DALFactory.GetLazyInstance<IWProductsDAO>().GetListToB2BExt(searchCondition);
                //返回仓库商品信息
                responseDto.TotalRecords = 0; 
                responseDto.ItemList = wProductList;

            }

            return this.SuccessActionResult(responseDto);
        }
    }
}
