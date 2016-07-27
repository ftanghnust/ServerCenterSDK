/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/5/2016 11:53:09 AM
 * *******************************************************/
using Frxs.ServiceCenter.Api.Core;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Promotion.StartUp
{
    /// <summary>
    /// 系统初始化需要做的一些事件
    /// </summary>
    public class StartUp : IStartUp
    {
        /// <summary>
        /// 内部转换对象
        /// </summary>
        internal class HttpResponseResult
        {
            /// <summary>
            /// 
            /// </summary>
            public int Flag { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public List<DbConfig> Data { get; set; }
        }

        /// <summary>
        /// 系统配置文件
        /// </summary>
        private SysConfig _sysConfig;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sysConfig">注入系统配置文件</param>
        public StartUp(SysConfig sysConfig)
        {
            this._sysConfig = sysConfig;
        }

        /// <summary>
        /// 站点启动的时候会自动运行此方法
        /// </summary>
        public void Init()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    //请求接口数据
                    var content = httpClient.GetStringAsync("{0}?ActionName=DataSync.Base.SysDbConfig.Get&format=JSON"
                        .With(this._sysConfig.ConnectionStringConfigUrl))
                        .Result;
                    var httpResponseResult = JsonConvert.DeserializeObject<HttpResponseResult>(content);
                    //保存数据库配置
                    SystemOptionsManager.Current.AdditionDatas["sysDbConfig"] = httpResponseResult.Data;
                }
                catch (Exception exc)
                {
                    throw new ApiException("dbconfig get error,host:{1},erros:{0}"
                        .With(exc.StackTrace, this._sysConfig.ConnectionStringConfigUrl));
                }
            }
        }
    }
}