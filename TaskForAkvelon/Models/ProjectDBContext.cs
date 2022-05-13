using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaskForAkvelon.Models
{
    public class ProjectDBContext: DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options)
        {

        }
    }
}
