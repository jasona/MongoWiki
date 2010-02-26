<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MongoWiki.Lib.Entities.User>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	UserList
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>UserList</h2>

    <table>
        <tr>
            <th></th>
            <th>
                FirstName
            </th>
            <th>
                LastName
            </th>
            <th>
                UserName
            </th>
            <th>
                EmailAddress
            </th>
            <th>
                Password
            </th>
            <th>
                Status
            </th>
            <th>
                Role
            </th>
            <th>
                CreateDate
            </th>
            <th>
                LastLoginDate
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "EditUser", new { key = item.UserName }) %> |
                <%= Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%= Html.Encode(item.FirstName) %>
            </td>
            <td>
                <%= Html.Encode(item.LastName) %>
            </td>
            <td>
                <%= Html.Encode(item.UserName) %>
            </td>
            <td>
                <%= Html.Encode(item.EmailAddress) %>
            </td>
            <td>
                <%= Html.Encode(item.Password) %>
            </td>
            <td>
                <%= Html.Encode(item.Status) %>
            </td>
            <td>
                <%= Html.Encode(item.Role) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.CreateDate)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.LastLoginDate)) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "CreateUser") %>
    </p>

</asp:Content>

