<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MongoWiki.Models.WikiPage>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Page: <%= Model.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit Page: <%= Html.Encode(Model.Title) %></h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="ID">ID:</label>
                <%= Html.Encode(Model.ID) %>
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
                <%= Html.TextArea("Body", Model.Body, new { Rows = "10", Cols = "30", Class = "resizable" })%>
                <%= Html.ValidationMessage("Body", "*") %>
            </p>
            <p>
                <label for="CreateDate">CreateDate:</label>
                <%= Html.TextBox("CreateDate", String.Format("{0:g}", Model.CreateDate)) %>
                <%= Html.ValidationMessage("CreateDate", "*") %>
            </p>
            <p>
                <label for="LastUpdateDate">LastUpdateDate:</label>
                <%= Html.TextBox("LastUpdateDate", String.Format("{0:g}", Model.LastUpdateDate))%>
                <%= Html.ValidationMessage("LastUpdateDate", "*")%>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to Page", "ViewPage", "Wiki", new { page = Model.URL }, null)%>
    </div>

</asp:Content>

