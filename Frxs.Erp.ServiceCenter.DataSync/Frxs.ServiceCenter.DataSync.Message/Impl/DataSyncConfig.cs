/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/24 17:05:48
 * *******************************************************/
using Frxs.ServiceCenter.Api.Core;
using System.Xml;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl
{
    /// <summary>
    /// <![CDATA[
    /// web.config节点配置对象；此配置节点会被IOC容器自动注册;
    /// <configuration>
    /// <configSections>
    ///  <section name="DataSyncConfig" type="Frxs.ServiceCenter.Api.Host.Data.DataSyncConfig,Frxs.ServiceCenter.Api.Host"/>
    /// </configSections>
    ///  <DataSyncConfig connectionStringName="connstring_sql"/>
    /// <configuration>
    /// ]]>
    /// </summary>
    [ConfigurationSectionName("DataSyncConfig", IsAutoRegister = true)]
    internal class DataSyncConfig : ConfigurationSectionHandlerBase
    {
        /// <summary>
        /// 默认消费速度，单位：毫秒
        /// </summary>
        private int _defaultConsumeSpeed = 10;

        /// <summary>
        /// 默认的消息队列保存路径
        /// </summary>
        private string _defaultMSMQPath = @".\private$\message";

        /// <summary>
        /// 消息默认的保存时间，单位：天
        /// </summary>
        private int _messageExpriedDays = 7;

        /// <summary>
        /// 配置文件对应的实体类
        /// </summary>
        public DataSyncConfig() { }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionStringName
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否启用消息队列作为缓存器
        /// </summary>
        public bool UseMSMQ { get; private set; }

        /// <summary>
        /// 对应的MSMQ消息队列路径
        /// </summary>
        public string MSMQPath { get; private set; }

        /// <summary>
        /// 发送消息错误日志记录消息队列路径
        /// </summary>
        public string SendErrorMSMQPath { get { return "{0}.send.errors".With(this.MSMQPath); } }

        /// <summary>
        /// 从消息队列里将消息分发到数据库的消费速度，单位为：毫秒
        /// </summary>
        public int ConsumeSpeed { get; private set; }

        /// <summary>
        /// 消息过期时间，到期后，系系统将会自动将过期消息删除
        /// </summary>
        public int MessageExpriedDays { get; set; }

        /// <summary>
        /// 创建配置对象信息
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="configContext"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public override object Create(object parent, object configContext, XmlNode section)
        {
            //初始化一个默认的配置文件
            var config = new DataSyncConfig
            {
                ConnectionStringName = string.Empty,
                ConsumeSpeed = this._defaultConsumeSpeed,
                MSMQPath = this._defaultMSMQPath,
                MessageExpriedDays = this._messageExpriedDays,
                UseMSMQ = true
            };

            //web.config配置节点不存在
            if (section.IsNull())
            {
                return config;
            }

            //XML配置文件属性节点集合
            var nodeAttributes = this.GetNodeAttributes(section);

            //获取数据库连接
            config.ConnectionStringName = nodeAttributes
                .GetValue("connectionstringname", key => string.Empty);

            //消息队列路径
            config.MSMQPath = nodeAttributes
                .GetValue("msmqpath", key => this._defaultMSMQPath);

            //消息队列消息速度，默认10毫秒
            config.ConsumeSpeed = nodeAttributes
                .GetValue("consumespeed", key => this._defaultConsumeSpeed.ToString())
                .AsInt(this._defaultConsumeSpeed);

            //消息默认保存时间
            config.MessageExpriedDays = nodeAttributes
                .GetValue("messageexprieddays", key => this._messageExpriedDays.ToString())
                .AsInt(this._messageExpriedDays);

            //是否启用消息队列作为缓冲器
            config.UseMSMQ = nodeAttributes
                .GetValue("usemsmq", key => "true").AsBool(true);

            //返回数据库配置信息
            return config;
        }

    }
}
