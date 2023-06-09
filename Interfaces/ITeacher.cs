﻿using BackendSico.Models;

namespace BackendSico.Interfaces
{
    public interface ITeacher
    {
        Task<List<Teacher>> GetTeachers();
        Task<Teacher> GetTeacherById(int id);
        Task<Teacher> CreateTeacher(Teacher teacher);
    }
}
