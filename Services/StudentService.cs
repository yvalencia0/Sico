using AutoMapper;
using BackendSico.Context;
using BackendSico.Interfaces;
using BackendSico.Models;
using BackendSico.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BackendSico.Services
{
    public class StudentService : IStudent
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public StudentService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
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

        public async Task<List<StudentDto>> GetStudents()
        {
            List<Person> listPeople = await _db.People.Where(person => person.typePerson == 2).ToListAsync();
            return _mapper.Map<List<StudentDto>>(listPeople);


            //List<Student> listStudents = await _db.Students.ToListAsync();
            //return _mapper.Map<List<StudentDto>>(listStudents);



            //List<Cliente> lista = await _db.Clientes.ToListAsync();

            //return _mapper.Map<List<ClienteDto>>(lista);




            /*
                        var innerJoinQuery =
                                from people in _db.People
                                join student in _db.Students on people.id equals student.fkPersonStu
                                select new { ProductName = prod.Name, Category = category.Name };

                        var innerJoinQuery =
                                from people in _db.People
                                join student in _db.Students on people.id equals student.fkPersonStu
                                select new {    id = people.id,
                                                name1 = people.name1,
                                                name2 = people.name2,
                                                lastname1 = people.lastname1,
                                                lastname2 = people.lastname2,
                                                typePerson = people.typePerson,
                                                tuition = student.tuition};
            */
            /*
                        var query = database.Posts    // your starting point - table in the "from" statement
                                       .Join(database.Post_Metas, // the source table of the inner join
                                          post => post.ID,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                                          meta => meta.Post_ID,   // Select the foreign key (the second part of the "on" clause)
                                          (post, meta) => new { Post = post, Meta = meta }) // selection
                                       .Where(postAndMeta => postAndMeta.Post.ID == id);
            */
            /*
                        List<StudentDto> listPeople = await _db.Students.Join(_db.People,
                                                                              student => student.fkPersonStu,
                                                                              person => person.id,
                                                                              (id, name1, name2, lastname1, lastname2, email, typePerson, tuition) => new {
                                                                                                          id = id,
                                                                                                          name1 = name1,
                                                                                                          name2 = name2,
                                                                                                          lastname1 = lastname1,
                                                                                                          lastname2 = lastname2,
                                                                                                          email = email,
                                                                                                          typePerson = typePerson,
                                                                                                          tuition = tuition
                                                                                                      }
                                                                            ).ToListAsync();

            */

        }
    }
}
