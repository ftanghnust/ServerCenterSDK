﻿<%@ Page Language="C#" %>
<%@ Assembly Name="System.Xml" %>
<%@ Assembly Name="System.Xml.Linq" %>
<%@ Assembly Name="Frxs.ServiceCenter.Api.Core" %>
<%@ Assembly Name="Frxs.ServiceCenter.DataSync.Message.Server" %>
<%@ Import Namespace="Frxs.ServiceCenter.Api.Core" %>
<%@ Import Namespace="System.Collections.Specialized" %>
<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Xml" %>
<%@ Import Namespace="System.Xml.Linq" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="Frxs.ServiceCenter.DataSync.Message.Server.Actions" %>

<script runat="server">
    public RequestContext RequestContext;
    public ActionResult ActionResult;
</script>

<%
    var responseDto = this.ActionResult.Data as Frxs.ServiceCenter.DataSync.Message.Server.IEvenSelector;

    //文档路径
    var docPath = "~/bin/{0}.xml".With(this.RequestContext.ActionDescriptor.ActionType.Assembly.GetName().Name);
    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load(this.RequestContext.HttpContext.Server.MapPath(docPath));
%>

/* ***************************************************************************
 * <auto-generated>
 *     This code was generated by a tool.
 *     .NET CLR Runtime Version:<%:Environment.Version.Major %>.<%:Environment.Version.Minor %>.<%:Environment.Version.Build %>.<%:Environment.Version.Revision %>
 *     Changes to this file may cause incorrect behavior and will be lost if
 *     the code is regenerated.
 * </auto-generated>
 * ***************************************************************************
 * FRXS(ISC) zhangliang4629@163.com <%:DateTime.Now.ToString("yyyy\\/MM\\/dd HH:mm:ss.fff") %>
 * **************************************************************************/
using Frxs.ServiceCenter.DataSync.Message.PublisherClient;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

<!--NewLine-->

namespace ConsoleApplication1
{
    /// <summary>
    /// 发布端测试事件
    /// </summary>
    class Program
    {
        /// <summary>
        /// 默认的序列化反序列化实现(Newtonsoft.Json)
        /// </summary>
        public class DefaultJosnSerializer : IJosnSerializer
        {
            /// <summary>
            /// 反序列化
            /// </summary>
            /// <typeparam name="T">需要反序列化的类型</typeparam>
            /// <param name="value">输入的JSON字符串</param>
            /// <returns></returns>
            public T Deserialize<T>(string value)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }

            <!--NewLine-->

            /// <summary>
            /// 序列化
            /// </summary>
            /// <param name="value">待序列化的对象</param>
            /// <returns>返回序列化后的JSON字符串</returns>
            public string Serialize(object value)
            {
                return JsonConvert.SerializeObject(value);
            }
        }

        <!--NewLine-->

        /// <summary>
        /// 消息发布扩展 (共【<%:responseDto.GetEventDescriptors().Count() %>】个发布事件)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            <!--NewLine-->

            //初始化消息发布者客户端
            var publisherClient = new MessagePublisherClient("http://m.api.com/Api",
                //客户端自己实现的序列化与反序列化对象
                new DefaultJosnSerializer(),
                //获取仓库编号委托，需要客户端自己实现具体的获取方式
                () => 0) { Enabled = true };

            <!--NewLine-->

            //测试循环触发领域事件，发布消息
            Parallel.For(0, 1, i =>
            {

                Console.WriteLine(i);

                PublishResult r = null;

<%foreach (var x in responseDto.GetEventDescriptors().GroupBy(o => o.GroupName)) {%>

                <!--NewLine-->
                #region <%:x.Key %> - Events: <%:x.Count() %>

<%foreach (var item in x.OrderBy(o=>o.GroupName).ThenBy(o=>o.SubGroupName)){

        //获取所有的摘要属性
        var propertys = item.MessageBodyType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

        Dictionary<string, string> sums = new Dictionary<string, string>();
        List<string> paramsValue = new List<string>();

        foreach (var p in propertys)
        {
            //将首字母小写
            var name = p.Name[0].ToString().ToLower() + p.Name.Substring(1, p.Name.Length - 1);
            name = name == "iD" ? "id" : name;
            name = name == "wID" ? "wid" : name;

            //参数类型
            var propertyName = p.PropertyType.Name;

            switch (propertyName)
            {
                case "Int32":
                    paramsValue.Add("100");
                    break;
                case "Int64":
                    paramsValue.Add("100");
                    break;
                case "String":
                    paramsValue.Add("\"" + new Random().Next(100000, 999999).ToString() + "\"");
                    break;
                default:

                    break;
            }

            //注释信息
            var psummary = xmlDoc.SelectSingleNode("doc/members/member[@name='P:{0}.{1}']".With(p.DeclaringType.FullName, p.Name));
            if (psummary != null)
            {
                sums.Add(name, psummary.InnerText.Trim());
            }
            else
            {
                sums.Add(name, "");
            }
        }

        //注释说明
        var summary = xmlDoc.SelectSingleNode("doc/members/member[@name='T:{0}']".With(item.MessageBodyType.FullName));
        var summaryTexts = (summary.IsNull() ? "" : summary.InnerText.Trim()).Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

 %>

<!--NewLine-->

                <%foreach (var text in summaryTexts) { %>
                // <%: text.Trim()%>
                <%} %>
                <%foreach (var ps in sums) { %>
                // <param name="<%:ps.Key %>"><%:ps.Value %></param>
                <%} %>
                r = publisherClient.<%:item.EventName %>(<%:string.Join(", ", paramsValue.ToArray()) %>);
                FluentConsole.Green.Line(r.IsSuccess + "    " + r.MessageId + "     <%:item.EventName %>");

        <%}%>

                <!--NewLine-->
                #endregion

        <%    } %>

            });

            <!--NewLine-->
            Console.ReadLine();

        }
    }
}

