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
    public class TaskDescPageModel : PageModel
    {
        private readonly ProjectDBContext _context;

        [BindProperty (SupportsGet = true)]
        public int NumTask { get; set; }

        [BindProperty(SupportsGet = true)]
        public int NumProject { get; set; }

        public Models.Task Task { get; set; }
        public Project Project { get; set; }
        
        public TaskDescPageModel(ProjectDBContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            //GET method, which show information about tasks and project, which these tasks are located
            Task = _context.Tasks.FirstOrDefault(x => x.Id == NumTask);
            Project = _context.Projects.FirstOrDefault(x => x.Id == NumProject);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //POST method, which removes certain task
            var task = _context.Tasks.FirstOrDefault(x => x.Id == NumTask);

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return Redirect($"ProjTasksPage?numProject={NumProject}");
        }
    }
}
