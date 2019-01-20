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
    public class StudentClassController : Controller
    {
        private readonly SchoolNetContext _context;

        public StudentClassController(SchoolNetContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            var studentClasses = await _context.GetAllAsync<StudentClass>("StudentsClasses");

            return Ok(studentClasses);
        }        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var studentClass = await _context.GetAsync<StudentClass>("StudentClasses", id);
            if (studentClass == null) return NotFound();

            return Ok(studentClass);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] StudentClass studentClass)
        {
            var response = await _context.InsertAsync(studentClass, "StudentClasses");

            return Created(string.Empty, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] StudentClass studentClass, string id)
        {
            await _context.UpdateAsync(id, studentClass, "StudentClasses");

            return Ok(studentClass);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _context.DeleteAsync<StudentClass>(id, "StudentClasses");

            return Ok();
        }
    }
}