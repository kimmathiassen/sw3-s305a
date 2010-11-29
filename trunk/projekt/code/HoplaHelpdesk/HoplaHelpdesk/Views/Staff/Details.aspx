﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.ProblemDetailsCommentListViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <fieldset>
        <legend><%: Model.Problem.Title %></legend>

                <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
                <p>
                    <% if (Model.Problem.SolvedAtTime != null)
                       { %>
                    <%: Html.CheckBox("solved", true) %> Solved
                    <% }
                       else
                       { %>
                       <%: Html.CheckBox("solved", false)%> Solved
                    <% } %>
                </p>
                
                <p>
                    <% if (Model.Problem.Reassignable == true)
                       { %>
                    <%: Html.CheckBox("reassignability", true) %> Reassignable
                    <% }
                       else
                       { %>
                       <%: Html.CheckBox("reassignability", false) %> Reassignable
                    <% } %>
                </p>

                <p>
                    <% if (Model.Problem.IsDeadlineApproved == true)
                       { %>
                    <%: Html.CheckBox("approveDeadline", true)%> Deadline approved
                    <% }
                       else
                       { %>
                       <%: Html.CheckBox("approveDeadline", false)%> Deadline approved
                    <% } %>
                </p>     


                <p>
                    <input type="submit" value="Submit changes" />
                </p>       
        <% } %>

        <% Html.RenderPartial("ProblemDetails", Model.Problem); %>
        <br />
        <h2>Solutions:</h2>
        
        <%: Html.ActionLink("Write new solution", "AddSolution", new { id= Model.Problem.Id })%><br />
        <%: Html.ActionLink("Attach solution from database", "ListSolutions", new { id= Model.Problem.Id })%><br />

        <% Html.RenderPartial("SolutionList", Model.Solutionlistviewmodel); %>
        <br />
        <h2>Comments:</h2>
        
        <% Html.RenderPartial("CommentList", Model.Commentlistviewmodel); %>

        <h2>Add Comment:</h2>

        <% Html.RenderPartial("EditorTemplates/CommentCreate", Model.comment); %>

        <br /><br />
        <%: Html.ActionLink("Reassign", "Index", "ReassignProblem", new { id = Model.Problem.Id }, null)%>
        <br /><br />
                



    </fieldset>
    


</asp:Content>
