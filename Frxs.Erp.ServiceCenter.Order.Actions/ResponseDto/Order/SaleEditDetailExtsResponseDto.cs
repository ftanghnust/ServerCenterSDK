using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto
{
   public class SaleEditDetailExtsResponseDto : ResponseDtoBase
    {
        #region 模型
        /// <summary>
        /// 编号(SaleEditDetails.ID)
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 改单编号(SaleEdit.EditID)
        /// </summary>
        public string EditID { get; set; }

        /// <summary>
        /// 基本分类一级分类ID(Category.CategoryId)
        /// </summary>
        public int CategoryId1 { get; set; }

        /// <summary>
        /// 基本分类一级分类名称
        /// </summary>
        public string CategoryId1Name { get; set; }

        /// <summary>
        /// 基本分类二级分类ID(Category.CategoryId)
        /// </summary>
        public int CategoryId2 { get; set; }

        /// <summary>
        /// 基本分类二级分类名称
        /// </summary>
        public string CategoryId2Name { get; set; }

        /// <summary>
        /// 基本分类三级分类ID(Category.CategoryId)
        /// </summary>
        public int CategoryId3 { get; set; }

        /// <summary>
        /// 基本分类三级分类名称
        /// </summary>
        public string CategoryId3Name { get; set; }

        /// <summary>
        /// 运营一级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        public int ShopCategoryId1 { get; set; }

        /// <summary>
        /// 运营一级分类名称
        /// </summary>
        public string ShopCategoryId1Name { get; set; }

        /// <summary>
        /// 运营二级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        public int ShopCategoryId2 { get; set; }

        /// <summary>
        /// 运营二级分类名称
        /// </summary>
        public string ShopCategoryId2Name { get; set; }

        /// <summary>
        /// 运营三级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        public int ShopCategoryId3 { get; set; }

        /// <summary>
        /// 运营三级分类名称
        /// </summary>
        public string ShopCategoryId3Name { get; set; }

        /// <summary>
        /// 品牌ID
        /// </summary>
        public int? BrandId1 { get; set; }

        /// <summary>
        /// 品牌ID名称
        /// </summary>
        public string BrandId1Name { get; set; }

        /// <summary>
        /// 子品牌ID
        /// </summary>
        public int? BrandId2 { get; set; }

        /// <summary>
        /// 子品牌名称
        /// </summary>
        public string BrandId2Name { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        public int? ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        public string ModifyUserName { get; set; }

        #endregion
    }
}
