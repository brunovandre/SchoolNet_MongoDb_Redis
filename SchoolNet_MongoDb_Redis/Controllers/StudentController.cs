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
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var student = await _context.GetAsync<Student>("Members", id);
            if (student == null) return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Student student)
        {
            student.Uid = Guid.NewGuid();
            var response = await _context.InsertAsync(student, "Members");

            return Created(string.Empty, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] Student student, Guid id)
        {
            var entity = await _context.GetAsync<Student>("Members", student.Uid);
            student._id = entity._id;

            await _context.UpdateAsync(id, student, "Members");

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _context.DeleteAsync<Student>(id, "Members");

            if (result == 0)
                return NotFound();

            return Ok();
        }
    }
}