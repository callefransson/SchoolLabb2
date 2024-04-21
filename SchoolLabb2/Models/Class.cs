using System.ComponentModel.DataAnnotations;

namespace SchoolLabb2.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Class name can't be longer then 50 characters")]
        public string ClassName { get; set; }
        public virtual ICollection<ClassStudentRelation> Students { get; set; }
        public virtual ICollection<TeacherClassRelation> Teachers { get; set; }
    }
}
