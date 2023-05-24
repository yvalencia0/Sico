using AutoMapper;
using BackendSico.Models;
using BackendSico.Models.Dtos;

namespace BackendSico
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<TeacherDto, Teacher>();
                config.CreateMap<Teacher, TeacherDto>();
            });

            return mappingConfig;
        }
    }
}
