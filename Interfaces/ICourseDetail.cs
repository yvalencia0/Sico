using BackendSico.Models;

namespace BackendSico.Interfaces
{
    public interface ICourseDetail
    {
        Task<List<CourseDetail>> GetCourseDetails();
        Task<CourseDetail> GetCourseDetailById(int id);
        Task<CourseDetail> CreateCourseDetail(CourseDetail courseDetail);
    }
}
