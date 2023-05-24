using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendSico.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        public Guid professionalLicense { get; set; }

        public int fkPersonTea { get; set; }
        [ForeignKey("fkPersonTea")]
        public virtual Person? Person { get; set; }

        //public virtual ICollection<Course>? Courses { get; set; }

    }
}
