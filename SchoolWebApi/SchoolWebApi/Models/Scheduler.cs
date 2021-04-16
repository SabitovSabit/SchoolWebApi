using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApi.Models
{
    public class Scheduler
    {
        [Key]
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public string SubjectName  { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public string Class_Name { get; set; }
        public int ClassNameId { get; set; }
        public ClassName ClassName { get; set; }

    }
}
