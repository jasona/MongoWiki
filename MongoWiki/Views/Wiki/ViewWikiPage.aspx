<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MongoWiki.Models.WikiPage>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ViewWikiPage
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ViewWikiPage</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            Title:
            <%= Html.Encode(Model.Title) %>
        </p>
        <p>
            URL:
            <%= Html.Encode(Model.URL) %>
        </p>
        <p>
            Body:
            <%= Html.Encode(Model.Body) %>
        </p>
        <p>
            CreateDate:
            <%= Html.Encode(Model.CreateDate) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

