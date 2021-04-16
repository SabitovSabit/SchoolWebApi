using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.Concrate;
using SchoolWebApi.Interface;
using SchoolWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private ISchoolRepository<Student> _repository;
        public StudentController(ISchoolRepository<Student> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
           var students= await _repository.GetAll();
            return Ok(students);
        }
        [HttpGet]
        [Route("[action]/{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var stude= await _repository.GetById(id);
            if (stude != null)
            {
                return Ok(stude);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var stude = await _repository.GetByName(name);
            if (stude != null)
            {
                return Ok(stude);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            
            
                var stude = await _repository.Create(student);
                return Ok(stude);
            
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] Student student)
        {
            if (_repository.GetById(student.Id) != null)
            {
                return Ok(await _repository.Update(student));
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_repository.GetById(id) != null)
            {
                await _repository.Delete(id);
               return Ok();
            }
            return NotFound();
        }
    }
}
