/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 4:05:37 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// 
    /// </summary>
    public class NullApiLogger : IApiLogger
    {
        /// <summary>
        /// 
        /// </summary>
        private static NullApiLogger _instance = new NullApiLogger();

        /// <summary>
        /// 
        /// </summary>
        public static IApiLogger Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private NullApiLogger() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Warn(string message)
        {

        }
    }
}
