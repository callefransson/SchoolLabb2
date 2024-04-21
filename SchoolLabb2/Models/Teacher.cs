using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolLabb2.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name can't be longer then 50 characters")]
        public string TeacherFirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last name can't be longer then 50 characters")]
        public string TeacherLastName { get; set; }
        public virtual ICollection<TeacherCourseRelation> Courses { get; set; }
        public virtual ICollection<TeacherClassRelation> Classes { get; set; }
    }
}
