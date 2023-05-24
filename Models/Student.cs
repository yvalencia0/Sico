using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendSico.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        public Guid tuition { get; set; }

        public int fkPersonStu { get; set; }
        [ForeignKey("fkPersonStu")]
        public virtual Person? Person { get; set; }

        //public virtual ICollection<CourseDetail>? CourseDetails { get; set; }

    }
}
