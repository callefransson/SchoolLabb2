using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolLabb2.Models
{
    public class TeacherClassRelation
    {
        [Key]
        public int TeacherClassId { get; set; }
        [ForeignKey("Teacher")]
        public int FkTeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [ForeignKey("Class")]
        public int FkClassId { get; set; }
        public Class Class { get; set; }

    }
}
