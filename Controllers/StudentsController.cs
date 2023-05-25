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
using NuGet.DependencyResolver;

namespace BackendSico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudent _student;
        protected ResponseDto _response;

        public StudentsController(IStudent student)
        {
            _student = student;
            _response = new ResponseDto();
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            try
            {
                var list = await _student.GetStudents();
                _response.IsSuccess = true;
                _response.Result = list;
                _response.DisplayMessage = "Students list";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _student.GetStudentById(id);

            if (student == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "This student don't exist";
                return NotFound(_response);
            }
            _response.IsSuccess = true;
            _response.Result = student;
            _response.DisplayMessage = "Student information";
            return Ok(_response);
        }

     
        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            try
            {
                Student model = await _student.CreateStudent(student);
                _response.IsSuccess = true;
                _response.Result = model;
                _response.DisplayMessage = "Student create";
                return CreatedAtAction("GetStudent", new { id = model.id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error to save register";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

    }
}
