using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendSico.Models
{
    public class CourseDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int fkStudent { get; set; }
        [ForeignKey("fkStudent")]
        public virtual Student? Student { get; set; }

        public int fkCourse { get; set; }
        [ForeignKey("fkCourse")]
        public virtual Course? Course { get; set; }
    }
}
