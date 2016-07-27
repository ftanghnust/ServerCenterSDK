/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/5/2016 12:42:07 PM
 * *******************************************************/
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models;
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Actions
{
    /// <summary>
    /// 获取订单库，促销库分库数据连接配置
    /// </summary>
    [ActionName("SysDbConfig.Get")]
    public class SysDbConfigGetAction : ActionBase<NullRequestDto, List<SYS_DB_CONFIG>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<SYS_DB_CONFIG> _sysDbConfigRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sysDbConfigRepository">配置信息仓储</param>
        public SysDbConfigGetAction(IRepository<SYS_DB_CONFIG> sysDbConfigRepository)
        {
            this._sysDbConfigRepository = sysDbConfigRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<SYS_DB_CONFIG>> Execute()
        {
            return this.SuccessActionResult(this._sysDbConfigRepository.TableNoTracking.ToList().ToList());
        }
    }
}