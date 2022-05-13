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
    public class ChangeProjectModel : PageModel
    {
        private readonly ProjectDBContext _context;

        [BindProperty(SupportsGet = true)]
        public int NumProject { get; set; }

        [BindProperty]
        public string ProjectName { get; set; }

        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime CompletionDate { get; set; }

        [BindProperty]
        public string ProjectStatus { get; set; }

        [BindProperty]
        public int ProjectPriority { get; set; }
        public Project Project { get; set; }

        public ChangeProjectModel(ProjectDBContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            //Get request for display information about project
            Project = _context.Projects.FirstOrDefault(x => x.Id == NumProject);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //Edit information about task, then we go to the ProjTasksPage
            Project = _context.Projects.FirstOrDefault(x => x.Id == NumProject);

            Project.ProjectName = ProjectName;
            Project.StartDate = StartDate;
            Project.CompletionDate = CompletionDate;
            Project.ProjectStatus = ProjectStatus;
            Project.ProjectPriority = ProjectPriority;
            await _context.SaveChangesAsync();
            return Redirect($"ProjTasksPage?numProject={NumProject}");
        }
    }
}
