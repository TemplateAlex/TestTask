using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;

namespace TaskForAkvelon.HtmlHelpers
{
    public static class HtmlHelperTasks
    {
        //This method creates HtmlHelper for our cards that have information about tasks.
        public static HtmlString CreateTaskCard(this IHtmlHelper html, Models.Task task, int numProject)
        {
            string result = "";

            result += "<div class='col-4'>";
            result += "<div class='container-fluid d-flex justify-content-center project-card__wrapper'>";
            result += $"<a class='text-muted project-link__wrapper' href='TaskDescPage?numTask={task.Id}&numProject={numProject}'>";
            result += "<div class='container-fluid project-card'>";

            result += "<div class='title-info__wrapper container-fluid d-flex justify-content-center'>";
            result += "<div class='container underlined-text__wrapper'>";
            result += $"<p class='unline-text'>{task.TaskName}</p>";
            result += "<div class='unline'></div>";
            result += "</div></div>";

            result += "<hr>";

            result += "<div class='project-info__wrapper container-fluid pt-3'>";
            result += "<div class='project-info'>";
            result += $"<p>Task Status: {task.TaskStatus}</p>";
            result += $"<p>Task Description: {task.TaskDesc}</p>";
            result += $"<p>Priority: {task.TaskPriority}</p>";
            result += "</div></div>";

            result += "</div></a></div></div>";


            HtmlString htmlString = new HtmlString(result);
            return htmlString;
        }
    }
}
