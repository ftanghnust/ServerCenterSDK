﻿<!--
 *********************************************************
 * FRXS(ISC) zhangliang4629@163.com <%:DateTime.Now.ToString("yyyy\\/MM\\/dd HH:mm:ss.fff") %>
 * *******************************************************
-->

<%@ Page Language="C#" %>

<%@ Assembly Name="Frxs.ServiceCenter.Api.Core" %>
<%@ Import Namespace="Frxs.ServiceCenter.Api.Core" %>
<%@ Import Namespace="System.Collections.Specialized" %>
<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="System.Web" %>

<script runat="server">
    public Frxs.ServiceCenter.Api.Core.RequestContext RequestContext;
    public Frxs.ServiceCenter.Api.Core.ActionResult ActionResult;
</script>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%:this.RequestContext.DecryptedRequestParams.ActionName %></title>
</head>
<body style="padding: 10px; font-family: 微软雅黑;">

    <b>ActionName</b>
    <ul>
        <li><%:this.RequestContext.DecryptedRequestParams.ActionName %></li>
    </ul>

    <%if (null != this.RequestContext.ActionDescriptor)
      { %>
    <b>ActionDescriptor</b>
    <ul>
        <%foreach (var item in this.RequestContext.ActionDescriptor.GetAttributes())
          { %>
        <li><%:item.Key %>：<%:item.Value.SerializeObjectToJosn() %></li>
        <%} %>
    </ul>
    <%} %>

    <b>AdditionDatas:</b>
    <br />
    <ul>
        <%foreach (var item in this.RequestContext.AdditionDatas)
          { %>
        <li><%:item.Key %>：<%: item.Value is DateTime? ((DateTime)item.Value).ToString("yyyy/MM/dd HH:mm:ss.ffffff"): item.Value %></li>
        <%} %>
    </ul>

    <b>RequestCacheKey:</b>
    <br />
    <ul>
        <li><%:this.RequestContext.GetRequestCacheKey() %></li>
    </ul>
    <b>SysOptions:</b>
    <br />
    <ul>
        <%foreach (var item in this.RequestContext.SysOptions.GetAttributes())
          { %>
        <%if (item.Value.GetType() == typeof(string[]))
          { %>
        <li><%:item.Key%>：<%:string.Join("<br />", (string[])item.Value)%></li>
        <%}
          else if (item.Value.GetType() == typeof(Dictionary<string, object>))
          { %>
        <li><%:item.Key%>：
         <%foreach (var kv in (Dictionary<string, object>)item.Value)
           { %>
            <br />
            <%:kv.Key%>：<%:kv.Value %></li>
        <%} %>
        <%}
          else
          { %>
        <li><%:item.Key%>：<%:item.Value%></li>
        <%}
          } %>
    </ul>

    <b>Headers:</b>
    <br />
    <ul>
        <%foreach (string key in this.RequestContext.HttpContext.Response.Headers.AllKeys)
          { %>
        <li><%:key %>：<%:this.RequestContext.HttpContext.Response.Headers[key] %></li>
        <%} %>
    </ul>

    <b>ActionConfigCollection:</b>
    <br />
    <ul>
        <%foreach (var item in ApiConfigManager.Configs.GetConfigs())
          { %>
        <li><b><%:item.Key.IsNullOrEmptyForDefault(()=>"全局",s=>s) %>：</b>
            <% foreach (var p in item.Value.GetAttributes(false))
               {
            %>
            <br />
            &nbsp;&nbsp;<%:p.Key %>：<%: (p.Value is IEnumerable) ? p.Value.SerializeObjectToJosn() : p.Value %>
            <% } %>
        </li>
        <%} %>
    </ul>

    <b>RequestParams:</b>
    <br />
    <ul>
        <%foreach (var kv in this.RequestContext.RawRequestParams.GetAttributes())
          { %>
        <li><%:kv.Key %>：<%:kv.Value %></li>
        <%} %>
    </ul>

    <b>ActionResult:</b>
    <br />
    <div style="padding: 10px;">
        <%:this.ActionResult.SerializeObjectToJosn() %>
    </div>
</body>
</html>
