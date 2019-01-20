using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolNet_MongoDb_Redis.Context;
using SchoolNet_MongoDb_Redis.Entities;

namespace SchoolNet_MongoDb_Redis.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly SchoolNetContext _context;

        public StudentController(SchoolNetContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            var students = await _context.GetAllAsync<Student>("Members");

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var student = await _context.GetAsync<Student>("Members", id);
            if (student == null) return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Student student)
        {
            var response = await _context.InsertAsync(student, "Members");

            return Created(string.Empty, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] Student student, string id)
        {
            await _context.UpdateAsync(id, student, "Members");

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _context.DeleteAsync<Student>(id, "Members");

            return Ok();
        }
    }
}