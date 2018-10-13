using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;
using TestWebApi.Interfaces;
using TestWebApi.Repositories;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]StudentModel student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            await _studentRepository.PostAsync(student);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentRepository.GetAsync();
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        [HttpGet("Names")]
        public async Task<IActionResult> GetNames()
        {
            var studentsNames = await _studentRepository.GetNamesAsync();
            if (studentsNames == null)
            {
                return NotFound();
            }
            return Ok(studentsNames);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var student = await _studentRepository.GetAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut]
        public async Task<IActionResult> PutStudent([FromBody] StudentModel student)
        {
            if (student == null || student.Id < 0)
            {
                return BadRequest();
            }
            var changedStudent = await _studentRepository.PutAsync(student);
            if (changedStudent == null)
            {
                return NotFound();
            }
            return Ok(changedStudent);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            await _studentRepository.Delete(id);
            return Ok();
        }
    }
}