using BackendSico.Models;

namespace BackendSico.Interfaces
{
    public interface ICourse
    {
        Task<List<Course>> GetCourses();
        Task<Course> GetCourseById(int id);
        Task<Course> CreateCourse(Course course);
    }
}
