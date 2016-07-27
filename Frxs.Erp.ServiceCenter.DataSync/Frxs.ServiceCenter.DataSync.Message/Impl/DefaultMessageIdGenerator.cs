/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/8/2016 8:41:24 AM
 * *******************************************************/
using System;
using Frxs.ServiceCenter.Data.Core;
using Frxs.ServiceCenter.Api.Core;
using System.Linq;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl
{
    /// <summary>
    /// 消息ID编号生成器(默认直接使用数据库实现)
    /// </summary>
    internal class DefaultMessageIdGenerator : IMessageIdGenerator
    {
        /// <summary>
        /// 全局流水码
        /// </summary>
        private static object locker = new object();

        /// <summary>
        /// 数据操作上下文
        /// </summary>
        private readonly IDbContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext">数据操作上下文</param>
        public DefaultMessageIdGenerator(IDbContext dbContext)
        {
            dbContext.CheckNullThrowArgumentNullException("dbContext");
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 获取待时间和顺序号的字符串
        /// </summary>
        /// <returns></returns>
        public string GetNextId()
        {
            //ID编号起始字符串
            string start = DateTime.Now.ToString("yyMMddHHmmssffffff");

            lock (locker)
            {
                //保存下当前时间，防止跨越
                var currentTime = DateTime.Now;

                //最大值
                long maxId = this._dbContext.SqlQuery<long>(@"DECLARE @Id BIGINT;
                                                              UPDATE 
                                                                    SequentialNumber 
                                                              SET 
                                                                    @Id = MaxIdentity = MaxIdentity + 1
                                                              WHERE 
                                                                    [Year] = @p0 AND [Month] = @p1 AND [Day] = @p2;
                                                              SELECT @Id;",
                                                              new object[] { currentTime.Year, currentTime.Month, currentTime.Day }).First();

                //消息ID格式为：年月日时分秒毫秒+12位流水数字；一共：18+12=30位
                return "{0}{1}".With(start, maxId.ToString("000000000000"));
            }
        }
    }
}
