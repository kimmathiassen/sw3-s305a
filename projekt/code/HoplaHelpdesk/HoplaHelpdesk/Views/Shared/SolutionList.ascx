﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.SolutionListViewModel>" %>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Description
            </th>
        </tr>

    <% foreach (var item in Model.Solutions) { %>
    
        <tr>
            <% if (Model.Deletable) { %>       
            <td>
                 <%: Html.ActionLink("Delete", "Delete", new { id = item.Id })%>
                
            </td>
            <% } %>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.Description %>
            </td>
        </tr>
    
    <% } %>

    </table>

