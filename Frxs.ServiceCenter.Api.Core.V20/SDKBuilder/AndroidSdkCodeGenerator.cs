/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/12 11:33:56
 * *******************************************************/
using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 安卓客户端SDK开发包生成器
    /// </summary>
    public class AndroidSdkCodeGenerator : SdkCodeGeneratorBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override Dictionary<string, string> CreateTypeMapping()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionDescriptor"></param>
        /// <returns></returns>
        public override KeyValuePair<string, string> GeneratorRequest(IActionDescriptor actionDescriptor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionDescriptor"></param>
        /// <returns></returns>
        public override KeyValuePair<string, string> GeneratorResponse(IActionDescriptor actionDescriptor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Language
        {
            get { throw new NotImplementedException(); }
        }
    }
}
