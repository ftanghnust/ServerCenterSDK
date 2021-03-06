﻿/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/11/11 19:35:42
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// 控制台显示(方便调试)
    /// </summary>
    public class ConsoleApiLogger : IApiLogger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Warn(string message)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
