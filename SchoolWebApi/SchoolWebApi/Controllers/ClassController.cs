using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ClassController : ControllerBase
    {
        private ISchoolRepository<ClassName> _repository;
        public ClassController(ISchoolRepository<ClassName> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var clas = await _repository.GetAll();
            return Ok(clas);
        }
        [HttpGet]
        [Route("[action]/{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var clas = await _repository.GetById(id);
            if (clas != null)
            {
                return Ok(clas);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var clas = await _repository.GetByName(name);
            if (clas != null)
            {
                return Ok(clas);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create([FromBody] ClassName className)
        {


            var clas = await _repository.Create(className);
            return Ok(clas);

        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] ClassName className)
        {
            if (_repository.GetById(className.Id) != null)
            {
                return Ok(await _repository.Update(className));
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
