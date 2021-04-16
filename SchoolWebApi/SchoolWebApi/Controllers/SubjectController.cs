﻿using Microsoft.AspNetCore.Http;
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
    public class SubjectController : ControllerBase
    {
        private ISchoolRepository<Subject> _repository;
        public SubjectController(ISchoolRepository<Subject> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var subjects = await _repository.GetAll();
            return Ok(subjects);
        }
        [HttpGet]
        [Route("[action]/{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var stude = await _repository.GetById(id);
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
        public async Task<IActionResult> Create([FromBody] Subject subject)
        {


            var stude = await _repository.Create(subject);
            return Ok(stude);

        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] Subject subject)
        {
            if (_repository.GetById(subject.Id) != null)
            {
                return Ok(await _repository.Update(subject));
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

