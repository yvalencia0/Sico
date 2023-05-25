using BackendSico.Models;

namespace BackendSico.Interfaces
{
    public interface IPerson
    {
        Task<List<Person>> GetPeople();
        Task<Person> GetPersonById(int id);
        Task<Person> CreatePerson(Person person);
    }
}
