/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/24 14:47:12
 * *******************************************************/
using System.Reflection;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.Api.Core.AccessRecorder
{
    /// <summary>
    /// Object context
    /// </summary>
    public class RecorderObjectContext : DbContextBase
    {
        /// <summary>
        /// ��־��¼��
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// ��ʼ�����ݿ�������
        /// </summary>
        /// <param name="nameOrConnectionString">���ݿ������ַ���</param>
        public RecorderObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            //��ʼ��һ���յ���־��¼��
            this.Logger = NullLogger.Instance;

            //��¼��SQL���ɣ�������е���
            //this.Database.Log = (sql) => { this.Logger.Debug(sql); };
        }

        /// <summary>
        /// ʵ��ӳ�����
        /// </summary>
        protected override Assembly EntityTypeConfigurationMapAssembly
        {
            get
            {
                return Assembly.GetExecutingAssembly();
            }
        }
    }
}