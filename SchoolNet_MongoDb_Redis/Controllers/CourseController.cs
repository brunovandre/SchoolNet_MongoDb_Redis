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
    public class CourseController : Controller
    {
        private readonly SchoolNetContext _context;

        public CourseController(SchoolNetContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            var courses = await _context.GetAllAsync<Course>("Courses");

            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var course = await _context.GetAsync<Course>("Courses", id);
            if (course == null) return NotFound();

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Course course)
        {
            var response = await _context.InsertAsync(course, "Courses");

            return Created(string.Empty, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] Course course, string id)
        {
            await _context.UpdateAsync(id, course, "Courses");

            return Ok(course);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _context.DeleteAsync<Course>(id, "Courses");

            return Ok();
        }
    }
}