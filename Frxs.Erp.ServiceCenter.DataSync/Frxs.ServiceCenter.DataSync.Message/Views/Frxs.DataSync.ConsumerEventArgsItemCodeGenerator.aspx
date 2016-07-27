﻿<%@ Page Language="C#" %>
<%@ Assembly Name="System.Xml" %>
<%@ Assembly Name="System.Xml.Linq" %>
<%@ Assembly Name="Frxs.ServiceCenter.Api.Core" %>
<%@ Assembly Name="Frxs.ServiceCenter.DataSync.Message.Server" %>
<%@ Import Namespace="Frxs.ServiceCenter.Api.Core" %>
<%@ Import Namespace="System.Collections.Specialized" %>
<%@ Import Namespace="System.Collections" %>
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
    var requestDto = this.RequestContext.RequestDto as ConsumerEventArgsItemCodeGeneratorAction.ConsumerEventArgsItemCodeGeneratorActionRequestDto;
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
using System;

<!--NewLine-->

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient.EventArgs
{

<%foreach(var item in responseDto.GetEventDescriptors().Where(o=>o.EventName==requestDto.EventName)) {

        //所有属性
        var ps = item.MessageBodyType.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

        //注释说明
        var summary = xmlDoc.SelectSingleNode("doc/members/member[@name='T:{0}']".With(item.MessageBodyType.FullName));

        var summaryTexts = (summary.IsNull() ? "" : summary.InnerText.Trim()).Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

 %>

    /// <summary>
    <%foreach (var text in summaryTexts){ %>
    /// <%: text.Trim()%>
    <%} %>
    /// </summary>
    [Serializable]
    public class <%:item.EventName %>EventAgrs : EventArgsBase
    {
         <%
           foreach (var p in ps) {

            var psummary = xmlDoc.SelectSingleNode("doc/members/member[@name='P:{0}.{1}']".With(p.DeclaringType.FullName, p.Name));

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

         %>

        /// <summary>
        /// <%:psummary.IsNull() ? "" : psummary.InnerText.Trim() %>
        /// </summary>
        public <%:propertyName %> <%:p.Name %> { get; set; }
       
      <%} %>
    }

<%} %>

}

