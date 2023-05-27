using BackendSico.Context;
using BackendSico.Interfaces;
using BackendSico.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System.Collections.Generic;

namespace BackendSico.Services
{
    public class CourseDetailService : ICourseDetail
    {
        private readonly ApplicationDbContext _db;

        public CourseDetailService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<CourseDetail> CreateCourseDetail(CourseDetail courseDetail)
        {
            List<CourseDetail> list = await _db.CourseDetails.ToListAsync();

            list.Where(student => student.fkStudent == courseDetail.fkStudent && student.fkCourse == courseDetail.fkCourse);

            if (list.Count > 0)
            {

            }

            await _db.CourseDetails.AddAsync(courseDetail);
            await _db.SaveChangesAsync();
            return courseDetail;
        }

        public async Task<CourseDetail> GetCourseDetailById(int id)
        {
            CourseDetail courseDetail = await _db.CourseDetails.FindAsync(id);

            return courseDetail;
        }

        public async Task<List<CourseDetail>> GetCourseDetails()
        {
            List<CourseDetail> list = await _db.CourseDetails.ToListAsync();

            return list;
        }

        public async Task<List<CourseDetail>> GetCourseDetailsStudent(int student)
        {
            List<CourseDetail> list = await _db.CourseDetails.Where(courseDetail => courseDetail.fkStudent == student).ToListAsync();

            return list;
        }

        public async Task<bool> DeleteCourseDetail(int id)
        {
            try
            {
                CourseDetail courseDetail = await _db.CourseDetails.FindAsync(id);
                if (courseDetail == null)
                {
                    return false;
                }
                _db.CourseDetails.Remove(courseDetail);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}