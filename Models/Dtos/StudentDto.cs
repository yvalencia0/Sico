using System.ComponentModel.DataAnnotations;

namespace BackendSico.Models.Dtos
{
    public class StudentDto
    {
        public int id { get; set; }
        public string name1 { get; set; }
        public string name2 { get; set; }
        public string lastname1 { get; set; }
        public string lastname2 { get; set; }
        public string email { get; set; }
        public int typePerson { get; set; }
        public Guid tuition { get; set; }
    }
}
