using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Labb2_LINQ.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherID { get; set; } = 0;

        [Required]
        [StringLength(50)]
        [DisplayName("First name")]
        public string TeacherFirstName { get; set; } = default!;

        [Required]
        [StringLength(50)]
        [DisplayName("Last name")]
        public string TeacherLastName { get; set; } = default!;

        [DisplayName("Teacher")]
        public string TeacherFullName => $"{TeacherFirstName} {TeacherLastName}";

        public virtual ICollection<SchoolConnection>? SchoolConnections { get; set; } // navigation
    }
}
