<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IPagination<Customer>>" %>
<%@ Import Namespace="MvcContrib.Pagination"%>
<%@ Import Namespace="Homework2.Models"%>
<%@ Import Namespace="MvcContrib.UI.Grid"%>
<%@ Import Namespace="MvcContrib.UI.Pager"%>
<%@ Import Namespace="MvcContrib.UI.Html" %>
<%@ Import Namespace="MvcContrib.UI" %>
<%@ Import Namespace="MvcContrib.UI.Grid.ActionSyntax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Customers
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Customers</h2>
    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>
    <%
        Html.Grid<Customer>(Model)
            .Columns(column =>
                         {
                             column.For(
                                 x =>
                                 Html.ActionLink("View", "Details", new {id = x.Id}) + " | " +
                                 Html.ActionLink("Edit", "Edit", new {id = x.Id})).DoNotEncode();
                             column.For(c => c.Id);
                             column.For(c => c.Name);
                             column.For(c => c.Email);
                             column.For(
                                 x =>
                                 Html.ActionLink("Delete", "Delete", new { id = x.Id })).DoNotEncode();
                         })
            .Attributes(style => "width: 60%").Render();
    %>
    <p>&nbsp;</p>
    <%= Html.Pager(Model) %>
</asp:Content>

