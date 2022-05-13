using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;
using TaskForAkvelon.Models;

namespace TaskForAkvelon.HtmlHelpers
{
    public static class HtmlHelperProjects
    {
        //This method creates HtmlHelper for our cards that have information about projects.
        public static HtmlString CreateProjectCard(this IHtmlHelper html, Project project)
        {
            string result = "";

            result += "<div class='col-4'>";
            result += "<div class='container-fluid d-flex justify-content-center project-card__wrapper'>";
            result += $"<a class='text-muted project-link__wrapper' href='ProjTasksPage?numProject={project.Id}'>";
            result += "<div class='container-fluid project-card'>";

            result += "<div class='title-info__wrapper container-fluid d-flex justify-content-center'>";
            result += "<div class='container underlined-text__wrapper'>";
            result += $"<p class='unline-text'>{project.ProjectName}</p>";
            result += "<div class='unline'></div>";
            result += "</div></div>";

            result += "<hr>";

            result += "<div class='project-info__wrapper container-fluid pt-3'>";
            result += "<div class='project-info'>";
            result += $"<p>Project Status: {project.ProjectStatus}</p>";
            result += $"<p>Start Date: {project.StartDate}</p>";
            result += $"<p>End Date: {project.CompletionDate}</p>";
            result += $"<p>Priority: {project.ProjectPriority}</p>";
            result += "</div></div>"; 

            result += "</div></a></div></div>"; 


            HtmlString htmlString = new HtmlString(result);
            return htmlString;
        }
    }
}
