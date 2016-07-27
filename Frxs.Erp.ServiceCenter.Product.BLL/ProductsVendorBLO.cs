using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    public class ProductsVendorBLO
    {



        #region 分页获取ProductsVendor集合
        /// <summary>
        /// 分页获取ProductsVendor 集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<ProductsVendor> GetPageList(PageListBySql<ProductsVendor> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IProductsVendorDAO>().GetPageList(page, conditionDict);
        }
        /// <summary>
        /// 分页获取ProductsVendor 集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static IDictionary<string, object> GetListExtByPage(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IProductsVendorDAO>().GetListExtByPage(conditionDict); ;
        }

        /// <summary>
        ///  ProductsVendor 集合
        /// </summary>
        /// <param name="conditionDict"></param>
        /// <returns></returns>
        public static IList<ProductsVendor> GetListNoPage(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IProductsVendorDAO>().GetListNoPage(conditionDict);
        }
        #endregion



        #region 供应商操作

        /// <summary>
        /// 更新最新采购价
        /// </summary>
        /// <param name="venderId">供应商编号</param>
        /// <param name="wid">仓库编号</param>
        /// <param name="productsVendorBuyPriceList">更新字段</param>
        /// <returns></returns>
        public static string UpdateLastBuyPrices(int venderId, int wid, List<ProductsVendor> productsVendorBuyPriceList)
        {
            IDictionary<string, object> vendorCondition = new Dictionary<string, object>();
            vendorCondition.Add("VendorID", venderId);
            Vendor vendor = DALFactory.GetLazyInstance<IVendorDAO>().GetModel(vendorCondition);

            if (vendor == null)
            {
                return "更新最新采购价失败，该供应商不存在！";
            }

            if (vendor.Status == 0)
            {
                return "更新最新采购价失败，该供应商已被冻结！";
            }

            var connection = DALFactory.GetLazyInstance<IProductsVendorDAO>().GetConnection();

            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {

                int detailscount = 0;
                foreach (ProductsVendor model in productsVendorBuyPriceList)
                {
                    int resultCount = DALFactory.GetLazyInstance<IProductsVendorDAO>().EditLastBuyPrice(model, connection, trans);
                    if (resultCount <= 0)
                    {
                        trans.Rollback();
                        return "更新最新采购价失败，数据更新错误！";
                    }
                    detailscount = detailscount + 1;
                }
                if (detailscount == productsVendorBuyPriceList.Count)
                {
                    trans.Commit();
                    return "1";
                }
                else
                {
                    trans.Rollback();
                    return "更新最新采购价失败，因部分更新未成功！";
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return "更新最新采购价失败！错误为:" + ex.Message;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }

        }

        /// <summary>
        /// 设置主供应商 
        /// </summary>
        /// <param name="venderId"></param>
        /// <param name="wid"></param>
        /// <param name="ProductIds"></param>
        /// <returns></returns>
        public static string SetMasterInfo(int venderId, int wid, List<int> ProductIds)
        {

            IDictionary<string, object> vendorCondition = new Dictionary<string, object>();
            vendorCondition.Add("VendorID", venderId);
            Vendor vendor = DALFactory.GetLazyInstance<IVendorDAO>().GetModel(vendorCondition);

            if (vendor == null)
            {
                return "操作失败，该供应商不存在！";
            }

            if (vendor.Status == 0)
            {
                return "操作失败，该供应商已被冻结！";
            }

            foreach (var obj in ProductIds)
            {
                IDictionary<string, object> whereDic = new Dictionary<string, object>();
                whereDic.Add("ProductID", obj);
                whereDic.Add("VendorID", venderId);
                var productVender = DALFactory.GetLazyInstance<IProductsVendorDAO>().GetModel(whereDic);
                if (productVender == null || productVender.IsMaster == 1)
                {
                    return "设置主供应商失败，只能对非主供应商商品关系设置！";
                }
            }

            var connection = DALFactory.GetLazyInstance<IProductsVendorDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {

                int detailscount = 0;
                int resultCount = 0;

                foreach (var obj in ProductIds)
                {

                    if (DALFactory.GetLazyInstance<IWProductsBuyDAO>().EditByProductID(venderId, obj, connection, trans) > 0)
                    {
                        //清除原有主供应商
                        if (DALFactory.GetLazyInstance<IProductsVendorDAO>().EditByProductId(obj, connection, trans) > 0)
                        {
                            //设置主供应商关系
                            resultCount = DALFactory.GetLazyInstance<IProductsVendorDAO>().EditByProductIdToMaster(obj, venderId, connection, trans);
                            if (resultCount <= 0)
                            {
                                trans.Rollback();
                                return "设置主供应商商品关系失败！仓库：" + wid.ToString();
                            }
                        }
                        else
                        {
                            trans.Rollback();
                            return "清除原有主供应商商品关系失败！仓库：" + wid.ToString();
                        }
                    }
                    else
                    {
                        trans.Rollback();
                        return "绑定商品与供应商关系失败！仓库：" + wid.ToString();
                    }

                    detailscount = detailscount + 1;
                }
                if (detailscount == ProductIds.Count)
                {
                    trans.Commit();
                    return "1";
                }
                else
                {
                    trans.Rollback();
                    return "删除供应商商品关系失败，因部分删除未成功！";
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return "删除供应商商品关系失败！错误为:" + ex.Message;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }

        }


        /// <summary>
        /// 删除供应商商品关系 
        /// </summary>
        /// <param name="venderId"></param>
        /// <param name="wid"></param>
        /// <param name="ProductIds"></param>
        /// <returns></returns>
        public static string DeleteProductsVender(int venderId, int wid, List<int> ProductIds)
        {

            IDictionary<string, object> vendorCondition = new Dictionary<string, object>();
            vendorCondition.Add("VendorID", venderId);
            Vendor vendor = DALFactory.GetLazyInstance<IVendorDAO>().GetModel(vendorCondition);

            if (vendor == null)
            {
                return "操作失败，该供应商不存在！";
            }

            if (vendor.Status == 0)
            {
                return "操作失败，该供应商已被冻结！";
            }

            var connection = DALFactory.GetLazyInstance<IProductsVendorDAO>().GetConnection();

            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {

                int detailscount = 0;
                int resultCount = 0;
                foreach (var obj in ProductIds)
                {

                    resultCount = DALFactory.GetLazyInstance<IProductsVendorDAO>().Delete(venderId, obj, wid, connection, trans);

                    if (resultCount <= 0)
                    {
                        trans.Rollback();
                        return "删除失败，只能删除非主供应商商品关系！";
                    }
                    detailscount = detailscount + 1;
                }
                if (detailscount == ProductIds.Count)
                {
                    trans.Commit();
                    return "1";
                }
                else
                {
                    trans.Rollback();
                    return "删除供应商商品关系失败，因部分删除未成功！";
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return "删除供应商商品关系失败！错误为:" + ex.Message;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }

        }


        /// <summary>
        /// 添加一个ProductsVendor
        /// </summary>
        /// <param name="pvlist"> </param>
        /// <returns>最新标识列</returns>
        public static string Save(IList<ProductsVendor> pvlist)
        {
            IList<ProductsVendor> newSpvlist = new List<ProductsVendor>();


            foreach (var searchObj in pvlist)
            {
                IDictionary<string, object> searchCondition = new Dictionary<string, object>();
                searchCondition.Add("WID", searchObj.WID);
                searchCondition.Add("ProductId", searchObj.ProductId);
                searchCondition.Add("VendorID", searchObj.VendorID);
                IDictionary<string, object> vendorCondition = new Dictionary<string, object>();
                vendorCondition.Add("VendorID", searchObj.VendorID);
                Vendor vendor = DALFactory.GetLazyInstance<IVendorDAO>().GetModel(vendorCondition);

                if (vendor == null)
                {
                    return "操作失败，该供应商不存在！";
                }

                if (vendor.Status == 0)
                {
                    return "操作失败，该供应商已被冻结！";
                }

                ProductsVendor model = DALFactory.GetLazyInstance<IProductsVendorDAO>().GetModel(searchCondition);
                if (model == null)  //如果有值，则移除
                {
                    newSpvlist.Add(searchObj);
                }
            }

            if (newSpvlist.Count == 0)
            {
                return "操作失败，要添加商品关系的数据已存在！";
            }

            var connection = DALFactory.GetLazyInstance<IProductsVendorDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();

            try
            {
                foreach (var obj in newSpvlist)
                {
                    int resultCount = 0;
                    if (obj.IsMaster == 0)
                    {
                        resultCount = DALFactory.GetLazyInstance<IProductsVendorDAO>().Save(obj, connection, trans);
                    }
                    else
                    {
                        trans.Rollback();
                        return "添加供应商商品关系失败,仅限添加非主供应商商品关系！";
                    }
                    if (resultCount <= 0)
                    {
                        trans.Rollback();
                        return "添加供应商商品关系失败！";
                    }

                }

                trans.Commit();
                return "1";

            }
            catch (Exception ex)
            {
                trans.Rollback();
                return "添加供应商商品关系失败！错误为:" + ex.Message;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }
        #endregion
        /// <summary>
        /// 查询供应商对应供货记录数
        /// </summary>
        /// <param name="vendorID"></param>
        /// <returns></returns>
        public static long GetVendProductsCount(int vendorID)
        {
            return DALFactory.GetLazyInstance<IProductsVendorDAO>().GetVendProductsCount(vendorID);
        }
    }
}
