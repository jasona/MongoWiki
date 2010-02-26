<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<MongoWiki.Lib.Entities.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EditUser
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>EditUser</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="FirstName">FirstName:</label>
                <%= Html.TextBox("FirstName", Model.FirstName) %>
                <%= Html.ValidationMessage("FirstName", "*") %>
            </p>
            <p>
                <label for="LastName">LastName:</label>
                <%= Html.TextBox("LastName", Model.LastName) %>
                <%= Html.ValidationMessage("LastName", "*") %>
            </p>
            <p>
                <label for="UserName">UserName:</label>
                <%= Html.TextBox("UserName", Model.UserName) %>
                <%= Html.ValidationMessage("UserName", "*") %>
            </p>
            <p>
                <label for="EmailAddress">EmailAddress:</label>
                <%= Html.TextBox("EmailAddress", Model.EmailAddress) %>
                <%= Html.ValidationMessage("EmailAddress", "*") %>
            </p>
            <p>
                <label for="Password">Password:</label>
                <%= Html.TextBox("Password", Model.Password) %>
                <%= Html.ValidationMessage("Password", "*") %>
            </p>
            <p>
                <label for="Status">Status:</label>
                <%= Html.TextBox("Status", Model.Status) %>
                <%= Html.ValidationMessage("Status", "*") %>
            </p>
            <p>
                <label for="Role">Role:</label>
                <%= Html.TextBox("Role", Model.Role) %>
                <%= Html.ValidationMessage("Role", "*") %>
            </p>
            <p>
                <label for="CreateDate">CreateDate:</label>
                <%= Html.TextBox("CreateDate", String.Format("{0:g}", Model.CreateDate)) %>
                <%= Html.ValidationMessage("CreateDate", "*") %>
            </p>
            <p>
                <label for="LastLoginDate">LastLoginDate:</label>
                <%= Html.TextBox("LastLoginDate", String.Format("{0:g}", Model.LastLoginDate)) %>
                <%= Html.ValidationMessage("LastLoginDate", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "UserList") %>
    </div>

</asp:Content>

