using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    /// <summary>
    /// 商品单位处理逻辑
    /// </summary>
    public class ProductsUnitBLO
    {
        /// <summary>
        /// √批量添加商品单位
        /// </summary>
        /// <param name="units">商品单位对象列表</param>
        /// <param name="conn">连接数据库对象 </param>
        /// <param name="trans"> 事务对象</param>
        /// <returns></returns>
        public static BackMessage<int> ProductUnitsAdd(ProductsUnit units, IDbConnection conn, IDbTransaction trans)
        {
            if (units == null)
            {
                return new BackMessage<int>()
                {
                    IsSuccess = false,
                    Message = "商品单位不能为空"
                };
            }
            if (units.PackingQty < 0)
            {
                return new BackMessage<int>()
                {
                    IsSuccess = false,
                    Message = "商品包装数不能为负数"
                };
            }

            if (string.IsNullOrWhiteSpace(units.Spec))
            {
                return new BackMessage<int>()
                {
                    IsSuccess = false,
                    Message = "商品规格不能为空"
                };
            }

            ////已经存在商品单位
            //if (DALFactory.GetLazyInstance<IProductsUnitDAO>().ExistsProductsUnitName(units))
            //{
            //    return new BackMessage<int>()
            //    {
            //        IsSuccess = false,
            //        Message = "商品单位已经存在"
            //    };
            //}

            units.ModifyTime = DateTime.Now;
            int result = DALFactory.GetLazyInstance<IProductsUnitDAO>().Save(units, conn, trans);
            return new BackMessage<int>()
            {
                IsSuccess = true,
                Message = "OK",
                Data = result
            };
        }



        /// <summary>
        /// √获取商品单位列表
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <returns>商品单位列表</returns>
        public static IList<ProductsUnit> ProductsUnitListGet(int productId)
        {
            Dictionary<string, object> conditionDict = new Dictionary<string, object> { { "ProductId", productId } };
            return DALFactory.GetLazyInstance<IProductsUnitDAO>().GetList(conditionDict);
        }
    }
}
