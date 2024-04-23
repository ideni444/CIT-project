using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School_Schedule_MVC.Models;

namespace School_Schedule_MVC.Controllers
{
    //Teacher controller with identity.
    [Authorize]
    public class TeachersController : Controller
    {
        private readonly School_Schedule_MVCDataContext _context;

        public TeachersController(School_Schedule_MVCDataContext context)
        {
            _context = context;
        }

        // GET: Teachers
        //Gets all teachers using a linq query.
        public async Task<IActionResult> Index()
        {
            return View((from  teachers in _context.Teacher select teachers).ToList());
        }

        // GET: Teachers/Details/5
        //Gets the details using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = _context.Teacher
                .FirstOrDefault(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        //Gets the create teacher form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds a teacher to database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,ContactNumber")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        //Gets a teacher for update uses a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = (from teachers in _context.Teacher
                           where teachers.Id == id
                           select teachers).FirstOrDefault();
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the teacher.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,ContactNumber")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                   _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
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
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        //Gets the teacher for delete  using  a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher =_context.Teacher
                .FirstOrDefault(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        //Deletes the teacher uses a linq query to select the teacher.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var teacher = (from teachers in _context.Teacher
                           where teachers.Id == id
                           select teachers).FirstOrDefault();
            _context.Teacher.Remove(teacher);
           _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the teacher for existance using a lamda query.
        private bool TeacherExists(int id)
        {
            return _context.Teacher.Any(e => e.Id == id);
        }
    }
}
