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
    public class CoursesController : ControllerBase
    {
        private readonly ICourse _course;
        protected ResponseDto _response;

        public CoursesController(ICourse course)
        {
            _course = course;
            _response = new ResponseDto();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _course.GetCourseById(id);

            if (course == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "This course don't exist";
                return NotFound(_response);
            }
            _response.IsSuccess = true;
            _response.Result = course;
            _response.DisplayMessage = "Course information";
            return Ok(_response);
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            try
            {
                var list = await _course.GetCourses();
                _response.IsSuccess = true;
                _response.Result = list;
                _response.DisplayMessage = "Course list";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }



        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            try
            {
                Course model = await _course.CreateCourse(course);
                _response.IsSuccess = true;
                _response.Result = model;
                _response.DisplayMessage = "Course create";
                return CreatedAtAction("GetCourse", new { id = model.id }, _response);
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
