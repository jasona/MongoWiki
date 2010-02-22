<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MongoWiki.Models.WikiPage>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create Page: <%= MongoWiki.Lib.Utility.UnFormatForUrl(ViewData["page"].ToString()) %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create Page: <%= MongoWiki.Lib.Utility.UnFormatForUrl(ViewData["page"].ToString())%></h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Title">Title:</label>
                <%= Html.TextBox("Title", null, new { size = "100" })%>
                <%= Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <label for="Body">Body:</label>
                <%= Html.TextArea("Body", new { Rows = "10", Cols = "50", Class = "resizable" })%>
                <%= Html.ValidationMessage("Body", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>

