
/*****************************
* Author:leidong
*
* Date:2016-04-14
******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.IOCFactory;
using Frxs.Platform.Utility.Pager;
using System.Reflection;



namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    /// <summary>
    /// SaleOrder业务逻辑类
    /// </summary>
    public partial class SaleOrderBLO
    {
        #region 成员方法
        #region 根据主键验证SaleOrder是否存在
        /// <summary>
        /// 根据主键验证SaleOrder是否存在
        /// </summary>
        /// <param name="model">SaleOrder对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SaleOrder model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderDAO>(warehouseId).Exists(model);
        }
        #endregion


        #region 添加一个SaleOrder
        /// <summary>
        /// 添加一个SaleOrder
        /// </summary>
        /// <param name="model">SaleOrder对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>最新标识列</returns>
        public static int Save(SaleOrder model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderDAO>(warehouseId).Save(model);
        }
        #endregion


        #region 更新一个SaleOrder
        /// <summary>
        /// 更新一个SaleOrder
        /// </summary>
        /// <param name="model">SaleOrder对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleOrder model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderDAO>(warehouseId).Edit(model);
        }
        #endregion


        #region 删除一个SaleOrder
        /// <summary>
        /// 删除一个SaleOrder
        /// </summary>
        /// <param name="model">SaleOrder对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SaleOrder model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderDAO>(warehouseId).Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个SaleOrder
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrder
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string orderId, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderDAO>(warehouseId).LogicDelete(orderId);
        }
        #endregion



        #region 根据主键获取SaleOrder对象
        /// <summary>
        /// 根据主键获取SaleOrder对象
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>SaleOrder对象</returns>
        public static SaleOrder GetModel(string orderId, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderDAO>(warehouseId).GetModel(orderId);
        }
        #endregion




        #region 根据字典获取SaleOrder数据集
        /// <summary>
        /// 根据字典获取SaleOrder数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取SaleOrder集合
        /// <summary>
        /// 分页获取SaleOrder集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleOrder> GetPageList(PageListBySql<SaleOrder> page, IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderDAO>(warehouseId).GetPageList(page, conditionDict);
        }
        #endregion


        #endregion
    }


     public partial class SaleOrderBLO
     {
         /// <summary>
         /// 取订单商品扩展明细
         /// </summary>
         /// <param name="orderId">订单ID</param>
         /// <returns></returns>
         public static IList<SaleOrderDetailsExt> GetDetailExsByOrderId(string orderId, int Wid)
         {
             var condtion = new Dictionary<string, object>();
             condtion.Add("OrderId", orderId);
             return DALFactory.GetLazyInstance<ISaleOrderDetailsExtDAO>(Wid.ToString()).GetList(condtion);
         }

         /// <summary>
         /// 取订单商品明细
         /// </summary>
         /// <param name="orderId">订单ID</param>
         /// <returns></returns>
         public static IList<SaleOrderDetails> GetDetailByOrderId(string orderId, int Wid)
         {
             var condtion = new Dictionary<string, object>();
             condtion.Add("OrderId", orderId);
             condtion.Add("Wid", Wid);
             return DALFactory.GetLazyInstance<ISaleOrderDetailsDAO>(Wid.ToString()).GetList(condtion);
         }



         /// <summary>
         /// 完成订单处理
         /// </summary>
         /// <param name="orderId">订单ID</param>
         /// <param name="user">操作者</param>
         /// <param name="wid">仓库ID</param>
         /// <returns></returns>
         public static BackMessage<bool> FinishOrder(string orderId,BaseUserModel user,int wid)
         {
             var orderPre = SaleOrderPreBLO.GetModel(orderId,wid);
             if(orderPre==null)
             {
                 return BackMessage<bool>.FailBack(false, "订单状态已发生改变，请查询后再提交！");
             }
             if(orderPre.Status!=(int)OrderStatus.Delivering)
             {
                 return BackMessage<bool>.FailBack(false, "订单状态已发生改变，请查询后再提交！");
             }

             var finishOrder = GetModel(orderId, wid.ToString());
             if(finishOrder!=null)
             {
                 return BackMessage<bool>.FailBack(false,"已完成订单有已存在订单ID相同的订单数据");
             }

             var detailsPre = SaleOrderPreBLO.GetDetailByOrderId(orderId, wid);
             if(detailsPre==null || detailsPre.Count<=0)
             {
                 return BackMessage<bool>.FailBack(false, "没有找到这个订单的商品明细数据");
             }

             var detailsExtsPre = SaleOrderPreBLO.GetDetailExsByOrderId(orderId, wid);
             if (detailsExtsPre == null || detailsExtsPre.Count <= 0)
             {
                 return BackMessage<bool>.FailBack(false, "没有找到这个订单的商品明细数据");
             }

             var picksPre = DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>(wid.ToString()).GetOrderPick(orderId);
             if (picksPre == null || picksPre.Count <= 0)
             {
                 return BackMessage<bool>.FailBack(false, "没有找到这个订单的拣货数据");
             }


             //shelfArea
             var conditon = new Dictionary<string, object>();
             conditon.Add("OrderId",orderId);
             var shelfArea = DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(wid.ToString()).GetList(conditon);
             if(shelfArea==null || shelfArea.Count<=0)
             {
                 return BackMessage<bool>.FailBack(false, "没有找到订单的拣货区域数据");
             }

             //pack
             var pack = DALFactory.GetLazyInstance<ISaleOrderPrePackingDAO>(wid.ToString()).GetList(conditon);
             if(pack==null || pack.Count<=0)
             {
                 return BackMessage<bool>.FailBack(false, "没有找到订单的装箱数据");
             }

             var connection = DALFactory.GetLazyInstance<ISaleOrderDAO>(wid.ToString()).GetConnection();
             connection.Open();
             var trans = connection.BeginTransaction();
             try
             {
                 orderPre.ShippingEndDate = DateTime.Now;
                 orderPre.FinishDate = DateTime.Now;
                 orderPre.ModifyTime = DateTime.Now;
                 orderPre.ModifyUserID = user.UserId;
                 orderPre.ModifyUserName = user.UserName;
                 orderPre.Status = (int) OrderStatus.Finished;
                 var order = orderPre.Map<SaleOrder>();
                 var flag=DALFactory.GetLazyInstance<ISaleOrderDAO>(wid.ToString()).Save(connection, trans, order);
                 if(flag<=0)
                 {
                     trans.Rollback();
                     return BackMessage<bool>.FailBack(false, "完成订单写入数据失败");
                 }
                 flag =DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wid.ToString()).Delete(
                         new SaleOrderPre() {OrderId = orderId}, connection, trans);
                 if(flag<=0)
                 {
                     trans.Rollback();
                     return BackMessage<bool>.FailBack(false, "删除原订单数据失败");
                 }
                 

                 foreach (var detail in detailsPre)
                 {
                     var d = detail.Map<SaleOrderDetails>();
                     flag = DALFactory.GetLazyInstance<ISaleOrderDetailsDAO>(wid.ToString()).Save(connection, trans, d);
                     if (flag <= 0)
                     {
                         trans.Rollback();
                         return BackMessage<bool>.FailBack(false, "完成订单写入明细数据失败");
                     }
                 }
                 flag=DALFactory.GetLazyInstance<ISaleOrderPreDetailsDAO>(wid.ToString()).DeleteByOrderId(orderId, connection, trans);
                 if (flag <= 0)
                 {
                     trans.Rollback();
                     return BackMessage<bool>.FailBack(false, "删除原订单商品明细数据失败");
                 }

                 foreach (var detailsExt in detailsExtsPre)
                 {
                     var d = detailsExt.Map<SaleOrderDetailsExt>();
                     flag = DALFactory.GetLazyInstance<ISaleOrderDetailsExtDAO>(wid.ToString()).Save(connection, trans, d);
                     if (flag <= 0)
                     {
                         trans.Rollback();
                         return BackMessage<bool>.FailBack(false, "完成订单写入明细数据失败");
                     }
                 }
                 flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsExtDAO>(wid.ToString()).DeleteByOrderId(orderId, connection, trans);
                 if (flag <= 0)
                 {
                     trans.Rollback();
                     return BackMessage<bool>.FailBack(false, "删除原订单商品明扩展数据失败");
                 }

                 foreach (var pick in picksPre)
                 {
                     var p = pick.Map<SaleOrderDetailsPick>();
                     flag = DALFactory.GetLazyInstance<ISaleOrderDetailsPickDAO>(wid.ToString()).Save(connection, trans, p);
                     if (flag <= 0)
                     {
                         trans.Rollback();
                         return BackMessage<bool>.FailBack(false, "完成订单写入拣货数据失败");
                     }
                 }
                 flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>(wid.ToString()).DeleteByOrderId(orderId, connection, trans);
                 if (flag <= 0)
                 {
                     trans.Rollback();
                     return BackMessage<bool>.FailBack(false, "删除原订单商品拣货信息失败");
                 }

                 foreach (var area in shelfArea)
                 {
                     var a = area.Map<SaleOrderShelfArea>();
                     flag = DALFactory.GetLazyInstance<ISaleOrderShelfAreaDAO>(wid.ToString()).Save(connection, trans,
                                                                                                       a);
                     if (flag <= 0)
                     {
                         trans.Rollback();
                         return BackMessage<bool>.FailBack(false, "完成订单写入货架区域信息失败");
                     }
                 }
                 flag = DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(wid.ToString()).DeleteByOrderId(orderId, connection, trans);
                 if (flag <= 0)
                 {
                     trans.Rollback();
                     return BackMessage<bool>.FailBack(false, "删除原订单商品货架区域信息失败");
                 }

                 foreach (var packing in pack)
                 {
                     var p = packing.Map<SaleOrderPacking>();
                     flag = DALFactory.GetLazyInstance<ISaleOrderPackingDAO>(wid.ToString()).Save(connection, trans,
                                                                                                     p);
                     if (flag <= 0)
                     {
                         trans.Rollback();
                         return BackMessage<bool>.FailBack(false, "完成订单写入装箱数据失败");
                     }
                 }
                 flag = DALFactory.GetLazyInstance<ISaleOrderPrePackingDAO>(wid.ToString()).DeleteByOrderId(orderId, connection, trans);
                 if (flag <= 0)
                 {
                     trans.Rollback();
                     return BackMessage<bool>.FailBack(false, "删除原订单商品装箱信息失败");
                 }
                 var track = new SaleOrderTrack()
                 {
                     ID = wid.ToString() + Guid.NewGuid().ToString(),
                     WID = wid,
                     CreateTime = DateTime.Now,
                     CreateUserID = user.UserId,
                     CreateUserName = user.UserName,
                     IsDisplayUser = 1,
                     OrderID = orderId,
                     OrderStatus = 7,
                     OrderStatusName = "交易完成",
                     Remark = "您的订单已交易完成"
                 };
                 flag = SaleOrderTrackBLO.Save(track, wid.ToString(), connection, trans);
                 if (flag <= 0)
                 {
                     trans.Rollback();
                     return BackMessage<bool>.FailBack(false, "添加订单跟踪信息失败");
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

         } 
     }

     internal static class ExtentClass
     {
         /// <summary>
         /// 将匿名的所有对象映射到指定的对象；映射过程中，只要数据类型键可以相互转换，无需2个转换对象属性类型完全一致
         /// </summary>
         /// <typeparam name="T">指定需要转换的类型;实体对象必须带无参构造函数</typeparam>
         /// <param name="anonymousObject">所有的实体对象，包括匿名类型</param>
         /// <param name="ignoreCase">是否忽略属性名称大小写</param>
         /// <returns>待转换类型anonymousObject=null的时候返回null，创建T类型的时候失败也会返回null，请注意转换结果null的判断</returns>
         public static T Map<T>(this object anonymousObject, bool ignoreCase = true)
         {
             //创建映射的对象
             var obj = default(T);

             //在传输对象为null情况下，直接返回空的转换对象，所有字段值都是默认的
             if (anonymousObject==null)
             {
                 return obj;
             }

             //创建映射的对象
             try
             {
                 obj = Activator.CreateInstance<T>();
             }
             catch (Exception ex)
             {
                 //throw new FRXSException("MapTo<{0}>类型失败，详细错误：{1}".With(typeof(T).FullName, ex.StackTrace));
                 return obj;
             }

             //获取匿名对象所有属性
             var anonymousObjectPropertys = anonymousObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

             //循环待映射对象的所有属性
             obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList().ForEach(p =>
             {
                 //查找属性名称是否一致
                 foreach (var property in anonymousObjectPropertys)
                 {
                     //是否忽略属性名称大小写
                     if (p.Name.Equals(property.Name, (ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)))
                     {
                         //待转换成的数据类型
                         Type convertType = p.PropertyType;
                         //判断下映射实体属性是否是可空类型;是空类型需要特殊处理
                         if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                         {
                             NullableConverter nullableConverter = new NullableConverter(p.PropertyType);
                             convertType = nullableConverter.UnderlyingType;
                         }
                         //对异常不处理
                         try
                         {
                             //数据转型
                             var propertyValue = Convert.ChangeType(property.GetValue(anonymousObject), convertType);
                             //设置属性值
                             p.SetValue(obj, propertyValue);
                         }
                         catch { }
                     }
                 }
             });

             return obj;
         }


         /// <summary>
         /// 将匿名的所有对象映射到指定的对象集合
         /// </summary>
         /// <typeparam name="T">指定需要转换的类型;实体对象必须带无参构造函数</typeparam>
         /// <param name="anonymousObjects">待转换的对象集合</param>
         /// <param name="ignoreCase">是否忽略属性名称大小写</param>
         /// <returns></returns>
         public static IEnumerable<T> MapList<T>(this IEnumerable<object> anonymousObjects, bool ignoreCase = true)
         {
             foreach (var item in anonymousObjects)
             {
                 yield return item.Map<T>(ignoreCase);
             }
         }
     }
}