using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendSico.Context;
using BackendSico.Models;
using BackendSico.Interfaces;
using BackendSico.Models.Dtos;

namespace BackendSico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacher _teacher;
        protected ResponseDto _response;

        public TeachersController(ITeacher teacher)
        {
            _teacher = teacher;
            _response = new ResponseDto();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(string id)
        {
            var teacher = await _teacher.GetTeacherById(id);

            if (teacher == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "This teacher don't exist";
                return NotFound(_response);
            }
            _response.IsSuccess = true;
            _response.Result = teacher;
            _response.DisplayMessage = "Teacher information";
            return Ok(_response);
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            try
            {
                var list = await _teacher.GetTeachers();
                _response.IsSuccess = true;
                _response.Result = list;
                _response.DisplayMessage = "Teachers list";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }


        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {
            try
            {
                Teacher model = await _teacher.CreateTeacher(teacher);
                _response.IsSuccess = true;
                _response.Result = model;
                _response.DisplayMessage = "Person create";
                return CreatedAtAction("GetPerson", new { id = model.id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error to save register";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }


        /*
                // GET: api/Teachers
                [HttpGet]
                public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
                {
                  if (_context.Teachers == null)
                  {
                      return NotFound();
                  }
                    return await _context.Teachers.ToListAsync();
                }

                // GET: api/Teachers/5
                [HttpGet("{id}")]
                public async Task<ActionResult<Teacher>> GetTeacher(string id)
                {
                  if (_context.Teachers == null)
                  {
                      return NotFound();
                  }
                    var teacher = await _context.Teachers.FindAsync(id);

                    if (teacher == null)
                    {
                        return NotFound();
                    }

                    return teacher;
                }

                // PUT: api/Teachers/5
                // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
                [HttpPut("{id}")]
                public async Task<IActionResult> PutTeacher(string id, Teacher teacher)
                {
                    if (id != teacher.id)
                    {
                        return BadRequest();
                    }

                    _context.Entry(teacher).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TeacherExists(id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    return NoContent();
                }

                // POST: api/Teachers
                // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
                [HttpPost]
                public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
                {
                  if (_context.Teachers == null)
                  {
                      return Problem("Entity set 'ApplicationDbContext.Teachers'  is null.");
                  }
                    _context.Teachers.Add(teacher);
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        if (TeacherExists(teacher.id))
                        {
                            return Conflict();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    return CreatedAtAction("GetTeacher", new { id = teacher.id }, teacher);
                }

                // DELETE: api/Teachers/5
                [HttpDelete("{id}")]
                public async Task<IActionResult> DeleteTeacher(string id)
                {
                    if (_context.Teachers == null)
                    {
                        return NotFound();
                    }
                    var teacher = await _context.Teachers.FindAsync(id);
                    if (teacher == null)
                    {
                        return NotFound();
                    }

                    _context.Teachers.Remove(teacher);
                    await _context.SaveChangesAsync();

                    return NoContent();
                }

                private bool TeacherExists(string id)
                {
                    return (_context.Teachers?.Any(e => e.id == id)).GetValueOrDefault();
                }

        */
    }
}
