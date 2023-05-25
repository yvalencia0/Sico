using BackendSico.Context;
using BackendSico.Interfaces;
using BackendSico.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendSico.Services
{
    public class StudentService : IStudent
    {
        private readonly ApplicationDbContext _db;

        public StudentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Student> GetStudentById(int id)
        {
            Student student = await _db.Students.FindAsync(id);

            return student;
        }

        public async Task<List<Student>> GetStudents()
        {
            List<Student> list = await _db.Students.ToListAsync();

            return list;
        }
    }
}
