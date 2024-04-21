using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolLabb2.Models
{
    public class StudentCourseRelation
    {
        [Key]
        public int StudentCourseId { get; set; }
        [ForeignKey("Student")]
        public int FkStudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Course")]
        public int FkCourseId { get; set; }
        public Course Course { get; set; }
    }
}
