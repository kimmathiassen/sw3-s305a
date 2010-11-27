﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Tag>>" %>

    <table class="problemList">
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Name
            </th>
            <th>
                Description
            </th>
            <th>
                Priority
            </th>
            <th>
                Category_Id
            </th>
            <th>
                SolvedProblems
            </th>
            <th>
                TimeConsumed
            </th>
            <th>
                AverageTimeSpent
            </th>
          
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", "Tag", new { id=item.Id }) %> |
                <%: Html.ActionLink("Details", "Details", "Tag", new { id = item.Id })%> |
                <% if (item.Hidden)
                   { %>
                <%: Html.ActionLink("Unhide", "HideUnHide", "Tag", new { id = item.Id, value = false })%> |
                <% }
                   else
                   { %>
                <%: Html.ActionLink("Hide", "HideUnHide", "Tag", new { id = item.Id, value = true })%> |
                <% } %>
                <%: Html.ActionLink("Delete", "Delete", "Tag", new { id = item.Id })%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.Description %>
            </td>
            <td>
                <%: item.Priority %>
            </td>
            <td>
                <%: item.Category_Id %>
            </td>
            <td>
                <%: item.SolvedProblems %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.TimeConsumed) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.AverageTimeSpent) %>
            </td>
      
        </tr>
    
    <% } %>

    </table>


