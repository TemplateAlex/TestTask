using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskForAkvelon.Models;

namespace TaskForAkvelon.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProjectDBContext _context;

        private readonly ILogger<IndexModel> _logger;
        
        public List<Project> Projects { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ProjectDBContext db)
        {
            _logger = logger;
            _context = db;
        }

        public void OnGet()
        {
            //This Get request show all projects on the page
            Projects = _context.Projects.ToList();
        }
    }
}
