using System;
using System.Collections.Generic;
using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    public interface IWProductsBuyEmpDAO : IBaseDAO
    {
        #region  成员方法
        #region 根据主键验证WProductsBuyEmp是否存在
        /// <summary>
        /// 根据主键验证WProductsBuyEmp是否存在
        /// </summary>
        /// <param name="model">WProductsBuyEmp对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WProductsBuyEmp model);
        #endregion


        #region 添加一个WProductsBuyEmp
        /// <summary>
        /// 添加一个WProductsBuyEmp
        /// </summary>
        /// <param name="model">WProductsBuyEmp对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WProductsBuyEmp model);
        #endregion


        #region 添加一个WProductsBuyEmp(事务处理)
        /// <summary>
        /// 添加一个WProductsBuyEmp(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">WProductsBuyEmp对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, WProductsBuyEmp model);
        #endregion


        #region 更新一个WProductsBuyEmp
        /// <summary>
        /// 更新一个WProductsBuyEmp
        /// </summary>
        /// <param name="model">WProductsBuyEmp对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WProductsBuyEmp model);
        #endregion


        #region 更新一个WProductsBuyEmp(事务处理)
        /// <summary>
        /// 更新一个WProductsBuyEmp(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">WProductsBuyEmp对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, WProductsBuyEmp model);
        #endregion


        #region 删除一个WProductsBuyEmp
        /// <summary>
        /// 删除一个WProductsBuyEmp
        /// </summary>
        /// <param name="model">WProductsBuyEmp对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WProductsBuyEmp model);
        #endregion


        #region 根据主键逻辑删除一个WProductsBuyEmp
        /// <summary>
        /// 根据主键逻辑删除一个WProductsBuyEmp
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        #endregion


        #region 根据字典获取WProductsBuyEmp对象
        /// <summary>
        /// 根据字典获取WProductsBuyEmp对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>WProductsBuyEmp对象</returns>
        WProductsBuyEmp GetModel(WProductsBuyEmpQuery query);
        #endregion


        #region 根据主键获取WProductsBuyEmp对象
        /// <summary>
        /// 根据主键获取WProductsBuyEmp对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WProductsBuyEmp对象</returns>
        WProductsBuyEmp GetModel(int iD);
        #endregion


        #region 根据字典获取WProductsBuyEmp集合
        /// <summary>
        /// 根据字典获取WProductsBuyEmp集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        IList<WProductsBuyEmp> GetList(WProductsBuyEmpQuery query);
        #endregion


        #region 根据字典获取WProductsBuyEmp数据集
        /// <summary>
        /// 根据字典获取WProductsBuyEmp数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WProductsBuyEmp集合
        /// <summary>
        /// 分页获取WProductsBuyEmp集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<WProductsBuyEmp> GetPageList(PageListBySql<WProductsBuyEmp> page, IDictionary<string, object> conditionDict);
        #endregion


        #endregion

        int DeleteByWProductID(int wid, int WProductID, IDbConnection conn, IDbTransaction tran);

        int BatDelWProductsBuyEmp(int wid, int UserId, string UserName, List<int> wProductIds, List<int> BuyEmpIds, IDbConnection conn, IDbTransaction tran);
        int SaveWProductsBuyEmp(int wid, int UserId, string UserName, List<int> wProductIds, List<int> BuyEmpIds,IDbConnection conn, IDbTransaction tran);
    }
}
