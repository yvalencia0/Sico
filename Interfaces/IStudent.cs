using BackendSico.Models;
using BackendSico.Models.Dtos;

namespace BackendSico.Interfaces
{
    public interface IStudent
    {
        Task<List<StudentDto>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> CreateStudent(Student student);
    }
}
