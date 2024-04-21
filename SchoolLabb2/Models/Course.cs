using System.ComponentModel.DataAnnotations;

namespace SchoolLabb2.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Course name can't be longer then 30 characters")]
        public string CourseName {  get; set; }
        public virtual ICollection<StudentCourseRelation> Students { get; set; } 
        public virtual ICollection<TeacherCourseRelation> Teachers { get; set; }

    }
}
