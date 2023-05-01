using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Labb2_LINQ.Models
{
    public class SchoolConnection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConnectionId { get; set; }

        [ForeignKey("Students")]
        public int FK_StudentID { get; set; }
        public virtual Student? Students { get; set; } // navigation

        [ForeignKey("Teachers")]
        public int FK_TeacherID { get; set; }
        public virtual Teacher? Teachers { get; set; } // navigation

        [ForeignKey("Classes")]
        public int FK_ClassID { get; set; }
        public virtual Class? Classes { get; set; } // navigation

        [ForeignKey("Courses")]
        public int FK_CourseID { get; set; }
        public virtual Course? Courses { get; set; } // navigation
    }
}
