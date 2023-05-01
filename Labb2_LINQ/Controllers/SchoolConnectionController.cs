using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb2_LINQ.Data;
using Labb2_LINQ.Models;

namespace Labb2_LINQ.Controllers
{
    public class SchoolConnectionController : Controller
    {
        private readonly ForzaDbContext _context;

        public SchoolConnectionController(ForzaDbContext context)
        {
            _context = context;
        }

        // GET: SchoolConnection
        public async Task<IActionResult> Index()
        {
            var forzaDbContext = _context.SchoolConnections.Include(s => s.Classes).Include(s => s.Courses).Include(s => s.Students).Include(s => s.Teachers);
            return View(await forzaDbContext.ToListAsync());
        }

        // GET: SchoolConnection/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SchoolConnections == null)
            {
                return NotFound();
            }

            var schoolConnection = await _context.SchoolConnections
                .Include(s => s.Classes)
                .Include(s => s.Courses)
                .Include(s => s.Students)
                .Include(s => s.Teachers)
                .FirstOrDefaultAsync(m => m.ConnectionId == id);
            if (schoolConnection == null)
            {
                return NotFound();
            }

            return View(schoolConnection);
        }

        // GET: SchoolConnection/Create
        public IActionResult Create()
        {
            ViewData["FK_ClassID"] = new SelectList(_context.Classes, "ClassId", "ClassName");
            ViewData["FK_CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseName");
            ViewData["FK_StudentID"] = new SelectList(_context.Students, "StudentID", "StudentFullName");
            ViewData["FK_TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherFullName");
            return View();
        }

        // POST: SchoolConnection/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConnectionId,FK_StudentID,FK_TeacherID,FK_ClassID,FK_CourseID")] SchoolConnection schoolConnection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schoolConnection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_ClassID"] = new SelectList(_context.Classes, "ClassId", "ClassName", schoolConnection.FK_ClassID);
            ViewData["FK_CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseName", schoolConnection.FK_CourseID);
            ViewData["FK_StudentID"] = new SelectList(_context.Students, "StudentID", "StudentFullName", schoolConnection.FK_StudentID);
            ViewData["FK_TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherFullName", schoolConnection.FK_TeacherID);
            return View(schoolConnection);
        }

        // GET: SchoolConnection/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SchoolConnections == null)
            {
                return NotFound();
            }

            var schoolConnection = await _context.SchoolConnections.FindAsync(id);
            if (schoolConnection == null)
            {
                return NotFound();
            }
            ViewData["FK_ClassID"] = new SelectList(_context.Classes, "ClassId", "ClassName", schoolConnection.FK_ClassID);
            ViewData["FK_CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseName", schoolConnection.FK_CourseID);
            ViewData["FK_StudentID"] = new SelectList(_context.Students, "StudentID", "StudentFullName", schoolConnection.FK_StudentID);
            ViewData["FK_TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherFullName", schoolConnection.FK_TeacherID);
            return View(schoolConnection);
        }

        // POST: SchoolConnection/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConnectionId,FK_StudentID,FK_TeacherID,FK_ClassID,FK_CourseID")] SchoolConnection schoolConnection)
        {
            if (id != schoolConnection.ConnectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolConnection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolConnectionExists(schoolConnection.ConnectionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_ClassID"] = new SelectList(_context.Classes, "ClassId", "ClassName", schoolConnection.FK_ClassID);
            ViewData["FK_CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseName", schoolConnection.FK_CourseID);
            ViewData["FK_StudentID"] = new SelectList(_context.Students, "StudentID", "StudentFullName", schoolConnection.FK_StudentID);
            ViewData["FK_TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherFullName", schoolConnection.FK_TeacherID);
            return View(schoolConnection);
        }

        // GET: SchoolConnection/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SchoolConnections == null)
            {
                return NotFound();
            }

            var schoolConnection = await _context.SchoolConnections
                .Include(s => s.Classes)
                .Include(s => s.Courses)
                .Include(s => s.Students)
                .Include(s => s.Teachers)
                .FirstOrDefaultAsync(m => m.ConnectionId == id);
            if (schoolConnection == null)
            {
                return NotFound();
            }

            return View(schoolConnection);
        }

        // POST: SchoolConnection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SchoolConnections == null)
            {
                return Problem("Entity set 'ForzaDbContext.SchoolConnections'  is null.");
            }
            var schoolConnection = await _context.SchoolConnections.FindAsync(id);
            if (schoolConnection != null)
            {
                _context.SchoolConnections.Remove(schoolConnection);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolConnectionExists(int id)
        {
          return (_context.SchoolConnections?.Any(e => e.ConnectionId == id)).GetValueOrDefault();
        }
    }
}
