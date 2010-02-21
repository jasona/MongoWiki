<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MongoWiki.Models.WikiPage>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EditWikiPage
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>EditWikiPage</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="ID">ID:</label>
                <%= Html.TextBox("ID", Model.ID) %>
                <%= Html.ValidationMessage("ID", "*") %>
            </p>
            <p>
                <label for="Title">Title:</label>
                <%= Html.TextBox("Title", Model.Title) %>
                <%= Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <label for="URL">URL:</label>
                <%= Html.TextBox("URL", Model.URL) %>
                <%= Html.ValidationMessage("URL", "*") %>
            </p>
            <p>
                <label for="Body">Body:</label>
                <%= Html.TextBox("Body", Model.Body) %>
                <%= Html.ValidationMessage("Body", "*") %>
            </p>
            <p>
                <label for="CreateDate">CreateDate:</label>
                <%= Html.TextBox("CreateDate", String.Format("{0:g}", Model.CreateDate)) %>
                <%= Html.ValidationMessage("CreateDate", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

