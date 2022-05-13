using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskForAkvelon.Models;

namespace TaskForAkvelon.Pages
{
    public class CreateProjectModel : PageModel
    {
        private readonly ProjectDBContext _context;
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

        public CreateProjectModel(ProjectDBContext db)
        {
            _context = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //Create new project and add in our DB, then we go to the main page
            Project project = new Project();
            project.ProjectName = ProjectName;
            project.StartDate = StartDate;
            project.CompletionDate = CompletionDate;
            project.ProjectStatus = ProjectStatus;
            project.ProjectPriority = ProjectPriority;

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
