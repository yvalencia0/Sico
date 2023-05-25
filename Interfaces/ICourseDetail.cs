using BackendSico.Models;

namespace BackendSico.Interfaces
{
    public interface ICourseDetail
    {
        Task<List<CourseDetail>> GetCourseDetails();
        Task<Teacher> GetCourseDetailById(int id);
        Task<Teacher> CreateCourseDetail(CourseDetail courseDetail);
    }
}
