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
    var responseDto = this.ActionResult.Data as ApiDescriptorAction.ApiDescriptorActionResponseDto;
%>

<b>ActionDescriptor - <%:responseDto.ActionDescriptor.ActionName %>(v<%:responseDto.ActionDescriptor.Version %>)</b>
<hr/>
<ul>
    <%foreach (var item in responseDto.ActionDescriptor.GetAttributes()){ %>
    <li><%:item.Key %>：<%:item.Value.SerializeObjectToJosn() %></li>
    <%} %>
</ul>