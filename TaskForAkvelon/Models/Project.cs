using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskForAkvelon.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string ProjectStatus { get; set; }
        public int ProjectPriority { get; set; }
        public List<Task> Tasks { get; set; }

        public Project()
        {
            Tasks = new List<Task>();
        }
    }
}
