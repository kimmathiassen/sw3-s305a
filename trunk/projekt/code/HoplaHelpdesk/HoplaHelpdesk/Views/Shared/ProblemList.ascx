﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.ProblemListViewModel>" %>

    

    <% foreach (var item in Model.Problems) { %>
    
        <table>
        <tr>
            <th> <%: item.Title %></th>
            <th> 
            
              <% if (Model.Editable)
                   { %>
                <%: Html.ActionLink("Edit", "Edit", new { item.Id })%> |
                <% } %>
                 <% if (Model.Deletable)
                   { %>
                <%: Html.ActionLink("Delete", "Delete", new { item.Id })%> |
                 <% } %>
               <%: Html.ActionLink("Details", "Delete", new { item.Id })%> 
            </th>
       </tr>
        <tr>
            <td colspan="2">   <%: item.Description %> </td>
        
        </tr>
        </table>
    <% } %>




