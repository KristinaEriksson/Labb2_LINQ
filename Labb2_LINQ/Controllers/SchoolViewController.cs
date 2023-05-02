using Labb2_LINQ.Data;
using Labb2_LINQ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Labb2_LINQ.Controllers
{
    public class SchoolViewController : Controller
    {
        private readonly ForzaDbContext _context;
        public SchoolViewController(ForzaDbContext context)
        {
            _context = context;
        }

        //GET: Teacher who teaches the subject Programming 1
        public async Task<IActionResult> TeacherProgramming()
        {
            var teacherList = await(from t in _context.Teachers
                                    join sc in _context.SchoolConnections on t.TeacherID equals sc.FK_TeacherID
                                    join c in _context.Courses on sc.FK_CourseID equals c.CourseID
                                    where c.CourseName == "Programming 1"
                                    select new SchoolViewModel
                                    {
                                        TeacherName = t.TeacherFullName,
                                        CourseName = c.CourseName
                                    }).Distinct().ToListAsync();
            return View(teacherList);
        }

        //GET: All students and their teachers
        public async Task<IActionResult> StudentsAndTeachers()
        {
            var studentsList = await(from s in _context.Students
                                     join sc in _context.SchoolConnections on s.StudentID equals sc.FK_StudentID
                                     join t in _context.Teachers on sc.FK_TeacherID equals t.TeacherID
                                     select new SchoolViewModel
                                     {
                                         StudentName = s.StudentFullName,
                                         TeacherName = t.TeacherFullName
                                     }).Distinct().ToListAsync();
            return View(studentsList);
        }

        //GET: All students in programming 1
        public async Task<IActionResult> StudentsInProgramming()
        {
            var studentsList = await (from s in _context.Students
                                      join sc in _context.SchoolConnections on s.StudentID equals sc.FK_StudentID
                                      join c in _context.Courses on sc.FK_CourseID equals c.CourseID
                                      join t in _context.Teachers on sc.FK_TeacherID equals t.TeacherID
                                      where c.CourseName == "Programming 1"
                                      select new SchoolViewModel
                                      {
                                          StudentID = s.StudentID,
                                          StudentName = s.StudentFullName,
                                          CourseName = c.CourseName,
                                          TeacherID = t.TeacherID,
                                          TeacherName = t.TeacherFullName
                                      }).Distinct().ToListAsync();

            ViewBag.TeacherList = new SelectList(_context.Teachers, "TeacherID", "TeacherFirstName");
            return View(studentsList.ToList());
        }
        
        [HttpGet]
        public async Task<IActionResult> EditTeacher(int id)
        {

            var teacher = await (from t in _context.Teachers
                                 where t.TeacherID == id
                                 select t).SingleOrDefaultAsync();
            if (teacher == null)
            {
                return NotFound();
            }

            //var teacherName = await (from t in _context.Teachers
            //                          select t.TeacherFirstName)
            //                          .ToListAsync();

            //ViewBag.TeacherFirstName = teacherName;
            return View(teacher);

        }
        // POST : Edit Teacher
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTeacher(int id, [Bind("TeacherID, TeacherFirstName")] Teacher teacher)
        {
            if (id != teacher.TeacherID)
            {
                return NotFound();
            }
           
            if (ModelState.IsValid)
            {
                try
                {
                    var teacherToUpdate = _context.Teachers.FirstOrDefault(t => t.TeacherID == id);
                    if (teacherToUpdate == null)
                    {
                        return NotFound();
                    }

                    teacherToUpdate.TeacherFirstName = teacher.TeacherFirstName.Trim();
                    
                    await _context.SaveChangesAsync();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.TeacherID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(StudentsInProgramming));
            }
            ModelState.AddModelError(string.Empty, "An error occurred while saving changes.");
            return View(teacher);
        }
        private bool TeacherExists(int teacher)
        {
            throw new NotImplementedException();
        }
        //GET: Course list 
        public async Task<IActionResult> GetEditCourse()
        {
            var courses = from c in _context.Courses
                          select c;
            return View(await courses.ToListAsync());
        }

        public async Task<IActionResult> EditCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        //POST: Edit course name
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCourse(int id, [Bind("CourseID, CourseName")] Course course)
        {
            if (id != course.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var courseToUpdate = _context.Courses.FirstOrDefault(c => c.CourseID == id);
                    if (courseToUpdate == null)
                    {
                        return NotFound();
                    }

                    courseToUpdate.CourseName = course.CourseName.Trim();

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(GetEditCourse));
            }
            return View(course);
        }

        private bool CourseExists(int courseID)
        {
            throw new NotImplementedException();
        }
        
    }
    
}
