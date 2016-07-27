<%@ Page Language="C#" %>
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
<%@ Import Namespace="Frxs.ServiceCenter.DataSync.Message.Server" %>
<%@ Import Namespace="Frxs.ServiceCenter.DataSync.Message.Server.Actions" %>

<script runat="server">
    public RequestContext RequestContext;
    public ActionResult ActionResult;
</script>

<%
    var responseDto = this.ActionResult.Data as IEvenSelector;

    var version = RequestContext.ActionDescriptor.ActionType.Assembly.GetName().Version;

    //文档路径
    var docPath = "~/bin/{0}.xml".With(this.RequestContext.ActionDescriptor.ActionType.Assembly.GetName().Name);
    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load(this.RequestContext.HttpContext.Server.MapPath(docPath));

    int index = 0;
%>

<!--
 *************************************************************
 * FRXS(ISC) zhangliang4629@163.com <%:DateTime.Now.ToString("yyyy\\/MM\\/dd HH:mm:ss.fff") %>
 * ***********************************************************
-->
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>同步消息发布端事件文档(V<%:"{0}.{1}".With(version.Major,version.Minor) %>)</title>
    <style type="text/css">
        html {
            height: 100%;
            margin: 0px;
        }

        body {
            height: 100%;
            width: 100%;
            background: #ffffff;
            color: #333;
            font: normal 12px/1.5 'Arial', 'SimSun', 'Tahoma', 'Helvetica', 'sans-serif','Consolas';
            text-align: left;
            overflow-x: hidden;
        }
    </style>
</head>
<body style="font-family: Consolas;">

    <table style="font-size: 14px; width: 99%; border-collapse: separate; padding: 10px; margin-top: 10px;">
        <tr>
            <td><b style="font-size: 24px; font-weight: bold;">数据同步系统(V<%:"{0}.{1}".With(version.Major,version.Minor) %>)事件文档(PublisherEvents)（共【<%:responseDto.GetEventDescriptors().Count() %>】事件）</b></td>
            <td style="text-align: right;">发布时间:<%:DateTime.Now.ToString("yyyy\\/MM\\/dd HH:mm:ss") %></td>
        </tr>
    </table>
    <table style="font-size: 14px; width: 99%; background: #ff6a00; border-collapse: separate; padding: 10px; margin-top: 10px; border-spacing: 1px; border-radius: 5px; -moz-border-radius: 5px; -webkit-border-radius: 5px;">
        <tr style="font-size: 14px; font-weight: bold;">
            <td style="width: 50px; height: 30px; text-align: center;">索引号</td>
            <td>发布端事件(Publisher)</td>
            <td>重要度</td>
            <td>消费端事件(Consumer)</td>
            <td>事件参数说明(EventArgs)</td>
            <td>事件描述</td>
            <td style="width:100px; text-align:center;">备注说明</td>
        </tr>

        <%foreach (var item in responseDto.GetEventDescriptors().OrderBy(o => o.GroupName).ThenBy(o=>o.SubGroupName))
            {

                index++;

                //获取所有的摘要属性
                var propertys = item.MessageBodyType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

                Dictionary<string, string> methodParams = new Dictionary<string, string>();
                Dictionary<string, string> sums = new Dictionary<string, string>();

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
                            propertyName = "int";
                            break;
                        case "Int64":
                            propertyName = "long";
                            break;
                        case "String":
                            propertyName = "string";
                            break;
                        default:
                            propertyName = p.PropertyType.Name;
                            break;
                    }

                    //方法参数
                    methodParams.Add(name, propertyName);

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

        %>

        <tr style="background: <%:index%2==0?"#ffffff":"#f4f4f4"%>;">
            <td style="text-align: center; color: orangered"><b><%:index %></b></td>
            <td style="padding-left: 5px; width:300px;"><b><%:item.EventName %></b><span style="font-size: 7pt; color: #888;">(<%:string.Join(", ", methodParams.Select(o => "<span style='color:blue'>{0}</span> {1}".With(o.Value, o.Key)))%>)</span></td>
            <td style="padding:0px 5px 0px 5px"><%:item.EventDegree %></td>
            <td style="padding-left: 5px; width:500px;">
                <b>On<%:item.EventName %></b><span style="font-size: 7pt; color: #888;">(<span style='color: blue'>object</span> sender, <span style='color: blue'><%:item.EventName %>EventAgrs</span> e)</span>
            </td>
            <td style="width:300px">
                <ul style="margin-left: -20px;"><%=string.Join("", methodParams.Select(o => "<li>{0}&nbsp;<label style='font-size:12px;color:#888888;'>{1}</label></li>".With("{0} <span style='color:blue'>{1}</span>".With(o.Key,o.Value), sums.FirstOrDefault(x => x.Key == o.Key).Value)).ToArray()) %></ul>
            </td>
            <td style="padding: 5px; font-size:12px; line-height:20px"><%: (summary.IsNull() ? "" : summary.InnerText.Trim()).Replace("\r","<br/>")%></td>
            <td style="text-align:center;"><%:item.GroupName %></td>
        </tr>

        <%} %>
    </table>
</body>
</html>


