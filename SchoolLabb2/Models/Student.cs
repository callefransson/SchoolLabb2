using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolLabb2.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name can't be longer then 50 characters")]
        public string StudentFirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last name can't be longer then 50 characters")]
        public string StudentLastName { get; set;}
        public virtual ICollection<StudentCourseRelation> Courses { get; set; }

    }
}
