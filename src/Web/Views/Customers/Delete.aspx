<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Homework2.Models.Customer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Delete</h2>
    <% using (Html.BeginForm())
       {%>
    <fieldset>
        <legend>Fields</legend>
        <p>
            Name:
            <%= Html.Encode(Model.Name) %>
        </p>
        <p>
            <input type="submit" value="Delete" />
        </p>
    </fieldset>
    <% } %>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %>
        |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>
</asp:Content>
