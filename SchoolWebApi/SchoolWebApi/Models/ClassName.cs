using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApi.Models
{
    public class ClassName
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Scheduler> Schedulers { get; set; }
        public virtual ICollection<Student> Students { get; set; }


    }
}
