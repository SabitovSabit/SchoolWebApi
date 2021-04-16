using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolWebApi.Data;
using SchoolWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulerController : ControllerBase
    {
        private SchoolDb _db;
        public SchedulerController(SchoolDb db)
        {
            _db = db;
        }
        [HttpGet]
        [Route("{name}")]

        public IActionResult GetAll(string name)
        {


            var result = from teacher in _db.Teachers
                         
                         join scheduler in _db.Schedulers on teacher.Id equals scheduler.TeacherId
                         join className in _db.ClassNames on scheduler.ClassNameId equals className.Id
                         join subject in _db.Subjects on scheduler.SubjectId equals subject.Id
                         where(teacher.Name==name)
                         select new Scheduler
                         {
                            TeacherName=teacher.Name,
                            Class_Name=className.Name,
                            SubjectName=subject.Name
                         };

            return Ok(result);





            //return await _db.Schedulers.Where(x => x.Teacher.Name == name).ToListAsync();
        }
    }
}
