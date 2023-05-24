using BackendSico.Models;

namespace BackendSico.Interfaces
{
    public interface IPerson
    {
        Task<List<Person>> GetPeople();
        Task<Person> GetPersonById(string id);
        Task<Person> CreatePerson(Person person);
    }
}
