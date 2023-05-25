using BackendSico.Context;
using BackendSico.Interfaces;
using BackendSico.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackendSico.Services
{
    public class TeacherService : ITeacher
    {
        private readonly ApplicationDbContext _db;

        public TeacherService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Teacher> CreateTeacher(Teacher teacher)
        {
            await _db.Teachers.AddAsync(teacher);
            await _db.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> GetTeacherById(int id)
        {
            Teacher teacher = await _db.Teachers.FindAsync(id);

            return teacher;
        }

        public async Task<List<Teacher>> GetTeachers()
        {
            List<Teacher> list = await _db.Teachers.ToListAsync();

            return list;
        }
    }
}
