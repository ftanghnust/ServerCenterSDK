/*********************************************************
 * FRXS zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// ��־��¼����������
    /// </summary>
    public interface ILoggerFactory
    {
        /// <summary>
        /// ������־��¼��
        /// </summary>
        /// <param name="type">��������ͣ�����Ӱ�쵽ILogger�Ĵ�����������Ϊ��־��¼�쳣��</param>
        /// <returns></returns>
        ILogger CreateLogger(Type type);
    }
}