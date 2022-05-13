using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskForAkvelon.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskStatus { get; set; }
        public string TaskDesc { get; set; }
        public int TaskPriority { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
