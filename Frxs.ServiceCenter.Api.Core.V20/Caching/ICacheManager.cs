/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/11/13 16:59:44
 * *******************************************************/
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// ϵͳ��ܻ������ӿڣ���ʵ��ʹ���������룺ICacheManager.Extensions��չ������ʹ��
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// ���ݻ������ȡ����ʵ�����
        /// </summary>
        /// <typeparam name="T">��ȷ�Ļ������</typeparam>
        /// <param name="key">�����</param>
        /// <returns>ָ���������͵Ķ���</returns>
        T Get<T>(string key);

        /// <summary>
        /// ���û��棻ע���������û��棬�Ƿ���ɾ�����滹�ǲ�ɾ�����л��棻���ھ���ʵ������
        /// </summary>
        /// <param name="key">�����</param>
        /// <param name="data">��������</param>
        /// <param name="cacheTime">�������ʱ��,��λΪ����</param>
        void Set(string key, object data, int cacheTime);

        /// <summary>
        /// ���ݻ�����ж��Ƿ��Ѿ��л���
        /// </summary>
        /// <param name="key">�����</param>
        /// <returns>Result</returns>
        bool IsSet(string key);

        /// <summary>
        /// ���ݻ����ɾ����Ӧ����
        /// </summary>
        /// <param name="key">�����</param>
        void Remove(string key);

        /// <summary>
        /// ����������ʽ��ɾ������
        /// </summary>
        /// <param name="pattern">������ʽƥ��ģʽ</param>
        void RemoveByPattern(string pattern);

        /// <summary>
        /// ���ȫ���Ļ����
        /// </summary>
        void Clear();
    }
}
