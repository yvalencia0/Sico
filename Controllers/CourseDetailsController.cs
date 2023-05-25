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
    public class CourseDetailsController : ControllerBase
    {
        private readonly ICourseDetail _courseDetail;
        protected ResponseDto _response;

        public CourseDetailsController(ICourseDetail courseDetail)
        {
            _courseDetail = courseDetail;
            _response = new ResponseDto();
        }

        // GET: api/CourseDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDetail>>> GetCourseDetails()
        {
            try
            {
                var list = await _courseDetail.GetCourseDetails();
                _response.IsSuccess = true;
                _response.Result = list;
                _response.DisplayMessage = "Course detail list";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // GET: api/CourseDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDetail>> GetCourseDetail(int id)
        {
            var courseDetail = await _courseDetail.GetCourseDetailById(id);

            if (courseDetail == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "This course detail don't exist";
                return NotFound(_response);
            }
            _response.IsSuccess = true;
            _response.Result = courseDetail;
            _response.DisplayMessage = "Course detail information";
            return Ok(_response);
        }

        // POST: api/CourseDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseDetail>> PostCourseDetail(CourseDetail courseDetail)
        {
            try
            {
                CourseDetail model = await _courseDetail.CreateCourseDetail(courseDetail);
                _response.IsSuccess = true;
                _response.Result = model;
                _response.DisplayMessage = "Course detail create";
                return CreatedAtAction("GetCourseDetail", new { id = model.id }, _response);
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
