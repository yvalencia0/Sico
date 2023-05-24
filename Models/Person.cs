using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendSico.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string name1 { get; set; }

        public string name2 { get; set; }

        [Required]
        [StringLength(20)]
        public string lastname1 { get; set; }

        [Required]
        [StringLength(20)]
        public string lastname2 { get; set; }

        [Required]
        public int typePerson { get; set; }

        //public virtual ICollection<Teacher>? Teachers{ get; set; }
        //public virtual ICollection<Student>? Students{ get; set; }
    }
}
