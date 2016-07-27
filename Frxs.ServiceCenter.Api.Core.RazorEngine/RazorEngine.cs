/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/17/2016 1:14:04 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Frxs.ServiceCenter.Api.Core.ViewEngine;
using RazorEngine;
using RazorEngine.Templating;

namespace Frxs.ServiceCenter.Api.Core.RazorEngine
{
    /// <summary>
    /// 
    /// </summary>
    public class RazorEngine : IViewEngine
    {
        /// <summary>
        /// 
        /// </summary>
        public string SupportedExtension
        {
            get
            {
                return ".cshtml";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewPath"></param>
        /// <param name="parameters"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public string CompileByViewPath(string viewPath, ViewParameterCollection parameters, System.Text.Encoding encode)
        {
            return this.CompileByViewSource(File.ReadAllText(viewPath), parameters, encode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewSource"></param>
        /// <param name="parameters"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public string CompileByViewSource(string viewSource, ViewParameterCollection parameters, System.Text.Encoding encode)
        {
            return Engine.Razor.RunCompile(viewSource, "TempKey_".With(MD5.Encrypt(viewSource)), null, parameters);
        }
    }
}

