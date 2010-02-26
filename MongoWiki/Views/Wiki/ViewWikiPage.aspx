<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MongoWiki.Lib.Entities.WikiPage>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Model.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Html.Encode(Model.Title) %></h2>
    <p class="body">
        <%= Model.Body %>
    </p>
    <p>
        <i>Created on: <%= Html.Encode(Model.CreateDate) %></i><br />
        <i>Last Updated on: <%= Html.Encode(Model.LastUpdateDate) %></i><br />
        <%=Html.ActionLink("Edit", "EditPage", new { /* id=Model.PrimaryKey */ }) %> |
    </p>

</asp:Content>

