using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskForAkvelon.Models;

namespace TaskForAkvelon.Pages
{
    public class CreateTaskModel : PageModel
    {
        private readonly ProjectDBContext _context;

        [BindProperty(SupportsGet = true)]
        public int NumProject { get; set; }

        [BindProperty]
        public string TaskName { get; set; }

        [BindProperty]
        public string TaskStatus { get; set; }

        [BindProperty]
        public string TaskDesc { get; set; }

        [BindProperty]
        public int TaskPriority { get; set; }

        public CreateTaskModel(ProjectDBContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //Create new task and then we go to the ProjTasksPage
            Models.Task task = new Models.Task();
            task.TaskName = TaskName;
            task.TaskStatus = TaskStatus;
            task.TaskPriority = TaskPriority;
            task.TaskDesc = TaskDesc;
            task.ProjectId = NumProject;

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return Redirect($"ProjTasksPage?numProject={NumProject}");
        }
    }
}
