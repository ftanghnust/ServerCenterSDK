
/*****************************
* Author:luojing
*
* Date:2016-03-10
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### BaseProducts数据库访问接口
    /// </summary>
    public partial interface IBaseProductsDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证BaseProducts是否存在
        /// <summary>
        /// 根据主键验证BaseProducts是否存在
        /// </summary>
        /// <param name="model">BaseProducts对象</param>
        /// <returns>是否存在</returns>
        bool Exists(BaseProducts model);
        #endregion

        /// <summary>
        /// 带验证的删除
        /// </summary>
        /// <param name="model">母商品模型</param>
        /// <param name="msg">返回消息</param>
        /// <param name="conn"> </param>
        /// <param name="tran"> </param>
        /// <returns>删除记录数</returns>
        int Delete(BaseProducts model, ref string msg, IDbConnection conn = null, IDbTransaction tran = null);

        /// <summary>
        /// 带验证的新增
        /// </summary>
        /// <param name="model">母商品模型</param>
        /// <param name="conn"> </param>
        /// <param name="tran"> </param>
        /// <returns>母商品ID</returns>
        int Save(BaseProducts model, IDbConnection conn = null, IDbTransaction tran = null);

        /// <summary>
        /// 带验证的编辑
        /// </summary>
        /// <param name="model">母商品模型</param>
        /// <param name="conn"> </param>
        /// <param name="tran"> </param>
        /// <returns>更新记录数量</returns>
        int Edit(BaseProducts model, IDbConnection conn = null, IDbTransaction tran = null);


        #region 根据主键逻辑删除一个BaseProducts
        /// <summary>
        /// 根据主键逻辑删除一个BaseProducts
        /// </summary>
        /// <param name="baseProductId">商品母表ID（初始值和Product.productID一样)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int baseProductId);
        #endregion


        #region 根据字典获取BaseProducts对象
        /// <summary>
        /// 根据字典获取BaseProducts对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="bGetAttachedInfo">是否获取除主表外的其他信息 </param>
        /// <returns>BaseProducts对象</returns>
        BaseProducts GetModel(Dictionary<string, object> conditionDict, bool bGetAttachedInfo = true);

        BaseProducts GetModel(int baseProductsId, bool bGetAttachedInfo = true);

        #endregion


        #region 根据主键获取BaseProducts对象
        /// <summary>
        /// 根据主键获取BaseProducts对象
        /// </summary>
        /// <param name="baseProductId">商品母表ID（初始值和Product.productID一样)</param>
        /// <returns>BaseProducts对象</returns>
        BaseProducts GetModel(int baseProductId);
        #endregion


        #region 根据字典获取BaseProducts集合
        /// <summary>
        /// 根据字典获取BaseProducts集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<BaseProducts> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取BaseProducts数据集
        /// <summary>
        /// 根据字典获取BaseProducts数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取BaseProducts集合
        /// <summary>
        /// 分页获取BaseProducts集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<BaseProducts> GetPageList(PageListBySql<BaseProducts> page, IDictionary<string, object> conditionDict);
        #endregion


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList);
        #endregion


        #endregion


    }

    /// <summary>
    /// ### BaseProducts数据库访问接口
    /// </summary>
    public partial interface IBaseProductsDAO : IBaseDAO
    {
        /// <summary>
        /// 母商品名称是否重复
        /// </summary>
        /// <param name="model">母商品模型</param>
        /// <returns>true or false</returns>
        bool ExistProductBaseName(BaseProducts model);

    }
}