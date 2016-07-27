<!--
 *************************************************************
 * FRXS(ISC) zhangliang4629@163.com <%:DateTime.Now.ToString("yyyy\\/MM\\/dd HH:mm:ss.fff") %>
 * ***********************************************************
-->

<%@ Page Language="C#" %>

<%@ Assembly Name="Frxs.ServiceCenter.Api.Core" %>
<%@ Assembly Name="Autofac" %>
<%@ Assembly Name="Frxs.ServiceCenter.Api.Core.SdkBuilder" %>
<%@ Import Namespace="Frxs.ServiceCenter.Api.Core.SdkBuilder.Actions" %>
<%@ Import Namespace="Frxs.ServiceCenter.Api.Core" %>
<%@ Import Namespace="System.Collections.Specialized" %>
<%@ Import Namespace="Autofac" %>
<%@ Import Namespace="Autofac.Core.Lifetime" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Linq" %>

<script runat="server">
    public RequestContext RequestContext;
    public ActionResult ActionResult;
</script>

<% 
    //上送参数
    var requestDto = this.RequestContext.RequestDto as BuildSdkAction.BuildSdkActionRequestDto;

    //输出的数据
    var responseDto = this.ActionResult.Data as BuildSdkAction.BuildSdkActionResponseDto;

    //命名空间，需要输出不同的命名空间，请修改下面命名空间变量
    var @namespace = responseDto.SdkNamespace;

    //全部接口
    var actions = responseDto.ActionSelector.GetActionDescriptors().OrderBy(o => o.ActionName);
%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>API接口文档生成器-基于接口框架：<%:Frxs.ServiceCenter.Api.Core.ApiVersion.Version %></title>
    <style type="text/css">
        html { height: 100%; margin: 0px; }
        body { height: 100%; width: 100%; background: #ffffff; color: #333; font: normal 12px/1.5 'Arial', 'SimSun', 'Tahoma', 'Helvetica', 'sans-serif','Consolas'; text-align: left; overflow-x: hidden; }
        .header { padding: 0px; background: #C00; width: 100%; margin: 0px; border-bottom: 0px solid #E3E6EB; height: 40px; font-size: 18px; font-weight: bold; border-bottom: 1px solid #ccc; line-height: 40px; color: #ffffff; position: fixed; left: 0px; top: 0px; }
        .header .lft { margin-left: 480px; }
        .header .rgt { position: fixed; right: 0px; top: 0px; padding-right: 10px; font-size: 12px; }
        .left { background: #305c9a; position:absolute; left: 0px; top: 0px; z-index: 2; width: 450px; height: auto; }
        .left .top { height: 40px; line-height: 40px; background: #205081; position: fixed; left: 0; top: 0px; z-index: 3; width: 450px; text-align: left; font-weight: bold; color: #ffffff; }
        .left ul { margin-top: 50px; }
        .left ul li span { font: normal 9px/1.0 'Consolas', 'Arial', 'SimSun', 'Tahoma', 'Helvetica', 'sans-serif'; color: red; }
        .right { width: 99%; overflow: hidden; padding-top: 40px; }
        .right-content { margin-left: 480px; }
        .right-content b { font-size: 26px; }
        a { text-decoration: none; color: #ffffff; outline: 0; cursor: pointer; }
        a:hover { color: #C00; text-decoration: underline; }
        .header .rgt a:hover { color: #305c9a; text-decoration: underline; }
    </style>
</head>
<body style="font-family: Consolas;">
    <div class="header">
        <div class="lft">API接口文档/SDK代码&nbsp;&nbsp;<span style="font-size: 9px;">Powered by：V<%:Frxs.ServiceCenter.Api.Core.ApiVersion.Version %></span> </div>
        <div class="rgt">
            <a target="_blank" href="/CSharpDownSdk">下载SDK开发包</a>&nbsp;|&nbsp;
            <a target="_blank" href="/CSharpDownSource">下载SDK源码</a>&nbsp;|&nbsp;
            <a target="_blank" href="/DocBuilder">下载API接口文档</a>&nbsp;|&nbsp;
        </div>
    </div>
    <div class="left">
        <div class="top"><span style="margin-left: 28px; font-size: 13px;">HOST:<%:this.RequestContext.HttpContext.Request.LocalAddr() %> API Numbers：<%:actions.Count(o => o.CanPackageToSdk) %></span></div>
        <ul>
            <%foreach (var item in actions)
              {
                  if (!item.CanPackageToSdk)
                  {
                      continue;
                  }
            %>
            <li style="color: #ffffff;">
                <a href="<%:"/Api?ActionName=API.BuildSDK&Format=view&data=" + this.RequestContext.HttpContext.Server.UrlEncode("{actionname:\"" + item.ActionName + "\",Version:\""+ item.Version +"\"}") %>" title="程序集：<%:item.ActionType.Assembly.GetName().Name %>，处理类：<%:item.ActionType.FullName %>"><%:item.ActionName %>&nbsp;(v<%:item.Version %>)<span style="color: red;"><%if (item.RequiredUserIdAndUserName)
                                                                                                                                                                                                                                                                                                                                                         { %>(U)<%} %></span><%if (!item.CanPackageToSdk)
                                                                                                                                                                                                                                                                                                                                                                               { %><span style="color: red" title="不打包到SDK库">⊙</span><%} %></a>
            </li>
            <%} %>
        </ul>
    </div>
    <div class="right">
        <div class="right-content">
            <%if (this.ActionResult.Info == "OK")
              { %>
            <div style="width: 100%">
                <b style="color:rgb(146, 39, 143);">Request: </b>
                测试<b style="font-size:14px;">(<a style="color: #000; font-size: 12px;" target="_blank" href="/Api?ActionName=<%:requestDto.ActionName %>&format=View&data={version:<%:requestDto.Version %>}">View</a>&nbsp;,&nbsp;<a style="color: #000; font-size: 12px;" target="_blank" href="/Api?ActionName=<%:requestDto.ActionName %>&format=JSON&data={}">JSON</a>&nbsp;,&nbsp;<a style="color: #000; font-size: 12px;" target="_blank" href="/Api?ActionName=<%:requestDto.ActionName %>&format=XML&data={}">XML</a>)</b>
                &nbsp;
                <b style="font-size:14px;">
                <a style="color: #000; font-size: 12px;" target="_blank" href="/Api?ActionName=Api.Doc&format=View&data=<%:RequestContext.HttpContext.Server.UrlEncode("{"+"version:\"{0}\",actionname:\"{1}\"".With(requestDto.Version,requestDto.ActionName)+"}") %>">
                    接口传输文档
                </a></b>
               <hr />
                <pre style="font-family: Consolas; line-height: 18px; font-size: 11px;"><%:RequestContext.HttpContext.Server.HtmlEncode(responseDto.RequestSource.ToString())%> </pre>
            </div>
            <hr style="border: 2px solid; color: red;" />
            <div style="width: 100%">
                <b style="color:rgb(146, 39, 143);">Response:</b>
                <hr />
                <pre style="font-family: Consolas; line-height: 18px; font-size: 11px;"><%:RequestContext.HttpContext.Server.HtmlEncode(responseDto.ResponseSource.ToString())%> </pre>
            </div>
            <%}
              else
              { %>
            <%:this.ActionResult.Info %>
            <%} %>
        </div>
    </div>

</body>
</html>
