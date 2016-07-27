using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    public class CategoriesBLO
    {
        /// <summary>
        /// 根据当前节点，获取父节点和自身的分类每次字符串
        /// </summary>
        /// <param name="categoryId1"> </param>
        /// <param name="categoryId2"></param>
        /// <param name="categoryId3"> </param>
        /// <returns></returns>
        public static string GetCategoriesString(int categoryId1, int categoryId2, int categoryId3)
        {
            //基本分类
            IList<string> categoryNames = new List<string>();
            var category1 = DALFactory.GetLazyInstance<ICategoriesDAO>().GetModel(categoryId1);
            if (category1 != null)
            {
                categoryNames.Add(category1.Name);
            }
            var category2 = DALFactory.GetLazyInstance<ICategoriesDAO>().GetModel(categoryId2);
            if (category2 != null)
            {
                categoryNames.Add(category2.Name);
            }
            var category3 = DALFactory.GetLazyInstance<ICategoriesDAO>().GetModel(categoryId3);
            if (category3 != null)
            {
                categoryNames.Add(category3.Name);
            }
            return string.Join(">>", categoryNames.ToArray());
        }

    }
}
