/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/22/2016 4:09:15 PM
 * *******************************************************/
using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 
    /// </summary>
    public static class DbContextExtensions
    {
        /// <summary>
        /// 获取实体映射的数据表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetTableName<T>(this DbContext context)
        {
            //var tableName = typeof(T).Name;
            //return tableName;
            //this code works only with Entity Framework.
            //If you want to support other database, then use the code above (commented)
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            var storageModel = (StoreItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.SSpace);
            var containers = storageModel.GetItems<EntityContainer>();
            var entitySetBase = containers.SelectMany(c => c.BaseEntitySets.Where(bes => bes.Name == typeof(T).Name)).First();
            // Here are variables that will hold table and schema name
            string tableName = entitySetBase.MetadataProperties.First(p => p.Name == "Table").Value.ToString();
            //string schemaName = productEntitySetBase.MetadataProperties.First(p => p.Name == "Schema").Value.ToString();
            return tableName;
        }

        /// <summary>
        /// 删除整张数据表，使用分批删除方式，方式删除日志膨胀，导致事务过大，造成删除失败
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Delete<T>(this DbContext context)
        {
            var tableName = context.GetTableName<T>();
            context.Database.ExecuteSqlCommand(string.Format(@"DECLARE @N INT;
                                                               SET @N = 10000;
                                                               WHILE(@N>0)
                                                               BEGIN
	                                                               DELETE TOP(@N) FROM [{0}]
	                                                               SET @N = @@ROWCOUNT;
                                                               END", tableName));
        }
    }
}
