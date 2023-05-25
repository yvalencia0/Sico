using BackendSico.Models;

namespace BackendSico.Interfaces
{
    public interface IStudent
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> CreateStudent(Student student);
    }
}
