using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Labb2_LINQ.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; } = 0;

        [Required]
        [StringLength(50)]
        [DisplayName("First name")]
        public string StudentFirstName { get; set; } = default!;

        [Required]
        [StringLength(50)]
        [DisplayName("Last name")]
        public string StudentLastName { get; set; } = default!;

        [DisplayName("Student")]
        public string StudentFullName => $"{StudentFirstName} {StudentLastName}";

        public virtual ICollection<SchoolConnection>? SchoolConnections { get; set; } // navigation
    }
}
