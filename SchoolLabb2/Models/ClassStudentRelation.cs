using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolLabb2.Models
{
    public class ClassStudentRelation
    {
        [Key] 
        public int ClassStudentId { get; set; }
        [ForeignKey("Class")]
        public int FkClassId { get; set; }
        public Class Class { get; set; }
        [ForeignKey("Student")]
        public int FkStudentId { get; set; }
        public Student Student { get; set; }
    }
}
