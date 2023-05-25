using BackendSico.Context;
using BackendSico.Interfaces;
using BackendSico.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendSico.Services
{
    public class CourseService : ICourse
    {
        private readonly ApplicationDbContext _db;

        public CourseService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Course> CreateCourse(Course course)
        {
            await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
            return course;
        }
        public async Task<Course> GetCourseById(int id)
        {
            Course course = await _db.Courses.FindAsync(id);

            return course;
        }

        public async Task<List<Course>> GetCourses()
        {
            List<Course> list = await _db.Courses.ToListAsync();

            return list;
        }

    }
}
