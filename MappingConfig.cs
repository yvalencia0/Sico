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
                config.CreateMap<StudentDto, Student>();
                config.CreateMap<Student, StudentDto>();

                config.CreateMap<StudentDto, Person>();
                config.CreateMap<Person, StudentDto>();
            });

            return mappingConfig;
        }
    }
}
