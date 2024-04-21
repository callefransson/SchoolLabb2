using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolLabb2.Models
{
    public class TeacherCourseRelation
    {
        [Key]
        public int TeacherCourseId { get; set; }
        [ForeignKey("Teacher")]
        public int FkTeacherId { get; set; }
        public Teacher Teacher { get; set; }
        [ForeignKey("Course")]
        public int FkCourseId { get; set; }
        public Course Course { get; set; }
    }
}
