﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Category>>" %>


    <% foreach (var item in Model) { %>
    

               <p><%: Html.ActionLink(item.Name, "EditCat","Category", new { item.Id },null)%></p> 
             
               

    <% } %>

 

