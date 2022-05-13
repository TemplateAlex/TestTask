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
    public class ProjTasksPageModel : PageModel
    {
        private readonly ProjectDBContext _context;

        [BindProperty(SupportsGet = true)]
        public int NumProject { get; set; }

        public Project Project { get; set; }

        public List<Models.Task> Tasks { get; set; }

        public ProjTasksPageModel(ProjectDBContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            //GET method, which show information about tasks certain project 
            Tasks = _context.Tasks.Where(x => x.ProjectId == NumProject).ToList();
            Project = _context.Projects.FirstOrDefault(x => x.Id == NumProject);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //This POST method removes project and linked tasks with it
            var project = _context.Projects.FirstOrDefault(x => x.Id == NumProject);
            var tasks = _context.Tasks.Where(x => x.ProjectId == NumProject);
            _context.Projects.Remove(project);
            _context.Tasks.RemoveRange(tasks);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
