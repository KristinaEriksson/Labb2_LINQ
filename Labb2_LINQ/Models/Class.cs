using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Labb2_LINQ.Models
{
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Class ID")]
        public int ClassId { get; set; } = 0;

        [DisplayName("Class")]
        public string ClassName { get; set; } = default!;

        public virtual ICollection<SchoolConnection>? SchoolConnections { get; set; } // navigation
    }
}
