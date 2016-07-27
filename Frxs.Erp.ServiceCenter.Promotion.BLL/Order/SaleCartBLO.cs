
/*****************************
* Author:leidong
*
* Date:2016-04-06
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using System.Data;
using Frxs.Platform.IOCFactory;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Promotion.BLL
{
    /// <summary>
    /// 销售购物车表SaleCart业务逻辑类
    /// </summary>
    public partial class SaleCartBLO
    {
        #region 成员方法
        #region 根据主键验证SaleCart是否存在
        /// <summary>
        /// 根据主键验证SaleCart是否存在
        /// </summary>
        /// <param name="model">SaleCart对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SaleCart model,int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).Exists(model);
        }
        #endregion


        #region 添加一个SaleCart
        /// <summary>
        /// 添加一个SaleCart
        /// </summary>
        /// <param name="model">SaleCart对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(SaleCart model, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).Save(model);
        }
        #endregion


        #region 更新一个SaleCart
        /// <summary>
        /// 更新一个SaleCart
        /// </summary>
        /// <param name="model">SaleCart对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleCart model, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).Edit(model);
        }
        #endregion


        #region 删除一个SaleCart
        /// <summary>
        /// 删除一个SaleCart
        /// </summary>
        /// <param name="model">SaleCart对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SaleCart model, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个SaleCart
        /// <summary>
        /// 根据主键逻辑删除一个SaleCart
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(long iD, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取SaleCart对象
        /// <summary>
        /// 根据字典获取SaleCart对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleCart对象</returns>
        public static SaleCart GetModel(IDictionary<string, object> conditionDict, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取SaleCart对象
        /// <summary>
        /// 根据主键获取SaleCart对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>SaleCart对象</returns>
        public static SaleCart GetModel(long iD, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).GetModel(iD);
        }
        #endregion


        #region 根据字典获取SaleCart集合
        /// <summary>
        /// 根据字典获取SaleCart集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<SaleCart> GetList(IDictionary<string, object> conditionDict, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取SaleCart数据集
        /// <summary>
        /// 根据字典获取SaleCart数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取SaleCart集合
        /// <summary>
        /// 分页获取SaleCart集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleCart> GetPageList(PageListBySql<SaleCart> page, IDictionary<string, object> conditionDict, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).GetPageList(page, conditionDict);
        }
        #endregion


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        public static int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }

    public partial class SaleCartBLO
    {
        private static int _remarkLength = 200;

        /// <summary>
        /// 获取购物车商品集合
        /// </summary>
        /// <param name="shopId">门店ID</param>
        /// <param name="wId">仓库ID，可不填</param>
        /// <returns>购物车商品集合</returns>
        public static IList<SaleCart> GetCartList(int shopId, int wId = 0)
        {
            var condition=new Dictionary<string, object>();
            condition.Add("ShopID",shopId);
            if(wId!=0)
            {
                condition.Add("WID",wId);
            }
            return DALFactory.GetLazyInstance<ISaleCartDAO>(wId.ToString()).GetList(condition);
        }

        /// <summary>
        /// 为购物车追加商品
        /// </summary>
        /// <param name="saleCarts"></param>
        public static BackMessage<bool> AppendProduct(IList<SaleCart> saleCarts,BaseUserModel user,bool deleteOld=false, int Wid=0)
        {
            var checkResult = CheckCarts(saleCarts,user);
            if(!checkResult.IsSuccess)
            {
                return checkResult;
            }

            //开始事务
            var connection = DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                if(deleteOld)
                {
                    var shopId = saleCarts[0].ShopID;
                    var flag = DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).DeleteList(shopId, 0,null,connection, trans);
                    if(!flag)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "清除原来购物车数据失败");
                    }
                }
                foreach (var saleCart in saleCarts)
                {
                    saleCart.CreateTime = DateTime.Now;
                    saleCart.ModifyTime = DateTime.Now;
                    var flag=DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).Save(saleCart, connection, trans);
                    if(flag<=0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "添加购物车商品失败");
                    }
                }
                trans.Commit();
                return BackMessage<bool>.SuccessBack(true);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return BackMessage<bool>.FailBack(false, ex.Message);
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return BackMessage<bool>.SuccessBack(true);
        }

        /// <summary>
        /// 删除购物车商品
        /// </summary>
        /// <param name="shopId">商店ID</param>
        /// <param name="productIds">商品ID列表,为null时，代表清空购物车</param>
        /// <returns></returns>
        public static BackMessage<bool> DeleteProduct(int shopId, IList<int> productIds = null, int Wid=0)
        {
            var result = DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).DeleteList(shopId, 0,productIds);
            if(result)
            {
                return BackMessage<bool>.SuccessBack(true);
            }
            else
            {
                return BackMessage<bool>.FailBack(false, "删除购物车商品失败");
            }
        } 

        /// <summary>
        /// 根据购物车列表获取商品信息
        /// </summary>
        /// <param name="carts"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        public static BackMessage<bool> GetProductInfo(IList<SaleCart> carts, IList<SaleCartDetail> details, int Wid)
        {
            return BackMessage<bool>.SuccessBack(true);
        } 

        /// <summary>
        /// 根据购物车列表获取商品促销信息
        /// </summary>
        /// <param name="carts"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        public static BackMessage<bool> GetProductPromotionInfo(IList<SaleCart> carts, IList<SaleCartDetail> details, int Wid)
        {
            return BackMessage<bool>.SuccessBack(true);
        }


        /// <summary>
        /// 购物车检查
        /// </summary>
        /// <param name="saleCarts"></param>
        /// <returns></returns>
        private static BackMessage<bool> CheckCarts(IList<SaleCart> saleCarts, BaseUserModel user=null)
        {
            if(saleCarts.Count<=0)
            {
                return BackMessage<bool>.FailBack(false, "购物车商品为空");
            }
            foreach (var saleCart in saleCarts)
            {
                if(saleCart.ProductID<=0)
                {
                    return BackMessage<bool>.FailBack(false, "商品编号为空");
                }
                if(saleCart.PreQty<=0)
                {
                    return BackMessage<bool>.FailBack(false, "商品预定数量不能小于等于0");
                }
                if(saleCart.WID<=0)
                {
                    return BackMessage<bool>.FailBack(false, "购物车商品没有指定仓库编号");
                }
                if(saleCart.XSUserID<=0)
                {
                    if(user!=null)
                    {
                        saleCart.XSUserID = user.UserId;  
                    }
                    //return BackMessage<bool>.FailBack(false, "下单人员编号不能为空");
                }
                if(!string.IsNullOrEmpty(saleCart.Remark) && saleCart.Remark.Length>_remarkLength)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("备注信息超过{0}长度",_remarkLength));
                }
            }
            return BackMessage<bool>.SuccessBack(true);
        }

        /// <summary>
        /// 编辑购物车单条商品
        /// </summary>
        /// <param name="cart">购物车单条商品</param>
        /// <returns></returns>
        public static BackMessage<bool> EditCart(SaleCart cart, int Wid,BaseUserModel user)
        {
            var old = DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).GetModel(cart.ID);
            if(old==null)
            {
                var list = new List<SaleCart>();
                list.Add(cart);
                return AppendProduct(list,user, false);
            }
            var flag=DALFactory.GetLazyInstance<ISaleCartDAO>(Wid.ToString()).Edit(cart);
            if(flag>0)
            {
                return BackMessage<bool>.SuccessBack(true);
            }
            else
            {
                return BackMessage<bool>.FailBack(false, "编辑失败");
            }
        } 

        /// <summary>
        /// 获取购物车商品总数量
        /// </summary>
        /// <param name="shopId">门店ID</param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public static BackMessage<decimal> CountCarts(int shopId ,int wid,int? productId )
        {
            var count = DALFactory.GetLazyInstance<ISaleCartDAO>(wid.ToString()).GetCartsCount(shopId,productId);
            return BackMessage<decimal>.SuccessBack(count);
        } 
    }
}