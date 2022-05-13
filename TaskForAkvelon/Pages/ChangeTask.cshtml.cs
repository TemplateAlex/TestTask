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
    public class ChangeTaskModel : PageModel
    {
        private readonly ProjectDBContext _context;

        [BindProperty(SupportsGet = true)]
        public int NumProject { get; set; }

        [BindProperty(SupportsGet = true)]
        public int NumTask { get; set; }

        [BindProperty]
        public string TaskName { get; set; }
        
        [BindProperty]
        public string TaskStatus { get; set; }

        [BindProperty]
        public string TaskDesc { get; set; }

        [BindProperty]
        public int TaskPriority { get; set; }

        public Models.Task Task { get; set; }

        public ChangeTaskModel(ProjectDBContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            //Get request for display information about task
            Task = _context.Tasks.FirstOrDefault(x => x.Id == NumTask);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //Edit information about task, then we go to the ProjTasksPage
            var task = _context.Tasks.FirstOrDefault(x => x.Id == NumTask);
            task.TaskName = TaskName;
            task.TaskStatus = TaskStatus;
            task.TaskDesc = TaskDesc;
            task.TaskPriority = TaskPriority;
            await _context.SaveChangesAsync();
            return Redirect($"ProjTasksPage?numProject={NumProject}");
        }
    }
}
