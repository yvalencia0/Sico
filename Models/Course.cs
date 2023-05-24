using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendSico.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(40)]
        public string description { get; set; }

        public int fkTeacher { get; set; }
        [ForeignKey("fkTeacher")]
        public virtual Teacher? Teacher { get; set; }

        //public virtual ICollection<CourseDetail>? CourseDetails { get; set; }

    }
}
