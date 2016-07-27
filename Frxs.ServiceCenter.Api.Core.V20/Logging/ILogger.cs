/*********************************************************
 * FRXS zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// ��־��¼��
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// �Ƿ�������־��¼��(���ĳһ�����)
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool IsEnabled(LogLevel level);

        /// <summary>
        /// ��¼��־
        /// </summary>
        /// <param name="level">��¼�ȼ�</param>
        /// <param name="exception">�����쳣</param>
        /// <param name="format">��ʽ���ַ������磺����������{0}......</param>
        /// <param name="args">��ʽ���ַ�����ֵ</param>
        void Log(LogLevel level, Exception exception, string format, params object[] args);
    }

    /// <summary>
    /// ������־��¼��������ʡ�Ե�ILoggerFactory�ӿ�ʵ��
    /// </summary>
    /// <typeparam name="TServiceType"></typeparam>
    public interface ILogger<TServiceType> : ILogger
        where TServiceType : class
    {
    }
}
