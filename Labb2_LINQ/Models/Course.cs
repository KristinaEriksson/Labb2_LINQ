using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Labb2_LINQ.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Course ID")]
        public int CourseID { get; set; } = 0;

        [Required]
        [StringLength(50)]
        [DisplayName("Course name")]
        public string CourseName { get; set; } = default!;

        public virtual ICollection<SchoolConnection>? SchoolConnections { get; set; } // navigation
    }
}
