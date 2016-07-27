using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    public class ShopCategoriesBLO
    {
        /// <summary>
        /// 根据当前节点，获取父节点和自身的分类每次字符串 （运营分类）
        /// </summary>
        /// <param name="shopCategoryId1">第一运营分类</param>
        /// <param name="shopCategoryId2">第二运营分类</param>
        /// <param name="shopCategoryId3">第三运营分类</param>
        /// <returns></returns>
        public static string GetShopCategoriesString(int shopCategoryId1, int shopCategoryId2, int shopCategoryId3)
        {
            IList<string> shopCategoryNames = new List<string>();
            var shopCategory1 = DALFactory.GetLazyInstance<IShopCategoriesDAO>().GetModel(shopCategoryId1);
            if (shopCategory1 != null)
            {
                shopCategoryNames.Add(shopCategory1.CategoryName);
            }
            var shopCategory2 = DALFactory.GetLazyInstance<IShopCategoriesDAO>().GetModel(shopCategoryId2);
            if (shopCategory2 != null)
            {
                shopCategoryNames.Add(shopCategory2.CategoryName);
            }
            var shopCategory3 = DALFactory.GetLazyInstance<IShopCategoriesDAO>().GetModel(shopCategoryId3);
            if (shopCategory3 != null)
            {
                shopCategoryNames.Add(shopCategory3.CategoryName);
            }
            return string.Join(">>", shopCategoryNames.ToArray());
        }
    }
}
