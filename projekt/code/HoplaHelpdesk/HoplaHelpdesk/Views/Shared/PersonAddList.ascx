﻿<%@ Control Language="C#"   
Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Person>>" %>

    <table>
        <tr>
            <th></th>
            <th>
                Name
            </th>
            <th>
                Email
            </th>
            <th>
                Staff
            </th>
            <th>
                Admin
            </th>
            <th>
                Department name
            </th>
        </tr>

    <% foreach (var item in Model)
       { %>
        <% if (item.IsStaff())
           {%>
                <tr>
                    <td>
                        
                        <%: Html.ActionLink("Add", "ChangeDepartment", new { DepId = ViewData["homeDepartment"], PerId = item.Id })%> |
                    </td>
                    <td>
                        <%: item.Name%>
                    </td>
                    <td>
                        <%: item.Email%>
                    </td>
                    <td>
                    <% foreach (var role in item.Roles)
                       {%>
                    <%    if (role.Selected && role.Name.ToString() == HoplaHelpdesk.Models.Constants.StaffRoleName)
                          {%>
                            x
                        <% } %>
                    <% } %>
                    </td>
                    <td>
                    <% foreach (var role in item.Roles)
                       {%>
                    <%    if (role.Selected && role.Name.ToString() == HoplaHelpdesk.Models.Constants.AdminRoleName)
                          {%>
                            x
                        <% } %>
                    <% } %>
                    </td>
                    <td><% if (item.Department != null)
                           { %>
                        <%: item.Department.Name%>
                        <% } %>
                    </td>
                </tr>
    
            <% } %>
            <%} %>

       </table>





