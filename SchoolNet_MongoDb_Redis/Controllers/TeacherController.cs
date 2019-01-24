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
    public class TeacherController : Controller
    {
        private readonly SchoolNetContext _context;

        public TeacherController(SchoolNetContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            var teachers = await _context.GetAllAsync<Teacher>("Members");            

            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var teacher = await _context.GetAsync<Teacher>("Members", id);
            if (teacher == null) return NotFound();

            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Teacher teacher)
        {
            teacher.Uid = Guid.NewGuid();
            var response = await _context.InsertAsync(teacher, "Members");

            return Created(string.Empty, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] Teacher teacher, Guid id)
        {
            var entity = await _context.GetAsync<Teacher>("Members", teacher.Uid);
            teacher._id = entity._id;

            await _context.UpdateAsync(id, teacher, "Members");

            return Ok(teacher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _context.DeleteAsync<Teacher>(id, "Members");

            if (result == 0)
                return NotFound();

            return Ok();
        }
    }
}