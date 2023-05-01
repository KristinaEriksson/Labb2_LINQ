using System.ComponentModel;

namespace Labb2_LINQ.Models
{
    public class SchoolViewModel
    {
        [DisplayName("Teacher ID")]
        public int? TeacherID { get; set; }
        [DisplayName("Teacher")]
        public string? TeacherName { get; set; }


        [DisplayName("Student ID")]
        public int? StudentID { get; set; }
        [DisplayName("Student")]
        public string? StudentName { get; set; }


        [DisplayName("Course ID")]
        public int CourseID { get; set; }

        [DisplayName("Course name")]
        public string? CourseName { get; set; }


        [DisplayName("Class ID")]
        public int ClassID { get; set; }

        [DisplayName("Class name")]
        public string? ClassName { get; set; }
    }
}
