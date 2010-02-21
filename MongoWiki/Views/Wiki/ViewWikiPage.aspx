<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MongoWiki.Models.WikiPage>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Model.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Html.Encode(Model.Title) %></h2>
    Created on: <%= Html.Encode(Model.CreateDate) %><br />
    Last Updated on: <%= Html.Encode(Model.LastUpdateDate) %>

    <p>
        <%= Html.Encode(Model.Body) %>
    </p>
    <p>
        <%=Html.ActionLink("Edit", "EditPage", new { /* id=Model.PrimaryKey */ }) %> |
    </p>

</asp:Content>

