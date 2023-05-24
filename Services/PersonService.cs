using BackendSico.Context;
using BackendSico.Interfaces;
using BackendSico.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendSico.Services
{
    public class PersonService : IPerson
    {
        private readonly ApplicationDbContext _db;

        public PersonService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Person> CreatePerson(Person person)
        {
            await _db.People.AddAsync(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task<Person> GetPersonById(string id)
        {
            Person person = await _db.People.FindAsync(id);

            return person;
        }

        public async Task<List<Person>> GetPeople()
        {
            List<Person> list = await _db.People.ToListAsync();

            return list;
        }

    }
}
