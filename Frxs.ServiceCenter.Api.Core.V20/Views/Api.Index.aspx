<!--
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
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="Frxs.ServiceCenter.Api.Core.Actions" %>

<script runat="server">
    public Frxs.ServiceCenter.Api.Core.RequestContext RequestContext;
    public Frxs.ServiceCenter.Api.Core.ActionResult ActionResult;
</script>

<%
    var responseDto = this.ActionResult.Data as IndexAction.IndexActionResponseDto;
%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>接口框架系统，接口框架版本：<%:ApiVersion.Version %></title>
    <script type="text/javascript" src="/GetResource?resourceName=jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="/GetResource?resourceName=jquery.poshytip.js"></script>
    <link rel="stylesheet" href="/GetResource?resourceName=tip-yellow.css" type="text/css" />
    <style type="text/css">
        html { height: 100%; margin: 0px; }
        body { height: 100%; width: 100%; margin: 0px; background: #f4f4f4; color: #333; font: normal 12px/1.5 'Arial', 'SimSun', 'Tahoma', 'Helvetica', 'sans-serif','Consolas'; text-align: left; overflow-x: hidden; }

        a { text-decoration: none; outline: 0; cursor: pointer; color: blueviolet; }
        a:hover { color: #305c9a; text-decoration: underline; }

        .header { padding: 0px; background: #C00; width: 100%; margin: 0px; height: 40px; font-size: 18px; font-weight: bold; line-height: 40px; color: #ffffff; position: fixed; }
        .header .lft { margin-left: 10px; float: left; }
        .header .rgt { padding-right: 10px; font-size: 12px; float: right; width: 200px; text-align: right; }
        .header .rgt a { color: #ffffff; text-decoration: underline; }
        .header .rgt a:hover { color: #305c9a; text-decoration: underline; }

        .main { margin-top: 0px; padding: 0px; width: 100%; border-collapse: collapse; top: 40px; }
        .main b { font-size: 24px; }

        .main .lft { background: #305c9a; color: #ffffff; width: 300px; padding-top:10px; }
        .main .lft a { color: #ffffff; }
        .main .lft a:hover { color: #ffffff; text-decoration: underline; }
        .main .lft ul li { font-size: 10px; line-height: 18px; }

        .main .rgt { padding-left: 20px; background: #ffffff; padding-top:10px; }
        .main .rgt .title { font-size: 24px; }
        .main .by { font-size: 12px; color: brown; }
        .main .rgt ul li { font-size: 10px; color: #008080; line-height: 20px; }
        img { padding: 0px; width: 50px; height: 50px; border: 1px solid #dedede; -moz-border-radius: 5px; /* Gecko browsers */ -webkit-border-radius: 5px; /* Webkit browsers */ border-radius: 5px; /* W3C syntax */ }
    </style>
</head>
<body style="font-family: Consolas;">
    <table class="header">
        <tr>
            <td class="lft">API接口框架系统&nbsp;&nbsp;<span style="font-size: 9px;">Powered by：V<%:ApiVersion.Version %>，HOST：<%:this.RequestContext.HttpContext.Request.LocalAddr() %></span></td>
            <td class="rgt">接口描述(<a target="_blank" href="/Help/Xml">Xml</a>,<a target="_blank" href="/Help/Json">Json</a>,<a target="_blank" href="/Help/View">View</a>)</td>
        </tr>
    </table>
    <table style="margin: 0px; padding:0px; width: 100%; border-collapse:collapse; margin-left:-2px;">
        <tr>
            <td style="padding-top: 45px;">
                <table class="main">
                    <tr>
                        <td class="lft" valign="top">
                            <b>&nbsp;当前项目接口数：(<%: responseDto.ActionDescriptors.Count() %>)</b>
                            <ul>
                                <% foreach (var actionDescriptor in responseDto.ActionDescriptors)
                                   { %>
                                <li><a href="javascript:void()" class="tooltip" data-actionname="<%:actionDescriptor.ActionName %>" data-version="<%:actionDescriptor.Version %>"><%:actionDescriptor.ActionName %>(v<%:actionDescriptor.Version %>)</a></li>
                                <% } %>
                            </ul>
                        </td>
                        <td class="rgt" valign="top">
                            <b style="color: #305c9a">当前接口项目已加载组件(<%: responseDto.ApiPluginDescriptors.Count() %>)</b>
                            <% foreach (var item in responseDto.ApiPluginDescriptors)
                               { %>
                            <table style="width: 98%; margin-top: 10px; border-bottom: 1px dotted #ccc;">
                                <tr>
                                    <td valign="top" style="width: 50px;">
                                        <img src="<%: item.Logo.IsNullOrEmptyForDefault(() => "/GetResource?resourceName=SystemPlugin.png", logo => logo) %>" />
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td class="title" valign="top">
                                                    <a href="<%: item.IndexUrl.IsNullOrEmptyForDefault(() => "javascript:void();", indexUrl => indexUrl) %>" target="_blank"><%: item.DisplayName %></a><span class="by">(By:<%: item.Author %>，Version:<%: item.Version %>)</span>
                                                </td>
                                            </tr>
                                            <% if (!item.Description.IsNullOrEmpty())
                                               {%>
                                            <tr>
                                                <td>&nbsp;<span style="color: #cc0000">Description：</span></td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left: 25px; padding-top: 0px;">
                                                    <pre style="color: dimgray"><%: item.Description.Trim().HtmlEncode() %></pre>
                                                </td>
                                            </tr>
                                            <% } %>
                                            <% if (item.ReferencedAssemblies.Any())
                                               { %>
                                            <tr>
                                                <td>&nbsp;<span style="color: #cc0000">Dependencies：</span>
                                                    <ul>
                                                        <% foreach (var referencedAssembly in item.ReferencedAssemblies.OrderBy(o => o))
                                                           { %>
                                                        <li><%: referencedAssembly %></li>
                                                        <% } %>
                                                    </ul>
                                                </td>
                                            </tr>
                                            <% } %>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <% } %>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>
<script type="text/javascript">
    $("a.tooltip").poshytip({
        className: 'tip-yellow',
        bgImageFrameSize: 11,
        content: function (updateCallback) {
            $.ajax({
                type: "post",
                url: "/Api",
                data: "ActionName=API.Descriptor&Format=View&Data={ActionName:\"" + $(this).attr("data-ActionName") + "\",Version:\"" + $(this).attr("data-Version") + "\"}",
                dataType: "html",
                cache: false,
                success: function (data) {
                    updateCallback(data);
                },
                error: function (e, textStatus, errorThrown) {
                    console.log(textStatus + ":" + errorThrown);
                }
            });

            return 'Loading...';
        }
    });
</script>
