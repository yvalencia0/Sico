using BackendSico.Models;

namespace BackendSico.Interfaces
{
    public interface ICourseDetail
    {
        Task<List<CourseDetail>> GetCourseDetails();
        Task<List<CourseDetail>> GetCourseDetailsStudent(int student);
        Task<CourseDetail> GetCourseDetailById(int id);
        Task<CourseDetail> CreateCourseDetail(CourseDetail courseDetail);
        Task<bool> DeleteCourseDetail(int id);
    }
}
